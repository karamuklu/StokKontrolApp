using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunKontrolWebApi.Entities
{
    public class TBLKULLANICI_MKA
    {
        [Key]
        public int KULLANICI_NO { get; set; }
        public string KULLANICI_ADI { get; set; }
        public string SIFRE { get; set; }
        public string ISIM { get; set; }
        public string SOYISIM { get; set; }
        public string MAIL_ADRESI { get; set; }
    }
}
