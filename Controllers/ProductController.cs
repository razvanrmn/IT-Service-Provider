﻿using MultiLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View(context.Products.ToList());
        }
        [HttpGet]
        public ActionResult Buy()
        {
            ProductModel model = new ProductModel();
            Singleton.Instance.writeMessage("Buy button clicked at: " + dateTimeNow.LocalDateTime);
            return View();
        }
        [HttpPost]
        public ActionResult Buy(ShoppingListModel model)
        {
            Singleton.Instance.writeMessage("Buy button clicked at: " + dateTimeNow.LocalDateTime);
            context.ShoppingList.Add(model);
            context.SaveChanges();
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
            return View(details);
        }
    }
}