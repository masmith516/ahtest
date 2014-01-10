using AHServices.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace AHServices.Controllers
{
    public class CurrencyController : ApiController
    {
        public Currency Get(string source, string target, string amount)
        {
            if (string.IsNullOrWhiteSpace(source) ||
                string.IsNullOrWhiteSpace(target) ||
                string.IsNullOrWhiteSpace(amount))
            {
                // TODO: should return some sort of error code
                return new Currency();
            }

            // TODO: should apply some sort of validation here.
            RegionInfo sourceCountryInfo = new RegionInfo(source);
            RegionInfo targetCountryInfo = new RegionInfo(target);
            //string amount = "50";

            string uri = string.Format("http://currency-api.appspot.com/api/{0}/{1}.json?key=2cf8b50eff6a05fb844b101ae323450b13dce2bc&amount={2}", 
                sourceCountryInfo.ISOCurrencySymbol,
                targetCountryInfo.ISOCurrencySymbol,
                amount );

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.ContentType = "text/json";

            WebResponse response = request.GetResponse();
            string rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
            
            JObject json = JObject.Parse(rawJson);
            Currency currency = new Currency
            {
                ConversionAmount = json["amount"].ToString(),
                SourceCountry = sourceCountryInfo.EnglishName,
                SourceCurrency = sourceCountryInfo.CurrencyEnglishName,
                SourceExchangeRate = json["rate"].ToString(),
                TargetCountry = targetCountryInfo.EnglishName,
                TargetCurrency = targetCountryInfo.CurrencyEnglishName,
                TargetExchangeRate = json["rate"].ToString()
            };

            return currency;
        }
    }
}
