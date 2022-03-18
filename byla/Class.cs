using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace bylos
{
    internal class Byla
    {
        public int sk;
        public string katF;
        public string katA;
        public string path;
        public Byla(int n, string name1)
        {
            sk = n;  //kuriamu bylu skaicius
            katF = name1;  //katalogo pavadinimas
            path = katF + "/";
        }

        public void kurimas()
        {  
            //tikrinama ar yra sukurtas failu katalogas, jei ne - sukuriame
            if (!FileSystem.DirectoryExists(katF))
            {
                FileSystem.CreateDirectory(katF);
                Console.WriteLine("Katalogas '" + katF + "' sukurtas.");
            }else
            {
                Console.WriteLine("Naujas katalogas nesukurtas, nes '" + katF + "' egzistuoja is seniau.");
            }

            var rand = new Random();
            string data = DateTime.Now.ToString("yyyy-MM-dd"); //paimama data

            for(int i = 1; i <= sk; i++)   //sukamas ciklas, kiek buvo ivesta vartotojo
            {
                string vardas = path + "a" + i + ".txt";  //nustatome failo vieta ir varda
                int tekstas = rand.Next(0,2);  //parenkami atsitiktiniai skaiciai tarp 0 ir 1

                if (!File.Exists(vardas))   //tikrinama ar dar neegzistuoja failas tokiu pavadinimu 
                {
                    File.WriteAllText(vardas, Convert.ToString(tekstas));  //jei neegzistuoja - sukuriame
                    Console.WriteLine(vardas + " sukurta");  
                }
                else
                {
                    string vardasN = "a" + i + "_" + data + ".txt";
                    FileSystem.RenameFile(vardas, vardasN);  //jei egzistuoja - pervadiname
                    Console.WriteLine(vardas + " pervadinta i " + vardasN);
                }
            }

        }

        public void ataskaita(string name2, string name)
        {
            katA = path + name2;  //ataskaitos katalogo pavadinimas
            //tikrinama ar ataskaitos katalogas egzistuoja, jei ne - sukuriame
            if (!FileSystem.DirectoryExists(katA))
            {
                FileSystem.CreateDirectory(katA);
                Console.WriteLine("Katalogas '" + katA + "' sukurtas.");
            }
            else
            {
                Console.WriteLine("Naujas katalogas nesukurtas, nes '" + katA + "' egzistuoja is seniau.");
            }
            //aprasomi kintamieji
            int nulis = 0;
            int vienas = 0;

            foreach(string Byla in FileSystem.GetFiles(katF))  //tikrinamas kiekvienas failas
            {
                string failas = FileSystem.ReadAllText(Byla);
                if (failas == "0")
                {
                    nulis++;
                }
                else if (failas == "1") { vienas++; }
            }
            FileSystem.WriteAllText(katA + "/" + name + ".txt", "Pateiktose bylose vienetu yra " + vienas + ", o nuliu - " + nulis, false);
            Console.WriteLine("Ataskaita patalpinta faile.");
        }

        public void trinti()
        {
            int n = 0; //sekti kiek failu buvo istrinta
            foreach (string Byla in FileSystem.GetFiles(katF))  //tikrinamas kiekvienas failas
            {
                string failas = FileSystem.ReadAllText(Byla);
                if (failas == "0")  //jeigu 0, failas trinamas
                {
                    FileSystem.DeleteFile(Byla);
                    n++;
                }
            }
            Console.WriteLine(n + " failai(-u) su 0 buvo istrinti.");
        }
    }
}
