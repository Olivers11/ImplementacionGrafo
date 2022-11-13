using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace implementacionGrafo
{
    public class Vertice
    {
        public int valor;
        public List<string> origen;
        public List<Vertice> Aristas;
        public bool _checked;
        public Vertice(int valor)
        {
            this.valor = valor;
            this._checked = false;
            this.origen = new List<string>();
            this.Aristas = new List<Vertice>();
        }
    }
}

