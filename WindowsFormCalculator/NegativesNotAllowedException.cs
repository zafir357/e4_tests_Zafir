using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormCalculator
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(IEnumerable<int> negativeNumbers) : base($"Negative Not allowed : {string.Join(",", negativeNumbers)}")
        {
        }
    }
}

