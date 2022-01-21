using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ConsumeWebApi.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ConsumeWebApi.Controllers
{
    public class CurrencyExController : Controller
    {

        public ActionResult Index()
        {
            string Baseurl = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/2020-11-24/currencies/eur.json";
            List<CurrencyExchangeModel> currencyExchangeList = new List<CurrencyExchangeModel>();
            List<CurrencyExchangeModel> currencyExchangeList1 = new List<CurrencyExchangeModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(Baseurl).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                JObject sparrow = JObject.Parse(dataObjects);
                string dd = sparrow["eur"].ToString();
                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(dd);
                foreach (var kv in dict)
                {
                        CurrencyExchangeModel currencyExchangeModel = new CurrencyExchangeModel();
                        currencyExchangeModel.CountryCode = kv.Key;
                        currencyExchangeModel.ExchangeRate = kv.Value;
                        currencyExchangeList.Add(currencyExchangeModel);                     
                        currencyExchangeModel = null;
                }
                List l1 = new List();
                foreach (var kv1 in dict)
                {
                    l1.Add(kv1.Key, kv1.Value);
                }
                List<string> sort =l1.BubbleSorted();
                for (int i=0;i<sort.Count;i=i+2)
                {
                    CurrencyExchangeModel currencyExchangeModel1 = new CurrencyExchangeModel();                  
                    currencyExchangeModel1.ExchangeRate = sort[i];
                    currencyExchangeModel1.CountryCode = sort[i+1];
                    currencyExchangeList1.Add(currencyExchangeModel1);
                    currencyExchangeModel1 = null;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return View(currencyExchangeList1);
        }        
    }
}