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

        /// <summary>
        /// Medical Record Number for the patient
        /// </summary>
        public virtual string MRN { get; set; }

        /// <summary>
        /// Given name for the patient
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Family name for the patient
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Street address for the patient
        /// </summary>
        public virtual string Address1 { get; set; }

        /// <summary>
        /// Street address (continued) for the patient
        /// </summary>
        public virtual string Address2 { get; set; }

        /// <summary>
        /// City of residence for the patient
        /// </summary>
        public virtual string City { get; set; }

        /// <summary>
        /// State of residence for the patient
        /// </summary>
        public virtual StateEnum State { get; set; }

        /// <summary>
        /// Zipcode for the patient
        /// </summary>
        public virtual string ZipCode { get; set; }

        private List<InsurancePolicy> _insurancePolicies = new List<InsurancePolicy>();

        /// <summary>
        /// Collection of insurance policies for the patient
        /// </summary>
        public virtual IEnumerable<InsurancePolicy> InsurancePolicies
        {
            get
            {
                foreach (var pol in _insurancePolicies) yield return pol;
                yield break;
            }
        }

        /// <summary>
        /// Add an insurance policy to the patient's collection
        /// </summary>
        /// <param name="policy">The insurance policy to add</param>
        /// <returns></returns>
        public virtual Patient AddInsurancePolicy(InsurancePolicy policy)
        {
            _insurancePolicies.Add(policy);
            return this;
        }

        /// <summary>
        /// Returns short string representation of the patient's first and last name, and first insurance policy
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns short string representation of the patient's first and last name, and first insurance policy
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns short string representation of the patient's first and last name, and first insurance policy
        /// </summary>
        /// <returns></returns>
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

    public static class PatientExtension
    {
        /// <summary>
        /// Returns a JSON representation of the patient information
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string ToJSON(this Patient p)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(p);
        }
    }
}
