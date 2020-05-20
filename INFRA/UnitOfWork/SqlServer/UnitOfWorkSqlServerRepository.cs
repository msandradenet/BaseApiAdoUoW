using BaseApiAdoUow.INFRA.Repository.Interfaces;
using BaseApiAdoUow.INFRA.Repository.SqlServer;
using BaseApiAdoUow.INFRA.UnitOfWork.Interfaces;
using System.Data.SqlClient;

namespace BaseApiAdoUow.INFRA.UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IClienteRepository ClienteRepository { get; }

        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            ClienteRepository = new ClienteRepository(context, transaction);
        }
    }
}
