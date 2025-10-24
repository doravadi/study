using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private static List<T> _dataStore = new List<T>();

        public void Add(T entity)
        {
            _dataStore.Add(entity);
        }

        public void Update(T entity)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                var id = (Guid)idProperty.GetValue(entity);
                var existingEntity = _dataStore.FirstOrDefault(e => (Guid)idProperty.GetValue(e) == id);
                if (existingEntity != null)
                {
                    _dataStore.Remove(existingEntity);
                    _dataStore.Add(entity);
                }
            }
        }

        public void Delete(Guid id)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                var entity = _dataStore.FirstOrDefault(e => (Guid)idProperty.GetValue(e) == id);
                if (entity != null)
                {
                    _dataStore.Remove(entity);
                }
            }
        }

        public T GetById(Guid id)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                return _dataStore.FirstOrDefault(e => (Guid)idProperty.GetValue(e) == id);
            }
            return null;
        }

        public List<T> GetAll()
        {
            return _dataStore;
        }
    }
}
