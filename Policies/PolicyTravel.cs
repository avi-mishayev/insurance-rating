using System;

namespace Nipendo.Evaluation
{

    public class PolicyTravel : Policy
    {
        private const int MaxDays = 180;

        public string Country { get; set; }
        public int Days { get; set; }

        public override decimal GetRating() {
            decimal rating;
            Console.WriteLine("Rating TRAVEL policy...");
            Console.WriteLine("Validating policy.");
            if (this.Days <= 0)
            {
                Console.WriteLine("Travel policy must specify Days.");
                return 0;
            }
            if (this.Days > MaxDays)
            {
                Console.WriteLine($"Travel policy cannot be more then {MaxDays} Days.");
                return 0;
            }
            if (String.IsNullOrEmpty(this.Country))
            {
                Console.WriteLine("Travel policy must specify country.");
                return 0;
            }
            rating = this.Days * 2.5m;
            if (this.Country == "Italy")
            {
                rating *= 3;
            }
            return rating;
        }

    }
}
