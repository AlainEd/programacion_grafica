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
            PrimitiveType linea = PrimitiveType.LineLoop;
            PrimitiveType rectangulo = PrimitiveType.Quads;

            
            /*  Dibujado de la casa con formas
            drawFachada(rectangulo, Color4.Aqua, 0, true);
            drawLados(  rectangulo, Color4.Aqua, ancho, 0, largo, true);
            drawFachada(rectangulo, Color4.Aqua, largo, false);
            drawLados(  rectangulo, Color4.Aqua, 0, largo, 0, true);

            drawTechoDer(rectangulo, Color4.Red);
            drawTechoIzq(rectangulo, Color4.Red);
            */


            //Dibujado de la casa solo con lineas
            drawFachada( linea, Color4.Red, 0, true);
            drawLados(   linea, Color4.Red, ancho, 0, largo, true);
            drawFachada( linea, Color4.Red, largo, false);
            drawLados(   linea, Color4.Red, 0, largo, 0, true);

            drawTechoDer(linea, Color4.Yellow);
            drawTechoIzq(linea, Color4.Yellow);
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
            GL.Vertex3(centro.X - ancho,     centro.Y,              centro.Z);
            GL.Vertex3(centro.X - ancho,     centro.Y,              centro.Z - largo);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z - largo);
            GL.End();
        }

        private void drawLados(PrimitiveType primitiveType, Color4 color, double posicion, 
            double der, double izq, bool ventana)
        {

            GL.Begin(primitiveType);
            GL.Color4(color);
            GL.Vertex3(centro.X - posicion, centro.Y,                    centro.Z - der);
            GL.Vertex3(centro.X - posicion, centro.Y - (alto / 2.5) * 2, centro.Z - der);
            GL.Vertex3(centro.X - posicion, centro.Y - (alto / 2.5) * 2, centro.Z - izq);
            GL.Vertex3(centro.X - posicion, centro.Y,                    centro.Z - izq);
            GL.End();

            if (ventana)
            {
                GL.Begin(primitiveType);
                GL.Color4(Color4.Transparent);
                GL.Vertex3(centro.X - posicion, centro.Y - alto / 4,   centro.Z - largo / 4);
                GL.Vertex3(centro.X - posicion, centro.Y - alto / 4,   centro.Z - 3 * largo / 4);
                GL.Vertex3(centro.X - posicion, centro.Y - alto / 1.8, centro.Z - 3 * largo / 4);
                GL.Vertex3(centro.X - posicion, centro.Y - alto / 1.8, centro.Z - largo / 4);
                GL.End();
            }
        }


        private void drawFachada(PrimitiveType primitiveType, Color4 color, double profundidad, bool puerta)
        {

            GL.Begin(primitiveType);
            GL.Color4(color);
            GL.Vertex3(centro.X, centro.Y,                  centro.Z - profundidad); 
            GL.Vertex3(centro.X, centro.Y - (alto/2.5) * 2, centro.Z - profundidad);

            if (puerta)
            {
                GL.Vertex3(centro.X - ancho / 4,     centro.Y - 2 * alto / 2.5, centro.Z - profundidad);
                GL.Vertex3(centro.X - ancho / 4,     centro.Y - alto / 4,       centro.Z - profundidad);
                GL.Vertex3(centro.X - 3 * ancho / 4, centro.Y - (alto / 4),     centro.Z - profundidad);
                GL.Vertex3(centro.X - 3 * ancho / 4, centro.Y - 2 * alto / 2.5, centro.Z - profundidad);
            }

            GL.Vertex3(centro.X - ancho, centro.Y - (alto/2.5) * 2, centro.Z - profundidad);
            GL.Vertex3(centro.X - ancho, centro.Y,                  centro.Z - profundidad);
            GL.End();

            //triangulo 

            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(color);
            GL.Vertex3(centro.X,             centro.Y,              centro.Z - profundidad);
            GL.Vertex3(centro.X - ancho,     centro.Y,              centro.Z - profundidad);
            GL.Vertex3(centro.X - ancho / 2, centro.Y + alto / 2.5, centro.Z - profundidad);
            GL.End();
        }


    }
}
