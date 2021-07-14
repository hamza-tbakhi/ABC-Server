using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces.Common
{
    public interface IService<Entity>
    {
        Entity Add(Entity entity);
        IEnumerable<Entity> AddRange(IEnumerable<Entity> entities);
        Entity Update(Entity entity);
        IEnumerable<Entity> UpdateRange(IEnumerable<Entity> entities);
        Entity Remove(Entity entity);
        IEnumerable<Entity> RemoveRange(IEnumerable<Entity> entities);
        IEnumerable<Entity> RemoveRangeByIDs(IEnumerable<long> IDs);
        Entity Get(long Id);
        IEnumerable<Entity> GetAll();

    }
}
