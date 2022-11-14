using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionGrafo
{
    public class Matriz
    {
        public List<List<int>> valores;
        public Matriz()
        {
            this.valores = new List<List<int>>();
        }
        public Matriz(List<List<int>> param)
        {
            this.valores = param;
        }
        public void printMatriz()
        {
            for (int i = 0; i < valores.Count; i++)
            {
                foreach (int val in valores[i])
                {
                    Console.Write("("+ val +")");
                }
            }
        }
    }
}
