using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AspnetMvcWebHelpers.Controllers
{
    public class MyCryptoController : Controller
    {
        private string sifresiz = "Kadir Murat Başeren";
        private string sifreli = "AAlXuaLFUVFFThD15yNmPCMci3qa11P6E2BmJVwo3vg10hfnxlKV+HsPEJ0F0II7HQ==";

        public ActionResult Index()
        {
            // key üretir..
            string salt = Crypto.GenerateSalt();

            // Verilen algoritmaya göre şifreler, default sha256
            string hash = Crypto.Hash(sifresiz,algorithm:"md5");
            string sh1 = Crypto.SHA1(sifresiz);
            string sh256 = Crypto.SHA256(sifresiz);

            // Password'ü random olarak hash'ler.. Aynı string her defasında farklı..
            string sonuc = Crypto.HashPassword(sifresiz);

            // HashPassword ile şifrelenmişi clean string ile kontrol eder.
            bool dogrumu = Crypto.VerifyHashedPassword(sifreli, sifresiz);

            return View();
        }
    }
}