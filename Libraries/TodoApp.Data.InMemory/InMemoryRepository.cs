using System.Collections.Generic;
using System.Linq;
using TodoApp.Core;

namespace TodoApp.Data.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseModel
    {
        private List<T> _entities;

        public InMemoryRepository()
        {
            
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public IList<T> Collection
        {
            get
            {
                return Entities;
            }            
        }

        public void Delete(T entity)
        {
            Entities.Remove(entity);
        }

        public T GetById(object id)
        {
            var entity = Entities.FirstOrDefault(x => x.Id == (int)id);
            return entity;
        }

        public void Update(T entity)
        {
            var currentEntity = GetById(entity.Id);
            currentEntity = entity;
        }

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual List<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = new List<T>();
                return _entities;
            }
            set
            {
                value = _entities;
            }
        }
    }
}
