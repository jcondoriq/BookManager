using BookManager.BusinessObjects.DTOs.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Controllers
{
    public interface ILoginController
    {
        ValueTask<string> Login(UserCredentialsDto userCredentialsDto);
    }
}
