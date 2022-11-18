using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionGrafo
{
    public class Celdas
    {
        public string id;
        public List<int> referencias;
        public List<int> posiciones;
        public Celdas(string id)
        {
            this.id = id;
            this.referencias = new List<int>();
            this.posiciones = new List<int>();
        }
    }
    public class Tabla
    {
        public List<Celdas> celdas;
        public Tabla()
        {
            this.celdas = new List<Celdas>();
        }
    }
}
