using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é um campo obrigatório.")]
        [EmailAddress(ErrorMessage = "Email informado é inválido.")]
        [StringLength(100, ErrorMessage = "Email precisa ser menor que 100 carácteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é um campo obrigatório.")]
        [StringLength(100, ErrorMessage = "Senha precisa ser menor que 20 carácteres.")]
        public string Password { get; set; }
    }
}