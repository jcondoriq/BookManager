using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.DTOs.CreateAutor;
using BookManager.BusinessObjects.DTOs.UpdateAuthor;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.BusinessObjects.POCOEntities;
using BookManager.Cross.Entities.Services;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BookManager.UseCases.UpdateAuthor
{
    internal class UpdateAuthorInteractor : IUpdateAuthorInputPort
    {
        readonly IUpdateAuthorRepository UpdateAuthorRepository;
        readonly ValidateService<UpdateAuthorDto> ValidationService;
        readonly IGetAuthorByIdRepository GetAuthorByIdRepository;

        public UpdateAuthorInteractor(IUpdateAuthorRepository updateAuthorRepository, 
            ValidateService<UpdateAuthorDto> validationService,
            IGetAuthorByIdRepository getAuthorByIdRepository)
        {
            UpdateAuthorRepository = updateAuthorRepository;
            ValidationService = validationService;
            GetAuthorByIdRepository = getAuthorByIdRepository;
        }

        public async ValueTask Handle(UpdateAuthorDto authorDto)
        {
            await ValidationService.ExecuteValidationGuard(authorDto);

            AuthorDto FindAuthor = await GetAuthorByIdRepository.Get(authorDto.Id);

            if (FindAuthor == null)
            {
                throw new Exception("Author not found");
            }

            if (!string.IsNullOrWhiteSpace(authorDto.Name) && authorDto.Name != FindAuthor.Name)
                FindAuthor.Name = authorDto.Name;

            if (authorDto.BirthDate.HasValue && authorDto.BirthDate != FindAuthor.BirthDate)
                FindAuthor.BirthDate = (DateTime)authorDto.BirthDate;

            await UpdateAuthorRepository.Update(FindAuthor);
        }
    }
}
