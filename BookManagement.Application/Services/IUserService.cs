using BookManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Services
{
    public interface IUserService
    {
        ResultViewModel<int> Register(RegisterUserInputModel model);
    }
}
