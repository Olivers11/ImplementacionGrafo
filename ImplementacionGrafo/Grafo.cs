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
            Vertice ver_padre = this.getVertice(padre);
            ver.origen.Add(origen);
            ver_padre.Aristas.Add(ver);
        }

        public void clearComponents()
        {
            this.recorridos = new List<int>();
            this.recorridos_2 = new List<int>();
            this.referencia_iterador = 0;
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
                conjunto.posiciones = conjunto.posiciones.Distinct().ToList();
                if (conjunto.index == valor_ref)
                {
                    foreach (int i in conjunto.posiciones)
                    {
                        Console.WriteLine("item: " + i + " " +  this.verificarOrigen(Convert.ToInt32(i), "e"));
                    }
                }
            }
            Console.WriteLine("");
        }


        public void contarHijos(Vertice ver, string referencia)
        {
            this.referencia_iterador = ver.valor;
            this.conjuntos.Add(new Conjunto(ver.valor));
            this.contarEscalas(ver, referencia);
            aux_cont = 0;
        }
        public int referencia_iterador = 0;

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
                            //Console.WriteLine("Contando: " + vr.valor);
                            if (!vr._checked) aux_cont += this.contarPadres(vr.origen, referencia);
                            vr._checked = true;
                            //Console.WriteLine("referencia usada: " + referencia_iterador);
                            if(this.verificarOrigen(vr.valor, referencia))this.agregarConjunto(vr.valor, referencia_iterador);
                            this.contarEscalas(vr, referencia);
                        }
                    }
                }

            }
        }

        public bool esPadre(Vertice reference, int child)
        {
            foreach(Vertice ver in reference.Aristas)
            {
                if (ver.valor == child) return true;
            }
            return false;
        }

        public bool  verificarOrigen(int pos, string origen)
        {
            Vertice ver = this.getVertice(pos);
            if(this.esPadre(ver, referencia_iterador))
            {
                for(int i = 1; i < ver.Aristas.Count; i++)
                {
                    if (ver.origen[i] == origen) return true;
                }
                return false;
            }
            foreach(string or in ver.origen)
            {
                if (or.Equals(origen)) return true;
            }
            return false;
        }

        public bool verificarPosicion()
        {
            return true;
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

        public void printVertices()
        {
            foreach(Vertice ver in this.v)
            {
                Console.WriteLine("Vert: " + ver.valor);
                foreach(Vertice vr in ver.Aristas)
                {
                    Console.WriteLine("Aris: " + vr.valor);
                }
            }
        }



    }
}

