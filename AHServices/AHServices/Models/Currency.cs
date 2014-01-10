using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHServices.Models
{
    public class Currency
    {
        public string SourceCountry { get; set; }
        public string SourceCurrency { get; set; }
        public string SourceExchangeRate { get; set; }
        public string TargetCountry { get; set; }
        public string TargetCurrency { get; set; }
        public string TargetExchangeRate { get; set; }
        public string ConversionAmount { get; set; }
    }
}