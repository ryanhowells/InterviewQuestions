using System;
using System.Threading.Tasks;
namespace InterviewQuestions
{
    /// <summary>
    /// What will happen when I execute the DoWork method? write your answer below
    /// 
    /// 
    /// Answer:
    /// dbObject Task is assigned to it's variable, but not performed as the task is not awaited and .Result hasn't been called to synchronously perform the task.
    /// dbobjectTask is then synchronously performed and passed into the DoMoreWork method.
    /// Console then writes the Database Objects Id.
    /// 
    /// 
    /// </summary>
    public class Question9
    {
        private readonly IRepository<DatabaseObject> _database;

        private Question9(IRepository<DatabaseObject> database)
        {
            _database = database;
        }

        public void DoWork()
        {
            var dbObject = GetObjectByIdAsync(5);
            DoMoreWork(dbObject.Result);
        }

        private void DoMoreWork(DatabaseObject obj)
        {
            Console.WriteLine(obj.Id);
        }

        private async Task<DatabaseObject> GetObjectByIdAsync(int id)
        {
            var dbObject = await _database.GetObjectFromDatabaseAsync(id);
            return dbObject;
        }

        private interface IRepository<T>
        {
            Task<T> GetObjectFromDatabaseAsync(int id);
        }

        private class DatabaseObject
        {
            public int Id { get; set; }
        }
    }
}
