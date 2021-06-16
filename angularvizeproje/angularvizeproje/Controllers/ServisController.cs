using angularvizeproje.Models;
using angularvizeproje.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace angularvizeproje.Controllers
{
    public class ServisController : ApiController
    {
        Database1Entities4 db = new Database1Entities4();
        SonucModel sonuc = new SonucModel();


        #region Üyeler
        [HttpGet]
        [Route("api/uyeliste")]

        public List<uyelerModel> uyeListe()
        {
            List<uyelerModel> liste = db.uyelertbl.Select(x => new uyelerModel()
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
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/uyebyid/{kId}")]
        public uyelerModel UyeById(int kId)
        {
            uyelerModel kayit = db.uyelertbl.Where(s => s.uyeid == kId).Select(x => new uyelerModel()
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

            return kayit;
        }
        [HttpPost]
        [Route("api/uyeekle")]
        public SonucModel UyeEkle(uyelerModel model)
        {
            if (db.uyelertbl.Count(s => s.uyeid == model.uyeid) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Üye Kayıtlıdır!";
                return sonuc;
            }

            uyelertbl yeni = new uyelertbl();
            yeni.uyeid = model.uyeid;
            yeni.ad = model.ad;
            yeni.soyad = model.soyad;
            yeni.cinsiyet = model.cinsiyet;
            yeni.uyeadi = model.uyeadi;
            yeni.sifre = model.sifre;
            yeni.kayitolmatarihi = model.kayitolmatarihi;
            yeni.email = model.email;
            yeni.seviye = model.seviye;
            db.uyelertbl.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/uyeduzenle")]
        public SonucModel UyeDuzenle(uyelerModel model)
        {
            uyelertbl kayit = db.uyelertbl.Where(s => s.uyeid == model.uyeid).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            kayit.ad = model.ad;
            kayit.soyad = model.soyad;
            kayit.cinsiyet = model.cinsiyet;
            kayit.uyeadi = model.uyeadi;
            kayit.sifre = model.sifre;
            kayit.kayitolmatarihi = model.kayitolmatarihi;
            kayit.email = model.email;
            kayit.seviye = model.seviye;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Üye Düzenlendi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/üyesil/{kId}")]
        public SonucModel UyeSil(int kId)
        {
            uyelertbl kayit = db.uyelertbl.Where(s => s.uyeid == kId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            if (db.uyelertbl.Count(s => s.uyeid == kId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üye Kayıtlı Olduğu İçin Üye Silinemez!";
                return sonuc;
            }


            db.uyelertbl.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Silindi";
            return sonuc;
        }


        #endregion
        
        #region Sorular
        [HttpGet]
        [Route("api/soruliste")]

        public List<SorularModel> soruListe()
        {
            List<SorularModel> liste = db.sorulartbl.Select(x => new SorularModel()
            {
                soruid = x.soruid,
                soru = x.soru,
                kategoriid = x.kategoriid,
                tarih = x.tarih,
                uyeid = x.uyeid,
                cevapid = x.cevapid,
                
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/sorubyid/{kId}")]
        public SorularModel SoruById(int kId)
        {
            SorularModel kayit = db.sorulartbl.Where(s => s.soruid == kId).Select(x => new SorularModel()
            {
                soruid = x.soruid,
                soru = x.soru,
                kategoriid = x.kategoriid,
                tarih = x.tarih,
                uyeid = x.uyeid,
                cevapid = x.cevapid,
            }).SingleOrDefault();

            return kayit;
        }
        [HttpPost]
        [Route("api/soruekle")]
        public SonucModel SoruEkle(SorularModel model)
        {
            if (db.sorulartbl.Count(s => s.soruid == model.soruid) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Soru Kayıtlıdır!";
                return sonuc;
            }

            sorulartbl yeni = new sorulartbl();
            yeni.soruid = model.soruid;
            yeni.soru = model.soru;
            yeni.kategoriid = model.kategoriid;
            yeni.tarih = model.tarih;
            yeni.uyeid = model.uyeid;
            yeni.cevapid = model.cevapid;
            db.sorulartbl.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Soru Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/soruduzenle")]
        public SonucModel SoruDuzenle(SorularModel model)
        {
            sorulartbl kayit = db.sorulartbl.Where(s => s.soruid == model.soruid).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            kayit.soruid = model.soruid;
            kayit.soru = model.soru;
            kayit.kategoriid = model.kategoriid;
            kayit.tarih = model.tarih;
            kayit.uyeid = model.uyeid;
            kayit.cevapid = model.cevapid;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Soru Düzenlendi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/sorusil/{kId}")]
        public SonucModel SoruSil(int kId)
        {
            sorulartbl kayit = db.sorulartbl.Where(s => s.soruid == kId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            if (db.sorulartbl.Count(s => s.soruid == kId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üye Kayıtlı Olduğu İçin Soru Silinemez!";
                return sonuc;
            }


            db.sorulartbl.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Soru Silindi";
            return sonuc;
        }


        #endregion

        #region Cevaplar
        [HttpGet]
        [Route("api/cevapliste")]

        public List<CevaplarModel> CevapListe()
        {
            List<CevaplarModel> liste = db.cevaplartbl.Select(x => new CevaplarModel()
            {
                cevapid = x.cevapid,
                soruid = x.soruid,
                uyeid = x.uyeid,
                cevap = x.cevap,
                tarih = x.tarih,
                
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/cevapbyid/{kId}")]
        public CevaplarModel CevapById(int kId)
        {
            CevaplarModel kayit = db.cevaplartbl.Where(s => s.cevapid == kId).Select(x => new CevaplarModel()
            {
                cevapid = x.cevapid,
                soruid = x.soruid,
                uyeid = x.uyeid,
                cevap = x.cevap,
                tarih = x.tarih,
            }).SingleOrDefault();

            return kayit;
        }
        [HttpPost]
        [Route("api/cevapekle")]
        public SonucModel CevapEkle(CevaplarModel model)
        {
            if (db.cevaplartbl.Count(s => s.cevapid == model.cevapid) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Cevap Kayıtlıdır!";
                return sonuc;
            }

            cevaplartbl yeni = new cevaplartbl();
            yeni.cevapid = model.cevapid;
            yeni.soruid = model.soruid;
            yeni.uyeid = model.uyeid;
            yeni.cevap = model.cevap;
            yeni.tarih = model.tarih;
            db.cevaplartbl.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Cevap Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/cevapduzenle")]
        public SonucModel CevapDuzenle(CevaplarModel model)
        {
            cevaplartbl kayit = db.cevaplartbl.Where(s => s.cevapid == model.cevapid).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            kayit.cevapid = model.cevapid;
            kayit.soruid = model.soruid;
            kayit.uyeid = model.uyeid;
            kayit.cevap = model.cevap;
            kayit.tarih = model.tarih;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Cevap Düzenlendi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/cevapsil/{kId}")]
        public SonucModel CevapSil(int kId)
        {
            cevaplartbl kayit = db.cevaplartbl.Where(s => s.cevapid == kId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            if (db.cevaplartbl.Count(s => s.cevapid == kId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üye Kayıtlı Olduğu İçin Cevap Silinemez!";
                return sonuc;
            }


            db.cevaplartbl.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Cevap Silindi";
            return sonuc;
        }


        #endregion

        #region Kategori
        [HttpGet]
        [Route("api/kategoriliste")]

        public List<KategoriModel> KategoriListe()
        {
            List<KategoriModel> liste = db.kategoritbl.Select(x => new KategoriModel()
            {
                kategoriid = x.kategoriid,
                kategoriAdi = x.kategoriAdi,
                
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/kategoribyid/{kId}")]
        public kategoritbl KategoriById(int kId)
        {
            kategoritbl kayit = db.kategoritbl.Where(s => s.kategoriid == kId).Select(x => new kategoritbl()
            {
                kategoriid = x.kategoriid,
                kategoriAdi = x.kategoriAdi,
            }).SingleOrDefault();

            return kayit;
        }
        [HttpPost]
        [Route("api/kategoriekle")]
        public SonucModel KategoriEkle(kategoritbl model)
        {
            if (db.kategoritbl.Count(s => s.kategoriid == model.kategoriid) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Kategori Kayıtlıdır!";
                return sonuc;
            }

            kategoritbl yeni = new kategoritbl();
            yeni.kategoriid = model.kategoriid;
            yeni.kategoriAdi = model.kategoriAdi;
            db.kategoritbl.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/kategoriduzenle")]
        public SonucModel KategoriDuzenle(kategoritbl model)
        {
            kategoritbl kayit = db.kategoritbl.Where(s => s.kategoriid == model.kategoriid).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            kayit.kategoriid = model.kategoriid;
            kayit.kategoriAdi = model.kategoriAdi;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Düzenlendi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/kategorisil/{kId}")]
        public SonucModel KategoriSil(int kId)
        {
            kategoritbl kayit = db.kategoritbl.Where(s => s.kategoriid == kId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            if (db.kategoritbl.Count(s => s.kategoriid == kId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üye Kayıtlı Olduğu İçin Kategori Silinemez!";
                return sonuc;
            }


            db.kategoritbl.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Silindi";
            return sonuc;
        }


        #endregion

        [HttpGet]
        [Route("api/giris/{uyeAdi}/{sifre}")]
        public SonucModel GirisYap(string uyeAdi, string sifre)
        {
            if (db.uyelertbl.Count(s => s.uyeadi == uyeAdi && s.sifre == sifre) > 0)
            {
                sonuc.islem = true;
                sonuc.mesaj = "Giriş başarılı!";

            }
            else
            {
                sonuc.islem = false;
                sonuc.mesaj = "Giriş başarısız!";
            }
            return sonuc;
        }

        [HttpGet]
        [Route("api/yetkilendir/{kID}/{yetki}")]
        public SonucModel Yetkilendir(int kID, string yetki)
        {
            uyelertbl kayit = db.uyelertbl.Where(s => s.uyeid == kID).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kullanıcı bulunamadı!";
            }
            else
            {
                kayit.seviye = yetki;
                db.SaveChanges();
                sonuc.islem = true;
                sonuc.mesaj = "Üye yetkilendirildi, yeni seviye: " + yetki;
            }
            return sonuc;

        }
    }
}
