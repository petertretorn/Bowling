using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Bowling.Infrastructure;

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
            var sut = new DataService();

            var result = await sut.FetchData<BowlingResponse>("http://13.74.31.101/api/points");

            Assert.IsNotNull(result);
        }
    }
}
