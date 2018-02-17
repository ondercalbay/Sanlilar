using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Sanlilar.CommonLibrary.Helpers
{

    public enum MailGonderen
    {
        sistem = 1,
        firma = 2
    }

    public class Mail
    {
        public int ekleyenId = 1;
        public MailGonderen mailGonderen { get; set; }
        public DateTime baslangicTarihi = DateTime.Now;
        public DateTime bitisTarihi = DateTime.Now.AddDays(1);

        public string kullaniciAdi;
        public string sifre;
        public bool useSSL;

        public string smtpServer;
        public int smptPort;

        public string gonderenAdres;
        public string gidenAdres;

        public string konu;
        public string mesaj;
        public string cc;
        public List<KeyValuePair<string, Stream>> eklentiler;

        private string ReadConfig(string key)
        {
            return ConfigurationManager.AppSettings[mailGonderen.ToString() + key].IsNull() ? ConfigurationManager.AppSettings[key] : ConfigurationManager.AppSettings[mailGonderen.ToString() + key];
        }

        public Mail(MailGonderen mailGonderen, string gidenAdres, string cc, string konu, string mesaj, List<KeyValuePair<string, Stream>> eklentiler = null)
        {
            this.mailGonderen = mailGonderen;
            this.gonderenAdres = ReadConfig("MailFrom");
            this.kullaniciAdi = ReadConfig("SmtpUser");
            this.sifre = ReadConfig("SmtpPass");
            this.useSSL = ReadConfig("UseSSL").ToBool();
            this.smtpServer = ReadConfig("SmtpServer");
            this.smptPort = ReadConfig("SmtpPort").ToInt();

            this.gidenAdres = gidenAdres;
            this.cc = cc;
            this.konu = konu;
            this.mesaj = mesaj;
            this.eklentiler = eklentiler;
        }
    }
    public static class MailHelper
    {
        public static bool SentMail(Mail mail)
        {

            if (mail.gidenAdres.IsNull())
                return false;

            string[] gidenliste = Listele(mail.gidenAdres);
            if (gidenliste.Length < 1)
                return false;

            MailMessage mailMessage = new MailMessage(mail.gonderenAdres, gidenliste[0]);
            for (int i = 1; i < gidenliste.Length; i++)
            {
                if (!gidenliste[i].IsNull())
                {
                    mailMessage.To.Add(gidenliste[i]);
                }
            }

            string[] ccliste = Listele(mail.cc);
            for (int i = 0; i < ccliste.Length; i++)
            {
                if (!ccliste[i].IsNull())
                {
                    mailMessage.CC.Add(ccliste[i]);
                }
            }

            if (mail.eklentiler.IsNotNull())
            {
                foreach (var item in mail.eklentiler)
                {
                    if (item.Key.IsNotNull() && item.Value.IsNotNull())
                    {
                        mailMessage.Attachments.Add(new Attachment(item.Value, item.Key, MediaTypeNames.Application.Octet));
                    }
                    else if (item.Key.IsNotNull())
                    {
                        mailMessage.Attachments.Add(new Attachment(item.Key));
                    }
                }
            }

            mailMessage.Subject = mail.konu;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = mail.mesaj;


            SmtpClient smtp = new SmtpClient(mail.smtpServer, mail.smptPort);
            if (!mail.kullaniciAdi.Equals(""))
                smtp.Credentials = new NetworkCredential(mail.kullaniciAdi, mail.sifre);
            else
                smtp.Credentials = CredentialCache.DefaultNetworkCredentials;

            smtp.EnableSsl = mail.useSSL;
            try
            {
                smtp.Send(mailMessage);
            }
            catch (SmtpException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private static string[] Listele(string str)
        {
            string[] liste = str.Split(',', ';', ' ');
            return liste;
        }
    }

}
