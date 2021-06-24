using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetAndPost.Models
{
    
        public class Context : DbContext
        {
            public Context(DbContextOptions<Context> options)
                : base(options)
            {
                Database.EnsureCreated();
            }
            public DbSet<Person> Personnes { get; set; }
        }
    
}
