using Bowling.Dtos;
using Bowling.Interfaces;
using System.Threading.Tasks;

namespace Bowling.Infrastructure
{
    public class BowlingApiService : IBowlingApiService
    {
        private IApiService _apiService;

        private const string url = "http://13.74.31.101/api/points";

        public BowlingApiService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<BowlingResponse> GetResults()
        {
            return await _apiService.FetchData<BowlingResponse>(url);
        }

        public async Task<ValidationResponse> ValidateCalculations(ValidationPayload payload)
        {
            return await _apiService.PostData<ValidationPayload, ValidationResponse>(payload, url);
        }
    }
}
