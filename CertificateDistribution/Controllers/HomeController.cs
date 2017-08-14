using System;
using System.Collections.Generic;
using System.IO;
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
            var platform = Request.UserAgent;
            ViewBag.Platform = platform;

            return View();
        }

        public ActionResult Download()
        {
            string fileName = "";
            string fileType = "";

            // Todo: check what OS the user is operating on
            var platform = Request.UserAgent;
            if (platform.Contains("Windows"))
            {
                fileName = "install_certificate.exe";
                fileType = "application/octet-stream";
            }
            else if (platform.Contains("Mac OS"))
            {
                fileName = "install_certificate.";
                fileType = "";
            }
            else if (platform.Contains("Linux"))
            {
                // show error, unsupported os
            }

            string fullPath = Path.Combine(Server.MapPath("~/Test_Content"), fileName);
            return File(fullPath, fileType, fileName);
        }
        
    }
}