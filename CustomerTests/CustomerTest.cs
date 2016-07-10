using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Customer;

namespace CustomerTests
{
    [TestFixture]
    public class CustomerTest
    {

        [TestCaseSource("TestParams")]
        public string Format_Tests(string str, object arg, IFormatProvider provider)
        {
            CustomerFormatProvider cfp = new CustomerFormatProvider();
            return cfp.Format(str, arg, provider);
        }
        public IEnumerable<TestCaseData> TestParams()
        {
            Customer.Customer customer = new Customer.Customer("Ivan", "+34445556666", 1000000);
            yield return new TestCaseData("F", customer, null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(null, customer, null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(null, null, null).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData("P", customer, null).Returns("+3 (444) 555-6666 ");
            yield return new TestCaseData("NP", customer, null).Returns("Ivan , + 3 (444) 555 - 6666 ");
            yield return new TestCaseData("N", customer, null).Returns("Ivan ");
            yield return new TestCaseData("R", customer, null).Returns("1000000 ");
            yield return new TestCaseData("RP", customer, null).Returns("+3 (444) 555-6666 ,101214 ");
            yield return new TestCaseData("RN", customer, null).Returns("Ivan ,1000000 ");
            yield return new TestCaseData("RNP", customer, null).Returns("Ivan ,+ 3 (444) 555 - 6666  ,1000000 ");
            yield return new TestCaseData("RNP", null, null).Throws(typeof(ArgumentNullException));


        }
    }
}

