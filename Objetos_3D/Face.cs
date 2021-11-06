using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Objetos_3D
{
    class Face
    {

        public Dictionary<string, float[]> ListaVert;
        public float[] Color;

        public Vector3d origenFace;
        public float anchoFace;
        public float altoFace;
        public float largoFace;


        public Face()
        {
            
        }

        public Face(Dictionary<string, float[]> listaVert, float[] color)
        {
            this.ListaVert = listaVert;
            this.Color = color;
            this.origenFace = new Vector3d(0, 0, 0);
            this.altoFace = this.anchoFace = this.largoFace = 1;
        }


        public void dibujar(float ancho, float alto, float largo, Vector3d origen)
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(Color[0], Color[1], Color[2]);
            foreach (var vertices in ListaVert)
            {
                GL.Vertex3(vertices.Value[0] * ancho + origen.X,
                           vertices.Value[1] * alto + origen.Y,
                           vertices.Value[2] * largo + origen.Z);
            }
            GL.End();
        }

        public void rotar(float grado, float x, float y, float z)
        {
            //GL.PushMatrix();
            GL.Rotate(grado, x, y, z);
            //GL.PopMatrix();
        }

        public void trasladar(float x, float y, float z)
        {
            GL.Translate(x, y, z);
        }

        public void escalar(float x, float y, float z)
        {
            GL.Scale(x, y, z);
        }

        /*private void techoDerecho(PrimitiveType primitiveType, Color4 color)
        {
            GL.Begin(primitiveType);
            GL.Color4(color);

            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z - largo);
            GL.Vertex3(centro.X, centro.Y, centro.Z - largo);
            GL.Vertex3(centro.X, centro.Y, centro.Z);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z);
            GL.End();
        }

        private void techoIzquierdo(PrimitiveType primitiveType, Color4 color)
        {
            GL.Begin(primitiveType);
            GL.Color4(color);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z - largo);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z - largo);
            GL.End();
        }

        private void paredDerecha(PrimitiveType primitiveType, Color4 color, bool ventana)
        {

            GL.Begin(primitiveType);
            GL.Color4(color);
            GL.Vertex3(centro.X, centro.Y, centro.Z - largo);
            GL.Vertex3(centro.X, centro.Y - (alto / 2.5) * 2, centro.Z - largo);
            GL.Vertex3(centro.X, centro.Y - (alto / 2.5) * 2, centro.Z);
            GL.Vertex3(centro.X, centro.Y, centro.Z);
            GL.End();

            if (ventana)
            {
                GL.Begin(primitiveType);
                GL.Color4(Color4.Transparent);
                GL.Vertex3(centro.X, centro.Y - alto / 4, centro.Z - largo / 4);
                GL.Vertex3(centro.X, centro.Y - alto / 4, centro.Z - 3 * largo / 4);
                GL.Vertex3(centro.X, centro.Y - alto / 1.8, centro.Z - 3 * largo / 4);
                GL.Vertex3(centro.X, centro.Y - alto / 1.8, centro.Z - largo / 4);
                GL.End();
            }
        }

        private void paredIzquierda(PrimitiveType primitiveType, Color4 color, bool ventana)
        {

            GL.Begin(primitiveType);
            GL.Color4(color);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z);
            GL.Vertex3(centro.X - ancho, centro.Y - (alto / 2.5) * 2, centro.Z);
            GL.Vertex3(centro.X - ancho, centro.Y - (alto / 2.5) * 2, centro.Z - largo);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z - largo);
            GL.End();

            if (ventana)
            {
                GL.Begin(primitiveType);
                GL.Color4(Color4.Transparent);
                GL.Vertex3(centro.X - ancho, centro.Y - alto / 4, centro.Z - largo / 4);
                GL.Vertex3(centro.X - ancho, centro.Y - alto / 4, centro.Z - 3 * largo / 4);
                GL.Vertex3(centro.X - ancho, centro.Y - alto / 1.8, centro.Z - 3 * largo / 4);
                GL.Vertex3(centro.X - ancho, centro.Y - alto / 1.8, centro.Z - largo / 4);
                GL.End();
            }
        }


        private void paredDelantera(PrimitiveType primitiveType, Color4 color, bool puerta)
        {

            GL.Begin(primitiveType);
            GL.Color4(color);
            GL.Vertex3(centro.X, centro.Y, centro.Z);
            GL.Vertex3(centro.X, centro.Y - (alto / 2.5) * 2, centro.Z);
            if (puerta)
            {
                GL.Vertex3(centro.X - ancho / 4, centro.Y - 2 * alto / 2.5, centro.Z);
                GL.Vertex3(centro.X - ancho / 4, centro.Y - alto / 4, centro.Z);
                GL.Vertex3(centro.X - 3 * ancho / 4, centro.Y - (alto / 4), centro.Z);
                GL.Vertex3(centro.X - 3 * ancho / 4, centro.Y - 2 * alto / 2.5, centro.Z);
            }
            GL.Vertex3(centro.X - ancho, centro.Y - (alto / 2.5) * 2, centro.Z);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z);
            GL.End();

        }

        private void paredTrasera(PrimitiveType primitiveType, Color4 color, bool puerta)
        {

            GL.Begin(primitiveType);
            GL.Color4(color);
            GL.Vertex3(centro.X, centro.Y, centro.Z - largo);
            GL.Vertex3(centro.X, centro.Y - (alto / 2.5) * 2, centro.Z - largo);
            if (puerta)
            {
                GL.Vertex3(centro.X - ancho / 4, centro.Y - 2 * alto / 2.5, centro.Z - largo);
                GL.Vertex3(centro.X - ancho / 4, centro.Y - alto / 4, centro.Z - largo);
                GL.Vertex3(centro.X - 3 * ancho / 4, centro.Y - (alto / 4), centro.Z - largo);
                GL.Vertex3(centro.X - 3 * ancho / 4, centro.Y - 2 * alto / 2.5, centro.Z - largo);
            }
            GL.Vertex3(centro.X - ancho, centro.Y - (alto / 2.5) * 2, centro.Z - largo);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z - largo);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z - largo);
            GL.End();

        }*/
    }
}
