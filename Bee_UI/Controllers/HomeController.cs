using Bee.Data.DataContext;
using Bee.Data.Model;
using System.Linq;
using System.Web.Mvc;

namespace Bee_UI.Controllers
{
    public class HomeController : Controller
    {
        BeeContext BC = new BeeContext();
        // GET: Home

        public ActionResult Index(Koloni Koloni)
        {
            string oturumacantc = (Session["oturumacan"] != null ? Session["oturumacan"].ToString() : null);
            Kullanici oturumacan = BC.Kullanici.FirstOrDefault(x => x.tc.ToString() == oturumacantc);
            if (oturumacan != null)
            {
                TempData["OturumacanAd"] = oturumacan.adSoyad;
                TempData["OturumacanFotograf"] = (oturumacan.fotograf != null ? oturumacan.fotograf : "/assets/images/Kullanici/avatar.jpg");

                string Kume = "";
                int say = 0;
                foreach (var item in BC.Koloni.OrderBy(x=>x.yerGrupNo + x.yerSiraNo))
                {

                    if (Kume == item.yerGrupNo)
                    {
                        TempData["Koloni"] +=
                            "<div class='item' style='cursor:pointer;'>" +
                                "<div class='col-md-12' style='margin-bottom:10px;'>" +
                                            "<ul class='nav' id='menum' style='width:100%;'>" +
                                                "<li><a href='#carousel-example-captions" + say + "' data-slide='prev'><img style='float:left; width:60%;' src='/assets/images/icons/undo.svg' /></a></li>" +
                                                "<li><h1 style='font-size:20px; line-height:60px;'>" + item.yerGrupNo + item.yerSiraNo + " </h1></li>" +
                                                "<li><a href='#carousel-example-captions" + say + "' data-slide='next'><img style='float:right; width:60%;' src='/assets/images/icons/redo.svg' /></a></li>" +
                                            "</ul>" +
                                "</div>" +
                                "<div class='col-md-12' onclick=\"verigetir('" + item.kovanId + "')\">" +
                                    "<img src='/assets/images/kovan.png' style='width:50%; margin-left:25%;' />" +
                                    "<h3 class='portlet-title'>Kovan ID:" + item.kovanId + "</h3>" +
                                    "<h3 class='portlet-title'>Yer Grup No:" + item.yerGrupNo + "</h3>" +
                                    "<h3 class='portlet-title'>Yer Sıra No:" + item.yerSiraNo + "</h3>" +
                                    "<h3 class='portlet-title'>Küme:" + item.kume + "</h3>" +
                                    "<h3 class='portlet-title'>Son Bal:" + item.sonBal + "</h3>" +
                                    "<h3 class='portlet-title'>Puan:" + item.puan + "</h3>" +
                                "</div>" +
                            "</div>";
                    }
                    else
                    {
                        if (say != 0)
                        {
                            TempData["Koloni"] +=
                                    "</div>" +
                                "</div>" +
                            "</div>";
                        }

                        say++;
                        TempData["Koloni"] +=
                        "<div class='col-md-4 box card-box'>" +
                            "<div id='carousel-example-captions"+say+"' data-ride='carousel' class='carousel slide'>" +
                                "<div role='listbox' class='carousel-inner'>"+
                                    "<div class='item active' style='cursor:pointer;'>" +
                                        "<div class='col-md-12' style='margin-bottom:10px;'>" +
                                            "<ul class='nav' id='menum' style='width:100%;'>" +
                                                "<li><a href='#carousel-example-captions" + say + "' data-slide='prev'><img style='float:left; width:60%;' src='/assets/images/icons/undo.svg' /></a></li>" +
                                                "<li><h1 style='font-size:20px; line-height:60px;'>" + item.yerGrupNo+ item.yerSiraNo +" </h1></li>" +
                                                "<li><a href='#carousel-example-captions" + say + "' data-slide='next'><img style='float:right; width:60%;' src='/assets/images/icons/redo.svg' /></a></li>" +
                                            "</ul>" +
                                        "</div>" +
                                        "<div class='col-md-12' onclick=\"verigetir('" + item.kovanId + "')\">" +
                                            "<img src='/assets/images/kovan.png' style='width:50%; margin-left:25%;' />" +
                                            "<h3 class='portlet-title'>Kovan ID:" + item.kovanId + "</h3>" +
                                            "<h3 class='portlet-title'>Yer Grup No:" + item.yerGrupNo + "</h3>" +
                                            "<h3 class='portlet-title'>Yer Sıra No:" + item.yerSiraNo + "</h3>" +
                                            "<h3 class='portlet-title'>Küme:" + item.kume + "</h3>" +
                                            "<h3 class='portlet-title'>Son Bal:" + "SON BAL GELECEK" + "</h3>" +
                                            "<h3 class='portlet-title'>Puan:" + "PUAN GELECEK" + "</h3>" +
                                        "</div>" +
                                    "</div>";
                        Kume = item.yerGrupNo;

                    }
                }
            }
            else
            {
                return RedirectToAction("Login", "Kullanici");
            }
            return View();
        }
        
