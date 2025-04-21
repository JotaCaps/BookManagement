using BookManagement.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Application.Models
{
    public class RegisterLoanInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O id do usuário é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Id do usuário deve ser maior que 1")]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "O id do livro é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Id do livro deve ser maior que 1")]
        public int IdBook { get; set; }

        [Required(ErrorMessage = "A data do empréstimo é obrigatória")]
        [DataType(DataType.Date, ErrorMessage = "Data de empréstimo inválida")]
        public DateTime LoanDate { get; set; }

        public Loan ToEntity()
            => new(Id, IdUser, IdBook);
    }
}
