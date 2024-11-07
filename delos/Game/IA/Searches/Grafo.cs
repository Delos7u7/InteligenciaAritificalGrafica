using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delos.Game.IA.Searches
{
    public class Grafo
    {
        List<Vertice> Vertices;
        string Nombre = "";
        public Grafo(string nombre) 
        {
            Nombre = nombre;
            Vertices = new List<Vertice>();    
        }


        public void AgregarVertice(Vertice v)
        {
            Vertices.Add(v);
        }

        public void MostrarVertices() 
        {
            Trace.WriteLine("Grafo: "+Nombre);
            foreach (Vertice item in Vertices) 
            {
                item.MostrarAdyacentes();   
            }
        }

        public Vertice Buscar(string nombre)
        {
            Vertice hallado = null;

            foreach (Vertice item in Vertices)
            {
                if (item.Nombre==nombre)
                {
                    hallado = item;
                    break;
                }
            }
            return hallado;
        }
    }
}
