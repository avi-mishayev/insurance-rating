using System;

namespace Nipendo.Evaluation
{

    public class PolicyHealth : Policy
    {
        private string Gender { get; set; }
        private decimal Deductible { get; set; }

        public override decimal GetRating() {
            decimal rating;
            Console.WriteLine("Rating HEALTH policy...");
            Console.WriteLine("Validating policy.");
            if (String.IsNullOrEmpty(this.Gender))
            {
                Console.WriteLine("Health policy must specify Gender");
                return 0;
            }
            if (this.Gender == "Male")
            {
                if (this.Deductible < 500)
                {
                    rating = 1000m;
                }
                rating = 900m;
            }
            else
            {
                if (this.Deductible < 800)
                {
                    rating = 1100m;
                }
                rating = 1000m;
            }

            return rating;
        }

    }
}
