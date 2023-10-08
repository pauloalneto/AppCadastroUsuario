using AppCadastroUsuario.Api.Application.Dtos;
using AppCadastroUsuario.Api.Domain;
using AutoMapper;

namespace AppCadastroUsuario.Api.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<UsuarioDto, Usuario>()
                .ConstructUsing(u => new Usuario(u.Nome, u.Email, u.Login, u.Senha, u.DataCadastro));
        }
    }
}
