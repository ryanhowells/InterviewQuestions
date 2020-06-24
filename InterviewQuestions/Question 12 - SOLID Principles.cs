using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    /// <summary>
    /// Write some theoretical code that satisfies the following user stories. Please ADHERE the solid principles as much as you possibly can.
    /// Aim to copy your answer from question 11 as much as possible, adding comments to explain why you have made any changes when turning your non-solid code into good code. 
    /// 
    /// Given I am answering question 12
    /// When I process entities
    /// Then only items that have not been updated in the last week will be processed
    /// 
    /// Given I am answering question 12
    /// When I process entities
    /// Then items being processed will '- done' appended to the end of their name
    /// And they will be marked as updated
    /// </summary>
    public class Question12
    {
        private IDatabase<IEntity> _db;
        private readonly IEntityService<IEntity> _entityService;

        public Question12(IDatabase<IEntity> db, IEntityService<IEntity> entityService)
        {
            _db = db;
            _entityService = entityService;
        }

        public void Process()
        {
            using (var session = _db.OpenSession())
            {
                var entities = session.GetObjects();
                IEnumerable<IEntity> filteredEntities = _entityService.FilterByDate(DateTime.UtcNow.AddDays(7)).ToList();

                foreach (var entity in filteredEntities)
                {
                    entity.Name = _entityService.ModifyName();
                    session.Insert(entity);
                }

                session.SaveChanges();
            }
        }


        #region Set Up Classes - Please look

        public interface IDatabase<T> where T : IEntity
        {
            ISession<T> OpenSession();
        }

        public interface ISession<T> : IDisposable where T : IEntity
        {
            IQueryable<T> GetObjects();

            void Insert(T entity);

            void SaveChanges();
        }

        public interface IEntityService<T> where T : IEntity
        {
            IQueryable<T> FilterByDate(DateTime filterDate);

            string ModifyName();
        }

        public interface IEntity
        {
            int Id { get; set; }

            string Name { get; set; }

            DateTimeOffset LastUpdated { get; set; }
        }

        #endregion
    }
}
