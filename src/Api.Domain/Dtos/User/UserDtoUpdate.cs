using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDtoUpdate
    {[
        Required(ErrorMessage = "ID é um campo obrigatório.")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Email é um campo obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        [StringLength(100, ErrorMessage = "Email precisa ser menor que 100 carácteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatório.")]
        [StringLength(60, ErrorMessage = "Nome precisa ser menor que 60 carácteres.")]
        public string Name { get; set; }       
        [Required(ErrorMessage = "Senha é um campo obrigatório.")]
        [StringLength(20, ErrorMessage = "A senha precisa ser menor que 20 carácteres.")]
        public string Password { get; set; } 
    }
}