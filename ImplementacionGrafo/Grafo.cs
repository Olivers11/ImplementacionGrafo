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
        public List<string> letras;
        public Grafo()
        {
            this.v = new List<Vertice>();
            this.conjuntos = new List<Conjunto>();
            this.letras = new List<string>();
        }

        public void addVertice(int valor)
        {
            this.v.Add(new Vertice(valor));
            this.conjuntos.Add(new Conjunto(valor));
        }

        public void clearConjuntos()
        {
            foreach(Vertice ver in this.v)
            {
                this.conjuntos.Add(new Conjunto(ver.valor));
            }
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
            this.letras.Add(letra);
            Vertice vertice_p = this.getVertice(padre);
            Vertice vertice_h = this.getVertice(hijo);
            vertice_h.origenes.Add(new Origen(letra, padre, hijo));
            vertice_p.Aristas.Add(vertice_h);
            this.letras = this.letras.Distinct().ToList();
        }

        public bool seSigue(Vertice ver, string letra)
        {
            foreach(Vertice vr in ver.Aristas)
            {
                foreach(Origen origen in vr.origenes)
                {
                    if (origen.origen == letra) return true;
                }
            }
            return false;
        }
        public void printArr(int estado, string letra)
        {
            int cont = 0;
            foreach (Vertice ver in this.v)
            {
                if (cont >= estado - 1)
                {
                    Console.WriteLine("Vertice: " + ver.valor);
                    if (!this.seSigue(ver, letra)) break;
                    foreach (Vertice vr in ver.Aristas)
                    {
                        foreach (Origen or in vr.origenes)
                        {
                            //Console.WriteLine("origen: " + or.origen + " padre: " + or.padre + " -- ari: " + vr.valor + " --ver: " + ver.valor);
                            if (or.padre == ver.valor && or.origen == letra)
                            {
                                this.agregarConjunto(ver.valor, vr.valor);
                                Console.WriteLine("ari: " + vr.valor);
                                Console.WriteLine("origen: " + or.origen);
                            }
                        }
                    }
                }
                cont++;
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

        public void agregarConjunto(int vertice, int arista)
        {
            Conjunto conj = this.conjuntos.Find(c => c.index == vertice);
            conj.posiciones.Add(arista);
        }

        public void printConjuntos()
        {
            foreach (Conjunto con in this.conjuntos)
            {
                Console.WriteLine("index: " + con.index);
                foreach (int ari in con.posiciones)
                {
                    Console.WriteLine("item: " + ari);
                }
            }
        }

        public int getConjuntoPos(int valor)
        {
            int cont = 0;
            foreach(Conjunto c in this.conjuntos)
            { 
                if (c.index == valor) return cont;
                cont++;
            }
            return -1;
        }
    }
}
