using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bowling.Interfaces;

namespace Bowling.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BowlingController : Controller
    {
        private IBowlingService _bowlingService;

        public BowlingController(IBowlingService bowlingService)
        {
            _bowlingService = bowlingService;
        }

        public async Task<IActionResult> ValidateResults()
        {
            var viewData = await _bowlingService.ValidateResults();

            return Ok(viewData);
        }
    }
}