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
            grafo.llenarMatriz();
            grafo.printMatriz();
            /*grafo.referenciarVertice("a", 2, 1);
            grafo.referenciarVertice("a", 3, 2);
            grafo.referenciarVertice("b", 3, 1);
            grafo.referenciarVertice("a", 4, 3);*/
            //grafo.recorrer(grafo.getVertice(2));
            //grafo.contarEscalas(grafo.getVertice(2), "a");
            //grafo.contarHijos(grafo.getVertice(2), "a");
            //grafo.printPosiciones(2);
            //grafo.clearComponents();
            //Console.WriteLine("Caminos de e en (1): " + grafo.aux_cont);
            for (int i = 1; i < grafo.v.Count; i++)
            {
                Console.WriteLine("recorriendo: " + i);
                grafo.contarHijos(grafo.getVertice(i), "e");
                grafo.printPosiciones(i);
                grafo.clearComponents();
            }
            Console.ReadKey();
        }
    }
}
