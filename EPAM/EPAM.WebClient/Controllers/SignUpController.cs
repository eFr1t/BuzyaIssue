using EPAM.Model;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPAM.WebClient.Controllers
{
    public class SignUpController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Client()
        {
            ViewBag.TimeZones = TimeZoneRepository.Instance.GetAllItems().OrderBy(i => i.Title);
            return View();
        }

        public ActionResult Author()
        {
            ViewBag.TimeZones = TimeZoneRepository.Instance.GetAllItems().OrderBy(i => i.Title);
            return View();
        }

        [HttpPost]
        public String RegisterAuthor(Author a, String repassword)
        {
            return Register(a, repassword);
        }

        [HttpPost]
        public String RegisterClient(Client c, String repassword)
        {
            return Register(c, repassword);
        }

        private String Register(Person p, String repassword)
        {
            if (p.Password == repassword && PersonRepository.Instance.Register(p))
                return "/Login/Index";
            return "";
        }
    }
}