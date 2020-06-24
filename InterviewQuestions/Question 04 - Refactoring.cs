using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    /// <summary>
    /// Refactor the code below so that the nested if statements are reduced as much as possible.
    /// Attempt to failfast as much as possible, so that all checks do not need to run if any validation has failed.
    /// </summary>
    public class Question4
    {
        private ISuccessChecker _initializationChecker;
        private ISuccessChecker _nullChecker;
        private ISuccessChecker _dataEntryValidation;
        private ISuccessChecker _databaseValiator;

        private Question4(ISuccessChecker initializationChecker, ISuccessChecker nullChecker,
            ISuccessChecker dataEntryChecker, ISuccessChecker databaseValidator)
        {
            _initializationChecker = initializationChecker;
            _nullChecker = nullChecker;
            _dataEntryValidation = dataEntryChecker;
            _databaseValiator = databaseValidator;
        }

        public string GetResult()
        {
            if (!_initializationChecker.DidSucceed())
                return "Entry did not pass initial validation";

            if (!_nullChecker.DidSucceed())
                return "Could not validate nulls";

            if (!_dataEntryValidation.DidSucceed())
                return "Could not validate data entry";

            if (!_databaseValiator.DidSucceed())
                return "could not validate database";

            return "validated";
        }

        private interface ISuccessChecker
        {
            bool DidSucceed();
        }
    }
}
