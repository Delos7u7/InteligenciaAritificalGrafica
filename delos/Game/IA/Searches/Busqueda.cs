using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delos.Game.IA.Searches
{
    public class Busqueda
    {
        public Busqueda() { }

        public void PrimeroEnAnchura(Vertice origen, Vertice destino)
        {
            Nodo ArbolSolucion = new Nodo();
            Queue<Nodo> Frontera = new Queue<Nodo>();
            Nodo NodoOrigen = new Nodo();
            NodoOrigen.vertice = origen;
            ArbolSolucion.AgregarHijo(NodoOrigen);
            Frontera.Enqueue(NodoOrigen);
            while (Frontera.Count > 0)
            {
                Nodo NodoActual = Frontera.Dequeue();
                Vertice V = NodoActual.vertice;
                if (V.visitado == false)
                {
                    V.visitado = true;
                }
                if (V.Nombre == destino.Nombre)
                {
                    CalcularRuta(NodoActual);
                }
                foreach (Vertice w in V.adyacentes)
                {
                    if (w.visitado == false)
                    {
                        w.visitado = true;
                        Nodo NodoAdyacente = new Nodo();
                        NodoAdyacente.vertice = w;
                        NodoActual.AgregarHijo(NodoAdyacente);
                        Frontera.Enqueue(NodoAdyacente);
                    }
                }
            }

        }

        public void PrimeroEnProfundidad(Vertice Origen, Vertice Destino)
        {
            Nodo ArbolSolucion = new Nodo();
            Stack<Nodo> Frontera = new Stack<Nodo>();
            Nodo NodoOrigen = new Nodo();
            NodoOrigen.vertice = Origen;
            ArbolSolucion.AgregarHijo(NodoOrigen);
            Frontera.Push(NodoOrigen);
            while (Frontera.Count > 0)
            {
                Nodo NodoActual = Frontera.Pop();
                Vertice v = NodoActual.vertice;
                if (!v.visitado)
                {
                    v.visitado = true;
                }
                if (v.Nombre == Destino.Nombre)
                {
                    CalcularRuta(NodoActual);
                    return;
                }
                foreach (Vertice w in v.adyacentes)
                {
                    if (!w.visitado)
                    {
                        w.visitado = true;
                        Nodo NodoAdyacente = new Nodo();
                        NodoAdyacente.vertice = w;
                        NodoActual.AgregarHijo(NodoAdyacente);
                        Frontera.Push(NodoAdyacente);
                    }
                }
            }
        }

        public void CalcularRuta(Nodo nodo)
        { 
            Stack<Nodo> ruta = new Stack<Nodo>();
            while (nodo.Padre != null)
            {
                ruta.Push(nodo);
                nodo = nodo.Padre;
            }
            while (ruta.Count > 0)
            {
                Nodo n = ruta.Pop();
                Trace.Write(n.vertice.Nombre + "->");
            }
        }

    }
}
