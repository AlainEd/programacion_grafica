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

        public string nombre { get; set; }
        public List<float> color { get; set; }
        public List<List<double>> listVert { get; set; }

        public Face(List<List<double>> listVert)
        {
            this.listVert = listVert;
        }

        public void dibujar(List<double> centroMasa)
        {

            double x = centroMasa[0];
            double y = centroMasa[1];
            double z = centroMasa[2];

            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(color[0], color[1], color[2]);
            foreach (List<double> vertices in listVert)
            {
                GL.Vertex3(vertices[0] + x, vertices[1] + y, vertices[2] + z);
            }
            GL.End();
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
