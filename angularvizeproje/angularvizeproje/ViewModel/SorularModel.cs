using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace angularvizeproje.ViewModel
{
    public class SorularModel
    {
        public int soruid { get; set; }
        public string soru { get; set; }
        public Nullable<int> kategoriid { get; set; }
        public string tarih { get; set; }
        public Nullable<int> uyeid { get; set; }
        public Nullable<int> cevapid { get; set; }
    }
}