using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator.Adam.Core
{
    public class SumNumbers:Command<double>
    {
        private string _numbersToSum;
        private string _delimiter;

        public SumNumbers(string numbersToSum,string delimiter = null)
        {
            _numbersToSum = numbersToSum;
            _delimiter = delimiter;
        }

        public override void Execute()
        {
            if (_numbersToSum == string.Empty)
            {
                return;
            }

            var delimiter = _delimiter;

            if (_delimiter == null)
            {
                delimiter = new Regex(@"\D").Match(_numbersToSum.Replace("-","")).Value;
            }
           
            var numbers = _numbersToSum.Split(new []{delimiter},StringSplitOptions.RemoveEmptyEntries);

            Func<string,string> matches = (d) => { return new Regex(@"-\d").Match(d).Value; };
            
            numbers.ToList().ForEach((n) => {
                                                if (matches(n) != string.Empty)
                                                {
                                                    var d = Convert.ToDouble(n);
                                                    throw new NegativeNumberNotAllowedException(d);
                                                }
            });

            Result = numbers.Sum((s) => Convert.ToDouble(s));
        }
    }
}
