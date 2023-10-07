using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrimeraPrueba.EN;

namespace PrimeraPrueba.DAL
{
    public class BDContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; } 
        public DbSet<Roles> Roles { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=Josue-Perez; Initial Catalog=PruebaTecnica;Integrated Security=True; Trusted_Connection=True; encrypt = false; trustServerCertificate = false");

        }
    }
}
