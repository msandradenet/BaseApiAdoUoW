using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApiAdoUow.INFRA.Repository.Interfaces.Actions
{
    public interface IReadRepository<T, Y> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Y id);
    }
}
