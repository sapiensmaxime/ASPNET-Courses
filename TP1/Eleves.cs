using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ifinfo.Shared
{
    public class Eleves
    {
        [Key]
        public int EleveID{get;set;}
        [Required]
        [StringLength(45)]
        public string NomEleve{get;set;} = null!;
        public string PrenomEleve{get;set;} = null!;
        public int ClasseID{get;set;} 
        public virtual Classes Classe{get;set;} = null!;
        
    }
}