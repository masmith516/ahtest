using AHMVCTest.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Xml.Linq;

namespace AHMVCTest.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ViewResult Index()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo ci in cultures)
            {
                dict.Add(ci.Name, ci.EnglishName);
            }

            ViewBag.Cultures = dict.OrderBy(d => d.Value);

            return View();
        }

        [HttpPost]
        public ViewResult Index(Home homeModel)
        {
            string uri = string.Format("http://ahservices.localtest.me/api/currency/{0}/{1}/{2}",
                homeModel.SourceCountryCode,
                homeModel.TargetCountryCode,
                homeModel.Amount);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.ContentType = "text/json";

            WebResponse response = request.GetResponse();
            string rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Currency currency = JsonConvert.DeserializeObject<Currency>(rawJson);
            return View("Conversion", currency);
        }
	}
}