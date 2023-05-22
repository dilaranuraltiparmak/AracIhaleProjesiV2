using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using AracIhale.API.DTO;

namespace AracIhale.CoreMVC.Models.VM
{
    public class IhaleListesi
    {
        [Key]
        public int IhaleID { get; set; }

        [StringLength(75)]
        public string IhaleAdi { get; set; } = "";


        public int BireyselKurumsalID { get; set; }

        [StringLength(50)]
        public string KurumsalSirketAdi { get; set; } = "";


        public int IhaleStatuID { get; set; }
        [StringLength(75)]
        public string IhaleBaslangicTarihi { get; set; }
        [StringLength(75)]
        public string IhaleBaslangicSaati { get; set; }
        [StringLength(75)]
        public string IhaleBitisTarihi { get; set; }
        [StringLength(75)]
        public string IhaleBitisSaati { get; set; }
        public string MarkaAdi { get; set; }
        public string ModelAdi { get; set; }

        public string Foto{ get; set; }

        public int AracID { get; set; }
        [StringLength(75)]
        public string IhaleBaslangicFiyati { get; set; } = "";
        [StringLength(75)]
        public string MinimumAlimFiyati { get; set; } = "";

        public int? AracOzellikID { get; set; }

        public virtual Araclar Araclar { get; set; }

        public virtual AracOzellik AracOzellik { get; set; }

        public virtual BireyselKurumsal BireyselKurumsal { get; set; }

        public virtual IhaleStatu IhaleStatu { get; set; }
        public virtual AracModel AracModel { get; set; }
        public virtual AracMarka AracMarka { get; set; }

        public virtual ICollection<IhaleTeklif> IhaleTeklifs { get; set; }
    }
}
