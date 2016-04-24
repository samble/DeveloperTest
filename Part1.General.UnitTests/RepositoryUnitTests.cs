using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Part1.General.Repositories;
using System.Collections.Generic;
using Part1.General.Entities;

namespace Part1.General.UnitTests
{
    [TestClass]
    public class RepositoryUnitTests
    {
        [TestMethod]
        public void TestSearchMethod()
        {
            PatientRepository pr = new PatientRepository();
            Patient p1 = PatientUnitTests.getValidPatient();

            string validFirstname = p1.FirstName;
            StateEnum validState = p1.State;

            pr.AddPatient(p1);

            pr.AddPatient(new Patient()
            {
                Address1 = "77 West Dr",
                City = "Joelton",
                State = StateEnum.TN,
                ZipCode = "12345",
                FirstName = "John",
                LastName = "Johnsonson",
                MRN = "abcd1235"
            });

            Patient p2 = PatientUnitTests.getValidPatient();
            p2.FirstName = validFirstname + "son";
            pr.AddPatient(p2);

            Patient p3 = PatientUnitTests.getValidPatient();
            p3.State = validState + 1;
            pr.AddPatient(p3);

            {
                List<Patient> result = pr.Search(p => p.FirstName == validFirstname);

                Assert.IsNotNull(result);
                Assert.IsTrue(result.TrueForAll(p => p.FirstName == validFirstname));
                Assert.IsTrue(result.Count == 2);
            }

            {
                List<Patient> result = pr.Search(p => p.State == validState);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.TrueForAll(p => p.State == validState));
                Assert.IsTrue(result.Count == 2);
            }
        }
    }
}
