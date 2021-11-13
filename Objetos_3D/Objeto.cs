using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;


namespace Objetos_3D
{
    class Objeto
    {
        public Dictionary<string, Face> ListaFaces { get; set; }
        public float[] origenObjeto;

        public Objeto()
        {
            this.ListaFaces = new Dictionary<string, Face>();
            this.origenObjeto = new float[3] { 0, 0, 0 };
        }

        public Objeto(string name, Face objeto)
        {
            this.ListaFaces = new Dictionary<string, Face>();
            ListaFaces.Add(name, objeto);   
        }

        public Objeto(Dictionary<string, Face> listaFaces)
        {
            this.ListaFaces = listaFaces;
            this.origenObjeto = new float[3] { 0, 0, 0 };
        }

        public void dibujar()
        {
            foreach (KeyValuePair<string, Face> faces in ListaFaces)
                faces.Value.dibujar(origenObjeto);
        }

        public void agregarFace(string nombre, Face face)
        {
            ListaFaces.Add(nombre, face);
        }

        public void eliminarFace(string nombre)
        {
            this.ListaFaces.Remove(nombre);
        }

        public Face getFace(string nombre)
        {
            foreach (var face in ListaFaces)
            {
                if (face.Key == nombre)
                    return face.Value;
            }
            return null;
        }

        public void establecerorigen(float[] origen)
        {
            this.origenObjeto = origen;
        }

        public void rotar(int angulo, Vector3d eje)
        {
            foreach (var face in ListaFaces)
            {
                face.Value.rotar(angulo, eje);
            }
        }

        public void trasladar(Vector3d centro)
        {
            
            foreach (var face in ListaFaces)
            {
                face.Value.trasladar(centro);
            }
        }

        public void escalar(Vector3d dim)
        {
            foreach (var face in ListaFaces)
            {
                face.Value.escalar(dim);
            }
        }

        public void escalar(float dim)
        {
            foreach (var face in ListaFaces)
            {
                face.Value.escalar(dim);
            }
        }
    }
}
