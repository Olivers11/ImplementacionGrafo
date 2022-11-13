using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace implementacionGrafo
{
    public class Vertice
    {
        public int valor;
        public List<string> origen;
        public List<Vertice> Aristas;
        public Vertice(int valor)
        {
            this.valor = valor;
            this.origen = new List<string>();
            this.Aristas = new List<Vertice>();
        }
    }
}

