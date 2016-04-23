using System.Collections.Generic;
using Part1.General.Entities;

namespace Part1.General
{
    internal class Patient
    {
        //- Medical record number(string)
        public string MRN { get; set; }

        //- First and last name
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //- Street address including city, state, and zip code
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public StateEnum State { get; set; }
        public string ZipCode { get; set; }

        private List<InsurancePolicy> _insurancePolicies = new List<InsurancePolicy>();

        public IEnumerable<InsurancePolicy> InsurancePolicies { get; private set; }

        public void AddInsurancePolicy(InsurancePolicy policy)
        {
            _insurancePolicies.Add(policy);
        }
    }
}
