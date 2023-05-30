using Microsoft.AspNetCore.HttpOverrides;
using System.Net;
using System.Web;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;


namespace MVCWebHello.Models
{
    public class Ember
    {
        public string? Nev { get; set; }

        public int Szul { get; set; }
       
        public string IpCim { get; private set; }

        public string Belepve { get; set; }

        public string? Kiir;

        public Ember()
        {
            Nev = "Senki";
            Szul = 0;
            IpCim = string.Empty;
            Belepve = string.Empty;
        }
                

        public string Udv(string Nev)
        {
            string udvozlet = string.Empty;
            int ora = int.Parse(DateTime.Now.ToString("HH"));

            if (ora > 0 && ora <= 10)            
                udvozlet = "Jó reggelt " + Nev + " !";
            
            else if (ora > 10 && ora <= 17)            
                udvozlet = "Jó napot " + Nev + " !";
            
            else            
                udvozlet = "Jó estét " + Nev + " !";            

            return udvozlet;
        }

        public void Suti(string Nev, HttpContext httpContext)
        {
            httpContext.Response.Cookies.Append("userNev", Nev);
        }


        public string Korod(int szul)
        {
            DateTime most = DateTime.Today;
            int age = most.Year - szul;
            string kor;
            if (szul > 1919)
            {
                if (age > 18)
                {
                    kor = $"A mai napon ({most.Year}.{most.Month}.{most.Day}) Ön {age} éves, tehát felnőtt, így megtekintheti a következő részeket";
                }
                else
                {
                    kor = $"A mai napon ({most}) te {age} évesen még nem láthatod a következő tartalmat.";
                }               
            }
            else
            {
                kor = "";
            }
            return kor;
        }

        public string Csinald()
        {
            string IpCim = IpAddress().Result;           
            return IpCim;
        }

        public static async Task<string> IpAddress()
        {
            var url = "https://api.ipify.org";

            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();                
            }
            else
            {
                return "Zavar támadt a lekérdezés során! Nem látható az ön IP címe";
            }         
        }

        public string FileIro(string Nev)
        {            
            string aktual = Directory.GetCurrentDirectory().ToString();
            string regDate = DateTime.Now.ToString();

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(aktual, "ferkoUsers.log"), true))
            {
                outputFile.WriteLine($"{regDate}; {Nev}; {Csinald()}");
                outputFile.Flush();
                outputFile.Close();
            }
            return aktual + "\\ferkoUsers.log";            
        }
    }
}
