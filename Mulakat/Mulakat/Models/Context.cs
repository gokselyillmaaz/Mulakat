using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mulakat.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=GKSELYILMAZ5671; database=Mulakat; integrated security=true; Encrypt=false;TrustServerCertificate=true");
        }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<SepetUrun> SepetUruns { get; set; }
    }
}
