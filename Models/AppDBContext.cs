using System;
using Microsoft.EntityFrameworkCore;

namespace ApiGTT.Models
{
    //Extendemos de la clase DbContext
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Jira> Jira { get; set; }
        public DbSet<Certificates> Certificates { get; set; }
    }
}