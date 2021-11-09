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

        public Dictionary<string, float[]> ListaVert { get; set; }
        public float[] Color;

        public Vector3d origenFace;
        //public double anchoFace;
        //public double altoFace;
        //public double largoFace;


        public Face()
        {
            
        }

        public Face(Dictionary<string, float[]> listaVert, float[] color)
        {
            this.ListaVert = listaVert;
            this.Color = color;
            this.origenFace = new Vector3d(0, 0, 0);
            //this.altoFace = this.anchoFace = this.largoFace = 1;
        }



        public float[] getVertice(string nombre)
        {
            foreach (var vert in ListaVert)
            {
                if (vert.Key == nombre)
                    return vert.Value;
            }
            return null;
        }

        public void setVertice(string nombre, float[] vertice)
        {
            foreach (var vert in ListaVert)
            {
                if (vert.Key == nombre)
                {
                    for (int i = 0; i < vertice.Length; i++)
                    {
                        vert.Value.SetValue(vertice[i], i);
                    }
                }
            }
        }

        public void dibujar(/*float ancho, float alto, float largo, */Vector3d origen)
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(Color[0], Color[1], Color[2]);
            foreach (var vertices in ListaVert)
            {
                GL.Vertex3(vertices.Value[0] + origen.X, //* ancho + origen.X,
                           vertices.Value[1] + origen.Y, //* alto + origen.Y,
                           vertices.Value[2] + origen.Z); //* largo + origen.Z);
            }
            GL.End();
        }

        public void rotar(int angulo, Vector3d eje)
        {
            Matriz Rx = new Matriz();
            Matriz Pp = new Matriz();

            if (eje.X == 1)
                Rx.rotacionX(angulo);
            if (eje.Y == 1)
                Rx.rotacionY(angulo);
            if (eje.Z == 1)
                Rx.rotacionZ(angulo);

            foreach (var vert in ListaVert)
            {
                Matriz P = new Matriz(vert.Value);
                Pp = new Matriz(P.nroFil, Rx.nroCol);
                Pp = Pp.multiplicarMatrices(P, Rx);
                float[] vertices = new float[3];
                for (int i = 0; i < Rx.nroCol - 1; i++)
                {
                    vertices[i] = (float)Pp.getCelda(0, i);
                }
                setVertice(vert.Key, vertices);
            }

        }

        public void trasladar(Vector3d centro)
        {
            Matriz Pp = new Matriz();
            Matriz T = new Matriz();
            T.traslacion(centro.X, centro.Y, centro.Z);
            foreach (var vert in ListaVert)
            {
                Matriz P = new Matriz(vert.Value);
                Pp = new Matriz(P.nroFil, T.nroCol);
                Pp = Pp.multiplicarMatrices(P, T);
                float[] vertices = new float[3];
                for (int i = 0; i < T.nroCol - 1; i++)
                {
                    vertices[i] = (float)Pp.getCelda(0, i);
                }
                setVertice(vert.Key, vertices);
            }
        }

        public void escalar(Vector3d dim)
        {
            Matriz Pp = new Matriz();
            Matriz S = new Matriz();
            S.escalacion(dim.X, dim.Y, dim.Z);
            foreach (var vert in ListaVert)
            {
                Matriz P = new Matriz(vert.Value);
                Pp = new Matriz(P.nroFil, S.nroCol);
                Pp = Pp.multiplicarMatrices(P, S);
                float[] vertices = new float[3];
                for (int i = 0; i < S.nroCol - 1; i++)
                {
                    vertices[i] = (float)Pp.getCelda(0, i);
                }
                setVertice(vert.Key, vertices);
            }
        }

        public void escalar(float dim)
        {
            Matriz Pp = new Matriz();
            Matriz S = new Matriz();
            S.escalacion(dim, dim, dim);
            foreach (var vert in ListaVert)
            {
                Matriz P = new Matriz(vert.Value);
                Pp = new Matriz(P.nroFil, S.nroCol);
                Pp = Pp.multiplicarMatrices(P, S);
                float[] vertices = new float[3];
                for (int i = 0; i < S.nroCol - 1; i++)
                {
                    vertices[i] = (float)Pp.getCelda(0, i);
                }
                setVertice(vert.Key, vertices);
            }
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
