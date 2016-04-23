using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Part1.General.Entities;
using FluentValidation.Results;
using FluentValidation.TestHelper;

namespace Part1.General.UnitTests
{
    [TestClass]
    public class PatientUnitTests
    {
        internal static Patient getValidPatient_noPolicy()
        {

            return new Patient()
            {
                Address1 = "123 Main St",
                City = "Beverly Hills",
                State = StateEnum.CA,
                ZipCode = "90210",
                FirstName = "Dave",
                LastName = "Smith",
                MRN = "abcd1234"
            };
        }

        internal static Patient getValidPatient()
        {
            return getValidPatient_noPolicy().AddInsurancePolicy(InsurancePolicyUnitTests.getValidInsurancePolicy());
        }

        [TestMethod]
        public void ValidPatientValidates()
        {
            Patient p = getValidPatient();
            PatientValidator v = new PatientValidator();

            var result = v.Validate(p);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void PatientMustHaveAtLeastOneValidInsurancePolicy()
        {
            PatientValidator v = new PatientValidator();


            // No policies
            {

                Patient p = getValidPatient_noPolicy();

                // This requires a setter for InsurancePolicies, which is not what i want for any other purpose
                //var result = v.ShouldHaveValidationErrorFor(pat => pat.InsurancePolicies, p);

                // So we do this instead which will break at runtime if the name of the property changes
                var result = v.Validate(p);
                Assert.IsFalse(result.IsValid);
                Assert.IsTrue(result.Errors.Count == 1);
                Assert.IsTrue(result.Errors[0].PropertyName == "InsurancePolicies");
            }

            // Has an invalid policy
            {
                Patient p = getValidPatient_noPolicy();
                p.AddInsurancePolicy(InsurancePolicyUnitTests.getInvalidInsurancePolicy());
                var result = v.Validate(p);
                Assert.IsFalse(result.IsValid);
            }

            // Has an invalid and valid policy
            {
                Patient p = getValidPatient_noPolicy();
                p.AddInsurancePolicy(InsurancePolicyUnitTests.getInvalidInsurancePolicy());
                p.AddInsurancePolicy(InsurancePolicyUnitTests.getValidInsurancePolicy());
                var result = v.Validate(p);
                Assert.IsFalse(result.IsValid);
            }

            {
                // Has only valid policy
                Patient p = getValidPatient_noPolicy();
                p.AddInsurancePolicy(InsurancePolicyUnitTests.getValidInsurancePolicy());
                var result = v.Validate(p);
                Assert.IsTrue(result.IsValid);
            }
        }

        [TestMethod]
        public void PatientMustHaveNonemptyAndNonnull_FirstName()
        {
            Patient p = getValidPatient();
            PatientValidator v = new PatientValidator();

            p.FirstName = String.Empty;
            var result = v.ShouldHaveValidationErrorFor(pat => pat.FirstName, p);

            p.FirstName = null;
            result = v.ShouldHaveValidationErrorFor(pat => pat.FirstName, p);
        }

        [TestMethod]
        public void PatientMustHaveNonemptyAndNonnull_LastName()
        {
            Patient p = getValidPatient();
            PatientValidator v = new PatientValidator();

            p.LastName = String.Empty;
            var result = v.ShouldHaveValidationErrorFor(pat => pat.LastName, p);

            p.LastName = null;
            result = v.ShouldHaveValidationErrorFor(pat => pat.LastName, p);
        }

        [TestMethod]
        public void PatientMustHaveNonemptyAndNonnull_MRN()
        {
            Patient p = getValidPatient();
            PatientValidator v = new PatientValidator();

            p.MRN = String.Empty;
            var result = v.ShouldHaveValidationErrorFor(pat => pat.MRN, p);

            p.MRN = null;
            result = v.ShouldHaveValidationErrorFor(pat => pat.MRN, p);
        }

        [TestMethod]
        public void PatientMustHaveNonemptyAndNonnull_Address1()
        {
            Patient p = getValidPatient();
            PatientValidator v = new PatientValidator();

            p.Address1 = String.Empty;
            var result = v.ShouldHaveValidationErrorFor(pat => pat.Address1, p);

            p.Address1 = String.Empty;
            result = v.ShouldHaveValidationErrorFor(pat => pat.Address1, p);
        }

        [TestMethod]
        public void DisplayTextMethodsMustDisplayText()
        {
            {
                Patient p = getValidPatient_noPolicy();
                string disp1 = p.GetDisplayText1();
                string disp2 = p.GetDisplayText2();
                string disp3 = p.GetDisplayText3();

                Assert.IsNotNull(disp1);
                Assert.AreNotEqual(disp1, string.Empty);
                Assert.AreEqual(disp1, disp2);
                Assert.AreEqual(disp2, disp3);
            }

            {
                Patient p = getValidPatient();
                string disp1 = p.GetDisplayText1();
                string disp2 = p.GetDisplayText2();
                string disp3 = p.GetDisplayText3();

                Assert.IsNotNull(disp1);
                Assert.AreNotEqual(disp1, string.Empty);
                Assert.AreEqual(disp1, disp2);
                Assert.AreEqual(disp2, disp3);
            }

        }
    }
}
