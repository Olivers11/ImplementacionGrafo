using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionGrafo
{
    public class Clausura
    {
        public int estado;
        public List<int> posiciones;
        public Clausura(int estado)
        {
            this.estado = estado;
            this.posiciones = new List<int>();
        }   
    }
}
