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
        public Dictionary<string, Objeto> ListaObj { get; set; }

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
            int i = 1;
            string n = nombre;
            while (existeLlave(n))
            {
                n = nombre;
                n += i;
                i++;
            }
            this.ListaObj.Add(n, JsonToObjeto(archivo));
        }

        private bool existeLlave(string nombre)
        {
            foreach (var obj in ListaObj.Keys)
            {
                if (obj == nombre)
                    return true;
            }
            return false;
        }

        public string getLastKey()
        {
            string key = "";
            foreach (var obj in ListaObj.Keys)
            {
                key = obj;
            }
            return key;
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

        public void rotar(float angulo, Vector3d eje)
        {
            foreach (var face in ListaObj)
            {
                face.Value.rotar(angulo, eje);
            }
        }

        public void trasladar(Vector3d centro)
        {

            foreach (var face in ListaObj)
            {
                face.Value.trasladar(centro);
            }
        }

        public void escalar(Vector3d dim)
        {
            foreach (var face in ListaObj)
            {
                face.Value.escalar(dim);
            }
        }

        public void escalar(float dim)
        {
            foreach (var face in ListaObj)
            {
                face.Value.escalar(dim);
            }
        }
    }
}
