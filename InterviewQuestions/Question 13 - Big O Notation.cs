using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    /// <summary>
    /// Write some code that could be described in Big O notation as O(n^2)
    /// </summary>
    public class Question13
    {
        public List<string> TheO { get; set; }

        public void DoSomethingToTheListUsingONotation(int number1, int number2)
        {
            // loop inside of a loop
            for (int i = 0; i < number1; i++)
            {
                for (int x = 0; x < number2; x++)
                {
                    TheO.Add(string.Format("{0}{1}", i, x));
                }
            }
        }
    }
}
