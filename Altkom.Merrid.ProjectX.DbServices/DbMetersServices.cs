using Altkom.Merrid.ProjectX.IServices;
using Altkom.Merrid.ProjectX.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altkom.Merrid.ProjectX.DbServices
{
    public class DbMetersServices : IMetersService
    {
        private readonly ProjectXContext context;

        public DbMetersServices(ProjectXContext context)
        {
            this.context = context;
        }

        public void Add(IList<Meter> entities)
        {
            context.Meters.AddRange(entities);
            context.SaveChanges();
        }

        public void Add(Meter entity)
        {
            context.Meters.Add(entity);
            context.SaveChanges();
        }

        public IList<Meter> Get()
        {
            return context.Meters.FromSql("select * from dbo.Meters").ToList();
           // return context.Meters.ToList();
        }

        public Meter Get(int id)
        {
            return context.Meters.FirstOrDefault(m => m.Id == id);

            // return context.Meters.SingleOrDefault(m => m.Id == id);
            // return context.Meters.Find(id);
        }

        public void Remove(int id)
        {
            var meter = Get(id);
            context.Meters.Remove(meter);

            // optymalizacja: bez pobierania encji z db
            //var meter = new Meter { Id = id };
            //context.Entry(meter).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(Meter entity)
        {
            context.Meters.Update(entity);
            context.SaveChanges();
        }
    }


}
