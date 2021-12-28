using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunKontrolWebApi.Entities
{
    public class TBLSEPETUST_MKA
    {
        [Key]
        public string SEPETID { get; set; }
        public string CARI_KODU { get; set; }
        public DateTime TARIH { get; set; }
        public int KAYITYAPANKUL { get; set; }
        public string NETSISDURUMU { get; set; }
        public decimal GENELTOPLAM { get; set; }
    }
}
