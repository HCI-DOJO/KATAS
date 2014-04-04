using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Adam.Core;

namespace StringCalculator.Adam.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void when_give_an_empty_string_the_calculator_returns_zero()
        {
            var testString = string.Empty;
            
            var result = Execute(new SumNumbers(testString));

            Assert.AreEqual(0,result);
        }

        [TestMethod]
        public void when_given_one_number_the_calculator_will_return_that_number()
        {
            var testString = "1";

            var result = Execute(new SumNumbers(testString));

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void when_given_two_comma_seperated_numbers_the_calculator_will_return_the_sum_of_them()
        {
            var testString = "1,1";

            var result = Execute(new SumNumbers(testString));

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void when_given_n_newline_seperated_numbers_the_calculator_will_return_the_sum_of_them()
        {
            var testString = "1\n1\n1\n";

            var result = Execute(new SumNumbers(testString));

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void when_given_n_numbers_seperated_by_a_supplied_delimiter_the_calculator_will_return_the_sum_of_delimited_numbers()
        {
            var testString = "1-1-1";

            var result = Execute(new SumNumbers(testString,"-"));

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeNumberNotAllowedException))]
        public void when_given_a_negative_number_the_calculator_will_throw_an_exception()
        {
            var testString = "-1";

            var result = Execute(new SumNumbers(testString));
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeNumberNotAllowedException))]
        public void when_given_a_negative_numbers_the_calculator_will_throw_an_exception()
        {
            var testString = "-1,-2";

            var result = Execute(new SumNumbers(testString));
        }


        private TResult Execute<TResult>(Command<TResult> command)
        {
            command.Execute();
            return command.Result;
        }
    }
}
