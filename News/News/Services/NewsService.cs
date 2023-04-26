using News.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace News.Services
{
    class NewsService
    {
        public async Task<NewsResult> GetNews(NewsScope scope)
        {
            return null;
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

