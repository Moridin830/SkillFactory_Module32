using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task2.Controllers;
using Task2.Middlewares;
using Task2.Models.Db.Context;
using Task2.Models.Db;

namespace Task2.Repositories.LoggerRepository
{
    public class LoggingRepository : ILoggingRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public LoggingRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddRequest(Request request)
        {
            // Добавление запроса
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            //// Получим всех активных пользователей
            return await _context.Requests.ToArrayAsync();
        }
    }
}
