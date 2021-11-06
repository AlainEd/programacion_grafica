using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;


namespace Objetos_3D
{
    class Escenario
    {
        public Dictionary<string, Objeto> ListaObj;

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

        public void rotacion(float grado, float x, float y, float z)
        {
            foreach (var obj in ListaObj)
            {
                obj.Value.rotar(grado, x, y, z);
            }
        }

        public void traslacion(float x, float y, float z)
        {
            foreach (var obj in ListaObj)
            {
                obj.Value.trasladar(x, y, z);
            }
        }

        public void escalacion(float x, float y, float z)
        {
            foreach (var obj in ListaObj)
            {
                obj.Value.escalar(x, y, z);
            }
        }

    }
}