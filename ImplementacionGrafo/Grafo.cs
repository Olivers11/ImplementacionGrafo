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
            foreach (Vertice ver in this.v)
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

        public void printArr()
        {
            foreach (Vertice ver in this.v)
            {
                Console.WriteLine("Vertice: " + ver.valor);
                foreach (Vertice vr in ver.Aristas)
                {
                    Console.WriteLine("ari: " + vr.valor);
                }
            }
        }

        public int getPos(int valor)
        {
            for (int i = 0; i < this.v.Count; i++)
            {
                if (this.v[i].valor == valor) return i;
            }
            return -1;
        }
        public bool esOrigen(string letra, Vertice ver, int valor)
        {
            foreach (Origen or in ver.origenes)
            {
                if (or.padre == valor && or.origen == letra) return true;
            }
            return false;
        }

        public void printOrigins(List<Origen> origenes)
        {
            foreach(Origen origen in origenes)
            {
                Console.WriteLine(origen.origen + " -- padre: " + origen.padre);
            }
        }

        public void print(Vertice vertice)
        {
            //Console.WriteLine("Vertice: " + vertice.valor);
            int cont = 0;
            foreach (Vertice ver in vertice.Aristas)
            {
                Console.WriteLine("ari: " + ver.valor);
                Console.WriteLine("Origenes");
                this.printOrigins(ver.origenes);
                //if (this.esOrigen("e", vertice, ver.valor)) Console.WriteLine("ari: " + ver.valor + " --origen: " + ver.origenes);
                if (!ver.isChecked())
                {
                    ver.checkearArista(cont);
                    cont++;
                    this.print(ver);
                }
            }
        }



    }
}

