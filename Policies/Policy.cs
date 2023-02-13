using System;

namespace Nipendo.Evaluation
{

    public abstract class Policy
    {
        public PolicyType Type { get; set; }

        #region General Policy Prop
        protected string FullName { get; set; }
        protected DateTime DateOfBirth { get; set; }
        #endregion

        public abstract decimal GetRating();
    }
}
