using API_ENTITY_FRAMEWORK.Models.Banco_Destinos;
using API_ENTITY_FRAMEWORK.UnitOfWork;

namespace API_ENTITY_FRAMEWORK.Services.PontoTuristico_Service;

public class PontoTurisiticoService : IPontoTuristicoService
{
    private readonly IUnitOfWork _unitOfWork;

    public PontoTurisiticoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PontoTuristico> AddAsync(PontoTuristico pontoTuristico)
    {
        await _unitOfWork.PontoTuristicoRepository.AddAsync(pontoTuristico);
        await _unitOfWork.Destinos_Commit();
        return pontoTuristico;
    }
}