using BaseApiAdoUow.CORE.Models;
using BaseApiAdoUow.INFRA.Repository.Interfaces.Actions;
using System.Collections.Generic;

namespace BaseApiAdoUow.INFRA.Repository.Interfaces
{
    public interface IClienteRepository : IReadRepository<Cliente, int>, ICreateRepository<Cliente>, IUpdateRepository<Cliente>, IRemoveRepository<int>
    {
        //void Create(IEnumerable<Cliente> model, int clienteId);
        //IEnumerable<Cliente> GetAllByClienteId(int clienteId);
        //void RemoveByClienteId(int clienteId);
    }
}
