using FluentAssertions;
using InterviewQuestions;
using Moq;
using System;
using Xunit;

namespace InterviewQuestionsTests.cs
{
    public class Question6Tests
    {
        public class GivenDependencyReturnsTest1234_WhenGettingFirstSixCharactersOfDatabaseValue
        {
            [Fact]
            public void ThenTheValueIsFormattedCorrectly()
            {
                var mockDependency = new Mock<IQuestion6Dependency>();
                mockDependency.Setup(x => x.GetValueFromDatabase()).Returns("Test1234");

                var question6 = new Question6(mockDependency.Object);

                string result = question6.GetFirstSixCharactersOfDatabaseValue();
                result.Should().Be("Test12");
            }
        }

        public class GivenDependencyReturnsTest12_WhenGettingFirstSixCharactersOfDatabaseValue
        {
            [Fact]
            public void ThenTheValueIsFormattedCorrectly()
            {
                var mockDependency = new Mock<IQuestion6Dependency>();
                mockDependency.Setup(x => x.GetValueFromDatabase()).Returns("Test12");

                var question6 = new Question6(mockDependency.Object);

                string result = question6.GetFirstSixCharactersOfDatabaseValue();
                result.Should().Be("Test12");
            }
        }
    }
}
