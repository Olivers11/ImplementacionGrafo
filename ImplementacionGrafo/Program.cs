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
        static void Main(string[] args)
        {
            Grafo grafo = new Grafo();
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
            Console.ReadKey();

        }
    }
}
