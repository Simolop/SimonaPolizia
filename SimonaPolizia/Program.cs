using System;
using System.Collections.Generic;

namespace SimonaPolizia
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Agente> agenti = Polizia.ElencoAgenti(true);
            

            foreach (Agente x in agenti)
            {
                Console.WriteLine(x);
                foreach (Assegnazione y in x.Assegnazioni)
                    Console.WriteLine(y);
            }



            /*string s = "GGFRF";
            Agente a = Polizia.RecuperaAgente(s, true);
            if (a == null)
                Console.WriteLine($"L'area {s} non è assegnata a nessun agente");
            else
                Console.WriteLine($"L'agente è: {a.CF} {a.Nome} {a.Cognome} AnniServizio:{a.AnniServizio}");*/

            int anniS = 2;
            Agente a = Polizia.ElencoAgentiAnni(anniS, true);
            if (a == null)
                Console.WriteLine($"Nessun agente ha {anniS} di servizio");
            else
                Console.WriteLine($"Gli agento sono: {a.CF} {a.Nome} {a.Cognome}");


            Polizia.InserisciAgente("DSG567HDFSH", "Debora", "Rossi", 7);


        }
    }
}
