using BookManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Services
{
    internal interface IBookService
    {
        ResultViewModel<int> Register(RegisterBookInputModel model);
        ResultViewModel<List<BookViewModel>> GetAll(string search ="");
        ResultViewModel<BookViewModel> GetById(int id);
        ResultViewModel Delete(int id);
    }
}
