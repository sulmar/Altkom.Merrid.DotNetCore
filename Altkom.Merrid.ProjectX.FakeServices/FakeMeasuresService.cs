using Altkom.Merrid.ProjectX.IServices;
using Altkom.Merrid.ProjectX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altkom.Merrid.ProjectX.FakeServices
{

    public class FakeMeasuresService : FakeEntitiesService<Measure>, IMeasuresService
    {
        public FakeMeasuresService(Generator generator)
        {
            _entities = generator.Measures;

        }

        public IList<Measure> Get(DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IList<Measure> GetByMeter(int meterId)
        {
            throw new NotImplementedException();
        }
    }
}
