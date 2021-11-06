using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;


namespace Objetos_3D
{
    class Objeto
    {
        public Dictionary<string, Face> ListaFaces;
        public Vector3d origenObjeto;
        public float anchoObjeto;
        public float altoObjeto;
        public float largoObjeto;


        public Objeto()
        {
            this.ListaFaces = new Dictionary<string, Face>();
            this.origenObjeto = new Vector3d(0, 0, 0);
            this.altoObjeto = this.anchoObjeto = this.largoObjeto = 1;
        }

        public Objeto(string name, Face objeto)
        {
            this.ListaFaces = new Dictionary<string, Face>();
            ListaFaces.Add(name, objeto);   
        }

        public Objeto(Dictionary<string, Face> listaFaces)
        {
            this.ListaFaces = listaFaces;
            this.origenObjeto = new Vector3d(0, 0, 0);
            this.altoObjeto = this.anchoObjeto = this.largoObjeto = 1;
        }

        public void dibujar()
        {
            
            foreach (KeyValuePair<string, Face> faces in ListaFaces)
            {
                
                faces.Value.dibujar(anchoObjeto, altoObjeto, largoObjeto, origenObjeto);
                
            }
       
        }

        public void agregarFace(string nombre, Face face)
        {
            ListaFaces.Add(nombre, face);
        }


        public void eliminarFace(string nombre)
        {
            this.ListaFaces.Remove(nombre);
        }

        public void dimensionarObjeto(float ancho, float alto, float largo)
        {
            this.anchoObjeto = ancho;
            this.altoObjeto = alto;
            this.largoObjeto = largo;
        }

        public void establecerOrigen(Vector3d origen)
        {
            this.origenObjeto = origen;
        }

        public void rotar(float grado, float x, float y, float z)
        {
            foreach (var cara in ListaFaces)
            {
                cara.Value.rotar(grado, x, y, z);
            }
        }

        public void trasladar(float x, float y, float z)
        {
            foreach (var cara in ListaFaces)
            {
                cara.Value.trasladar(x, y, z);
            }
        }

        public void escalar(float x, float y, float z)
        {
            foreach (var cara in ListaFaces)
            {
                cara.Value.escalar(x, y, z);
            }
        }

    }
}
