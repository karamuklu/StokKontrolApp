using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunKontrolWebApi.Entities
{
    public class STOKBAKIYEOTR
    {
        [Key]
        public string STOK_KODU { get; set; }
        public string STOK_ADI { get; set; }
        public int SIPARISBAKIYE { get; set; }
        public int SERBESTSTOK { get; set; }
        public int BEKLEMEGUNU { get; set; }
    }
}
