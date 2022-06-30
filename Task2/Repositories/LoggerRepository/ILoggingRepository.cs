using System;
using System.Threading.Tasks;
using Task2.Controllers;
using Task2.Middlewares;
using Task2.Models.Db;

namespace Task2.Repositories.LoggerRepository
{
    public interface ILoggingRepository
    {
        Task AddRequest(Request request);

        Task<Request[]> GetRequests();
    }
}
