using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Ifinfo.Shared
{
    public class Classes
    {
        [Key]
        public int ClasseID{get;set;}
        [Required]
        [StringLength(45)]
        public string NomClasse{get;set;}
        public string NiveauClasse{get;set;}

        public virtual ICollection<Eleves> Eleves {get;set;}
        public Classes()
        {
            this.Eleves = new HashSet<Eleves>();
        }
    }
}