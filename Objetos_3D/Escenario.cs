using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.IO;

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
                foreach (var objeto in ListaObj)      
                    objeto.Value.dibujar();                  
        }

        public void agregarObjeto(string nombre, Objeto objeto)
        {
            this.ListaObj.Add(nombre, objeto);
        }

        public void agregarObjeto(string nombre, string archivo)
        {
            this.ListaObj.Add(nombre, JsonToObjeto(archivo));
        }

        public void eliminarObjeto(string nombre)
        {
            this.ListaObj.Remove(nombre);
        }
        public Objeto getObjeto(string nombre)
        {
            foreach (var obj in ListaObj)
            {
                if (obj.Key == nombre)
                    return obj.Value;
            }
            return null;
        }

        private Objeto JsonToObjeto(string archivo)
        {
            archivo = File.ReadAllText(archivo);
            return JsonConvert.DeserializeObject<Objeto>(archivo);
        }

    }
}