using System.ComponentModel.DataAnnotations;

namespace AracIhale.CoreMVC.Models.VM
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }

        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Telefon { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        public int? AktifPasifID { get; set; }

        [StringLength(50)]
        public string Sifre { get; set; }

        public int? RolID { get; set; }


        public int? BireyselKurumsalID { get; set; }





















      
    }
}
