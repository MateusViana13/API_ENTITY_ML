using API_ENTITY_FRAMEWORK.DTO.BancoDestinosDTOs;
using API_ENTITY_FRAMEWORK.Models.Banco_Destinos;
using AutoMapper;

namespace API_ENTITY_FRAMEWORK.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<DestinoDTO, Destino>();
        CreateMap<Destino, DestinoDTO>();
    }
}