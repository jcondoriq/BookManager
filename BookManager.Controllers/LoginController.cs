using BookManager.BusinessObjects.DTOs.Login;
using BookManager.BusinessObjects.Interfaces.Controllers;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Controllers
{
    internal class LoginController : ILoginController
    {
        readonly ILoginInputPort InputPort;
        readonly ILoginPresenter presenter;
        public LoginController(ILoginInputPort inputPort, ILoginPresenter presenter)
        {
            InputPort = inputPort;
            this.presenter = presenter;
        }
        public async ValueTask<string> Login(UserCredentialsDto userCredentialsDto)
        {
            await InputPort.Handle(userCredentialsDto);
            return presenter.Token;
        }
    }
}
