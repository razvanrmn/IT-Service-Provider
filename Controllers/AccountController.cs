using MultiLanguage.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MultiLanguage.Controllers
{

    public class AccountController : Controller
    {
        
        private MainDbContext context = new MainDbContext();
        DateTimeOffset dateTimeNow = DateTimeOffset.Now;
        public ActionResult Index()
        {
            Singleton.Instance.writeMessage("Account index button clicked at: " + dateTimeNow.LocalDateTime);
            return View(context.Accounts.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            AccountModel model = new AccountModel();
            Singleton.Instance.writeMessage("Create button clicked at: " + dateTimeNow.LocalDateTime);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(AccountModel model)
        {
            Singleton.Instance.writeMessage("Create button clicked at: " + dateTimeNow.LocalDateTime);
            var user = context.Accounts.SingleOrDefault(x => x.Username == model.Username || x.Password == model.Password || x.Email == model.Email);
            // var password = context.Accounts.SingleOrDefault(x => x.Password == model.Password);
            //var email = context.Accounts.SingleOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                context.Accounts.Add(model);
                context.SaveChanges();
            }
            else
            {
               
            }
                return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Modify(int id) {
            Singleton.Instance.writeMessage("Modify button clicked at: " + dateTimeNow.LocalDateTime);
            AccountModel accountModel = context.Accounts.Find(id);
            if (accountModel == null)
            {
                return HttpNotFound();
            }
            return View(accountModel);
        }
        [HttpPost]
        public ActionResult Modify(AccountModel accountModel)
        {
            Singleton.Instance.writeMessage("Modify button clicked at: " + dateTimeNow.LocalDateTime);
            context.Entry(accountModel).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");   
        }
        public ActionResult ViewDetails(int id)
        {
            Singleton.Instance.writeMessage("View account details button clicked at: " + dateTimeNow.LocalDateTime);
            AccountModel details = context.Accounts.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }
        public ActionResult Delete(int? id)
        {
            Singleton.Instance.writeMessage("Delete button clicked at: " + dateTimeNow.LocalDateTime);
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            AccountModel model = context.Accounts.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Singleton.Instance.writeMessage("Delete button clicked at: " + dateTimeNow.LocalDateTime);
            if (ModelState.IsValid)
            {
                AccountModel accountModel = context.Accounts.Find(id);
                context.Accounts.Remove(accountModel);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}