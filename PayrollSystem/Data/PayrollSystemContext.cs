using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayrollSystem.Models;

namespace PayrollSystem.Data
{
    public class PayrollSystemContext : DbContext
    {
        public PayrollSystemContext (DbContextOptions<PayrollSystemContext> options)
            : base(options)
        {
        }

        public DbSet<PayrollSystem.Models.EmployeeDetailViewModel> EmployeeDetailViewModel { get; set; } = default!;
    }
}
