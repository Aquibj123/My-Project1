using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebApi.Models
{
    public class CurrencyExchangeModel
    {
        public string CountryCode { get; set; }
        public string ExchangeRate { get; set; }
    }
}