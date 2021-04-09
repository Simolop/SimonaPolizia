using System;
using System.Collections.Generic;
using System.Text;

namespace SimonaPolizia
{
    abstract class Persona
    {
        //public static bool operator ==(Persona p1, Persona p2)
        //{
        //    return p1.Equals(p2);
        //}
        //public static bool operator !=(Persona p1, Persona p2)
        //{
        //    return !p1.Equals(p2);
        //}

        public string Nome { get; }
        public string Cognome { get; }
        public string CF { get; }

        //Costruttore della classe base
        public Persona (string cf, string nome, string cognome)
        {
            CF = cf;
            Nome = nome;
            Cognome = cognome;
  
        }



        //Due persone sono uguali se hanno lo stesso cf
        //public override bool Equals(object obj)
        //{
        //    if (obj.GetType() != this.GetType())
        //            return false;

        //    return CF == ((Persona)obj).CF;
        //}


        //public override string ToString()
        //{
        //    return CF;
        //}

    }
}
