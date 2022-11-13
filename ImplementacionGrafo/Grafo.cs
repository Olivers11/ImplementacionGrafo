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

        public Vertice getVertice(int valor)
        {
            foreach (Vertice ver in v)
            {
                if (ver.valor == valor)
                {
                    return ver;
                }
            }
            return null;
        }

        public void referenciarVertice(string origen, int valor, int padre)
        {
            Vertice ver = this.getVertice(valor);
            //Console.WriteLine("vertice hijo: " + ver.valor);
            Vertice ver_padre = this.getVertice(padre);
            //Console.WriteLine("vertice padre: " + ver_padre.valor);
            ver.origen.Add(origen);
            ver_padre.Aristas.Add(ver);
        }

        public void clearComponents()
        {
            this.recorridos = new List<int>();
            this.recorridos_2 = new List<int>();
        }
        public void recorrer(Vertice ver)
        {
            if (ver != null)
            {
                if (!this.fueRecorrido(ver.valor, recorridos))
                {
                    Console.WriteLine(ver.valor);
                    recorridos.Add(ver.valor);
                    foreach (Vertice vr in ver.Aristas)
                    {
                        this.recorrer(vr);
                    }
                }

            }
        }

        public List<int> recorridos = new List<int>();
        public bool fueRecorrido(int valor, List<int> r)
        {
            foreach (int i in r)
            {
                if (i == valor) return true;
            }
            return false;
        }

        public void agregarConjunto(int num, int valor_ref)
        {
            foreach (Conjunto conjunto in this.conjuntos)
            {
                if (conjunto.index == valor_ref)
                {
                    conjunto.posiciones.Add(num);
                }
            }
        }

        public void printPosiciones(int valor_ref)
        {
            foreach (Conjunto conjunto in this.conjuntos)
            {
                if (conjunto.index == valor_ref)
                {
                    foreach (int i in conjunto.posiciones)
                    {
                        Console.WriteLine("item: " + i);
                    }
                }
            }
            Console.WriteLine("");
        }


        public void contarHijos(Vertice ver, string referencia)
        {
            this.conjuntos.Add(new Conjunto(ver.valor));
            this.contarEscalas(ver, referencia);
            aux_cont = 0;
        }

        public int aux_cont = 0;
        public List<int> recorridos_2 = new List<int>();
        public void contarEscalas(Vertice ver, string referencia)
        {
            if (ver != null)
            {
                if (!this.fueRecorrido(ver.valor, recorridos_2))
                {
                    recorridos_2.Add(ver.valor);
                    foreach (Vertice vr in ver.Aristas)
                    {
                        if (this.podemosIr(vr.origen, referencia))
                        {
                            Console.WriteLine("Contando: " + vr.valor);
                            if (!vr._checked) aux_cont += this.contarPadres(vr.origen, referencia);
                            vr._checked = true;
                            this.agregarConjunto(vr.valor, ver.valor);
                            this.contarEscalas(vr, referencia);
                        }
                    }
                }

            }
        }

        public int contarPadres(List<string> origenes, string referencia)
        {
            int cont = 0;
            foreach (string s in origenes)
            {
                if (s == referencia)
                {
                    cont++;
                }
            }
            return cont;
        }

        public bool podemosIr(List<string> origenes, string referencia)
        {
            return origenes.Contains(referencia);
        }


    }
}

