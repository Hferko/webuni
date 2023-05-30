using System.Threading;

namespace MVCWebHello.Models
{
    public class Beolvas
    {
        public List<string> Idok { get; set; }
        public List<string> Nevek { get; set; }
        public List<string> Ipk { get; set; }
        public int? Szamlalo { get; set; }


        public Beolvas()
        {
            Idok = new List<string>();
            Nevek = new List<string>();
            Ipk = new List<string>();

            Nev(Nevek);
            Ido(Idok);
            IP(Ipk);
            Szamlalo = Idok.Count();
        }

        public string[] FileOlvaso()
        {
            string aktual = Directory.GetCurrentDirectory().ToString();
            try
            {
                string[] Tartalom = File.ReadAllLines(Path.Combine(aktual, "ferkoUsers.log"));
                return Tartalom;
            }
            catch (IOException)
            {
                string[] Tartalom = { };
                return Tartalom;
            }
        }

        public List<string> Nev(List<string> Nevek)
        {
            string[] sorok;
            for (int i = 0; i < FileOlvaso().Length; i++)
            {
                sorok = FileOlvaso()[i].Split(';');
                Nevek.Add(sorok[0]);
            }
            return Nevek;
        }

        public List<string> Ido(List<string> Idok)
        {
            string[] sorok;
            for (int i = 0; i < FileOlvaso().Length; i++)
            {
                sorok = FileOlvaso()[i].Split(';');
                Idok.Add(sorok[1]);
            }
            return Idok;
        }

        public List<string> IP(List<string> Ipk)
        {
            string[] sorok;
            for (int i = 0; i < FileOlvaso().Length; i++)
            {
                sorok = FileOlvaso()[i].Split(';');
                Ipk.Add(sorok[2]);
            }
            return Ipk;
        }

    }
}
