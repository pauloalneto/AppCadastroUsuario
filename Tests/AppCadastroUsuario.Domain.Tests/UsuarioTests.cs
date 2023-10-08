using AppCadastroUsuario.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastroUsuario.Domain.Tests
{
    public class UsuarioTests
    {
        [Fact(DisplayName = "Adicionar Usuário Válido")]
        [Trait("Usuario", "Usuario Cadastro")]
        public void AdicionarUsuario_DevePassarNaValidacao()
        {
            //Arrange
            var usuario = new Usuario("Fulano A", "fulano_a@gmail.com", "fulano.a", "12345678", DateTime.Now);

            //Act
            var result = usuario.EhValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Usuário Válido")]
        [Trait("Usuario", "Usuario Cadastro")]
        public void AdicionarUsuario_NãoDevePassarNaValidacao()
        {
            //Arrange
            var usuario = new Usuario("", "", "", "", DateTime.Now);

            //Act
            var result = usuario.EhValido();

            //Assert
            Assert.False(result);
            Assert.Contains(UsuarioValidation.NomeErroMsg, usuario.ValidationResult.Errors.Select(u => u.ErrorMessage));
            Assert.Contains(UsuarioValidation.EmailErroMsg, usuario.ValidationResult.Errors.Select(u => u.ErrorMessage));
            Assert.Contains(UsuarioValidation.LoginErroMsg, usuario.ValidationResult.Errors.Select(u => u.ErrorMessage));
            Assert.Contains(UsuarioValidation.SenhaErroMsg, usuario.ValidationResult.Errors.Select(u => u.ErrorMessage));
            Assert.Contains(UsuarioValidation.SenhaMinCaracteresErroMsg, usuario.ValidationResult.Errors.Select(u => u.ErrorMessage));
        }
    }
}
