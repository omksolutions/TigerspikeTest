using System;
using TigerspikeTest.Classes.Rates;

namespace TigerspikeTest.Intrfaces
{
    public interface ICarParkRateManager
    {
        /// <summary>
        /// Main Calculate method
        /// </summary>
        /// <param name="enter">Entry Time</param>
        /// <param name="exit">Exit Time</param>
        void Calculate(DateTime enter, DateTime exit);

        /// <summary>
        /// Acquire correct rate based on business rules
        /// </summary>
        /// <param name="enter">Entry time</param>
        /// <param name="exit"Exit time</param>
        /// <returns>Instance of Rate</returns>
        Rate GetCorrectRate(DateTime enter, DateTime exit);
    }
}
