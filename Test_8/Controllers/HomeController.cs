using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_8.Models;

namespace Test_8.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        UserContext userContext;
        const int PageSize = 4;

        public HomeController()
        {
            userContext = new UserContext();
        }

        public ViewResult List(string searchString, string currentFilter, int page = 1)
        {
            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var users = from s in userContext.UserInformations
                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Name.Contains(searchString));
            }

            var productlist = users.OrderBy(c => c.ID)
                              .Skip((page - 1) * PageSize)
                              .Take(PageSize)
                              .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = PageSize;
            ViewBag.TotalPages = Math.Ceiling((double)users.Count() / PageSize);

            return View(productlist);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserProfile collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userContext.UserInformations.Add(collection);
                    userContext.SaveChanges();
                    return RedirectToAction("List");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        public ActionResult Edit(Int32 id)
        {
            var cust = userContext.UserInformations.Where(c => c.ID == id).FirstOrDefault();
            return View(cust);
        }

        [HttpPost]
        public ActionResult Edit(UserProfile student, Int32 id)
        {

            UserProfile std = userContext.UserInformations.Where(c => c.ID == id).First();
            std.ID = student.ID;
            std.Name = student.Name;
            std.Email = student.Email;
            std.Phone = student.Phone;
            std.Marital_Status = student.Marital_Status;
            std.Country = student.Country;
            std.State = student.State;
           
            userContext.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(UserProfile student, int id)
        {
            var itemToRemove = userContext.UserInformations.Single(r => r.ID == id);
            userContext.UserInformations.Remove(itemToRemove);
            userContext.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Details(Int32 id)
        {
            var std = userContext.UserInformations.Where(c => c.ID == id).FirstOrDefault();

            return View(std);
        }

    }
}