        public ActionResult QROkuma()
        {
            return View();
        }

        public JsonResult QRKod(string Veri)
        {
            string veri = Veri;
            Koloni koloni = BC.Koloni.FirstOrDefault(x => x.kovanId.ToString() == veri);
            if (koloni != null)
            {
                string muayene = "<p>Muayene bilgisi bulunamadı.</p>";
                string uygulama = "<p>Uygulama bilgisi bulunamadı.</p>";
                string isplani = "<p>İş planı bilgisi bulunamadı.</p>";
                Muayene Muayene = BC.Muayene.OrderByDescending(x => x.id).FirstOrDefault(x => x.kovanId == koloni.kovanId);
                if (Muayene != null)
                {
                    muayene =
                        "<p>Ana Durumu:" + Muayene.anaDurumu + "</p>" +
                        "<p>Ana Memesi:" + Muayene.anaMemesi + "</p>" +
                        "<p>Bal Durumu:" + Muayene.balDurumu + "</p>" +
                        "<p>Besin Durumu:" + Muayene.besinDurumu + "</p>" +
                        "<p>Ekleme Tarihi:" + Muayene.eklemeTarihi + "</p>" +
                        "<p>Eksik Çerçeve:" + Muayene.eksikCerceve + "</p>" +
                        "<p>Fiziksel Sorun:" + Muayene.fizikselSorun + "</p>" +
                        "<p>Hastalık:" + Muayene.hastalik + "</p>" +
                        "<p>Mevcut Durumu:" + Muayene.mevcutDurumu + "</p>" +
                        "<p>Oğul:" + Muayene.ogul + "</p>" +
                        "<p>Parazit:" + Muayene.parazit + "</p>" +
                        "<p>Yalancı Ana:" + Muayene.yalanciAna + "</p>" +
                        "<p>Zararlı:" + Muayene.zararli + "</p>";
                }
                Uygulama Uygulama = BC.Uygulama.OrderByDescending(x => x.id).FirstOrDefault(x => x.kovanId == koloni.kovanId);
                if (Uygulama != null)
                {
                    uygulama =
                        "<p>Ana Verme:" + Uygulama.anaVerme + "</p>" +
                        "<p>Bal Hasadı:" + Uygulama.balHasadi + "</p>" +
                        "<p>Ballık Alma:" + Uygulama.ballikAlma + "</p>" +
                        "<p>Besin Verme:" + Uygulama.besinVerme + "</p>" +
                        "<p>Birleştirme:" + Uygulama.birlestirme + "</p>" +
                        "<p>Bölme:" + Uygulama.bolme + "</p>" +
                        "<p>Çerçeve Alma:" + Uygulama.cerceveAlma + "</p>" +
                        "<p>Çerçeve Verme:" + Uygulama.cerceveVerme + "</p>" +
                        "<p>Ekleme Tarihi:" + Uygulama.eklemeTarihi + "</p>" +
                        "<p>Fiziksel Onarım:" + Uygulama.fizikselOnarim + "</p>" +
                        "<p>İlaçlama:" + Uygulama.ilaclama + "</p>";
                }
                string[] dizi =
                    {
                    koloni.yerGrupNo+koloni.yerSiraNo,
                    "<p>Koloni ID:"+koloni.kovanId+"</p>"+
                    "<p>Yer Grup No:"+koloni.yerGrupNo+"</p>"+
                    "<p>Yer Sıra No:"+koloni.yerSiraNo+"</p>"+
                    "<p>Küme:"+koloni.kume+"</p>"+
                    "<p>Puan:"+koloni.puan+"</p>"+
                    "<p>Son Bal:"+koloni.sonBal+"</p>",
                    muayene,
                    uygulama,
                    isplani
                };
                return Json(dizi);
            }
            else
            {
                return Json("error");
            }
        }

    }
}