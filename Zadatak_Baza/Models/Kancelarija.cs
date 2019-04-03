using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zadatak_Baza.Models
{
    public class Kancelarija
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long KancelarijaId { get; set; }
        public string NazivKancelarije { get; set; }

        public List<Osoba> Osobe { get; set; }
    
    }
}
