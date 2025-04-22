using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Application.Models;
using MediatR;

namespace BookManagement.Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommand : IRequest<ResultViewModel>
    {
        public DeleteBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
