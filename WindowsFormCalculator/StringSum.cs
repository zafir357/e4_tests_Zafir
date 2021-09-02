using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormCalculator
{
   public class StringSum
    {
        /*
         * 1. A windows application,
           2. For new line hold tab and press enter on the windows box.(Multiline)
           3.Unit testing in XUnitTestProjXCalc project
         * */
        public static int Add(string numbers)
        {
            char[] custDelims = GetDelimiters(numbers);
            string[] strings = numbers.Split(custDelims);
            List<int> numberList = new List<int>();
            foreach(var s in strings)
            {
                if (int.TryParse(s, out int number))
                {
                    numberList.Add(number);
                }
            }
            ValidateNegative(numberList);
            return numberList.Sum();
        }

        private static char[] GetDelimiters(string numbers)
        {
            var delims = new List<char> { ',', '\n' };
            if (numbers.StartsWith("//"))
            {
                
                //if we got a delimiter we should have new line to seperate delimiter
               String delimInit= numbers.Split('\n').First();
                char delim = delimInit.Substring(2,1).Single();
                delims.Add(delim);
          
            }
            return delims.ToArray();
        }

        private static void ValidateNegative(List<int> numberList)
        {
            var negativeNumber = numberList.Where(x => x < 0).ToList();
            if(negativeNumber.Any())
            {
                throw new NegativesNotAllowedException(negativeNumber);
                
            }
        }

    }
}
