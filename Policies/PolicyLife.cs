using System;

namespace Nipendo.Evaluation
{

    public class PolicyLife : Policy
    {
        private const int MaxAge = -100;

        private bool IsSmoker { get; set; }
        private decimal Amount { get; set; }

        public override decimal GetRating() {
            decimal rating;
            Console.WriteLine("Rating LIFE policy...");
            Console.WriteLine("Validating policy.");
            if (IsDateOfBirthMissing())
            {
                Console.WriteLine("Life policy must include Date of Birth.");
                return 0;
            }
            if (this.DateOfBirth < DateTime.Today.AddYears(MaxAge))
            {
                Console.WriteLine("Max eligible age for coverage is 100 years.");
                return 0;
            }
            if (this.Amount == 0)
            {
                Console.WriteLine("Life policy must include an Amount.");
                return 0;
            }

            decimal baseRate = this.Amount * GetAge() / 200;
            if (this.IsSmoker)
            {
                rating = baseRate * 2;
                return rating;
            }
            rating = baseRate;
            return rating;
        }

        #region Helpers

        private bool IsDateOfBirthMissing()
        {
            return this.DateOfBirth == DateTime.MinValue;
        }

        private int GetAge()
        {
            int age = DateTime.Today.Year - this.DateOfBirth.Year;
            if (this.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < this.DateOfBirth.Day ||
                DateTime.Today.Month < this.DateOfBirth.Month)
            {
                age--;
            }
            return age;
        }

        #endregion Helpers
    }
}
