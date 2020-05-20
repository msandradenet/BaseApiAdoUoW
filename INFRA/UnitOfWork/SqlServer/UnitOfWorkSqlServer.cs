using BaseApiAdoUow.INFRA.UnitOfWork.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApiAdoUow.INFRA.UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServer : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public UnitOfWorkSqlServer(IConfiguration configuration = null)
        {
            _configuration = configuration;
        }

        public IUnitOfWorkAdapter Create()
        {
            var connectionString = _configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

            return new UnitOfWorkSqlServerAdapter(connectionString);
        }
    }
}
