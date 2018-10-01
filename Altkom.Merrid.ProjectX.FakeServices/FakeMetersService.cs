using Altkom.Merrid.ProjectX.IServices;
using Altkom.Merrid.ProjectX.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.Merrid.ProjectX.FakeServices
{
    public class FakeMetersService : IMetersService
    {
        private IList<Meter> _meters = new List<Meter>();

        public void Add(Meter meter)
        {
            _meters.Add(meter);
        }

        public void Add(IList<Meter> meters)
        {
            foreach (var meter in meters)
            {
                _meters.Add(meter);
            }

            // meters.ToList().ForEach(meter => _meters.Add(meter));

        }

        public IList<Meter> Get()
        {
            return _meters;
        }

        public Meter Get(int id)
        {
            return _meters.SingleOrDefault(meter => meter.Id == id);
        }

        public void Remove(Meter meter)
        {
            _meters.Remove(meter);
        }

        public void Update(Meter meter)
        {
            throw new NotImplementedException();
        }
    }
}
