using System;
using Microsoft.EntityFrameworkCore;
using Task2.Middlewares;
using Task2.Repositories;

namespace Task2.Models.Db
{
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
