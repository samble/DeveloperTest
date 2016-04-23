using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1.General
{
    class Patient
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
        public Entities.StateEnum State { get; set; }
        public string ZipCode { get; set; }

    }
}
