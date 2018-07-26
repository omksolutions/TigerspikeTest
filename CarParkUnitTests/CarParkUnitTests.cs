using System;
using TigerspikeTest.Classes.CarParkRateManager;
using TigerspikeTest.Classes.Rates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarParkUnitTests
{
    [TestClass]
    public class CarParkUnitTests
    {
        CarParkRateManager cpManager;

        [TestInitialize]
        public void Init()
        {
            cpManager = new CarParkRateManager();
        }

        [TestMethod]
        public void CalculateTotalTestInvalidTimes()
        {
        }

        [TestMethod]
        public void CalculateTotalTest()
        {
            DateTime entry = DateTime.Parse("08:00:00 AM");
            DateTime exit = entry.AddHours(60);

            Rate rt = cpManager.GetCorrectRate(entry, exit);
            rt.CalculateTotal(entry, exit);

            Assert.AreEqual(40.0M, rt.Price);            
        }

        [TestMethod]
        public void RateManagerCalculateTest()
        {
            DateTime entry = DateTime.Parse("12:00:00 PM");
            DateTime exit = entry.AddHours(2);

            Rate currentRate = cpManager.GetCorrectRate(entry, exit);
            currentRate.CalculateTotal(entry, exit);

            Assert.AreEqual("Standard Rate", currentRate.Name);
            Assert.AreEqual("Hourly Rate", currentRate.Type);
            Assert.AreEqual(10.0M, currentRate.Price);
        }

        [TestMethod]

        public void RateManagerCalculateTestInvalidTimesTest()
        {

        }

        [TestMethod]
        public void RateManagerGetRateTest()
        {

        }

        [TestMethod]
        public void RateManagerGetRateInvalidTimesTest()
        {

        }
    }
}
