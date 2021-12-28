using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunKontrolWebApi.Entities
{
    public class STOKBAKIYE_MKA
    {
        //public int SIRANO { get; set; }
        [Key]
        public string STOK_KODU { get; set; }
        public string STOK_ADI { get; set; }
        public decimal DEPOBAKIYE { get; set; }
        public decimal SERBESTSTOK { get; set; }
        public string DEPO_ADI { get; set; }
        public Int16 DEPO_KODU { get; set; }
        public string GRUP_KODU { get; set; }
        public DateTime SONHAREKETTARIHI { get; set; }
        public int BEKLEMEGUNU { get; set; }
        public decimal SIPARISBAKIYE { get; set; }
        public decimal SATIS_FIYAT { get; set; }

    }
}
