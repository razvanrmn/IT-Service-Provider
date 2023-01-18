using MultiLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiLanguage.Controllers
{
    public class ShoppingListController : Controller
    {
        private MainDbContext context = new MainDbContext();

        // GET: ShoppingList
        public ActionResult Index()
        {
            return View(context.ShoppingList.ToList());
        }

        public ActionResult Details(int id)
        {
            ShoppingListModel details = context.ShoppingList.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }
    }
}