using API_ENTITY_FRAMEWORK.Models.Banco_Destinos;

namespace API_ENTITY_FRAMEWORK.Services.Destino_Service;
public interface IDestinosServices
{
    Task<Destino> GetDestinoAsync(Guid externalKey);
    Task<Destino> AddAsync(Destino destino);
    Task UpdateAsync(Destino destino);
    Task DeleteAsync(Guid externalKey);
}