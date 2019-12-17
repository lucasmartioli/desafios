using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using API.Model;
using HtmlAgilityPack;

namespace API.Service
{
    public class WebCrawler
    {
        private readonly string _baseUrl;
        private readonly string _path;
        private readonly Dictionary<string, string> _parameters;
        public HtmlNodeCollection AllNodes;

        public WebCrawler(string baseUrl, string path, Dictionary<string, string> parameters)
        {
            _baseUrl = baseUrl;
            _path = path;
            _parameters = parameters;
        }

        public IEnumerable<Ad> Read()
        {
            var client = new WebClient();

            var url = ResolveUrl();
            var html = client.DownloadString(url);
            
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var ads = new List<Ad>();
            
            SearchAds(htmlDoc, ads);

            return ads;
        }

        private string ResolveUrl()
        {
            var url = _baseUrl;

            if (!string.IsNullOrEmpty(_path))
                url += $"/{_path}";

            if (_parameters.Count > 0)
            {
                url += ResolveParameters();
            }

            return url;
        }

        private string ResolveParameters()
        {
            return "?" + string.Join("&",
                       _parameters.Select(kvp =>
                           $"{kvp.Key}={HttpUtility.UrlEncode(kvp.Value)}"));
        }

        private static void SearchAds(HtmlDocument htmlDoc, List<Ad> ads)
        {
            foreach (var htmlNode in htmlDoc.DocumentNode.SelectNodes("//ul[@id='main-ad-list']"))
            {
                
                
                ads.AddRange(htmlNode.SelectNodes(".//li[@class='item']")
                    .Select(item => new Ad()
                    {
                        Name = ExtractProductName(item),
                        Link = ExtractLink(item),
                        Value = ExtractValue(item)
                    }));
            }
        }

        private static string ExtractProductName(HtmlNode item)
        {
            return item.SelectSingleNode(".//h2[@class='OLXad-list-title']")?.InnerText.Trim().Normalize();
        }

        private static string ExtractLink(HtmlNode item)
        {
            return item.SelectSingleNode(".//a")?.Attributes.First(i => i.Name == "href")?.Value.Trim();
        }

        private static decimal? ExtractValue(HtmlNode item)
        {
            var valueRegex = Regex.Match(item.SelectSingleNode(".//p[@class='OLXad-list-price']")
                                             ?.InnerText.Trim() ?? "", @"\d+.\d+");

            return valueRegex.Success ? Convert.ToDecimal(valueRegex.Value) : (decimal?) null;
        }
    }
}