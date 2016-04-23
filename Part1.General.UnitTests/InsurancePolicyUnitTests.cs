using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Part1.General.Entities;
using FluentValidation.TestHelper;


namespace Part1.General.UnitTests
{
    [TestClass]
    public class InsurancePolicyUnitTests
    {
        internal static InsurancePolicy getValidInsurancePolicy()
        {
            return new InsurancePolicy() { PolicyNumber = "ZYX987-22", ProviderName = "Blue Sky" };
        }

        internal static InsurancePolicy getInvalidInsurancePolicy()
        {
            return new InsurancePolicy() { PolicyNumber = null, ProviderName = String.Empty };
        }

        [TestMethod]
        public void PolicyNumberMustBeNonemptyAndNonnull()
        {
            InsurancePolicy i = getValidInsurancePolicy();
            InsurancePolicyValidator v = new InsurancePolicyValidator();

            i.PolicyNumber = String.Empty;
            v.ShouldHaveValidationErrorFor(ins => ins.PolicyNumber, i);

            i.PolicyNumber = null;
            v.ShouldHaveValidationErrorFor(ins => ins.PolicyNumber, i);
        }

        [TestMethod]
        public void ProvidernameMustBeNonemptyAndNonnull()
        {
            InsurancePolicy i = getValidInsurancePolicy();
            InsurancePolicyValidator v = new InsurancePolicyValidator();

            i.ProviderName = String.Empty;
            v.ShouldHaveValidationErrorFor(ins => ins.ProviderName, i);

            i.ProviderName = null;
            v.ShouldHaveValidationErrorFor(ins => ins.ProviderName, i);
        }

    }
}
