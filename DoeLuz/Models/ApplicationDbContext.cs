using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace DoeLuz.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Doador> Doadores { get; set; }
        public DbSet<Beneficiario> Beneficiarios { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Doador>().ToTable("Doador");
            modelBuilder.Entity<Beneficiario>().ToTable("Beneficiario");
            modelBuilder.Entity<Doacao>().ToTable("Doacao");
        }
    }
}
