﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunKontrolWebApi.Entities
{
    public class TBLSEPET_MKA
    {
        [Key]
        public string STOK_KODU { get; set; }
        public int MIKTAR { get; set; }
        public DateTime TARIH { get; set; }
        public int SEPETID { get; set; }
        public int KAYITYAPANKUL { get; set; }
        public string NETSISDURUMU { get; set; }
        public int DEPO_KODU { get; set; }
        public decimal SATIS_FIYAT { get; set; }
        public decimal ISKONTO { get; set; }
        public int SIRA { get; set; }
    }
}
