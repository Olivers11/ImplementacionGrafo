using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionGrafo
{
    public class Columna
    {
        public string letra;
        public List<Conjunto> conjuntos;
        public Columna(string letra)
        {
            this.letra = letra;
            this.conjuntos = new List<Conjunto>();
        }   
    }
}
