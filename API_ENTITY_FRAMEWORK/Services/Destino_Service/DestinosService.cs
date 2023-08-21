using API_ENTITY_FRAMEWORK.MiddleWare.Exceptions;
using API_ENTITY_FRAMEWORK.Models.Banco_Destinos;
using API_ENTITY_FRAMEWORK.UnitOfWork;

namespace API_ENTITY_FRAMEWORK.Services.Destino_Service;

public class DestinosService : IDestinosServices
{
    private readonly IUnitOfWork _unitOfWork;

    public DestinosService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Destino> GetDestinoAsync(Guid externalKey)
    {
        var destino = await _unitOfWork.DestinoRepository.GetAsync(d => d.ExternalKey == externalKey);

        if (destino == null)
            throw new DataNotFoundException(nameof(destino));

        return destino;
    }

    public async Task<Destino> AddAsync(Destino destino)
    {
        destino.ExternalKey = Guid.NewGuid();

        await _unitOfWork.DestinoRepository.AddAsync(destino);
        await _unitOfWork.Destinos_Commit();
        return destino;
    }    

    public async Task UpdateAsync(Destino destino)
    {
        _unitOfWork.DestinoRepository.Update(destino);
        await _unitOfWork.Destinos_Commit();
    }

    public async Task DeleteAsync(Guid externalKey) 
    {
        var destino = await _unitOfWork.DestinoRepository.GetAsync(d => d.ExternalKey == externalKey);

        if(destino == null)
            throw new DataNotFoundException(nameof(destino));

        _unitOfWork.DestinoRepository.Remove(destino);
        await _unitOfWork.Destinos_Commit();
    }
}