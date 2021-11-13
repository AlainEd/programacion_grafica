using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.IO;



namespace Objetos_3D
{
    class Game : GameWindow 
    {
        int arriba = 0, abajo = 0, derecha = 0, izquierda = 0;
        Escenario escenario;



        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.W)) arriba += 10;
            else if (input.IsKeyDown(Key.S)) abajo += 10;
            else if (input.IsKeyDown(Key.D)) derecha += 10;
            else if (input.IsKeyDown(Key.A)) izquierda += 10;

            base.OnUpdateFrame(e);
        }

        protected override void OnLoad(EventArgs e)
        {

            GL.ClearColor(Color4.Black);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Ortho(-300, 300, -300, 300, -300, 300);

       

            escenario = new Escenario();
            escenario.agregarObjeto("casa1", "Casa.json");
            escenario.agregarObjeto("casa2", "Casa.json");
            Objeto obj = escenario.getObjeto("casa1");
            obj.establecerorigen(new float[3] { 120, 0, 0 });
            obj.escalar(0.5f);


            base.OnLoad(e);
        }

        int x = 120;

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.ColorMaterial);
            GL.Rotate(arriba, abajo, derecha, izquierda);

            Objeto obj = escenario.getObjeto("casa2");
            obj.rotar(1, new Vector3d(0, 1, 0));

            escenario.dibujar();
            x = 0;

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

//Dictionary<string, float[]> ParedIzq = new Dictionary<string, float[]>();
//            ParedIzq.Add("Vert1", new float[3] { 0, 5, 0 });
//            ParedIzq.Add("Vert2", new float[3] { 0, 5, 10 });
//            ParedIzq.Add("Vert3", new float[3] { 0, 0, 10 });
//            ParedIzq.Add("Vert4", new float[3] { 0, 0, 0 });

//            float[] color = new float[] { 0, 1, 0 };
//            Face FaceparedIzq = new Face(ParedIzq, color);



//            Dictionary<string, float[]> ParedDer = new Dictionary<string, float[]>();
//            ParedDer.Add("Vert1", new float[3] { 5, 5, 0 });
//            ParedDer.Add("Vert2", new float[3] { 5, 5, 10 });
//            ParedDer.Add("Vert3", new float[3] { 5, 0, 10 });
//            ParedDer.Add("Vert4", new float[3] { 5, 0, 0 });

//            Face FaceparedDer = new Face(ParedDer, color);

//            Dictionary<string, float[]> ParedDel = new Dictionary<string, float[]>();
//            ParedDel.Add("Vert1", new float[3] { 0, 5, 0 });
//            ParedDel.Add("Vert2", new float[3] { 0, 0, 0 });
//            ParedDel.Add("Vert3", new float[3] { 5, 0, 0 });
//            ParedDel.Add("Vert4", new float[3] { 5, 5, 0 });
//            ParedDel.Add("Vert5", new float[3] { 2.5f, 7.5f, 0 });

//            Face FaceparedDel = new Face(ParedDel, color);

//            Dictionary<string, float[]> ParedTra = new Dictionary<string, float[]>();
//            ParedTra.Add("Vert1", new float[3] { 0, 5, 10 });
//            ParedTra.Add("Vert2", new float[3] { 0, 0, 10 });
//            ParedTra.Add("Vert3", new float[3] { 5, 0, 10 });
//            ParedTra.Add("Vert4", new float[3] { 5, 5, 10 });
//            ParedTra.Add("Vert5", new float[3] { 2.5f, 7.5f, 10 });

//            Face FaceparedTra = new Face(ParedTra, color);

//            Dictionary<string, float[]> TechoDer = new Dictionary<string, float[]>();
//            TechoDer.Add("Vert1", new float[3] { 2.5f, 7.5f, 0 });
//            TechoDer.Add("Vert2", new float[3] { 0, 5, -1 });
//            TechoDer.Add("Vert3", new float[3] { 0, 5, 11 });
//            TechoDer.Add("Vert4", new float[3] { 2.5f, 7.5f, 11 });

//            float[] color2 = new float[] { 0, 0, 1 };
//            Face FacetechoDer = new Face(TechoDer, color2);

//            Dictionary<string, float[]> TechoIzq = new Dictionary<string, float[]>();
//            TechoIzq.Add("Vert1", new float[3] { 5, 5, 0 });
//            TechoIzq.Add("Vert2", new float[3] { 2.5f, 7.5f, 0 });
//            TechoIzq.Add("Vert3", new float[3] { 2.5f, 7.5f, 11 });
//            TechoIzq.Add("Vert4", new float[3] { 5.0f, 5.0f, 11 });

//            Face FacetechoIzq = new Face(TechoIzq, color2);


//            Dictionary<string, Face> listaFaces = new Dictionary<string, Face>();
//            listaFaces.Add("lado1", FaceparedIzq);
//            listaFaces.Add("lado2", FaceparedDer);
//            listaFaces.Add("lado3", FaceparedDel);
//            listaFaces.Add("lado4", FaceparedTra);
//            listaFaces.Add("lado5", FacetechoDer);
//            listaFaces.Add("lado6", FacetechoIzq);


//            Objeto objeto = new Objeto(listaFaces);

//            objeto.escalar(new Vector3d(50, 50, 100));

//            objeto.dibujar();

//            //var options = new JsonSerializerOptions { WriteIndented = true };
//            //string jsonString = System.Text.Json.JsonSerializer.Serialize(objeto, options);
//            //Console.WriteLine(jsonString);





