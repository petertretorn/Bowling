using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Interfaces
{
    public interface IDataService
    {
        Task<T> FetchData<T>(string url);
        Task<Response> PostData<Payload, Response>(Payload payload, string url);
    }
}
