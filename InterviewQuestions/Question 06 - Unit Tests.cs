﻿namespace InterviewQuestions
{
    /// <summary>
    /// Write a new unit test class that will test the method below.
    /// The expectation is that 2 unit tests will be written.
    /// 
    /// No unit test frameworks have been added, so it is up to your preference whether to use Nunit, Xunit, MSTest, or any other testing frameworks.
    /// </summary>
    public class Question6
    {
        // please find this question's answer in the new test project.
        private readonly IQuestion6Dependency _dependency;

        public Question6(IQuestion6Dependency dependency)
        {
            _dependency = dependency;
        }

        public string GetFirstSixCharactersOfDatabaseValue()
        {
            var dbValue = _dependency.GetValueFromDatabase();
            return dbValue.Substring(0, 6);
        }
    }

    public interface IQuestion6Dependency
    {
        string GetValueFromDatabase();
    }
}
