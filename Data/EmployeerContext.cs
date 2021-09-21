using FirstWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApplication.Data
{
    public class EmployeerContext:DbContext
    {
        public EmployeerContext(DbContextOptions<EmployeerContext> options): base(options)
        {

        }
        public DbSet <Employeer>  Employeers{ get; set; }
    }
}
