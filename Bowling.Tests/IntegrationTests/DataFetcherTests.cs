using Bowling.Dtos;
using Bowling.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Bowling.Tests
{
    /// <summary>
    /// Summary description for DataFetcherTests
    /// </summary>
    [TestClass]
    public class DataFetcherTests
    {
        
        [TestMethod]
        public async Task Can_Call_External_Api()
        {
            var sut = new ApiService();

            var result = await sut.FetchData<BowlingResponse>("http://13.74.31.101/api/points");

            Assert.IsNotNull(result);
        }
    }
}
