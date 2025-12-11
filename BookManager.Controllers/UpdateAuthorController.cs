using BookManager.BusinessObjects.DTOs.UpdateAuthor;
using BookManager.BusinessObjects.Interfaces.Controllers;
using BookManager.BusinessObjects.Interfaces.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Controllers
{
    internal class UpdateAuthorController : IUpdateAuthorController
    {
        readonly IUpdateAuthorInputPort UpdateAuthorInputPort;

        public UpdateAuthorController(IUpdateAuthorInputPort updateAuthorInputPort)
        {
            UpdateAuthorInputPort = updateAuthorInputPort;
        }

        public async ValueTask Update(UpdateAuthorDto updateAuthorDto)
        {
            await UpdateAuthorInputPort.Handle(updateAuthorDto);
        }
    }
}
