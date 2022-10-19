using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Ex.Models;

    public class AgendaDB : DbContext
    {
        public AgendaDB (DbContextOptions<AgendaDB> options)
            : base(options)
        {
        }

        public DbSet<API_Ex.Models.Person> Person { get; set; }
    }
