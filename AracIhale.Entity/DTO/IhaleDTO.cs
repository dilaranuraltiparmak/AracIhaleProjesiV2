using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entity.DTO
{
    public class IhaleDTO
    {
        [Key]
        public int IhaleID { get; set; }

        [StringLength(75)]
        public string IhaleAdi{ get; set; } = "";

        [StringLength(75)]
        public int BireyselKurumsalD { get; set; }

        [StringLength(50)]
        public string KurumsalSirketAdi { get; set; } = "";

        [StringLength(75)]
        public string IhaleStatuID { get; set; } = "";
        [StringLength(75)]
        public DateTime IhaleBaslangicTarihi { get; set; }
        [StringLength(75)]
        public DateTime IhaleBaslangicSaati { get; set; }
        [StringLength(75)]
        public DateTime IhaleBitisTarihi { get; set; } 
        [StringLength(75)]
        public DateTime IhaleBitisSaati { get; set; }
        public int AracID { get; set; }
        [StringLength(75)]
        public string IhaleBaslangicFiyati { get; set; } = ""; [StringLength(75)]
        public string MinimumAlimFiyati { get; set; } = "";

    }
}
