using Bee.Data.DataContext;
using Bee.Data.Model;
using Bee.UI.Class;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Bee_UI.Controllers
{

    public class KullaniciController : Controller
    {
        BeeContext BC = new BeeContext();
        Email mail = new Email();
        public ActionResult Kullanicilar(Kullanici Kullanici)
        {
            string oturumacantc = (Session["oturumacan"] != null ? Session["oturumacan"].ToString() : null);
            Kullanici oturumacan = BC.Kullanici.FirstOrDefault(x => x.tc.ToString() == oturumacantc);
            if (oturumacan != null)
            {
                TempData["OturumacanAd"] = oturumacan.adSoyad;
                TempData["OturumacanFotograf"] = (oturumacan.fotograf != null ? oturumacan.fotograf : "/assets/images/Kullanici/avatar.jpg");


                try
                {

                    foreach (var item in BC.Kullanici)
                    {
                        TempData["Personel"] += "<tr> <td>" + item.adSoyad + "</td> <td>" + item.tc + "</td> <td>" + item.mail + "</td> <td>" + item.iletisimTel + "</td> <td><a href='/Kullanici/KullaniciDuzenle/" + (oturumacan == item ? "" : item.id.ToString()) + "'>Düzenle</a></td> </tr>";
                    }
                }
                catch (Exception hata)
                {
                    TempData["msg"] = hata;
                }

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Kullanici");
            }
        }
        public ActionResult KullaniciEkle(Kullanici Kullanici)
        {
            string oturumacantc = (Session["oturumacan"] != null ? Session["oturumacan"].ToString() : null);
            Kullanici oturumacan = BC.Kullanici.FirstOrDefault(x => x.tc.ToString() == oturumacantc);
            if (oturumacan != null)
            {
                TempData["OturumacanAd"] = oturumacan.adSoyad;
                TempData["OturumacanFotograf"] = (oturumacan.fotograf != null ? oturumacan.fotograf : "/assets/images/Kullanici/avatar.jpg");

                int sayac = 0;
                foreach (var item in BC.Kullanici)
                {
                    if (sayac == 0)
                    {
                        if (item.tc == Kullanici.tc)
                        {
                            sayac++;
                        }
                    }

                }

                if (Kullanici.adSoyad != "" && Kullanici.mail != "" && Kullanici.iletisimTel != "" && Kullanici.iletisimTel != null && Kullanici.mail != null && Kullanici.adSoyad != null && Kullanici.tc != null && Kullanici.tc != "" && sayac == 0 && Kullanici.sifre != null)
                {
                    try
                    {
                        Kullanici.yetki = "Kullanıcı";
                        Kullanici.fotograf = "/assets/images/Kullanici/avatar.jpg";
                        BC.Kullanici.Add(Kullanici);
                        BC.SaveChanges();
                        TempData["msg"] = "<script>alert('KAYIT EKLENDİ');</script>";
                    }
                    catch (Exception hata)
                    {
                        TempData["msg"] = "<script>alert('HATA OLUŞTU.'"+hata+");</script>";
                    }
                }
                else if (sayac > 0)
                {

                    TempData["msg"] = "<script>alert('AYNI TC ILE BASKA BIR KAYIT MEVCUT.');</script>";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Kullanici");
            }
        }


        public ActionResult KullaniciDuzenle(int? ID, Kullanici GelenKullanici, string BTN, string Ysifre, string Fotograf)
        {
            string oturumacantc = (Session["oturumacan"] != null ? Session["oturumacan"].ToString() : null);
            Kullanici oturumacan = BC.Kullanici.FirstOrDefault(x => x.tc.ToString() == oturumacantc);
            if (oturumacan != null)
            {
                TempData["OturumacanAd"] = oturumacan.adSoyad;
                TempData["OturumacanFotograf"] = (oturumacan.fotograf != null ? oturumacan.fotograf : "/assets/images/Kullanici/avatar.jpg");

                Kullanici Kullanici = new Kullanici();
                if (ID != null)
                {

                    if (oturumacan.yetki == "admin")
                    {
                        Kullanici = BC.Kullanici.FirstOrDefault(x => x.id == ID);
                    }
                    else
                        return RedirectToAction("Kullanicilar", "Kullanici");
                }
                else
                {
                    Kullanici = oturumacan;
                }
                if (BTN == null)
                {

                    TempData["Fotograf"] = Kullanici.fotograf;
                    TempData["AdSoyad"] = Kullanici.adSoyad;
                    TempData["TC"] = Kullanici.tc;
                    TempData["Eposta"] = Kullanici.mail;
                    TempData["Telefon"] = Kullanici.iletisimTel;


                    return View();
                }
                else
                {


                    switch (BTN)
                    {
                        case "Kaydet":
                            {
                                Kullanici.adSoyad = (GelenKullanici.adSoyad != null ? GelenKullanici.adSoyad : Kullanici.adSoyad);
                                Kullanici.tc = (GelenKullanici.tc != null ? GelenKullanici.tc : Kullanici.tc);
                                Kullanici.mail = (GelenKullanici.mail != null ? GelenKullanici.mail : Kullanici.mail);
                                Kullanici.iletisimTel = (GelenKullanici.iletisimTel != null ? GelenKullanici.iletisimTel : Kullanici.iletisimTel);
                                BC.SaveChanges();
                                if (GelenKullanici.tc != null)
                                    Session["TCKimlikNo"] = GelenKullanici.tc;
                                if (GelenKullanici.adSoyad != null)
                                    TempData["OAAdSoyad"] = GelenKullanici.adSoyad;
                                break;
                            }
                        case "Fotoğrafı Kaydet":
                            {
                                if (Fotograf != null)
                                {
                                    int hatakontrol = 0;
                                    string DosyaYolu = "";
                                    string DosyaAdi = "";
                                    if (Fotograf != null)
                                    {
                                        DosyaAdi = Kullanici.tc;
                                        string Uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                                        if (Uzanti == ".jpg" || Uzanti == ".JPG" || Uzanti == ".png" || Uzanti == ".PNG" || Uzanti == ".jpeg" || Uzanti == ".JPEG")
                                        {
                                            DosyaYolu = "/assets/images/Kullanici/" + DosyaAdi + Uzanti;
                                            Request.Files[0].SaveAs(Server.MapPath(DosyaYolu));
                                            Kullanici.fotograf = DosyaYolu;
                                        }
                                        else
                                        {
                                            hatakontrol = 1;
                                            TempData["msg"] = "<script>swal('Hata Oluştu!', 'Hatalı Dosya Uzantısı', 'error');location.reload();</script>";
                                        }
                                    }
                                    if (hatakontrol == 0)
                                        BC.SaveChanges();
                                }
                                break;
                            }
                        case "Şifreyi Değiştir":
                            {
                                if (Ysifre == GelenKullanici.sifre)
                                {
                                    Kullanici = BC.Kullanici.FirstOrDefault(x => x.id == Kullanici.id);
                                    Kullanici.sifre = Ysifre;
                                    BC.SaveChanges();
                                    TempData["msg"] = "<script>swal('İşlem başarılı!', 'Şifre değiştirildi!', 'success');</script>";
                                }
                                else
                                {
                                    TempData["msg"] = "<script>swal('Hata Oluştu!', 'Şifreler eşleşmiyor!', 'error');</script>";
                                }
                            }
                            break;
                    }
                }
            }
            else
            {
                return RedirectToAction("Kullanici", "Login");
            }
            return View();
        }
        public ActionResult Login(Kullanici Kullanici)
        {
            try
            {
                Session.Clear();
                if (Kullanici.mail != null && Kullanici.sifre != null)
                {

                    Kullanici oturumacan = BC.Kullanici.FirstOrDefault(x => x.mail == Kullanici.mail && x.sifre == Kullanici.sifre);
                    if (oturumacan != null)
                    {
                        Session["oturumacan"] = oturumacan.tc;
                        return RedirectToAction("index", "home");
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('Kullanıcı adı veya şifre hatalı');</script>";

                    }
                }

            }
            catch (Exception hata)
            {
                TempData["msg"] = "<script>alert('Hata Oluştu!');</script>";
                mail.HataMaili(hata);
            }
            return View();
        }
        public ActionResult SifreYenile()
        {
            return View();
        }
    }
}