using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zadatak_Baza.Models
{
    public class Uredjaj
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UredjajId { get; set; }
        public string NazivUredjaja { get; set; }
        
    }
}
