using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    /// <summary>
    /// Rewrite the GetIntValuesFromStrings method to make the most of LINQ. 
    /// While method syntax is preferred, you are permitted to use query syntax.
    /// 
    /// The nature of the query should not change. The query adheres to the following user story.
    /// 
    /// Given I am processing a list of entities
    /// When the name of the entity starts with a two digit number
    /// Then the record will be processed
    /// 
    /// Given I am processing a list of entities
    /// When the name of the entity does not start with a two digit number
    /// Then the record will be ignored
    /// </summary>
    public class Question5
    {
        public List<int> GetIntValuesFromStrings(List<string> entities)
        {
            var firstCharacters = new List<string>();
            firstCharacters.AddRange(entities.Select(x => x.Substring(0, 2)));

            var parsedEntities = new List<int>();
            int parsedValue = 0;
            parsedEntities.AddRange(firstCharacters.Where(x => int.TryParse(x, out parsedValue)).Select(x => parsedValue));
            
            return parsedEntities;
        }
    }
}
