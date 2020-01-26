using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(60, ErrorMessage = "Name length can't be more than 60.")]
        public string Name { get; set; }
        [StringLength(60, ErrorMessage = "Email length can't be more than 60.")]
        public string Email { get; set; }
    }
}
