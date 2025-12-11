using BookManager.BusinessObjects.DTOs.BulkUploadBooks;
using BookManager.BusinessObjects.DTOs.CreateBook;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.BusinessObjects.POCOEntities;
using BookManager.Cross.Entities.Interfaces;
using BookManager.UseCases.CreateBook;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UseCases.BulkUploadBooks
{
    internal class BulkUploadBooksInteractor : IBulkUploadBooksInputPort
    {
        readonly IStringNormalizer Normalizer;
        readonly IGetAuthorByNameRepository GetAuthorByNameRepository;
        readonly ICreateAuthorRepository CreateAuthorRepository;
        readonly ICreateBookInputPort CreateBookInputPort;
        readonly IBulkUploadBooksOutputPort OutputPort;

        public BulkUploadBooksInteractor(IStringNormalizer normalizer, 
            IGetAuthorByNameRepository getAuthorByNameRepository, 
            ICreateAuthorRepository createAuthorRepository, 
            ICreateBookInputPort createBookInputPort, 
            IBulkUploadBooksOutputPort outputPort)
        {
            Normalizer = normalizer;
            GetAuthorByNameRepository = getAuthorByNameRepository;
            CreateAuthorRepository = createAuthorRepository;
            CreateBookInputPort = createBookInputPort;
            OutputPort = outputPort;
        }

        public async ValueTask Handle(BulkUploadBooksRequestDto fileDto)
        {
            var result = new BulkUploadResultDto();
            var Errors = new List<BulkUploadErrorDto>();
            using var reader = new StreamReader(fileDto.File.OpenReadStream());

            int rowNumber = 0;
            while (!reader.EndOfStream)
            {
                rowNumber++;
                var line = await reader.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Errors.Add(new BulkUploadErrorDto
                    {
                        RowNumber = rowNumber,
                        ErrorMessage = "Fila vacía."
                    });
                    continue;
                }

                var columns = line.Split(',');

                if (columns.Length != 4)
                {
                    Errors.Add(new BulkUploadErrorDto
                    {
                        RowNumber = rowNumber,
                        ErrorMessage = "Formato incorrecto. Se esperaban: isbn,title,publicationYear,authorName"
                    });
                    continue;
                }

                string isbn = columns[0].Trim();
                string title = columns[1].Trim();
                string yearText = columns[2].Trim();
                string authorName = columns[3].Trim();

                if (!int.TryParse(yearText, out int publicationYear))
                {
                    Errors.Add(new BulkUploadErrorDto
                    {
                        RowNumber = rowNumber,
                        ErrorMessage = "El campo publicationYear no es un número válido."
                    });
                    continue;
                }

                try
                {
                    // Buscar o crear autor
                    var author = await GetAuthorByNameRepository.Get(Normalizer.Normalize(authorName));
                    Author NewAuthor;
                    if (author == default)
                    {
                        NewAuthor = new Author
                        {
                            Id = Guid.NewGuid(),
                            Name = authorName,
                            NormalizedName = Normalizer.Normalize(authorName),
                            BirthDate = DateTime.MinValue
                        };

                        await CreateAuthorRepository.CreateAuthorAsync(NewAuthor);
                        author.Id = NewAuthor.Id;
                    }

                    var dto = new CreateBookDto
                    {
                        Isbn = isbn,
                        Title = title,
                        PublicationYear = publicationYear,
                        PageNumber = 1,
                        AuthorId = author.Id
                    };

                    await CreateBookInputPort.Handle(dto);

                    result.SuccessCount++;
                }
                catch (Exception ex)
                {
                    Errors.Add(new BulkUploadErrorDto
                    {
                        RowNumber = rowNumber,
                        ErrorMessage = ex.Message
                    });
                }
            }

            result.TotalRows = rowNumber;
            result.Errors = Errors;

            await OutputPort.Handle(result);
        }
    }
}
