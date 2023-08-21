using API_ENTITY_FRAMEWORK.Context;
using API_ENTITY_FRAMEWORK.Models.Banco_Destinos;
using Microsoft.EntityFrameworkCore;

namespace API_ENTITY_FRAMEWORK.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly BancoDestinosContext _bancoDestinosContext;

    public IBaseRepository<BancoDestinosContext, Destino> DestinoRepository { get; set; }
    public IBaseRepository<BancoDestinosContext, PontoTuristico> PontoTuristicoRepository { get; set; }

    public UnitOfWork(BancoDestinosContext bancoDestinosContext,
        IBaseRepository<BancoDestinosContext, Destino> destinoRepository,
        IBaseRepository<BancoDestinosContext, PontoTuristico> pontoTuristicoRepository)
    {
        _bancoDestinosContext = bancoDestinosContext;
        DestinoRepository = destinoRepository;
        PontoTuristicoRepository = pontoTuristicoRepository;
    }

    public async Task Destinos_Commit()
    {
        await _bancoDestinosContext.SaveChangesAsync();
    }
}
