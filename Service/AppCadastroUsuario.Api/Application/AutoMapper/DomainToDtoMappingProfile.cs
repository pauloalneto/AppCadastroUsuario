using AppCadastroUsuario.Api.Application.Dtos;
using AppCadastroUsuario.Api.Domain;
using AutoMapper;

namespace AppCadastroUsuario.Api.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
