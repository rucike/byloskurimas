using System;
using System.Diagnostics;
using System.Threading;

namespace bylos
{
    class Program
    {
        static void Main(string[] args)
        {
            string katal1 = "failai";  //failu buvimo katalogas
            string katal2 = "ataskaita";  //ataskaitos buvimo vieta
            Console.Write("Iveskite skaiciu, kiek noresite sukurti skirtingu bylu: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            Byla obj = new Byla(n, katal1);
            obj.kurimas();
            Console.ReadLine();
            obj.ataskaita(katal2, "report");
            Console.ReadLine();
            obj.trinti();
            
            Console.ReadLine();
        }
    }
}