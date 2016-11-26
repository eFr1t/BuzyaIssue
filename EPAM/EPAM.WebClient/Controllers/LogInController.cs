using EPAM.Model;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPAM.WebClient.Controllers
{
    public class LogInController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String LogIn(String login, String password)
        {
            Person p = PersonRepository.Instance.Login(login, password);
            if (p != null)
            {
                Session["PersonId"] = p.Id;
                Session["PersonName"] = p.Name + " " + p.SName;
                if (p.GetType() == typeof(Client))
                    return "/Client/Profile?id=" + Session["PersonId"];
                else
                    return "/Author/Profile?id=" + Session["PersonId"];
            }
            return "";
        }

        public ActionResult LogOut()
        {
            Session["PersonId"] = null;
            Session["PersonName"] = null;
            return RedirectToAction("Index", "LogIn");
        }
    }
}