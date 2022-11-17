using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImplementacionGrafo;

namespace implementacionGrafo
{
    public class Vertice
    {
        public int valor;
        public List<Origen> origenes;
        public List<Vertice> Aristas;
        public bool cheked;
        public Vertice(int valor)
        {
            this.valor = valor;
            this.cheked = false;
            this.origenes = new List<Origen>();
            this.Aristas = new List<Vertice>();
        }

        public bool isChecked()
        {
            int cont = 0;
            for(int i = 0; i < this.Aristas.Count; i++)
            {
                if (this.Aristas[i].cheked) cont++;
            }
            return cont == this.Aristas.Count;
        }
        public void checkearArista(int pos)
        {
            for(int i = 0; i < this.Aristas.Count; i++)
            {
                this.Aristas[i].cheked = true;
            }
        }
    }
}

