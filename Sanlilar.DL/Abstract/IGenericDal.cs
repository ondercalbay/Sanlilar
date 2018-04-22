using System.Collections.Generic;

namespace Sanlilar.DL.Abstract
{
    public interface IGenericDal<Entity>
    {
        Entity Add(Entity ent);

        Entity Update(Entity ent);

        void Delete(int id, int userId);

        List<Entity> Get(Entity filter);

        Entity Get(int id);
    }
}
