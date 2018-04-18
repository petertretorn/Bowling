using Bowling.Domain;
using Bowling.Dtos;
using Bowling.Interfaces;
using System;
using System.Threading.Tasks;

namespace Bowling.ApplicationServices
{
    public class BowlingService : IBowlingService
    {
        private const string url = "http://13.74.31.101/api/points";

        private IBowlingApiService _bowlingApi;
        private IFrameBuilder _builder;
        private IBowlingCalculator _calculator;

        public BowlingService(
            IBowlingApiService bowlingApi, 
            IFrameBuilder frameBuilder, 
            IBowlingCalculator calculator)
        {
            _bowlingApi = bowlingApi;
            _builder = frameBuilder;
            _calculator = calculator;
        }

        public async Task<ViewData> ValidateResults()
        {
            var response = await _bowlingApi.GetResults();

            var token = response.Token;
            var scores = response.Points;

            var startFrame = _builder.BuildFrames(scores);

            var points  = _calculator.CalulatePoints(startFrame);

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
