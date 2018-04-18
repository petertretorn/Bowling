using Bowling.Domain;
using Bowling.Infrastructure;
using Bowling.Infrastructure.Dtos;
using Bowling.Interfaces;
using System;
using System.Threading.Tasks;

namespace Bowling.ApplicationServices
{
    public class BowlingService
    {
        private const string url = "http://13.74.31.101/api/points";

        private IDataService _dataFetcher;
        private IFrameBuilder _builder;
        private IBowlingCalculator _calculator;

        public BowlingService(
            IDataService fetcher, 
            IFrameBuilder frameBuilder, 
            IBowlingCalculator calculator)
        {
            _dataFetcher = fetcher;
            _builder = frameBuilder;
            _calculator = calculator;
        }

        public async Task<ViewData> ValidateResults()
        {
            var response = await _dataFetcher.FetchData<BowlingResponse>(url);

            var token = response.Token;
            var scores = response.Points;

            var startFrame = _builder.BuildFrames(scores);

            var points  = _calculator.CalulatePoints(startFrame);

            var payload = new ValidationPayload()
            {
                points = points,
                token = token
            };

            var result = await _dataFetcher.PostData<ValidationPayload, ValidationResponse>(payload, url);

            return new ViewData()
            {
                Scores = scores,
                CalculatedPoints = points,
                Result = result.Success
            };
        }
    }
}
