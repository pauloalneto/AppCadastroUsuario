using AppCadastroUsuario.Api.Application.Dtos;
using AppCadastroUsuario.Api.Application.Interfaces;
using AppCadastroUsuario.Api.Domain;
using AutoMapper;
using System.Collections.Generic;

namespace AppCadastroUsuario.Api.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioApplicationService(IUsuarioRepository usuarioRepository, 
            IUsuarioService usuarioService, 
            IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> GetWithFilter(UsuarioFilter filters)
        {
            return _mapper.Map<IEnumerable<UsuarioDto>>(await _usuarioRepository.GetWithFilters(filters));

        }
        public async Task<UsuarioDto> GetById(Guid id)
        {
            return _mapper.Map<UsuarioDto>(await _usuarioRepository.GetById(id));
        }

        public async Task Insert(UsuarioDto usuarioDto)
        {
            Usuario model = _mapper.Map<Usuario>(usuarioDto);

            if (!await _usuarioService.AdicionarUsuario(model))
                throw new Exception("Falha ao tentar adicionar o usuário");
        }

        public async Task Update(UsuarioDto usuario)
        {
            var model = _mapper.Map<Usuario>(usuario);

            if(!await _usuarioService.AtualizarUsuario(model))
                throw new Exception("Falha ao tentar atualizar o usuário");
        }
        public async Task Delete(Guid id)
        {
            if(!await _usuarioService.ExcluirUsuario(id))
                throw new Exception("Falha ao tentar excluir o usuário");
        }

    }
}
