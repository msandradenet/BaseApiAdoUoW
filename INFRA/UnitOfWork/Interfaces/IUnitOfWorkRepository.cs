using BaseApiAdoUow.INFRA.Repository.Interfaces;

namespace BaseApiAdoUow.INFRA.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IClienteRepository ClienteRepository { get; }
    }
}
