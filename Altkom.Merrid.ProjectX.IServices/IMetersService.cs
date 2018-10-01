using Altkom.Merrid.ProjectX.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Altkom.Merrid.ProjectX.IServices
{
    public interface IMetersService
    {
        IList<Meter> Get();
        Meter Get(int id);
        void Add(IList<Meter> meters);
        void Add(Meter meter);
        void Update(Meter meter);
        void Remove(Meter meter);
    }

}
