using News.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace News.Services
{
    public class NewsService
    {
        public async Task<NewsResult> GetNews(NewsScope scope)
        {
            string url = GetUrl(scope);
            var client = new WebClient();
            var jsonResult = await client.DownloadStringTaskAsync(url);
            NewsResult retorno = JsonConvert.DeserializeObject<NewsResult>(jsonResult);
            return retorno;
        }

        public string GetUrl(NewsScope scope)
        {
            return scope switch
            {
                NewsScope.HeadLines => HeadLines,
                NewsScope.Local => Local,
                NewsScope.Global => Global,
                 _   => throw new Exception("Escopo não definido")

            };
        }

        public string HeadLines => 
            "https://newsapi.org/v2/yop-headlines?" +
            "country=us&" +
            $"apikey={Settings.NewsApiKey}";
    
        public string Local =>
           "https://newsapi.org/v2/yop-everything?" +
           "q=Local&" +
           $"apikey={Settings.NewsApiKey}";

        public string Global =>
          "https://newsapi.org/v2/yop-everything?" +
          "q=global&" +
          $"apikey={Settings.NewsApiKey}";
    }
}

