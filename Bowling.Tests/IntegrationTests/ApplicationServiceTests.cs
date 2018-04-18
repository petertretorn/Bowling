using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling.ApplicationServices;
using Bowling.Infrastructure;
using Bowling.Domain;
using System.Threading.Tasks;

namespace Bowling.Tests
{
    [TestClass]
    public class ApplicationServiceTests
    {
        [TestMethod]
        public async Task Can_InVoke_Service()
        {
            var bowlingApi = new BowlingApiService(new ApiService());
            var calculator = new BowlingCalculator(new FrameLinker());

            var sut = new BowlingService(bowlingApi, calculator);

            var result = await sut.ValidateResults();

            Assert.IsTrue(result.Result);
        }
    }
}
