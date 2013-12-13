namespace StringCalculator.Brooke
{
    using NUnit.Framework;

    [TestFixture]
    public class String_Calculator_Specifications : Given_A_String_Calculator
    {
        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            var sum = Calculator.Add(string.Empty);

            Assert.AreEqual(0, sum);
        }

        [Test]
        public void Add_OneNumber_ReturnTheNumber()
        {
            var sum = Calculator.Add("1");

            Assert.AreEqual(1,sum);
        }

        [Test]
        public void Add_TwoNumbersSperatedByAComma_ReturnTheSumOfTheTwoNumbers()
        {
            var sum = Calculator.Add("1,2");

            Assert.AreEqual(3,sum);
        }

        [Test]
        public void Add_ManyNumbers_ReturnTheSumOfAllNumbers()
        {
            var sum = Calculator.Add("1,2,3,4,5");

            Assert.AreEqual(15, sum);
        }

        [Test]
        public void Add_NumbersContainingANewLineCharacter_ReturnTheSumOfAllNumbers()
        {
            var sum = Calculator.Add("1\n2");

            Assert.AreEqual(3,sum);
        }

        [Test]
        public void Add_NumbersSeperatedByASpecifiedDelimeter_ReturnTheSumOfTheNumbers()
        {
            var sum = Calculator.Add("//:1:2:3");

            Assert.AreEqual(6, sum);
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Negative numbers are not allowed: -1")]
        public void Add_OneNegativeNumber_ThrowAnException()
        {
            var sum = Calculator.Add("-1");
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Negative numbers are not allowed: -1,-2")]
        public void Add_ManyNegativeNumber_ThrowAnException()
        {
            var sum = Calculator.Add("//%-1%-2");
        }
    }
}