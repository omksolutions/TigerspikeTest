using System;

namespace TigerspikeTest.Classes.Rates
{
    /// <summary>
    /// Rate base class
    /// </summary>
    public class Rate
    {
        public DateTime EnterStartTime { get; set; }
        public DateTime ExitStartTime { get; set; }
        public DateTime EnterEndTime { get; set; }
        public DateTime ExitEndTime { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// Calculate total if needed
        /// </summary>
        /// <param name="enter">entry time</param>
        /// <param name="exit">exit time</param>
        public virtual void CalculateTotal(DateTime enter, DateTime exit) { }
    }

    /// <summary>
    /// Early Bird Rate
    /// </summary>
    public class EarlyBirdRate : Rate
    {
        public EarlyBirdRate()
        {
            Name = "Early Bird";
            Type = "Flat Rate";
            Price = 13.0M;
            EnterStartTime = DateTime.Parse("06:00:00 AM");
            EnterEndTime = DateTime.Parse("09:00:00 AM");
            ExitStartTime = DateTime.Parse("15:30:00 PM");
            ExitEndTime = DateTime.Parse("23:30:00 PM");
        }
    }

    /// <summary>
    /// Night Rate
    /// </summary>
    public class NightRate : Rate
    {
        public NightRate()
        {
            Name = "Night Rate";
            Type = "Flat Rate";
            Price = 6.50M;
            EnterStartTime = DateTime.Parse("18:00:00 PM");
            EnterEndTime = DateTime.Parse("23:59:59 PM");
        }
    }

    /// <summary>
    /// Standard Rate
    /// </summary>
    public class StandardRate : Rate
    {
        public StandardRate()
        {
            Name = "Standard Rate";
            Type = "Hourly Rate";
            Price = 0;
        }

        public override void CalculateTotal(DateTime enter, DateTime exit)
        {
            double totalHours = exit.Subtract(enter).TotalHours;

            if (totalHours >= 0 && totalHours <= 1)
            {
                Price = 5.0M;
            }
            else if (totalHours >= 1 && totalHours <= 2)
            {
                Price = 10.0M;
            }
            else if (totalHours >= 2 && totalHours <= 3)
            {
                Price = 15.0M;
            }
            else
            {
                if (totalHours > 3)
                {
                    int dayCount = (Int32)exit.Subtract(enter).TotalDays;

                    if (dayCount > 0)
                    {
                        Price = (decimal)dayCount * 20.0M;
                    }
                    else
                        Price = 20.0M;
                }
            }
        }
    }
}
