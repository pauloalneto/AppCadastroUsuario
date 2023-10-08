using AppCadastroUsuario.Api.Domain;
using Common.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AppCadastroUsuario.Api.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppCadastroUsuarioContext _context;
        
        public UsuarioRepository(AppCadastroUsuarioContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Usuario>> GetWithFilters(UsuarioFilter filters)
        {
            return await _context.Usuarios.AsNoTracking()
                .Where(u => (filters.Nome.IsNullOrEmpty() || u.Nome.ToLower().Contains(filters.Nome.ToLower())) &&
                            (filters.Email.IsNullOrEmpty() || u.Email.ToLower().Contains(filters.Email.ToLower()))&&
                            (filters.Login.IsNullOrEmpty() || u.Login.ToLower().Contains(filters.Login.ToLower()))&&
                            (filters.Senha.IsNullOrEmpty() || (u.Senha == filters.Senha)))
                .ToListAsync();
        }

        public async Task<Usuario> GetById(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public void Insert(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            var usuarioOld = GetById(usuario.Id).Result;
            _context.Entry(usuarioOld).CurrentValues.SetValues(usuario);
            _context.Usuarios.Update(usuarioOld);
        }
        public void Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
