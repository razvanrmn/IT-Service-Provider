using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MultiLanguage.Controllers
{
    public class HomeController : Controller
    {
        DateTimeOffset dateTimeNow = DateTimeOffset.Now;
        public ActionResult Index()
        {
            Singleton.Instance.writeMessage("Language button clicked at: " + dateTimeNow.LocalDateTime);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Change(string LanguageAbbreviation)
        {
            if (LanguageAbbreviation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbreviation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbreviation);
            }
            HttpCookie cookie = new HttpCookie("Home");
            cookie.Value = LanguageAbbreviation;
            Response.Cookies.Add(cookie);
            Singleton.Instance.writeMessage("Language changed succesfuly at: " + dateTimeNow.LocalDateTime);
            return View("Index");
        }
    }
}