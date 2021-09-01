using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormCalculator
{
    public class NegativesNotAllowedException : Exception
    {
        static char sep = ',';

        public NegativesNotAllowedException(IEnumerable<int> negativeNumbers) : base($"Negative Not allowed : {string.Join(",", negativeNumbers)}")
        {
        }
    }
}

