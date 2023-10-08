using FluentValidation;

namespace AppCadastroUsuario.Api.Domain
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public static string NomeErroMsg => "O campo Nome do usuário não pode estar vazio";
        public static string EmailErroMsg => "O campo E-mail do usuário não pode estar vazio";
        public static string LoginErroMsg => "O campo Login do usuário não pode estar vazio";
        public static string SenhaErroMsg => "O campo Senha do usuário não pode estar vazio";
        public static string SenhaMinCaracteresErroMsg => "O campo Senha deve conter no minímo 6 caracteres";

        public UsuarioValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage(NomeErroMsg);

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage(EmailErroMsg);

            RuleFor(c => c.Login)
                .NotEmpty()
                .WithMessage(LoginErroMsg);

            RuleFor(c => c.Senha)
                .NotEmpty()
                .WithMessage(SenhaErroMsg);

            RuleFor(c => c.Senha)
                .MinimumLength(6)
                .WithMessage(SenhaMinCaracteresErroMsg);
        }
    }
}
