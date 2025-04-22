using BookManagement.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Commands.LoanCommands.RegisterReturnCommand
{
    public class RegisterReturnCommand : IRequest<ResultViewModel<string>>
    {
        public RegisterReturnCommand(int id, DateTime returnDate)
        {
            Id = id;
            ReturnDate = returnDate;
        }

        public int Id { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
