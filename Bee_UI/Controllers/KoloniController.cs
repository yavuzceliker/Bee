using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bee.Data.Model;
using Bee.Data.DataContext;

namespace Bee_UI.Controllers
{
    public class KoloniController : Controller
    {
        BeeContext BC = new BeeContext();

        public ActionResult Koloniler(Koloni Koloni)
        {
            string oturumacantc = (Session["oturumacan"] != null ? Session["oturumacan"].ToString() : null);
            Kullanici oturumacan = BC.Kullanici.FirstOrDefault(x => x.tc.ToString() == oturumacantc);
            if (oturumacan != null)
            {
                TempData["OturumacanAd"] = oturumacan.adSoyad;
                TempData["OturumacanFotograf"] = (oturumacan.fotograf != null ? oturumacan.fotograf : "/assets/images/Kullanici/avatar.jpg");

                foreach (var item in BC.Koloni)
                {
                    TempData["Koloniler"] +=
                        "<tr>" +
                            "<td>" + item.kovanId + "</td>" +
                            "<td>" + item.yerGrupNo + "</td>" +
                            "<td>" + item.yerSiraNo + "</td>" +
                            "<td>" + item.kume + "</td>" +
                            "<td>" + item.sonBal + "</td>" +
                            "<td>" + item.puan + "</td>" +
                            "<td style='text-align:center;cursor:pointer;'><i class='fa fa-edit'></i></td>" +
                        "</tr>";
                }
            }
            else
            {
                return RedirectToAction("Login", "Kullanici");
            }
            
            return View();
        }


        public ActionResult KoloniDuzenle(int? ID)
        {
            return View();
        }

        public ActionResult KoloniKayit(Koloni Koloni)
        {
            string oturumacantc = (Session["oturumacan"] != null ? Session["oturumacan"].ToString() : null);
            Kullanici oturumacan = BC.Kullanici.FirstOrDefault(x => x.tc.ToString() == oturumacantc);
            if (oturumacan != null)
            {
                TempData["OturumacanAd"] = oturumacan.adSoyad;
                TempData["OturumacanFotograf"] = (oturumacan.fotograf != null ? oturumacan.fotograf : "/assets/images/Kullanici/avatar.jpg");


                int sayac = 0;

                foreach (var item in BC.Cins)
                {
                    TempData["CinsAdi"] += "<option>" + item.cinsAdi + "</option>";
                }

                foreach (var item in BC.Koloni)
                {
                    if (sayac == 0)
                    {
                        if (item.kovanId == Koloni.kovanId)
                        {
                            sayac++;
                        }
                    }

                }

                if (Koloni.kovanId != null && Koloni.yerGrupNo != null && Koloni.yerSiraNo != null && Koloni.yerGrupNo != null && Koloni.anaCins != null && Koloni.anaYil != null && Koloni.kume != null)
                {
                    try
                    {

                        BC.Koloni.Add(Koloni);
                        BC.SaveChanges();
                        TempData["msg"] = "<script>alert('KAYIT EKLENDİ');</script>";
                    }
                    catch
                    {
                        TempData["msg"] = "<script>alert('EKLENİRKEN HATA OLUŞTU.');</script>";
                    }
                }


                if (sayac > 0)
                {
                    TempData["msg"] = "<script>alert('AYNI KOVAN ID ILE BASKA BIR KAYIT MEVCUT.');</script>";
                }
                sayac++;
            }
            else
            {
                return RedirectToAction("Login", "Kullanici");
            }
            return View();

        }

        public ActionResult YeniCins(Cins Cins)
        { string oturumacantc = (Session["oturumacan"] != null ? Session["oturumacan"].ToString() : null);
            Kullanici oturumacan = BC.Kullanici.FirstOrDefault(x => x.tc.ToString() == oturumacantc);
            if (oturumacan != null)
            {
                TempData["OturumacanAd"] = oturumacan.adSoyad;
                TempData["OturumacanFotograf"] = (oturumacan.fotograf != null ? oturumacan.fotograf : "/assets/images/Kullanici/avatar.jpg");
                if (Cins.cinsAdi!=null)
                {
                    if (BC.Cins.FirstOrDefault(x => x.cinsAdi == Cins.cinsAdi) == null)
                    {
                        BC.Cins.Add(Cins);
                        BC.SaveChanges();
                        TempData["msg"] = "<script>alert('" + Cins.cinsAdi + " Eklendi!');</script>";
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('"+Cins.cinsAdi+" daha önce eklenmiş!');</script>";
                        return View();
                    }
                }

            }
            else
            {
                return RedirectToAction("Login", "Kullanici");
            }
                return View();
        }

        public JsonResult QRKod(int Veri)
        {

            return null;
        }
    }
}