using HtmlAgilityPack;
using System.Globalization;

namespace ExchangeRatesApp
{
    internal class FastWebScraper
    {
        CultureInfo cultureInfo = new CultureInfo("ru-RU");

        public List<Currency> GetCurrencies(string url)
        {
            var currencies = new List<Currency>();

            var web = new HtmlWeb();
            var doc = web.Load(url);

            var nodes = doc.DocumentNode.SelectNodes("//*[@id=\"s-page-content\"]/div/form/div/div[1]/table/tbody/tr[position()>1]");
            var date = doc.DocumentNode.SelectSingleNode("//*[@id=\"s-page-content\"]/div/form/h3");

            foreach ( var node in nodes )
            {
                var currency = new Currency()
                {
                    FullName = node.SelectSingleNode("td[2]").InnerText,
                    ShortName = node.SelectSingleNode("td[3]").InnerText.Substring(0, 3),
                    Value = double.Parse(node.SelectSingleNode("td[4]").InnerText),
                    Date = DateTime.Parse(date.InnerText.Substring(date.InnerText.Length - 11), cultureInfo),
                };

                currencies.Add(currency);
            }

            return currencies;
        }

        
    }
}
