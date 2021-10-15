using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos_3D
{
    class Casa
    {
        private double largo, alto, ancho;
        private Vector3 centro;

        public Casa(Vector3 centro, double largo, double alto, double ancho)
        {
            this.centro = centro;
            this.largo = largo;
            this.alto = alto;
            this.ancho = ancho;
        }

        public void dibujar()
        {
            PrimitiveType primitiveType = PrimitiveType.LineLoop;


            //drawPuerta(PrimitiveType.Quads, Color4.Brown);
            //drawParteDelantera(PrimitiveType.Quads, Color4.Pink);
            
            //drawLadoIzq(PrimitiveType.Quads, Color4.Pink);
            //drawParteTrasera(PrimitiveType.Quads, Color4.Pink);
            //drawLadoDer(PrimitiveType.Quads, Color4.Pink);

            //drawTechoDer(PrimitiveType.Quads, Color4.Orange);
            //drawTechoIzq(PrimitiveType.Quads, Color4.Orange);


            drawFachada(PrimitiveType.LineLoop, Color4.Pink, 0, true);
            drawLados(PrimitiveType.LineLoop, Color4.Pink, ancho, 0, largo, true);
            drawFachada(PrimitiveType.LineLoop, Color4.Pink, largo, false);
            drawLados(PrimitiveType.LineLoop, Color4.Pink, 0, largo, 0, true);

            drawTechoDer(PrimitiveType.LineLoop, Color4.Orange);
            drawTechoIzq(PrimitiveType.LineLoop, Color4.Orange);



            /*//cierre techo delantero
            GL.Begin(primitiveType);
            GL.Color4(Color4.Blue);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z - largo);
            GL.Vertex3(centro.X, centro.Y, centro.Z - largo);
            GL.End();

            //cierre techo trasero
            GL.Begin(primitiveType);
            GL.Color4(Color4.Blue);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z);
            GL.Vertex3(centro.X, centro.Y, centro.Z);
            GL.End();

            

            //cara der
            GL.Begin(primitiveType);
            GL.Color4(Color4.Blue);
            GL.Vertex3(centro.X, centro.Y, centro.Z - largo);
            GL.Vertex3(centro.X, centro.Y - (alto / 2.5) * 2, centro.Z - largo);
            GL.Vertex3(centro.X, centro.Y - (alto / 2.5) * 2, centro.Z);
            GL.Vertex3(centro.X, centro.Y, centro.Z);
            GL.End();

            //cierre piso del
            GL.Begin(primitiveType);
            GL.Color4(Color4.Blue);
            GL.Vertex3(centro.X - ancho, centro.Y - (alto / 2.5) * 2, centro.Z);
            GL.Vertex3(centro.X, centro.Y - (alto / 2.5) * 2, centro.Z);
            GL.End();

            //cierre piso trasero
            GL.Begin(primitiveType);
            GL.Color4(Color4.Blue);
            GL.Vertex3(centro.X - ancho, centro.Y - (alto / 2.5) * 2, centro.Z - largo);
            GL.Vertex3(centro.X, centro.Y - (alto / 2.5) * 2, centro.Z - largo);
            GL.End();*/











            //Parte delantera de la casa

            /*GL.Begin(primitiveType);
            GL.Color4(Color4.Orange);
            GL.Vertex3(centro.X, centro.Y, centro.Z); 
            GL.Vertex3(centro.X, centro.Y - (alto/2.5) * 2, centro.Z);
            GL.Vertex3(centro.X - ancho, centro.Y - (alto/2.5) * 2, centro.Z);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z);
            GL.End();

            //puerta en la parte delantera
            GL.Begin(primitiveType);
            GL.Color4(Color4.Orange);
            GL.Vertex3(centro.X - (ancho / 4) * 3, centro.Y - (alto / 2.5) * 2, centro.Z);
            GL.Vertex3(centro.X - (ancho / 4) * 3, centro.Z - (alto / 2.5), centro.Z);
            GL.Vertex3(centro.X - (ancho / 4), centro.Z - (alto / 2.5), centro.Z);
            GL.Vertex3(centro.X - (ancho / 4), centro.Y - (alto / 2.5) * 2, centro.Z);
            GL.End();

            //parte de atras de la casa

            GL.Begin(primitiveType);
            GL.Color4(Color4.Orange);
            GL.Vertex3(centro.X, centro.Y, centro.Z - largo); 
            GL.Vertex3(centro.X, centro.Y - (alto/2.5) * 2, centro.Z - largo);
            GL.Vertex3(centro.X - ancho, centro.Y - (alto/2.5) * 2, centro.Z - largo);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z - largo);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z - largo);
            GL.End();

            //union techo arriba
            GL.Begin(primitiveType);
            GL.Color4(Color4.Orange);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z - largo);
            GL.End();

            //union techo izq
            GL.Begin(primitiveType);
            GL.Color4(Color4.Orange);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z - largo);
            GL.End();

            //union techo der
            GL.Begin(primitiveType);
            GL.Color4(Color4.Orange);
            GL.Vertex3(centro.X, centro.Y, centro.Z);
            GL.Vertex3(centro.X, centro.Y, centro.Z - largo);
            GL.End();

            //union piso der
            GL.Begin(primitiveType);
            GL.Color4(Color4.Orange);
            GL.Vertex3(centro.X, centro.Y - (alto / 2.5) * 2, centro.Z);
            GL.Vertex3(centro.X, centro.Y - (alto / 2.5) * 2, centro.Z - largo);
            GL.End();

            //union piso izq
            GL.Begin(primitiveType);
            GL.Color4(Color4.Orange);
            GL.Vertex3(centro.X - ancho, centro.Y - (alto / 2.5) * 2, centro.Z);
            GL.Vertex3(centro.X - ancho, centro.Y - (alto / 2.5) * 2, centro.Z - largo);
            GL.End();*/
        }

        private void drawTechoDer(PrimitiveType primitiveType, Color4 color)
        {
            GL.Begin(primitiveType);
            GL.Color4(color);
           
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z - largo);
            GL.Vertex3(centro.X, centro.Y, centro.Z - largo);
            GL.Vertex3(centro.X, centro.Y, centro.Z);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z);
            GL.End();
        }

        private void drawTechoIzq(PrimitiveType primitiveType, Color4 color)
        {
            GL.Begin(primitiveType);
            GL.Color4(color);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z - largo);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z - largo);
            GL.End();
        }

        private void drawLados(PrimitiveType primitiveType, Color4 color, double posicion, 
            double der, double izq, bool ventana)
        {

            GL.Begin(primitiveType);
            GL.Color4(color);
            GL.Vertex3(centro.X - posicion, centro.Y, centro.Z - der);
            GL.Vertex3(centro.X - posicion, centro.Y - (alto / 2.5) * 2, centro.Z - der);
            GL.Vertex3(centro.X - posicion, centro.Y - (alto / 2.5) * 2, centro.Z - izq);
            GL.Vertex3(centro.X - posicion, centro.Y, centro.Z - izq);
            GL.End();

            if (ventana)
            {
                GL.Begin(primitiveType);
                GL.Color4(color);
                GL.Vertex3(centro.X - posicion, centro.Y - alto / 4, centro.Z - largo / 4);
                GL.Vertex3(centro.X - posicion, centro.Y - alto / 4, centro.Z - 3 * largo / 4);
                GL.Vertex3(centro.X - posicion, centro.Y - alto / 1.8, centro.Z - 3 * largo / 4);
                GL.Vertex3(centro.X - posicion, centro.Y - alto / 1.8, centro.Z - largo / 4);
                GL.End();
            }
        }


        private void drawFachada(PrimitiveType primitiveType, Color4 color, double profundidad, bool puerta)
        {

            GL.Begin(primitiveType);
            GL.Color4(color);
            GL.Vertex3(centro.X, centro.Y, centro.Z - profundidad); 
            GL.Vertex3(centro.X, centro.Y - (alto/2.5) * 2, centro.Z - profundidad);

            if (puerta)
            {
                GL.Vertex3(centro.X - ancho / 4, centro.Y - 2 * alto / 2.5, centro.Z - profundidad);
                GL.Vertex3(centro.X - ancho / 4, centro.Y - alto / 4, centro.Z - profundidad);
                GL.Vertex3(centro.X - 3 * ancho / 4, centro.Y - (alto / 4), centro.Z - profundidad);
                GL.Vertex3(centro.X - 3 * ancho / 4, centro.Y - 2 * alto / 2.5, centro.Z - profundidad);
            }

            GL.Vertex3(centro.X - ancho, centro.Y - (alto/2.5) * 2, centro.Z - profundidad);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z - profundidad);
            GL.End();

            //triangulo 

            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(Color4.Red);
            GL.Vertex3(centro.X, centro.Y, centro.Z - profundidad);
            GL.Vertex3(centro.X - ancho, centro.Y, centro.Z - profundidad);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z - profundidad);
            GL.End();
        }


    }
}
