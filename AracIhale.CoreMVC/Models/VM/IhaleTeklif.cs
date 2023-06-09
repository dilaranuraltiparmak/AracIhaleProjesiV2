﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AracIhale.CoreMVC.Models.VM    
{
    public class IhaleTeklif
    {
        [Key]
        public int TeklifID { get; set; }

        public int? KullaniciID { get; set; }

        [StringLength(50)]
        public string TeklifFiyati { get; set; }

        public DateTime? TeklifTarihi { get; set; }

        public int? IhaleID { get; set; }

        public virtual IhaleListesi IhaleListesi { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
    }
