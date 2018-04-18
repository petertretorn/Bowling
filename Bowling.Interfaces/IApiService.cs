using System.Threading.Tasks;

namespace Bowling.Interfaces
{
    public interface IApiService
    {
        Task<T> FetchData<T>(string url);
        Task<Response> PostData<Payload, Response>(Payload payload, string url);
    }
}
