using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionGrafo
{
    public class Conjunto
    {
        public int index;
        public List<int> posiciones;
        public Conjunto(int index)
        {
            this.index = index;
            this.posiciones = new List<int>();
        }
    }
}
