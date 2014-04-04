using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Adam.Core
{
    public sealed class NegativeNumberNotAllowedException:Exception
    {
        private const string ExceptionMessage = "Negative numbers are not allowed";

        public NegativeNumberNotAllowedException(double negativeNumber):base(string.Format("{0} - {1}",ExceptionMessage,negativeNumber))
        {

        }

        public NegativeNumberNotAllowedException(IEnumerable<double> negativeNumbers)
            : base(string.Format("{0} - {1}", ExceptionMessage, string.Join(",", negativeNumbers)))

    {

    }
    }
}
