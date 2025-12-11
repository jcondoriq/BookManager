using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UseCases.GetAllAuthors
{
    internal class GetAllAuthorsInteractor: IGetAllAuthorInputPort
    {
        readonly IGetAllAuthorsRepository GetAllAuthorsRepository;
        readonly IGetAllAuthorsOutputPort GetAllAuthorsOutputPort;

        public GetAllAuthorsInteractor(IGetAllAuthorsRepository getAllAuthorsRepository,
            IGetAllAuthorsOutputPort getAllAuthorsOutputPort)
        {
            GetAllAuthorsRepository = getAllAuthorsRepository;
            GetAllAuthorsOutputPort = getAllAuthorsOutputPort;
        }

        public async ValueTask Handle()
        {
            var authorDtos = await GetAllAuthorsRepository.GetAllAuthorsAsync();
            await GetAllAuthorsOutputPort.Handle(authorDtos);
        }
    }
}
