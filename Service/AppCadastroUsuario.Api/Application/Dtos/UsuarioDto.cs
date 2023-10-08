using System.ComponentModel.DataAnnotations;

namespace AppCadastroUsuario.Api.Application.Dtos
{
    public class UsuarioDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Login { get; set; }

        [StringLength(8, ErrorMessage = "O campo {0} precisa ter o valor entre {1} e {2} caracteres", MinimumLength = 6)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
