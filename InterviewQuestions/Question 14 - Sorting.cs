using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    /// <summary>
    /// Without using any kind of .Sort or OrderBy Method or touching the constructor re-arrange the Numbers list into numerical order
    /// Hint: I'm looking for loops
    /// </summary>
    public class Question14
    {
        public List<int> Numbers { get; set; }

        public Question14()
        {
            Numbers = new List<int>()
            {
                1,9,32,5,2,6,4,2,7
            };    
        }

        public List<int> Answer()
        {
            // create new list, get a count of previous list, go through list count number of times, each time goes through list, 
            // add lowest number to the new list, and then remove it. thus ending in a numerical order.
            var answer = new List<int>();
            var count = Numbers.Count();
            for (int i = 0; i < count; i++)
            {
                var lowestNumber = Numbers.Min();
                answer.Add(lowestNumber);
                Numbers.Remove(lowestNumber);
            }

            return answer;
        }
    }
}
