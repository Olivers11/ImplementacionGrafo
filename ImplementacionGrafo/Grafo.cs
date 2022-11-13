using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace implementacionGrafo
{
    public class Grafo
    {
        public List<Vertice> v;
        public Grafo()
        {
            this.v = new List<Vertice>();
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
            Console.WriteLine("vertice hijo: " + ver.valor);
            Vertice ver_padre = this.getVertice(padre);
            Console.WriteLine("vertice padre: " + ver_padre.valor);
            ver.origen.Add(origen);
            ver_padre.Aristas.Add(ver);
        }

        public void recorrer(Vertice ver)
        {
            if (ver != null)
            {
                if (!this.fueRecorrido(ver.valor, recorridos))
                {
                    foreach (string str in ver.origen)
                    {
                        Console.WriteLine(ver.valor + " - " + str);
                    }
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

        public int aux_cont = 0;
        public List<int> recorridos_2 = new List<int>();
        public void contarEscalas(Vertice ver, string referencia)
        {
            if (ver != null)
            {
                if (!this.fueRecorrido(ver.valor, recorridos_2))
                {
                    foreach (string str in ver.origen)
                    {
                        if(str == referencia)
                        {
                            aux_cont++;
                        }
                    }
                    recorridos_2.Add(ver.valor);
                    foreach (Vertice vr in ver.Aristas)
                    {
                        if (this.podemosIr(vr.origen, referencia))
                        {
                            this.contarEscalas(vr, referencia);
                        }
                    }
                }

            }
        }

        public bool podemosIr(List<string> origenes, string referencia)
        {
            return origenes.Contains(referencia);
        }


    }
}

