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
            pr.AddPatient(PatientUnitTests.getValidPatient());
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

            List<Patient> result = pr.Search(p => p.FirstName == "Dave");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.TrueForAll(p => p.FirstName == "Dave"));
        }
    }
}
