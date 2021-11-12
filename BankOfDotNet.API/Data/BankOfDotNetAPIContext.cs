using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankOfDotNet.API.Models;

namespace BankOfDotNet.API.Data
{
    public class BankOfDotNetAPIContext : DbContext
    {
        public BankOfDotNetAPIContext (DbContextOptions<BankOfDotNetAPIContext> options)
            : base(options)
        {
        }

        public DbSet<BankOfDotNet.API.Models.Customer> Customer { get; set; }
    }
}
