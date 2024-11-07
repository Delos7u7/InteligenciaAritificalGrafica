using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delos.Game.IA.Searches
{
    public class Vertice
    {
        public bool visitado = false;
        public List<Vertice> adyacentes;
        public string Nombre = "";
        public Vertice(string nombre) 
        {
            Nombre = nombre;    
            adyacentes = new List<Vertice>();
        }

        public void AgregarAdyacente (Vertice v)
        {
            adyacentes.Add(v);  
        }

        public void MostrarAdyacentes()
        {
            Trace.WriteLine(Nombre);
            foreach (Vertice item in adyacentes)
            {
                Trace.WriteLine(" - "+item.Nombre);
            }
        }
    }
}
