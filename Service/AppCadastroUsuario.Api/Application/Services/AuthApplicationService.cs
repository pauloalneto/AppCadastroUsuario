using AppCadastroUsuario.Api.Application.Dtos;
using AppCadastroUsuario.Api.Application.Interfaces;
using AppCadastroUsuario.Api.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppCadastroUsuario.Api.Application.Services
{
    public class AuthApplicationService : IAuthApplicationService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthApplicationService(IUsuarioRepository usuarioRepository,
            IMapper mapper,
            IConfiguration config)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _config = config;
        }

        public async Task<dynamic> Autenticar(CredencialUsuarioDto credencialUsuarioDto)
        {
            var usuarioRep = await _usuarioRepository.GetWithFilters(new UsuarioFilter { Login = credencialUsuarioDto.Login, Senha = credencialUsuarioDto.Senha });
            var usuario = usuarioRep.FirstOrDefault();

            if (usuario == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.UTF8.GetBytes(_config["JwtConfigs:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, "AcessoLimitado")
                 }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            //Apenas para simulação do acesso as rotas
            var listaRotas = new List<string>()
            {
                "usuario"
            };

            return new
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Perfil = "Admin",
                Permissoes = "AcessoLimitado",
                token = jwtToken,
                Rotas = listaRotas
            };
        }
    }
}
