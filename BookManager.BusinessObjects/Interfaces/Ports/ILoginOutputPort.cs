using BookManager.BusinessObjects.DTOs.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Ports
{
    public interface ILoginOutputPort
    {
        ValueTask Handle(UserDto userDto);
    }
}
