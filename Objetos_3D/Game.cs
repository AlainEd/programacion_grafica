using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Objetos_3D
{
    class Game : GameWindow
    {
        int arriba = 0, abajo = 1, derecha = 1, izquierda = 0;
        public static string path = @"C:\Users\Edson\source\repos\Objetos_3D\Objetos_3D\appsetings.json";
        public static string jsonString;
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

            /*List<List<double>> listaVert = new List<List<double>>();
            listaVert.Insert(0, new List<double> { 0, 50, 0 });
            listaVert.Insert(1, new List<double> { 0, 50, 100 });
            listaVert.Insert(2, new List<double> { 0, 0, 100 });
            listaVert.Insert(3, new List<double> { 0, 0, 0 });

            List<List<double>> listaVert2 = new List<List<double>>();
            listaVert2.Insert(0, new List<double> { 50, 50, 0 });
            listaVert2.Insert(1, new List<double> { 50, 50, 100 });
            listaVert2.Insert(2, new List<double> { 50, 0, 100 });
            listaVert2.Insert(3, new List<double> { 50, 0, 0 });

            Face faces = new Face(listaVert);
            Face faces2 = new Face(listaVert2);

            List<Face> listaFaces = new List<Face>();
            listaFaces.Add(faces);
            listaFaces.Add(faces2);

            Objeto objeto = new Objeto(listaFaces);
            List<Objeto> listaObj = new List<Objeto>();
            listaObj.Add(objeto);

            Escenario escenario = new Escenario(listaObj);

            escenario.dibujar();


            var options = new JsonSerializerOptions { WriteIndented = true };
            jsonString = System.Text.Json.JsonSerializer.Serialize(objeto, options);


            Console.WriteLine(jsonString);*/

            string jsonString = readFile();
            Escenario obj = JsonConvert.DeserializeObject<Escenario>(jsonString);
            obj.dibujar();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

 
        public static string readFile()
        {
            string objeto;
            using (var reader = new StreamReader(path))
            {
                objeto = reader.ReadToEnd();
            }
            return objeto;
        }

        protected override void OnResize(EventArgs e)
        {
            Console.WriteLine(jsonString);

            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }

        
    }
}
