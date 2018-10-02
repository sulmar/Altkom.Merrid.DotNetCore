using Altkom.Merrid.ProjectX.IServices;
using Altkom.Merrid.ProjectX.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.Merrid.ProjectX.FakeServices
{
    public class FakeEntitiesService<T> : IEntitiesService<T>
        where T : Base
    {
        protected IList<T> _entities = new List<T>();

        public virtual void Add(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                _entities.Add(entity);
            }
        }

        public virtual void Add(T entity)
        {
            _entities.Add(entity);
        }

        public virtual IList<T> Get()
        {
            return _entities;
        }

        public virtual T Get(int id)
        {
            return _entities.SingleOrDefault(e => e.Id == id);
        }

        public virtual void Remove(int id)
        {
            _entities.Remove(Get(id));
        }

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
