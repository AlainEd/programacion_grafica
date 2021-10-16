using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;



namespace Objetos_3D
{
    class Game : GameWindow
    {
        int arriba = 0, abajo = 1, derecha = 1, izquierda = 0;
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.W)) arriba++;
            else if (input.IsKeyDown(Key.S)) abajo += 300;
            else if (input.IsKeyDown(Key.D)) derecha += 300;
            else if (input.IsKeyDown(Key.A)) izquierda += 300;

            base.OnUpdateFrame(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.Black);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-300, 300, -300, 300, -300, 300);
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Rotate(arriba, abajo, derecha, izquierda);

            Casa casa = new Casa(new Vector3(0, 0, 0), 100, 100, 50);
            Casa casa2 = new Casa(new Vector3(100, -100, 0), 200, 200, 100);
            Casa casa3 = new Casa(new Vector3(-100, -100, 0), 100, 100, 50);
            casa.dibujar();
            casa2.dibujar();
            casa3.dibujar();

            GL.ObjectLabel(ObjectLabelIdentifier.Texture, 1, 10, "HOla mundo");

            /*GL.Begin(PrimitiveType.Triangles);
            GL.Color4(Color4.Black);
            GL.Vertex2(-0.5, -0.5);
            GL.Color4(Color4.Red);
            GL.Vertex2(0.5, -0.5);
            GL.Color4(Color4.White);
            GL.Vertex2(0, 0.5);
            GL.End();*/

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            
            
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }
    }
}
