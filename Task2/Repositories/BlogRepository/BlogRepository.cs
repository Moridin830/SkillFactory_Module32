using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task2.Controllers;
using Task2.Models;
using Task2.Middlewares;
using Task2.Models.Db;
using Task2.Models.Db.Context;

namespace Task2.Repositories.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            //// Получим всех активных пользователей
            return await _context.Users.ToArrayAsync();
        }
    }
}
