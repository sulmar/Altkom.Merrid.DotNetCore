using Altkom.Merrid.ProjectX.IServices;
using Altkom.Merrid.ProjectX.Models;

namespace Altkom.Merrid.ProjectX.FakeServices
{
    public class FakeUnitsService : FakeEntitiesService<Unit>, IUnitsService
    {
        public FakeUnitsService()
        {
        }
    }
}
