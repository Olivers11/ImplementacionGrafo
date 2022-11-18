using implementacionGrafo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionGrafo
{
    public class Program
    {

        public static void interpretarLinea(string linea, ref Grafo grafo)
        {
            linea = linea.Replace("}", "");
            linea = linea.Replace("{", "");
            string[] lines = linea.Split(';');
            for (int i = 0; i < lines.Length; i++)
            {
                string l = lines[i].Replace("(", "");
                l = l.Replace(")", "");
                //Console.WriteLine(l);
                string[] internas = l.Split(',');
                grafo.referenciarVertice(internas[1], Convert.ToInt32(internas[2]), Convert.ToInt32(internas[0]));
            }
        }
        static void Main(string[] args)
        {
            Grafo grafo = new Grafo();
            grafo.addVertice(1);
            grafo.addVertice(2);
            grafo.addVertice(3);
            grafo.addVertice(4);
            interpretarLinea("{(1,a,1);(1,e,2);(2,a,3);(2,e,4);(3,b,2);(4,e,4);(1,e,4)}", ref grafo);
            //grafo.printArr(2, "e");
            Console.WriteLine("imprimiendo");
            //grafo.printConjuntos();
            List<Columna> columnas = new List<Columna>();
            foreach (string l in grafo.letras)
            {
                int tam = grafo.v.Count;
                Console.WriteLine("Letra: " + l);
                Columna col = new Columna(l);
                for (int i = 1; i <= tam; i++)
                {
                    grafo.printArr(i, l);
                    int pos = grafo.getConjuntoPos(i);
                    if (pos != -1)
                    {
                        Conjunto c = grafo.conjuntos[pos];
                        Conjunto aux = new Conjunto(c.index);
                        foreach(int x in c.posiciones)
                        {
                            bool existe = false;
                            foreach(Vertice arista in grafo.getVertice(i).Aristas)
                            {
                                if (arista.valor == x) existe = true;
                            }
                            if (existe)
                            {
                                aux.posiciones.Add(x);
                            }
                        }
                        col.conjuntos.Add(aux);
                        grafo.clearConjuntos();
                    }
                }
                columnas.Add(col);
            }

            Console.WriteLine("---------------------------------------");
            //foreach (Columna col in columnas)
            //{
            //    Console.WriteLine("************************************************");
            //    Console.WriteLine("Letra: " + col.letra);
            //    foreach (Conjunto conj in col.conjuntos)
            //    {
            //        Console.WriteLine("index: " + conj.index);
            //        foreach (int pos in conj.posiciones)
            //        {
            //            Console.WriteLine(pos);
            //        }
            //    }
            //}
            for (int i = 0; i < columnas.Count; i++)
            {
                Console.WriteLine("letra: " + columnas[i].letra);
                for (int j = 0; j < columnas[i].conjuntos.Count; j++)
                {
                    Console.WriteLine("index: " + columnas[i].conjuntos[j].index);
                    for (int k = 0; k < columnas[i].conjuntos[j].posiciones.Count; k++)
                    {
                        Console.WriteLine("item: " + columnas[i].conjuntos[j].posiciones[k]);
                    }
                    Console.WriteLine("-----------------------------------");
                }
                Console.WriteLine("*******************************************");
            }


            Console.ReadKey();
        }
    }
}
