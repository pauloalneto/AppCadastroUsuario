using Common.Data;

namespace AppCadastroUsuario.Api.Domain
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetWithFilters(UsuarioFilter filters);
        Task<Usuario> GetById(Guid id);

        void Insert(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
    }
}
