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
        private const string ADMIN_DIR = "Admin_Cert";

        private const string READONLY_DIR = "ReadOnly_Cert";

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
            return DownloadFile(READONLY_DIR);
        }

        /*
         * Use to download a Admin Certificate
         */
        public ActionResult DownloadAdmin()
        {
            return DownloadFile(ADMIN_DIR);
        }

        private ActionResult DownloadFile(string directory)
        {

            string downloadFile = GetDownloadFileName();
            


            string fullPath = Path.Combine(Server.MapPath($"~/Distribution_Apps/{directory}/"), downloadFile);
            return File(fullPath, downloadFile, downloadFile);

        }

        private string GetDownloadFileName()
        {
            var platform = Request.UserAgent;
            platform = platform.ToLower();

            if (platform.Contains("windows"))
            {
                if (platform.Contains("x64"))
                {
                    if (platform.Contains("7.0"))
                    {
                        return "cert-install-win7-x64.zip";
                    }
                    else if (platform.Contains("10.0"))
                    {
                        return "cert-install-win10-x64.zip";
                    }
                    else
                    {
                        return "unknown";
                    }
                }
                else if (platform.Contains("x86"))
                {
                    if (platform.Contains("7.0"))
                    {
                        return "cert-install-win7-x86.zip";
                    }
                    else if (platform.Contains("10.0"))
                    {
                        return "cert-install-win10-x86.zip";
                    }
                    else
                    {
                        return "unknown";
                    }
                }
                else
                {
                    return "unknown";
                }
            }
            else 
            {
                // TODO: finish 
                return "unknown";
            }

        }
    }
}