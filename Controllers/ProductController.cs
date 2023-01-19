using MultiLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MultiLanguage.Controllers
{
    public class ProductController : Controller
    {
        private MainDbContext context = new MainDbContext();
        DateTimeOffset dateTimeNow = DateTimeOffset.Now;

        public ActionResult Index()
        {
            Singleton.Instance.writeMessage("Product index button clicked at: " + dateTimeNow.LocalDateTime);
            Thread t = new Thread(new ThreadStart(Singleton.WriteToConsole));
            t.Start();
            return View(context.Products.ToList());
        }
        
        public ActionResult Buy(int id)
        {
            ProductModel model = context.Products.Find(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            ShoppingListModel model1= new ShoppingListModel();
            model1.Name = model.Name;
            model1.Description = model.Description;
            model1.Price = model.Price;
            Singleton.Instance.writeMessage("Buy button clicked at: " + dateTimeNow.LocalDateTime);
            context.ShoppingList.Add(model1);
            context.SaveChanges();
            Thread t = new Thread(new ThreadStart(Singleton.WriteToConsole));
            t.Start();
            return RedirectToAction("Index");
        }

        public ActionResult ViewDetails(int id)
        {
            ProductModel details = context.Products.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            Singleton.Instance.writeMessage("View product details button clicked at: " + dateTimeNow.LocalDateTime);
            Thread t = new Thread(new ThreadStart(Singleton.WriteToConsole));
            t.Start();
            return View(details);
        }
    }
}