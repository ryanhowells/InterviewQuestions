//Question 7 - Code review the code below. Write any comments / suggestions in code comments next to the affected line.
// if you feel like your comment can be backed up with evidence: eg 'this breaks the open closed principle' - please point to any evidence via MSDN, 
// blogposts etc


//Start code review HERE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; // remove unused directives

namespace InterviewQuestions
{
    public class Question7
    {
        public string defaultAnswer;// add line break
        private List<string> AvaliableAnswers { get; set; } // typo... "available"
        // remove extra line break

        public Question7(List<string> avaliableAnswers) // add space after ctor name and typo... "available"
        {
            defaultAnswer = GetDefaultAnswer(avaliableAnswers);
        }

        public string GetDefaultAnswer(List<string> avaliableAnswers)
        {
            try
            {
                // we shouldn't have more than one avaliable answer NORMALLY, so lets try and get one. // try not to add comments where the logic can explain.
                return avaliableAnswers.Single(); // this will blow up IF there is more than one, so if there is a scenario where there can be more than one we need to cater for it...
                // it's bad practice to use try catch's as part of your logic process, please use a different approach, e.g. if (availableAnswers.Count != 0)
            }
            catch (Exception e) // not using the exception here, don't need to declare, you can catch all exceptions without declaring e
            {
                if (avaliableAnswers.Count == 0)
                {
                    return "There are no answers avaliable"; // typo... "available"
                }
                else
                {
                    // there were multiple answers. Inform the user // don't need this comment, code already explains what is happening here.
                    return "There are more than 1 answers to this question";
                }
            }
        }

        public void DisplayAnswersToUser()
        {
            foreach (var answer in AvaliableAnswers)
            {
                var currentItemPosition = AvaliableAnswers.IndexOf(answer) + 1;
                Console.WriteLine(currentItemPosition + " - " + answer); // if you're expecting < 1000, most performant way to concatenate string would be String.Join("-", currentItemPosition, answer);
            }
        }
    }
}
