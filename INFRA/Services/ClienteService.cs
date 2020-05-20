using BaseApiAdoUow.CORE.Services;
using BaseApiAdoUow.CORE.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using BaseApiAdoUow.INFRA.UnitOfWork.Interfaces;

namespace BaseApiAdoUow.INFRA.Services
{
    public class ClienteService : IClienteService
    {
        private IUnitOfWork _unitOfWork;

        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Cliente> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var records = context.Repositories.ClienteRepository.GetAll();

                return records;
            }
        }

        public Cliente Get(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.ClienteRepository.Get(id);

                return result;
            }
        }

        public bool Create(Cliente model)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.ClienteRepository.Create(model);

                context.SaveChanges();

                return result;
            }
        }

        public bool Update(Cliente model)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.ClienteRepository.Update(model);

                context.SaveChanges();

                return result;
            }
        }

        public bool Delete(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.ClienteRepository.Remove(id);

                context.SaveChanges();

                return result;
            }
        }

    }
}
