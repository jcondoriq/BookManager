using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Cross.Entities.Interfaces
{
    public interface IApiContextFactory
    {
        IApiContext Create(string clientName);
    }
}
