using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Security.Authentication;
using SchoolJournal.Services;
using SchoolJournal.Areas.Admin.Services;
using SchoolJournal.Models;
using SchoolJournal.Areas.Admin.Models;

namespace SchoolJournal.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // Basic Admin page
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}