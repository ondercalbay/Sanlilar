using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.IL
{
    public interface IGenericManager<Entity, ListDto, EditDto>
    {
        EditDto Add(EditDto editDto);

        EditDto Update(EditDto editDto);

        void Delete(int id);

        List<ListDto> Get(Entity filter);

        EditDto Get(int id);
    }
}
