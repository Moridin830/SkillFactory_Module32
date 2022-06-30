using System;
using System.Threading.Tasks;
using Task2.Controllers;
using Task2.Models;
using Task2.Models.Db;
using Task2.Models.Db.Context;
using Task2.Middlewares;

namespace Task2.Repositories.BlogRepository
{
    public interface IBlogRepository
    {
        Task AddUser(User user);

        Task<User[]> GetUsers();
    }
}
