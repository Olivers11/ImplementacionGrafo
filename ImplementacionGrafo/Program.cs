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


        static bool seRecorrio(List<int> refs, List<int> rec)
        {
            if (refs.Count == 0) return false;
            int cont = 0;
            List<int> repetidos = new List<int>();
            foreach (int item in refs)
            {
                if (rec.Contains(item) && repetidos.Contains(item) == false)
                {
                    cont++;
                    repetidos.Add(item);
                }
            }
            return cont == refs.Count;
        }
        static Celdas obtenerCelda(string letra, Celdas celda, List<Columna> columnas)
        {
            List<int> referencias = new List<int>();
            List<int> recorridos = new List<int>();
            List<int> indices = new List<int>();
            Celdas aux = new Celdas("");
            for (int i = 0; i < columnas.Count; i++)
            {
                if (columnas[i].letra == letra)
                {
                    for (int j = 0; j < columnas[i].conjuntos.Count; j++)
                    {
                        Conjunto current = columnas[i].conjuntos[j];
                        if (celda.posiciones.Contains(current.index))
                        {
                            if (current.posiciones.Count > 0)
                            {
                                foreach (int item in current.posiciones)
                                {
                                    referencias.Add(item);
                                }
                            }
                            else
                            {
                                Conjunto epsilon = columnas[i].conjuntos[1];
                                foreach (int item in epsilon.posiciones)
                                {
                                    Console.WriteLine("estado:" + i +" eps: " + item);
                                    celda.posiciones.Add(item);
                                }
                            }
                        }
                    }
                }
            }
            aux.referencias = referencias;
            return aux;
        }

        static Clausura obtenerClausura(int valor, List<Clausura> clausuras)
        {
            foreach (Clausura clausura in clausuras)
            {
                if (clausura.estado == valor) return clausura;
            }
            return null;
        }

        static string ultimaLetra(List<Tabla> matriz)
        {
            string letra = "";
            for (int i = 0; i < matriz.Count; i++)
            {
                Tabla tabla = matriz[i];
                letra = tabla.celdas[0].id;
            }
            return letra;
        }

        static Celdas obtenerCelda(string letra, List<Tabla> matriz)
        {
            for (int i = 0; i < matriz.Count; i++)
            {
                Tabla tabla = matriz[i];
                for (int j = 0; j < tabla.celdas.Count; j++)
                {
                    if (tabla.celdas[j].id == letra) return tabla.celdas[j];
                }
            }
            return null;
        }

        static int getPos(string letra, string letras)
        {
            for (int i = 0; i < letras.Length; i++)
            {
                string l = letras[i].ToString();
                if (l == letra) return i + 1;
            }
            return -1;
        }

        static void generarAutomata(List<Columna> columnas, List<Clausura> clausuras, List<string> letras)
        {
            string encabezado = "abcdefghijklmnopqrstuvwxyz";
            encabezado = encabezado.ToUpper();
            int letra_apuntador = 0;
            Celdas celda_actual = new Celdas(encabezado[letra_apuntador].ToString());
            celda_actual.referencias.Add(clausuras[0].estado);
            celda_actual.posiciones = clausuras[0].posiciones;
            List<Tabla> matriz = new List<Tabla>();
            bool trabajar = true;
            letra_apuntador++;
            Console.WriteLine("Antes de trabajar");
            while (trabajar && letra_apuntador < 6)
            {
                Tabla tabla = new Tabla();
                if (letra_apuntador == 1)
                {
                    tabla.celdas.Add(celda_actual);
                }
                else
                {
                    string ultima_letra = ultimaLetra(matriz);
                    int pos = getPos(ultima_letra, encabezado);
                    if (pos != -1)
                    {
                        celda_actual = obtenerCelda(encabezado[pos].ToString(), matriz);
                        tabla.celdas.Add(celda_actual);
                    }
                }

                foreach (string letra in letras)
                {
                    Console.WriteLine("usando letra: " + letra);
                    Celdas celda2 = obtenerCelda(letra, celda_actual, columnas);
                    celda2.id = encabezado[letra_apuntador].ToString();
                    Console.WriteLine("celda: " + celda2.id);
                    List<int> elementos = new List<int>();
                    List<Clausura> cls = new List<Clausura>();
                    Console.WriteLine("Tamaño de referencias: " + celda2.referencias.Count);
                    foreach (int item in celda2.referencias)
                    {
                        Clausura cl = obtenerClausura(item, clausuras);
                        cls.Add(cl);
                    }
                    foreach (Clausura cl in cls)
                    {
                        foreach (int item in cl.posiciones)
                        {
                            elementos.Add(item);
                        }
                    }

                    //Llenamos las posiciones de nuestra celda lol
                    //elementos = elementos.Distinct().ToList();
                    celda2.posiciones = elementos;
                    //imprimiremos las clausuras de nuestra celda

                    celda_actual = celda2;
                    letra_apuntador++;
                    tabla.celdas.Add(celda_actual);
                }
                matriz.Add(tabla);
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
            printByLetter(columnas, "e");
            generarAutomata(columnas, clausuras, grafo.letras);
            Console.ReadKey();
        }
    }
}
