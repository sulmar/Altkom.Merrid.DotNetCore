using Altkom.Merrid.ProjectX.IServices;
using Altkom.Merrid.ProjectX.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altkom.Merrid.ProjectX.DbServices
{
    public class DbMeasuresService : IMeasuresService
    {
        private readonly ProjectXContext context;

        public DbMeasuresService(ProjectXContext context)
        {
            this.context = context;
        }

        public void Add(IList<Measure> entities)
        {
            throw new NotImplementedException();
        }

        public void Add(Measure entity)
        {
            context.Measures.Add(entity);
            context.SaveChanges();
        }

        public IList<Measure> Get(DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IList<Measure> Get()
        {
            // add using Microsoft.EntityFrameworkCore;
            return context.Measures.Include(p=>p.Unit).ToList();
        }

        public Measure Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Measure entity)
        {
            throw new NotImplementedException();
        }
    }
}
