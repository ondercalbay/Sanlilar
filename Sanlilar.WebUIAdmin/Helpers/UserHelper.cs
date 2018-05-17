using Sanlilar.BL;
using Sanlilar.DL.EntityFramework;
using Sanlilar.Dto;
using Sanlilar.IL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Sanlilar.WebUIAdmin.Helpers
{
    public class UserHelper
    {


        public static bool AcikOturumVarMi
        {
            get
            {
                try
                {
                    FormsIdentity sId = (FormsIdentity)HttpContext.Current.User.Identity;


                    if (HttpContext.Current.User.Identity.Name != null)
                    {
                        if (HttpContext.Current.User.Identity.Name.ToInt(0) != 0)
                        {
                            return true;
                        }
                    }
                }
                catch { }
                return false;
            }
        }

        public static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        private static string KullaniciId
        {
            get
            {
                return HttpContext.Current.User.Identity.Name;
                //string _userData = UserData;
                //if (_userData != null && !_userData.Equals(""))
                //{
                //    string[] _arrData = _userData.Split('@');
                //    return _arrData[0];
                //}
                //else
                //{
                //    return "0";
                //}
            }
        }

        public static KullaniciSessionDto Kullanici
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }
                if (KullaniciId.ToInt(0) == 0)
                {
                    return null;
                }
                else if (Session["Kullanici"].IsNull())
                {
                    IKullaniciManager servis = new KullaniciManager(null, new EfKullaniciDal());
                    KullaniciLoginDto filter = new KullaniciLoginDto { Id = KullaniciId.ToInt(0) };
                    KullaniciSessionDto kul = servis.Authenticate(filter);
                    Session["Kullanici"] = kul;                                        
                }

                return Session["Kullanici"] as KullaniciSessionDto;
            }

            set { Session["Kullanici"] = value; }
        }

        public static void AddCookies(KullaniciSessionDto kullanici, bool beniHatirla)
        {
            Session.Abandon();
            UserHelper.Kullanici = kullanici;
            FormsAuthentication.SetAuthCookie(kullanici.Id.ToString(), beniHatirla);
        }

        public enum KullaniciRol
        {
            SistemOnayci = 1,
            SistemKullanici = 2,
            SistemIzleyici = 3,
            SatisMuduru = 4,
            BolgeMuduru = 5,
            UrunUzmani = 6,
            Admin = 7
        };

        public enum OnayIslemTipi
        {
            Ekleme = 1,
            Guncelleme = 2,
            Silme = 3
        };

        public enum ToastMessageType
        {
            Success = 1,
            Error = 2,
            Info = 3,
            Warning = 4
        }

        //public enum LogIslemTipi
        //{
        //    SistemeGiris = 1,
        //    SistemdenCikis = 2,
        //    YeniMusteriTanimlama = 3,
        //    YeniMusteriTanimlamaVazgec = 4,
        //    MusteriUrunUzmaniDegisikligi = 5,
        //    MusteriUrunUzmaniDegisikligiVazgec = 6,
        //    YeniMusteriTanimlamaOnay = 7,
        //    MusteriUrunUzmaniDegisikligiOnay = 8,
        //    MusteriBilgiDegisikligi = 9,
        //    KullaniciEkleme = 10,
        //    KullaniciDuzenleme = 11,
        //    KullaniciSilme = 12,
        //    KullaniciEklemeOnayi = 13,
        //    KullaniciDuzenlemeOnayi = 14,
        //    KullaniciSilmeOnayi = 15,
        //    UrunEkleme = 16,
        //    UrunDuzenleme = 17,
        //    UrunSilme = 18,
        //    UrunGrubuEkleme = 19,
        //    UrunGrubuDuzenleme = 20,
        //    UrunGrubuSilme = 21,
        //    UrunSinifiEkleme = 22,
        //    UrunSinifiDuzenleme = 23,
        //    UrunSinifiSilme = 24,
        //    UrunEklemeOnayi = 25,
        //    UrunDuzenlemeOnayi = 26,
        //    UrunSilmeOnayi = 27,
        //    UrunGrubuEklemeOnayi = 28,
        //    UrunGrubuDuzenlemeOnayi = 29,
        //    UrunGrubuSilmeOnayi = 30,
        //    UrunSinifiEklemeOnayi = 31,
        //    UrunSinifiDuzenlemeOnayi = 32,
        //    UrunSinifiSilmeOnayi = 33,
        //    SatisDegisikligi = 34,
        //    SatisDegisikligiOnayi = 35,
        //    HedefEkleme = 36,
        //    HedefDuzenleme = 37,
        //    HedefSilme = 38,
        //    HedefEklemeOnayi = 39,
        //    HedefDuzenlemeOnayi = 40,
        //    HedefSilmeOnayi = 41,
        //    KullaniciSifreDegisikligi = 42,
        //    KullaniciBilgiDegisikligiVazgec = 43,
        //    KullaniciBilgiDegisikligiReddet = 44,
        //    UrunIslemleriVazgec = 45,
        //    SatisDegisikligiVazgec = 46,
        //    MusteriBilgiDegisikligiOnayi = 47,
        //    ManuelSatisEkleme = 48,
        //    ManuelSatisDuzeltme = 49,
        //    ManuelSatisSilme = 50,
        //    ManuelSatisOnaylama = 51,
        //    ManuelSatisDuzeltmeVazgec = 52,
        //    ManuelSatisOnayiVazgec = 53,
        //    YeniMusteriTanimlamaReddet = 54,
        //    ZincirMusteriTanimlama = 55,
        //    ZincirMusteriTanimlamaVazgec = 56,
        //    ZincirMusteriTanimlamaOnayi = 57,
        //    ZincirMusteriTanimlamaOnayiReddet = 58,
        //    MusteriUrunUzmaniDegisikligiReddet = 59
        //}
    }
}