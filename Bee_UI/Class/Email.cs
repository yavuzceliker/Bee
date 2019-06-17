using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Bee.UI.Class
{
    public class Email
    {
        public string MailGonder(string EMail, string Konu, string Mesaj)
        {
            string durum = "";
            try
            {
                var Gonderici = new MailAddress("beebozok@gmail.com");
                var Alici = new MailAddress(EMail);
                using (var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Gonderici.Address, "bee12345")
                })
                {
                    using (var message = new MailMessage(Gonderici, Alici) { Subject = Konu, Body = Mesaj })
                    {
                        smtp.Send(message);
                    }
                }
                return durum = "OK";
            }
            catch (Exception hata)
            {
                return durum = hata.Message.ToString();
            }

        }


        public void HataMaili(Exception hata)
        {
            string hatamesaj = hata.Message + "\n";
            string saat = DateTime.Now.ToString("dd MMMMMMM yyyy HH:mm:ss") + "\n";
            string detay = hata.ToString();
            MailGonder("16008116016@ogr.bozok.edu.tr", "Hata Bee", hatamesaj + "\n\n" + saat + "\n\n" + detay);
        }
    }
}