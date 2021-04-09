using System;
using System.Collections.Generic;
using System.Text;

namespace SimonaPolizia
{
    class Assegnazione
    {
        public int IdAssegnazione { get; }
        public int IdArea { get; }
        public int IdAgente { get; }

        public Assegnazione (int idAssegnazione, int idArea, int idAgente)
        {
            IdAssegnazione = idAssegnazione;
            IdArea = idArea;
            IdAgente = idAgente;
        }

        public override string ToString()
        {
            return $"IdAssegnazione: {IdAssegnazione} IdArea: {IdArea} IdAgente: {IdAgente}";
        }
    }
}
