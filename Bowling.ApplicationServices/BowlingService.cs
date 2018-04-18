using Bowling.Domain;
using Bowling.Dtos;
using Bowling.Interfaces;
using System;
using System.Threading.Tasks;

namespace Bowling.ApplicationServices
{
    public class BowlingService : IBowlingService
    {
        private IBowlingApiService _bowlingApi;
        private IBowlingCalculator _calculator;

        public BowlingService(
            IBowlingApiService bowlingApi, 
            IBowlingCalculator calculator)
        {
            _bowlingApi = bowlingApi;
            _calculator = calculator;
        }

        public async Task<ViewData> ValidateResults()
        {
            var response = await _bowlingApi.GetResults();

            var token = response.Token;
            var scores = response.Points;

            var points  = _calculator.CalulatePoints(scores);

            var payload = new ValidationPayload()
            {
                points = points,
                token = token
            };

            var result = await _bowlingApi.ValidateCalculations(payload);

            return new ViewData()
            {
                Scores = scores,
                CalculatedPoints = points,
                Result = result.Success
            };
        }
    }
}
