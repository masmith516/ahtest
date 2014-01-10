using System.ComponentModel;

namespace AHMVCTest.Models
{
    public class Home
    {
        [DisplayName("Source Country")]
        public string SourceCountryCode { get; set; }

        [DisplayName("Target Country")]
        public string TargetCountryCode { get; set; }

        [DisplayName("Amount")]
        public string Amount { get; set; }
    }

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