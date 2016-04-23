using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Attributes;

namespace Part1.General.Entities
{
    [Validator(typeof(InsurancePolicyValidator))]
    public sealed class InsurancePolicy
    {
        //an insurance policy has a provider name and a policy number (string).
        public string ProviderName { get; set; }
        public string PolicyNumber { get; set; }
    }

    public class InsurancePolicyValidator : AbstractValidator<InsurancePolicy>
    {
        // insurance policy which also should be validated (non-null or empty strings)
        public InsurancePolicyValidator()
        {
            RuleFor(x => x.PolicyNumber).NotEmpty();
            RuleFor(x => x.ProviderName).NotEmpty();
        }
    }
}
