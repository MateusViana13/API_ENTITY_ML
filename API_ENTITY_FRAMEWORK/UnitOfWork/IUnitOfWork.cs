using API_ENTITY_FRAMEWORK.Context;
using API_ENTITY_FRAMEWORK.Models.Banco_Destinos;

namespace API_ENTITY_FRAMEWORK.UnitOfWork;

public interface IUnitOfWork
{
    public IBaseRepository<BancoDestinosContext, Destino> DestinoRepository { get; set; }
    public IBaseRepository<BancoDestinosContext, PontoTuristico> PontoTuristicoRepository { get; set; }
    Task Destinos_Commit();
}