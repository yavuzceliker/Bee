using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bee.Data.Model;
using Bee.Data.DataContext;
namespace Bee_UI.Controllers
{
    public class MuayeneUygulamaController : Controller
    {
        BeeContext BC = new BeeContext();

        public ActionResult MuayeneUygulamaEkle(Muayene Muayene, Uygulama Uygulama, DurumListesi DurumListesi, string saat, string fizikselSoruncb, string muayenecb, string uygulamacb, string hastalikcb, string parazitcb, string zararlicb, string ilaclamacb, string fizikselOnarimcb, string besinVermecb, string birlestirmecb, string bolmecb, string ballikAlmacb, string balHasadicb, string []MuayeneAdi, string[] MuayeneMetni, string[] UygulamaAdi, string[] UygulamaMetni,string[] yavrudurumu )
        {
            string oturumacantc = (Session["oturumacan"] != null ? Session["oturumacan"].ToString() : null);
            Kullanici oturumacan = BC.Kullanici.FirstOrDefault(x => x.tc.ToString() == oturumacantc);
            if (oturumacan != null)
            {
                TempData["OturumacanAd"] = oturumacan.adSoyad;
                TempData["OturumacanFotograf"] = (oturumacan.fotograf != null ? oturumacan.fotograf : "/assets/images/Kullanici/avatar.jpg");

                //Uygulama ve muayene chb kontrolü
                if (muayenecb !="on" && uygulamacb !="on"  &&  saat != null)
                {
                    TempData["msg"] = "<script>alert('Seçim yapılmadı.');</script>";
                }
                else
                {
                    if(muayenecb =="on")
                    {
                        
                    }
                }
                
            }
            else
            {
                return RedirectToAction("Login", "Kullanici");
            }
            return View();
        }
        
        public ActionResult MuayeneUygulamaGoster()
        {
            string oturumacantc = (Session["oturumacan"] != null ? Session["oturumacan"].ToString() : null);
            Kullanici oturumacan = BC.Kullanici.FirstOrDefault(x => x.tc.ToString() == oturumacantc);
            if (oturumacan != null)
            {
                TempData["OturumacanAd"] = oturumacan.adSoyad;
                TempData["OturumacanFotograf"] = (oturumacan.fotograf != null ? oturumacan.fotograf : "/assets/images/Kullanici/avatar.jpg");

                TempData["Muayene"] = 
                    "<tr onclick='ac(1" +  /* MUAYENE UYG ID  */  ")'>" +
                        "<td>1" /*MUAYENE UYG ID  */ + "</td>" +
                        "<td>1" + /* KOLONİ ID  */ "</td>" +
                        "<td>1" /*   İşlem Muayene/Uygulama/ikisi de    */ + "</td>" +
                        "<td>1"  /* TARİH  */ + "</td>" +
                        "<td>1"  /* SAAT  */ + "</td>" +
                    "</tr>";
            }
            else
            {
                return RedirectToAction("Login", "Kullanici");
            }
            return View();
        }

        public JsonResult MuayeneGoster(int? ID)
        {
            string veri = "<h3>"+"Veri1"+"</h3>";
            veri += "<h3>" + "Veri2" + "</h3>";
            veri += "<h3>" + "Veri3" + "</h3>";
            veri += "<h3>" + "Veri4" + "</h3>";
            veri += "<h3>" + "Veri5" + "</h3>";
            /* İSTEDİĞİN KADAR ARTIR*/
            return Json(veri);
        }
    }
}