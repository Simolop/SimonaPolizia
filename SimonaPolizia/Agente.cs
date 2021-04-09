using System;
using System.Collections.Generic;
using System.Text;


namespace SimonaPolizia
{
    class Agente : Persona
    {
       
        public int IdAgente { get; }
        public DateTime DataNascita { get; }
        public int AnniServizio { get; }

        public List<Assegnazione> Assegnazioni { get; } = new List<Assegnazione>();
      
        public Agente (int idAgente, string cf, string nome, string cognome, int anniServizio)
            : base(cf, nome, cognome)
        {
            IdAgente = idAgente;
            AnniServizio = anniServizio;
        }


        public override string ToString()
        {
            return $"{CF} {Nome} {Cognome} AnniServizio: {AnniServizio}";
        }

    }
}
