using Common.Entity;
using System.ComponentModel.DataAnnotations;

namespace AppCadastroUsuario.Api.Domain
{
    public class Usuario : EntityBase
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataCadastro { get; private set; }

        protected Usuario()
        {
        }

        public Usuario(string nome, string email, string login, string senha, DateTime dataCadastro)
        {
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            DataCadastro = dataCadastro;
        }

        public bool EhValido()
        {
            ValidationResult = new UsuarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
