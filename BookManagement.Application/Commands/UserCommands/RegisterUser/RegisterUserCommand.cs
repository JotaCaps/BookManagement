using BookManagement.Application.Models;
using BookManagement.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Application.Commands.UserCommands.RegisterUser
{
    public class RegisterUserCommand : IRequest<ResultViewModel<int>>
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
