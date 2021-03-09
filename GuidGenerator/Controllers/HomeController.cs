using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GuidGenerator.Models;

namespace GuidGenerator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<string> GetGUID(int count, bool uppercase, bool braces, bool hyphens, bool base64encode)
        {
            List<string> guids = new List<string>();
            try
            {
                var userIp = Request.HttpContext.Connection.RemoteIpAddress;
                Logger.Log($"{userIp} Requested {count} GUIDs");
                if (count > 2000)
                {
                    guids.Add("Enter a Number Less Than 2000");
                    return guids;
                }

                for (int i = 0; i < count; i++)
                {
                    string g;
                    g = hyphens ? Guid.NewGuid().ToString() : Guid.NewGuid().ToString("N");
                    g = uppercase ? g.ToUpper() : g;
                    g = braces ? "{" + g + "}" : g;
                    g = base64encode ? Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(g)) : g;
                    guids.Add(g);
                }

                Logger.Log("Done");
                return guids;
            }
            catch (Exception ex)
            {
                Logger.Log("Exception Occured",ex);
                guids.Add(ex.Message);
                return guids;
            }

        }

        public string ValidateGUID(string inputdata)
        {
            Guid x;
            bool isValid = Guid.TryParse(inputdata, out x);
            return x.ToString();
        }
    }
}
