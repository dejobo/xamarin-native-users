using System.Collections.Generic;

namespace TodoApp.Core
{
    public partial interface IRepository<T> where T: BaseModel
    {
        IList<T> Collection { get; }
        T GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
