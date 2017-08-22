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
        private const string ADMIN_DIR = "admin";

        private const string READONLY_DIR = "readonly";
        
        public ActionResult Index()
        {
            var platform = Request.UserAgent;
            var fileName = GetDownloadFileName(platform);

            if (fileName.Equals("unknown"))
            {
                ViewBag.isValid = false;
                ViewBag.Platform = "Unsupported Device Platform";
            }
            else
            {
                ViewBag.isValid = true;
                ViewBag.Platform = platform;
            }

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
            var downloadFile = DownloadFile(ADMIN_DIR);
            return downloadFile;
        }

        private ActionResult DownloadFile(string directory)
        {
            var fileName = GetDownloadFileName(Request.UserAgent);
            
            string fullPath = Path.Combine(Server.MapPath($"~/Distribution_Apps/{directory}/"), fileName);
            return File(fullPath, fileName, fileName);

        }

        private string GetDownloadFileName(string platform)
        {
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