using angularvizeproje.Models;
using angularvizeproje.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace angularvizeproje.Auth
{
    public class UyeService
    {
        Database1Entities4 db = new Database1Entities4();

        public uyelerModel UyeOturumAc(string kadi, string parola)
        {
            uyelerModel uye = db.uyelertbl.Where(s => s.uyeadi == kadi && s.sifre == parola).Select(x => new uyelerModel()
            {
                uyeid = x.uyeid,
                ad = x.ad,
                soyad = x.soyad,
                cinsiyet = x.cinsiyet,
                uyeadi = x.uyeadi,
                sifre = x.sifre,
                kayitolmatarihi = x.kayitolmatarihi,
                email = x.email,
                seviye = x.seviye
            }).SingleOrDefault();
            return uye;

        }
    }
}