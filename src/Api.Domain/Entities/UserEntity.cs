using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório.")]
        [StringLength(60, ErrorMessage = "Nome precisa ser menor que 60 carácteres.")]
        public string Name { get; set; }
        [StringLength(60, ErrorMessage = "Email precisa ser menor que 60 carácteres.")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
