using Microsoft.EntityFrameworkCore;
using SistemaDeNotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data
{
    public class SistemaDeNotasContext:DbContext
    {
        public SistemaDeNotasContext(DbContextOptions<SistemaDeNotasContext> options):base(options)
        {
        }
        public DbSet<EstudanteModel> Estudantes { get; set; }
        public DbSet<NotasModel> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstudanteModel>().ToTable("Estudante");
            modelBuilder.Entity<NotasModel>().ToTable("Notas");
        }
    }
}
