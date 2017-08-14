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
        private const string ADMIN_PREFIX = "admin_";

        private const string READONLY_PREFIX= "readonly_";

        public ActionResult Index()
        {
            var platform = Request.UserAgent;
            ViewBag.Platform = platform;

            return View();
        }

        /*
         * Use to download a ReadOnly Certificate
         */
        public ActionResult DownloadReadOnly()
        {
            return DownloadFile(READONLY_PREFIX);
        }

        /*
         * Use to download a Admin Certificate
         */
        public ActionResult DownloadAdmin()
        {
            return DownloadFile(ADMIN_PREFIX);
        }

        private ActionResult DownloadFile(string filePrefix)
        {
            // readonly prefix - readonly_
            // admin prefix - admin_

            string fileName = "";
            string fileType = "";

            // Todo: check what OS the user is operating on
            var platform = Request.UserAgent;
            if (platform.Contains("Windows"))
            {
                fileName = filePrefix + "install_certificate.exe";
                fileType = "application/octet-stream";
            }
            else if (platform.Contains("Mac OS"))
            {
                fileName = filePrefix + "install_certificate.";
                fileType = "";
            }
            else if (platform.Contains("Linux"))
            {
                // show error, unsupported os
            }
            else
            {
                // show error, unknown os 
            }

            string fullPath = Path.Combine(Server.MapPath("~/Test_Content"), fileName);
            return File(fullPath, fileType, fileName);

        }


    }
}