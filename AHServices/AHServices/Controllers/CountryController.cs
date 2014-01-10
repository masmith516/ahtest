using AHServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AHServices.Controllers
{
    public class CountryController : ApiController
    {
        public Country Get()
        {
            return new Country { Code = "US", CurrencyName = "US Dollar", Name = "United States" };
        }
    }
}
