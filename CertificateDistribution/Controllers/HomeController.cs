﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CertificateDistribution.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.OS = Environment.OSVersion.Platform;

            return View();
        }
        
    }
}