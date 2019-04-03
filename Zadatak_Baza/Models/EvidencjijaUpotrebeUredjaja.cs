using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zadatak_Baza.Models
{
    public class EvidencjijaUpotrebeUredjaja
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EvidencijaId { get; set; }
        [Display(Name = "Datum zaduženja uređaja")]
        [Required]
        public DateTime DatumZaduzenjaUredjaja { get; set; }
        public DateTime? DatumRazdruzenjaUredjaja { get; set; }

        [Display(Name = "Id korisnika uređaja")]
        public long OsobaId { get; set; }
        public Osoba Osoba { get; set; }

        [Display(Name = "Id korišćenog uređaja")]
        public long UredjajId { get; set; }
        public Uredjaj Uredjaj { get; set; }
        
   }
}
