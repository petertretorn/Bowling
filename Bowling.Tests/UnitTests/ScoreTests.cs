using Bowling.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Tests
{
    [TestClass]
    public class ScoreTests
    {
        [TestMethod]
        public void Can_Calculate_Correct_Scores()
        {
            IEnumerable<int[]> scores = new List<int[]>() { new[] { 3, 7 }, new[] { 10, 0 } , new[] { 8, 2 }, new[] { 8, 1 }, new[] { 10, 0 }, new[] { 3, 4 }, new[] { 7, 0 }, new[] { 5, 5 }, new[] { 3, 2 }, new[] { 2, 5 } };

            var calculator = new BowlingCalculator(new FrameLinker());

            var result = calculator.CalulatePoints(scores);

            var expected = new int[] { 20, 40, 58, 67, 84, 91, 98, 111, 116, 123 };

            CollectionAssert.AreEqual(expected, result.ToList());

        }

        [TestMethod]
        public void Can_Calculate_Double_Strike()
        {
            IEnumerable<int[]> scores = new List<int[]>() { new[] { 10, 0 }, new[] { 10, 0 }, new[] { 4, 2 } };

            var calculator = new BowlingCalculator(new FrameLinker());

            var result = calculator.CalulatePoints(scores);

            var expected = new int[] { 24, 40, 46 };

            CollectionAssert.AreEqual(expected, result.ToList());
        }
    }
}
