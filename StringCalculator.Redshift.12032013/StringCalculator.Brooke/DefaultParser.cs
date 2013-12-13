namespace StringCalculator.Brooke
{
    using System.Linq;

    public class DefaultParser : IParser
    {
        /// <summary>
        /// Gets the parser's delimiters.
        /// </summary>
        /// <value>The delimiters.</value>
        public string Delimiters { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultParser"/> class.
        /// </summary>
        public DefaultParser()
        {
            Delimiters = ",\n";
        }

        /// <summary>
        /// Parses the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public int[] Parse(string expression)
        {
            if (UsesAdaptiveDelimiters(expression))
            {
                AddDelimiter(expression);
                TrimExpression(ref expression);
            }

            return string.IsNullOrWhiteSpace(expression) ? new[] { 0 }
                : expression.Split(Delimiters.ToCharArray()).Select(int.Parse).ToArray();
        }

        /// <summary>
        /// Expression uses the adaptive delimiters?
        /// </summary>
        /// <param name="expression">The string expression.</param>
        /// <returns></returns>
        private bool UsesAdaptiveDelimiters(string expression)
        {
            return expression.StartsWith("//");
        }

        /// <summary>
        /// Adds the delimiter to our list.
        /// </summary>
        /// <param name="expression">The expression.</param>
        private void AddDelimiter(string expression)
        {
            Delimiters += expression.Substring(2, 1);
        }

        /// <summary>
        /// Trims the expression to adjust for the 'escaped' delimiter.
        /// </summary>
        /// <param name="expression">The expression.</param>
        private void TrimExpression(ref string expression)
        {
            expression = expression.Substring(3, expression.Length - 3);
        }




    }
}