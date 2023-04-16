using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CicekciBaciDapper.Models
{
    public class CicekBilgiModel
    {
        public int cicekNo { get; set; }
        public string cicekadi { get; set;}
        public string renk { get; set;}
        public decimal fiyat { get; set;}
        public int adet { get; set;}
        public string mensei { get; set;}
    }
}