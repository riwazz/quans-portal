using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace angularvizeproje.ViewModel
{
    public class CevaplarModel
    {
        public int cevapid { get; set; }
        public Nullable<int> soruid { get; set; }
        public Nullable<int> uyeid { get; set; }
        public string cevap { get; set; }
        public string tarih { get; set; }
    }
}