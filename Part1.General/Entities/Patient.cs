using System.Collections.Generic;
using Part1.General.Entities;
using FluentValidation;

namespace Part1.General.Entities
{
    public class Patient
    {
        ~Patient()
        {
            MRN = null;
            FirstName = null;
            LastName = null;
            Address1 = null;
            Address2 = null;
            City = null;
            //State = null;
            ZipCode = null;
            _insurancePolicies = null;
        }

        //- Medical record number(string)
        public virtual string MRN { get; set; }

        //- First and last name
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        //- Street address including city, state, and zip code
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string City { get; set; }
        public virtual StateEnum State { get; set; }
        public virtual string ZipCode { get; set; }

        private List<InsurancePolicy> _insurancePolicies = new List<InsurancePolicy>();

        public virtual IEnumerable<InsurancePolicy> InsurancePolicies
        {
            get
            {
                return _insurancePolicies;
            }
        }

        public virtual Patient AddInsurancePolicy(InsurancePolicy policy)
        {
            _insurancePolicies.Add(policy);
            return this;
        }
    }

    public class PatientValidator : AbstractValidator<Patient>
    {
        // The medical record number, first and last name, and street address must contain some
        // string value that is not empty or null. Patient class must have at least one valid insurance policy
        public PatientValidator()
        {
            RuleFor(x => x.MRN).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Address1).NotEmpty();

            RuleFor(x => x.InsurancePolicies).Must(policies => policies.GetEnumerator().MoveNext() != false);
            RuleForEach(x => x.InsurancePolicies).SetValidator(new InsurancePolicyValidator());
        }
    }
}
