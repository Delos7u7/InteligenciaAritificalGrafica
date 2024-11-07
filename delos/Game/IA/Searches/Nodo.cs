using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace delos.Game.IA.Searches
{
    public class Nodo
    {
        public Nodo Padre = null;
        public Vertice vertice = null;

        List<Nodo> hijos;
        public Nodo() 
        {
            hijos = new List<Nodo>();
        }

        public void AgregarHijo(Nodo hijo)
        {
            hijos.Add(hijo);
            hijo.Padre = this;
        }
    }
}
