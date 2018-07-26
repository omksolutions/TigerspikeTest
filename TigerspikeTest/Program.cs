using System;
using TigerspikeTest.Classes.CarParkRateManager;

namespace TigerspikeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instance of CarParkRateManager
            CarParkRateManager carParkRateManager = new CarParkRateManager();

            DateTime enterTime = DateTime.Parse("12:00:00 AM");
            DateTime exitTime = enterTime.AddHours(1);

            carParkRateManager.Calculate(enterTime, exitTime);
        }
    }
}
