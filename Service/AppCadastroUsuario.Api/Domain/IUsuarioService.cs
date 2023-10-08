namespace AppCadastroUsuario.Api.Domain
{
    public interface IUsuarioService : IDisposable
    {
        Task<bool> AdicionarUsuario(Usuario usuario);
        Task<bool> AtualizarUsuario(Usuario usuario);
        Task<bool> ExcluirUsuario(Guid id);
    }
}
