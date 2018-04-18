using System;
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
            var sut = new BowlingService(
                new DataService(),
                new FrameBuilder(),
                new BowlingCalculator()
                );

            var result = await sut.ValidateResults();

            Assert.IsTrue(result.Result);
        }
    }
}
