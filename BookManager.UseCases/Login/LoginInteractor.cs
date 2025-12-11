using BookManager.BusinessObjects.DTOs.Login;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UseCases.Login
{
    internal class LoginInteractor : ILoginInputPort
    {
        readonly ILoginOutputPort OutputPort;
        readonly IGetUserByCredentialsRepository GetUserByCredentialsRepository;

        public LoginInteractor(ILoginOutputPort outputPort, IGetUserByCredentialsRepository getUserByCredentialsRepository)
        {
            OutputPort = outputPort;
            GetUserByCredentialsRepository = getUserByCredentialsRepository;
        }

        public async ValueTask Handle(UserCredentialsDto userData)
        {
            var User = await GetUserByCredentialsRepository.GetUserByCredentials(userData);
            if (User == default)
            {
                throw new UnauthorizedAccessException(
                    "Las credenciales proporcionadas son incorrectas");
            }
            await OutputPort.Handle(User);
        }
    }
}
