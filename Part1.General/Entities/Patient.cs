using System.Collections.Generic;
using Part1.General.Entities;
using FluentValidation;
using System.Text;

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
                foreach (var pol in _insurancePolicies) yield return pol;
                yield break;
            }
        }

        public virtual Patient AddInsurancePolicy(InsurancePolicy policy)
        {
            _insurancePolicies.Add(policy);
            return this;
        }

        // methods GetDisplayText1(), GetDisplayText2(), and GetDisplayText3() which use each of these methods.The output
        //should be in the format:
        //    [FirstName] [LastName]

        //If the Patient class has at least one insurance policy, add some text to the end so the output is like this:
        //	[FirstName] [LastName] - [InsuranceProviderName] [InsurancePolicyNumber]

        public string GetDisplayText1()
        {

            string returnString = FirstName + " " + LastName;

            var policies = InsurancePolicies.GetEnumerator();
            if (policies.MoveNext())
            {
                returnString += " - " + policies.Current.GetDisplayText();
            }

            return returnString;
        }

        public string GetDisplayText2()
        {
            string returnString = string.Concat(FirstName, " ", LastName);
            string insuranceString = string.Empty;

            var policies = InsurancePolicies.GetEnumerator();
            if (policies.MoveNext())
            {
                insuranceString = string.Concat(" - ", policies.Current.GetDisplayText());
            }

            return string.Concat(returnString, insuranceString);
        }

        public string GetDisplayText3()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FirstName).Append(" ").Append(LastName);

            var policies = InsurancePolicies.GetEnumerator();
            if (policies.MoveNext())
            {
                sb.Append(" - ").Append(policies.Current.GetDisplayText());
            }

            return sb.ToString();
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
