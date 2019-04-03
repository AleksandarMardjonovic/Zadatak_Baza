using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zadatak_Baza.Models
{
    public class Osoba
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OsobaId { get; set; }
        public string ImeOsoba { get; set; }
        public string PrezimeOsoba { get; set; }

        public long KancelarijaId { get; set; }
        public Kancelarija Kancelarija { get; set; }

        public List<EvidencjijaUpotrebeUredjaja> EvidencijaUpotrebeUredjaja { get; set; }
   
    }
}
