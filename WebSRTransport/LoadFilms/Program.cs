using DB.DBModels;
using DB.Repositories;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace LoadFilms
{
    class Program
    {

        //static string url = "https://kinopoiskapiunofficial.tech/api/v2.1/films/search-by-filters?order=RATING&type=ALL&ratingFrom=0&ratingTo=10&yearFrom=1888&yearTo=2020&page=1";
        static string url = "https://kinopoiskapiunofficial.tech/api/v2.1/films/search-by-filters?order=RATING&type=ALL&ratingFrom=0&ratingTo=10&yearFrom=1888&yearTo=2020";

        static void Main(string[] args)
        {
            var rep = new FilmRepository();

            int page = 0;
            long pageCount = 2;
            while (page++ < pageCount)
            {
                var res = Get($"{url}&page={page}");
                dynamic result = JsonConvert.DeserializeObject(res);

                pageCount = result.pagesCount.Value ?? 0;
                var list = result.films;
                for(int index = 0; index < list.Count; index++)
                {
                    var item = list[index];

                    var film = rep.Get(item.nameRu.Value);

                    var f = film ?? new DBFilm();
                    f.Status = 0;
                    f.Name = item.nameRu.Value;
                    f.Year = int.Parse(item.year.Value.Replace(".","").Replace("-",""));
                    f.Country = "";
                    foreach (var itm in item.countries)
                    {
                        f.Country += $"{itm.country},";
                    }
                    f.Country.Trim(',');

                    rep.Save(f);

                }

                //var f = new Film(res);
            }

            Console.ReadLine();
        }

        static string Get(string URI)
        {
            WebClient client = new WebClient();

            // Add a user agent header in case the 
            // requested URI contains a query.

            client.Headers.Add("X-API-KEY", "61b9e458-e22b-4fcb-b7d9-4c1bce7fe041");

            Stream data = client.OpenRead(URI);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();

            return s;
        }
    }
}
