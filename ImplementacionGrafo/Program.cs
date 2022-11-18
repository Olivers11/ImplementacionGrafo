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
        public static void printByLetter(List<Columna> columnas, string letra)
        {
            for (int i = 0; i < columnas.Count; i++)
            {
                if (columnas[i].letra == letra)
                {
                    Console.WriteLine("letra: " + columnas[i].letra);
                    for (int j = 0; j < columnas[i].conjuntos.Count; j++)
                    {
                        Console.Write(columnas[i].conjuntos[j].index);
                        for (int k = 0; k < columnas[i].conjuntos[j].posiciones.Count; k++)
                        {
                            Console.Write("     " + columnas[i].conjuntos[j].posiciones[k]);
                        }
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine();
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
            Console.WriteLine("imprimiendo");
            List<Columna> columnas = new List<Columna>();
            List<Clausura> clausuras = new List<Clausura>();
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
                        foreach (int x in c.posiciones)
                        {
                            bool existe = false;
                            foreach (Vertice arista in grafo.getVertice(i).Aristas)
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

            for (int i = 1; i <= grafo.v.Count; i++)
            {
                grafo.printArr(i, "e");
                int pos = grafo.getConjuntoPos(i);
                if (pos != -1)
                {
                    Conjunto c = grafo.conjuntos[pos];
                    Clausura cl = new Clausura(c.index);
                    cl.posiciones = c.posiciones;
                    clausuras.Add(cl);
                    grafo.clearConjuntos();
                }
            }



            //foreach (Clausura clausura in clausuras)
            //{
            //    Console.WriteLine("ref: " + clausura.estado);
            //    foreach (int pos in clausura.posiciones)
            //    {
            //        Console.WriteLine("pos: " + pos);
            //    }
            //    Console.WriteLine("-----------------------------");
            //}
            Celdas celda_actual;
            //printByLetter(columnas, "e");
            Console.ReadKey();
        }
    }
}
