using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using implementacionGrafo;

namespace ImplementacionGrafo
{
    public class Origen
    {
        public string origen;
        public int padre;
        public Vertice referencia;
        public Origen(string origen, int padre, int value)
        {
            this.referencia = new Vertice(value);
            this.padre = padre;
            this.origen = origen;
        }
    }
}
