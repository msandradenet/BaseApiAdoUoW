using BaseApiAdoUow.CORE.Models;
using System.Collections.Generic;

namespace BaseApiAdoUow.CORE.Services
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAll();
        Cliente Get(int id);
        bool Create(Cliente cliente);
        bool Update(Cliente cliente);
        bool Delete(int id);
    }
}
