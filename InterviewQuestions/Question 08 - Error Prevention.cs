namespace InterviewQuestions
{
    /// <summary>
    /// Write some code in the method below that will cause a stack overflow exception
    /// </summary>
    public class Question8
    {
        // will just be in a loop calling itself forever until it blows up with a stack overflow exception.
        public void CauseStackOverflowException(long number)
        {
            CauseStackOverflowException(number);
        }
    }
}
