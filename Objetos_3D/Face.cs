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
        public float[] Color { get; set; }

        public float[] origenFace { get; set; }


        public Face()
        {

        }

        public Face(Dictionary<string, float[]> listaVert, float[] color)
        {
            this.ListaVert = listaVert;
            this.Color = color;
            this.origenFace = new float[] { 0, 0, 0 };
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

        public void setOrigen(float[] origen)
        {
            this.origenFace = origen;
        }

        public void dibujar()
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(Color[0], Color[1], Color[2]);
            foreach (var vertices in ListaVert)
            {
                GL.Vertex3(vertices.Value[0] + origenFace[0],
                           vertices.Value[1] + origenFace[1],
                           vertices.Value[2] + origenFace[2]);
            }
            GL.End();
        }

        public void rotar(float angulo, Vector3d eje)
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

        //escalar en las 3 dimensiones
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

        //escalar en porcentaje
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
    }
}
