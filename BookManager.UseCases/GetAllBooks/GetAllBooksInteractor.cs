using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UseCases.GetAllBooks
{
    internal class GetAllBooksInteractor : IGetAllBooksInputPort
    {
        readonly IGetAllBooksOutputPort GetAllBooksOutputPort;
        readonly IGetAllBooksRepository GetAllBooksRepository;

        public GetAllBooksInteractor(IGetAllBooksOutputPort getAllBooksOutputPort, 
            IGetAllBooksRepository getAllBooksRepository)
        {
            GetAllBooksOutputPort = getAllBooksOutputPort;
            GetAllBooksRepository = getAllBooksRepository;
        }

        public async ValueTask Handle()
        {
            var BooksDtos = await GetAllBooksRepository.GetAllBooksAsync();
            await GetAllBooksOutputPort.Handle(BooksDtos);
        }
    }
}
