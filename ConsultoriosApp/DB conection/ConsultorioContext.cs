using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsultoriosApp
{
    public class ConsultorioContext : DbContext
    {
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        //public DbSet<Especiality> Especialities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=Consultorios.db");
            optionsBuilder.UseSqlServer("Server=DESKTOP-588K2RQ\\SQLEXPRESS;Database=Consultorios;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=SSPI;");
            optionsBuilder.UseLazyLoadingProxies();
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}
