using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApiAdoUow.INFRA.Repository.Interfaces.Actions
{
    public interface IRemoveRepository<T>
    {
        bool Remove(T id);
    }
}
