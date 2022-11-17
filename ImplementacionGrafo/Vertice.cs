using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImplementacionGrafo;

namespace implementacionGrafo
{
    public class Vertice
    {
        public int valor;
        public List<Origen> origenes;
        public List<Vertice> Aristas;
        public Vertice(int valor)
        {
            this.valor = valor;
            this.origenes = new List<Origen>();
            this.Aristas = new List<Vertice>();
        }
    }
}

