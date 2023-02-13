using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Nipendo.Evaluation
{
    public class PolicyJsonConverter : JsonConverter<Policy>
    {
        private static readonly Dictionary<PolicyType, Policy> Policies = new Dictionary<PolicyType, Policy>
                {
                    { PolicyType.Health, new PolicyHealth() },
                    { PolicyType.Travel, new PolicyTravel() },
                    { PolicyType.Life, new PolicyLife() },
                };

        public override Policy ReadJson(JsonReader reader, Type objectType, Policy existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var target = Create(objectType, jsonObject);
            if (target == null)
            {
                return null;
            }
            serializer.Populate(jsonObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, Policy value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected Policy Create(Type objectType, JObject jsonObject)
        {
            var typeName = jsonObject["type"].ToString();
            bool isConvertSucceeded = Enum.TryParse(typeName, out PolicyType policyType);
            if (isConvertSucceeded)
            {
                return Policies[policyType];
            }
            Console.WriteLine("Unknown policy type");
            return null;
        }
    }
}
