using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL.Models;

namespace WebApplication1.DAL.Contexts
{
    public class DziekanatContext : DbContext
    {
        public DziekanatContext(DbContextOptions<DziekanatContext> options) : base(options)
        {

        }
        public DbSet<Zajecia> Zajecia {get;set;}
        public DbSet<Student> Student { get; set; }
    }
}
