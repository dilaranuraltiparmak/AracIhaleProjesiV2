using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AracIhale.API.DTO
{
    public class Kullanici
    {
        public Kullanici()
        {
            //AracAliciBilgis = new HashSet<AracAliciBilgi>();
            Araclars = new HashSet<Araclar>();
            OnaylananTeklifs = new HashSet<OnaylananTeklif>();
            //BireyselAracTeklifs = new HashSet<BireyselAracTeklif>();
            //KurumsalUyeOnays = new HashSet<KurumsalUyeOnay>();
            //OdemeBilgisis = new HashSet<OdemeBilgisi>();
        }
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
        public virtual Rol Rol { get; set; }
        public virtual ICollection<Araclar> Araclars { get; set; }
        public virtual ICollection<OnaylananTeklif> OnaylananTeklifs { get; set; }
        public virtual ICollection<IhaleTeklif> IhaleTeklifs { get; set; }

        public virtual BireyselKurumsal BireyselKurumsal { get; set; }
        public int? BireyselKurumsalID { get; set; }
    }
}
