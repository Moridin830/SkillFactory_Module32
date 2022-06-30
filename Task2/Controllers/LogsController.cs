using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Task2.Models;
using Task2.Models.Db;
using Task2.Repositories;
using Task2.Repositories.LoggerRepository;

namespace Task2.Controllers
{
    public class LogsController : Controller
    {
        private ILoggingRepository _loggerRepository;

        public LogsController(ILoggingRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }
        public async Task<IActionResult> Index()
        {
            var requests = await _loggerRepository.GetRequests();
            return View(requests);
        }
    }
}
