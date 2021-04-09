using System;
using System.Collections.Generic;
using System.Text;

namespace SimonaPolizia
{
    class AreaMetropolitana
    {
        public int IdArea { get; }
        public string CodiceArea { get; }
        public bool AltoRischio { get; }

        public AreaMetropolitana (int idArea, string codiceArea)
        {
            IdArea = idArea;
            CodiceArea = codiceArea;
        }
    }
}
