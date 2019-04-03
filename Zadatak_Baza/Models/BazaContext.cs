using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Zadatak_Baza.Models
{
    public class BazaContext : DbContext
    {
        public BazaContext(DbContextOptions<BazaContext> options) : base(options)
        {

        }

        public DbSet<Osoba> Osobe { get; set; }
        public DbSet<Kancelarija> Kancelarije { get; set; }
        public DbSet<Uredjaj> Uredjaji { get; set; }
        public DbSet<EvidencjijaUpotrebeUredjaja> EvidencijaUpotrebeUredjaja { get; set; }
    }
}
