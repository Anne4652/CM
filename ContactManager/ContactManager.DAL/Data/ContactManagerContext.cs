using ContactManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DAL.Data
{
    public class ContactManagerContext(DbContextOptions<ContactManagerContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
