using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Models;
using Task2.Models.Db;
using Task2.Models.Db.Context;
using Task2.Repositories;
using Task2.Repositories.LoggerRepository;

namespace Task2.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILoggingRepository _loggingRepository;
        private BlogContext _blogContext;

        ///// <summary>
        /////  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        ///// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILoggingRepository loggingRepository)
        {
            _loggingRepository = loggingRepository;

            Request request = new()
            {
                Url = $"http://{context.Request.Host.Value + context.Request.Path}",
                Date = DateTime.Now,
                Id = Guid.NewGuid()
            };
           
            _loggingRepository.AddRequest(request);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
