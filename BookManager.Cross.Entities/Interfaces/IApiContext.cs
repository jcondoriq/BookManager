using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Cross.Entities.Interfaces
{
    public interface IApiContext
    {
        Task<T?> GetAsync<T>(string url);
        Task<string> GetStringAsync(string url);
    }
}
