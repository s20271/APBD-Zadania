using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        public async static Task Main(string[] args)
        {
            var httpClient = new HttpClient();

            try
            {
                if (args.Length == 0)
                {
                    throw new ArgumentNullException("Parametr nie został przekazany");
                }

                var webstieUrl = args[0];
                if (!Uri.IsWellFormedUriString(webstieUrl, UriKind.Absolute))
                {
                    throw new ArgumentException("Parametr nie jest poprawnym adresem URL");
                }

                HttpResponseMessage response = await httpClient.GetAsync(webstieUrl);

                var content = await response.Content.ReadAsStringAsync();
                var regex = new Regex(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])");
                MatchCollection matchCollection = regex.Matches(content);
                var emailList = new List<String>();

                foreach (var match in matchCollection)
                {
                    if (!emailList.Contains(match.ToString())) 
                    {
                        emailList.Add(match.ToString());
                        Console.WriteLine(match);
                    }
                }
                if(emailList.Count == 0)
                {
                    Console.WriteLine("Nie znaleziono adresów email");
                }
            }
            catch(HttpRequestException reqE)
            {
                Console.WriteLine("Błąd w czasie pobierania strony");
            }
            catch (Exception e)
            {
                Console.WriteLine("Blad: " + e);
            }
            finally
            {
                httpClient.Dispose();
            }
        }
    }
}