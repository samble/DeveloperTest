using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part1.General.Entities;

namespace Part1.General.Repositories
{
    public class PatientRepository
    {
        private List<Patient> Data = new List<Patient>();

        public void AddPatient(Patient p)
        {
            Data.Add(p);
        }

        // Implement Search here
        public List<Patient> Search(Predicate<Patient> searchFunc)
        {
            return Data.FindAll(searchFunc);
        }
    }
}
