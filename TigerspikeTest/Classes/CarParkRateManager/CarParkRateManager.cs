using System;
using TigerspikeTest.Intrfaces;
using TigerspikeTest.Classes.Rates;

namespace TigerspikeTest.Classes.CarParkRateManager
{
    /// <summary>
    /// Car Park Manager class, implements ICarParkRateManager
    /// </summary>
    public class CarParkRateManager : ICarParkRateManager
    {
        /// <summary>
        /// Main Calculate method
        /// </summary>
        /// <param name="enter">Entry Time</param>
        /// <param name="exit">Exit Time</param>
        public void Calculate(DateTime enter, DateTime exit)
        {
            //Ideally should use tryparse!
            if (enter != null && exit != null)
            {
                Rate patronRate = GetCorrectRate(enter, exit);
                patronRate.CalculateTotal(enter, exit);

                Console.WriteLine("Welcome to the Car Park!");
                Console.WriteLine("------------------------");
                Console.WriteLine("");
                Console.WriteLine("Your Rate is: {0} ", patronRate.Name);
                Console.WriteLine("Your Total Price is: ${0} ", patronRate.Price);

                Console.WriteLine("Thank you for using the car park!");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Acquire correct rate based on business rules
        /// </summary>
        /// <param name="enter">Entry time</param>
        /// <param name="exit"Exit time</param>
        /// <returns>Instance of Rate</returns>
        public Rate GetCorrectRate(DateTime enter, DateTime exit)
        {
            Rate earlyBird = new EarlyBirdRate();
            Rate nightRate = new NightRate();
            Rate standardRate = new StandardRate();
            DayOfWeek dow = enter.DayOfWeek;

            if (enter >= earlyBird.EnterStartTime && enter <= earlyBird.EnterEndTime)
            {
                if (exit >= earlyBird.ExitStartTime && exit <= earlyBird.ExitEndTime)
                {
                    return earlyBird;
                }
                else
                    return standardRate;
            }
            else if (enter >= nightRate.EnterStartTime && enter <= nightRate.EnterEndTime)
            {
                if ((dow == DayOfWeek.Saturday) || (dow == DayOfWeek.Sunday))
                {
                    return standardRate;
                }

                int dayDifference = exit.Day - enter.Day;
                if ((dayDifference == 1) && exit.Hour <= 6)
                {
                    return nightRate;
                }
                else
                    return standardRate;
            }
            else
            {
                return standardRate;
            }
        }
    }
}
