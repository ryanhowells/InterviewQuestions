﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    /// <summary>
    /// Write some theoretical code that satisfies the following user stories. Please VIOLATE the solid principles as much as you possibly can.
    /// 
    /// Given I am answering question 11
    /// When I process entities
    /// Then only items that have not been updated in the last week will be processed
    /// 
    /// Given I am answering question 11
    /// When I process entities
    /// Then items being processed will '- done' appended to the end of their name
    /// And they will be marked as updated
    /// </summary>
    public class Question11
    {
        private IDatabase<IEntity> _db;

        public Question11(IDatabase<IEntity> db)
        {
            _db = db;
        }

        public void Process()
        {
            using (var session = _db.OpenSession())
            {
                var entities = session.GetObjects();
                IEnumerable<IEntity> filteredEntities = entities.Where(x => x.LastUpdated <= DateTime.UtcNow.AddDays(7)).ToList();

                foreach (var entity in filteredEntities)
                {
                    entity.Name = string.Join(string.Empty, entity.Name, "- done");
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

        public interface IEntity
        {
            int Id { get; set; }

            string Name { get; set; }

            DateTimeOffset LastUpdated { get; set; }
        }

        #endregion
    }
}
