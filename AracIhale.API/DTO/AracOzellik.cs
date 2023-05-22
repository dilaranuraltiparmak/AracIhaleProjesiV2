using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AracIhale.API.DTO
{
    public class AracOzellik
    {
        public AracOzellik()
        {
            Araclars = new HashSet<Araclar>();
            //IhaleListesis = new HashSet<IhaleListesi>();
        }

        public int AracOzellikID { get; set; }

        public int? AracMarkaID { get; set; }

        public int? YilID { get; set; }

        public int? AracModelID { get; set; }

        public int? GovdeTipiID { get; set; }

        public int? YakitTipiID { get; set; }

        public int? VitesTipiID { get; set; }

        [StringLength(50)]
        public string Versiyon { get; set; }

        public int? RenkID { get; set; }

        [StringLength(50)]
        public string OpsiyonelDonanim { get; set; }

        public virtual ICollection<Araclar> Araclars { get; set; }

        public virtual AracMarka AracMarka { get; set; }

        public virtual AracModel AracModel { get; set; }
    }
}
