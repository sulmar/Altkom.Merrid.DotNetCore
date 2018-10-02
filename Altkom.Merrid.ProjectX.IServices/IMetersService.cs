using Altkom.Merrid.ProjectX.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Altkom.Merrid.ProjectX.IServices
{
    //public interface IMetersService
    //{
    //    IList<Meter> Get();
    //    Meter Get(int id);
    //    void Add(IList<Meter> meters);
    //    void Add(Meter meter);
    //    void Update(Meter meter);
    //    void Remove(int id);
    //}

    public interface IMetersService : IEntitiesService<Meter>
    {

    }

    public interface IUnitsService : IEntitiesService<Unit>
    {

    }

    public interface IMeasuresService : IEntitiesService<Measure>
    {
        IList<Measure> Get(DateTime begin, DateTime end);
    }

    public interface IEntitiesService<TEntity>
    {
        IList<TEntity> Get();
        TEntity Get(int id);
        void Add(IList<TEntity> entities);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }


}
