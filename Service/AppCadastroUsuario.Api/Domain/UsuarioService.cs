namespace AppCadastroUsuario.Api.Domain
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> AdicionarUsuario(Usuario usuario)
        {
            _usuarioRepository.Insert(usuario);
            return await _usuarioRepository.UnitOfWork.Commit();
        }

        public async Task<bool> AtualizarUsuario(Usuario usuario)
        {
            _usuarioRepository.Update(usuario);
            return await _usuarioRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ExcluirUsuario(Guid id)
        {
            var usuario = await _usuarioRepository.GetById(id);
            if (usuario == null) return false;

            _usuarioRepository.Delete(usuario);
            return await _usuarioRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }

    }
}
