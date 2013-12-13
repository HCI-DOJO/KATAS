namespace StringCalculator.Brooke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringCalculator : IStringCalculator
    {
        /// <summary>
        /// Gets the current implementation of the string parser.
        /// </summary>
        /// <value>The string parser.</value>
        public IParser Parser { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringCalculator"/> class.
        /// </summary>
        /// <param name="stringParser">The string parser.</param>
        public StringCalculator(IParser stringParser)
        {
            Parser = stringParser;
        }

        /// <summary>
        /// Adds the numbers in the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>The sum of the expression.</returns>
        public int Add(string expression)
        {
            var values = Parser.Parse(expression);
            
            if (values.Any(i => i < 0))
                ThrowNegativeNumberException(values);

            return values.Sum();

        }

        /// <summary>
        /// Throws the negative number exception.
        /// </summary>
        /// <param name="values">The offending values.</param>
        /// <exception cref="System.Exception"></exception>
        private void ThrowNegativeNumberException(IEnumerable<int> values)
        {
            throw new Exception(
                string.Format(
                    "Negative numbers are not allowed: {0}",
                    string.Join(",", values.Where(i => i < 0))));
        }
        
    }
 
}