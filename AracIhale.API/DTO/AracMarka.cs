using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AracIhale.API.DTO
{
    public class AracMarka
    {


        public AracMarka()
        {
            AracModels = new HashSet<AracModel>();
            AracOzelliks = new HashSet<AracOzellik>();
        }

        [Key]
        public int AracMarkaID { get; set; }

        [StringLength(50)]
        public string MarkaAdi { get; set; }

       
        public virtual ICollection<AracModel> AracModels { get; set; }

  
        public virtual ICollection<AracOzellik> AracOzelliks { get; set; }
    }
}

