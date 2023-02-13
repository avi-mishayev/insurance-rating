using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;

namespace Nipendo.Evaluation
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; } = 0;

        public void Rate()
        {
            // log start rating
            Console.WriteLine("Starting rate.");

            var policy = LoadPolicy("policy.json");

            if (policy != null)
            {
                Rating = policy.GetRating();
            }

            Console.WriteLine("Rating completed.");
        }

        private Policy LoadPolicy(string fileName)
        {
            Console.WriteLine("Loading policy.");

            // load policy - open file policy.json
            string policyJson = File.ReadAllText(fileName);
            var policy = JsonConvert.DeserializeObject<Policy>(policyJson, new PolicyJsonConverter());

            return policy;
        }
    }
}
