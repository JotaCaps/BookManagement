using BookManagement.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Application.Models
{
    public class RegisterUserInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        public User ToEntity()
            => new(Id, Name, Email);
    }
}
