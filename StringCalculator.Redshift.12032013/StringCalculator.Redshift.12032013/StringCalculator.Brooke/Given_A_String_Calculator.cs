namespace StringCalculator.Brooke
{
    public abstract class Given_A_String_Calculator
    {
        /// <summary>
        /// Gets the string calculator.
        /// </summary>
        /// <value>The calculator.</value>
        public IStringCalculator Calculator { get; private set; }

        protected Given_A_String_Calculator()
        {
            Calculator = new StringCalculator(
                new DefaultParser()
            );
        }
    }
}