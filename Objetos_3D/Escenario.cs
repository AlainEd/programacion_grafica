using System;
using System.Collections.Generic;


namespace Objetos_3D
{
    class Escenario
    {
        public Dictionary<string, Objeto> ListaObj { get; set; }

        public Escenario()
        {
            this.ListaObj = new Dictionary<string, Objeto>();
        }

        public void dibujar()
        {
            if (ListaObj != null)
            {
                foreach (var objeto in ListaObj)
                {
                    objeto.Value.dibujar();
                }
            }
        }

        public void agregarObjeto(string nombre, Objeto objeto)
        {
            this.ListaObj.Add(nombre, objeto);
        }

        public void eliminarObjeto(string nombre)
        {
            this.ListaObj.Remove(nombre);
        }


    }
}