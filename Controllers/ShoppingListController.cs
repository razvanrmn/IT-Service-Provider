using MultiLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MultiLanguage.Controllers
{
    public class ShoppingListController : Controller
    {
        private MainDbContext context = new MainDbContext();
        DateTimeOffset dateTimeNow = DateTimeOffset.Now;

        // GET: ShoppingList
        public ActionResult Index()
        {
            Singleton.Instance.writeMessage("ShoppingList index button clicked created at: " + dateTimeNow.LocalDateTime);
            Thread t = new Thread(new ThreadStart(Singleton.WriteToConsole));
            t.Start();
            return View(context.ShoppingList.ToList());
        }

        public ActionResult Details(int id)
        {
            Singleton.Instance.writeMessage("ShoppingList details button clicked created at: " + dateTimeNow.LocalDateTime);
            ShoppingListModel details = context.ShoppingList.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            Thread t = new Thread(new ThreadStart(Singleton.WriteToConsole));
            t.Start();
            return View(details);
        }
    }
}