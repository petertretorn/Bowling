using Bowling.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Interfaces
{
    public interface IBowlingApiService
    {
        Task<BowlingResponse> GetResults();

        Task<ValidationResponse> ValidateCalculations(ValidationPayload payload);
    }
}
