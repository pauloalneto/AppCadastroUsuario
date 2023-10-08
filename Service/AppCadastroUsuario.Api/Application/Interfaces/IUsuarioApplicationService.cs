using AppCadastroUsuario.Api.Application.Dtos;
using AppCadastroUsuario.Api.Domain;
using Common.Service;

namespace AppCadastroUsuario.Api.Application.Interfaces
{
    public interface IUsuarioApplicationService : IApplicationService<UsuarioDto, UsuarioFilter>
    {


    }
}
