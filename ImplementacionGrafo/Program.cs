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

        public static void interpretarLinea(string linea)
        {
            linea = linea.Replace("}", "");
            linea = linea.Replace("{", "");
            string[] lines = linea.Split(';');
            for(int i = 0; i < lines.Length; i++)
            {
                string l = lines[i].Replace("(", "");
                l = l.Replace(")", "");
                Console.WriteLine(l);
                string[] internas = l.Split(',');
            }
        }
        static void Main(string[] args)
        {
            interpretarLinea("{(1,a,1);(1,e,2);(2,a,3);(2,e,4);(3,b,2);(4,a,4)}");
            /*Grafo grafo = new Grafo();
            grafo.addVertice(1);
            grafo.addVertice(2);
            grafo.addVertice(3);
            grafo.addVertice(4);
            Console.WriteLine("comenzaremos a referenciar");
            grafo.referenciarVertice("a", 2, 1);
            grafo.referenciarVertice("a", 3, 2);
            grafo.referenciarVertice("b", 3, 1);
            grafo.referenciarVertice("a", 4, 3);
            grafo.recorrer(grafo.getVertice(1));
            grafo.contarEscalas(grafo.getVertice(1), "a");
            Console.WriteLine("Caminos de a en (1): " + grafo.aux_cont);
            */
            Console.ReadKey();
        }
    }
}
