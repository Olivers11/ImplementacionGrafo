using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImplementacionGrafo;

namespace implementacionGrafo
{
    public class Grafo
    {
        public List<Vertice> v;
        public List<Conjunto> conjuntos;
        public Grafo()
        {
            this.v = new List<Vertice>();
            this.conjuntos = new List<Conjunto>();
        }

        public void addVertice(int valor)
        {
            this.v.Add(new Vertice(valor));
        }

        public Vertice getVertice(int val)
        {
            foreach(Vertice ver in this.v)
            {
                if (ver.valor == val) return ver;
            }
            return null;
        }
        public void referenciarVertice(string letra, int hijo, int padre)
        {
            Vertice vertice_p = this.getVertice(padre);
            Vertice vertice_h = this.getVertice(hijo);
            vertice_h.origenes.Add(new Origen(letra, padre, hijo));
            vertice_p.Aristas.Add(vertice_h);
        }

        public void print(Vertice vertice)
        {
            if(vertice != null)
            {
                Console.WriteLine("Vertice: " + vertice.valor);
                foreach(Vertice ver in vertice.Aristas)
                {
                    this.print(ver);
                }
            }
        }



    }
}

