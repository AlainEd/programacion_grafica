using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.IO;



namespace Objetos_3D
{
    class Game : GameWindow
    {
        int arriba = 0, abajo = 0, derecha = 0, izquierda = 0;
        Escenario escenario;
        int n = 0;
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
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-300, 300, -300, 300, -300, 300);

            Objeto casa = JsonToObjeto("Casa.json");
            Objeto casa2 = JsonToObjeto("Casa.json");

            casa2.establecerOrigen(new Vector3d(200, 0, 0));

            escenario = new Escenario();
            escenario.agregarObjeto("casa", casa);
            escenario.agregarObjeto("casa2", casa2);
            



            base.OnLoad(e);
        }

        public Objeto JsonToObjeto(string archivo)
        {
            archivo = File.ReadAllText(archivo);
            return JsonConvert.DeserializeObject<Objeto>(archivo);
        }

        float x = 0.5f;
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Rotate(arriba, abajo, derecha, izquierda);

            
            escenario.rotacion(x, 0, 1, 0);
            //escenario.traslacion(10, 0, 0);
            escenario.dibujar();
            x += 0.5f;


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
//ParedIzq.Add("Vert1", new float[3] { 0, 5, 0 });
//ParedIzq.Add("Vert2", new float[3] { 0, 5, 10 });
//ParedIzq.Add("Vert3", new float[3] { 0, 0, 10 });
//ParedIzq.Add("Vert4", new float[3] { 0, 0, 0 });

//float[] color = new float[] { 0, 1, 0 };
//Face FaceparedIzq = new Face(ParedIzq, color);



//Dictionary<string, float[]> ParedDer = new Dictionary<string, float[]>();
//ParedDer.Add("Vert1", new float[3] { 5, 5, 0 });
//ParedDer.Add("Vert2", new float[3] { 5, 5, 10 });
//ParedDer.Add("Vert3", new float[3] { 5, 0, 10 });
//ParedDer.Add("Vert4", new float[3] { 5, 0, 0 });

//Face FaceparedDer = new Face(ParedDer, color);

//Dictionary<string, float[]> ParedDel = new Dictionary<string, float[]>();
//ParedDel.Add("Vert1", new float[3] { 0, 5, 0 });
//ParedDel.Add("Vert2", new float[3] { 0, 0, 0 });
//ParedDel.Add("Vert3", new float[3] { 5, 0, 0 });
//ParedDel.Add("Vert4", new float[3] { 5, 5, 0 });
//ParedDel.Add("Vert5", new float[3] { 2.5f, 7.5f, 0 });

//Face FaceparedDel = new Face(ParedDel, color);

//Dictionary<string, float[]> ParedTra = new Dictionary<string, float[]>();
//ParedTra.Add("Vert1", new float[3] { 0, 5, 10 });
//ParedTra.Add("Vert2", new float[3] { 0, 0, 10 });
//ParedTra.Add("Vert3", new float[3] { 5, 0, 10 });
//ParedTra.Add("Vert4", new float[3] { 5, 5, 10 });
//ParedTra.Add("Vert5", new float[3] { 2.5f, 7.5f, 10 });

//Face FaceparedTra = new Face(ParedTra, color);

//Dictionary<string, float[]> TechoDer = new Dictionary<string, float[]>();
//TechoDer.Add("Vert1", new float[3] { 2.5f, 7.5f, 0 });
//TechoDer.Add("Vert2", new float[3] { 0, 5, -1 });
//TechoDer.Add("Vert3", new float[3] { 0, 5, 11 });
//TechoDer.Add("Vert4", new float[3] { 2.5f, 7.5f, 11 });

//float[] color2 = new float[] { 0, 0, 1 };
//Face FacetechoDer = new Face(TechoDer, color2);

//Dictionary<string, float[]> TechoIzq = new Dictionary<string, float[]>();
//TechoIzq.Add("Vert1", new float[3] { 5, 5, 0 });
//TechoIzq.Add("Vert2", new float[3] { 2.5f, 7.5f, 0 });
//TechoIzq.Add("Vert3", new float[3] { 2.5f, 7.5f, 11 });
//TechoIzq.Add("Vert4", new float[3] { 5.0f, 5.0f, 11 });

//Face FacetechoIzq = new Face(TechoIzq, color2);


//Dictionary<string, Face> listaFaces = new Dictionary<string, Face>();
//listaFaces.Add("lado1", FaceparedIzq);
//listaFaces.Add("lado2", FaceparedDer);
//listaFaces.Add("lado3", FaceparedDel);
//listaFaces.Add("lado4", FaceparedTra);
//listaFaces.Add("lado5", FacetechoDer);
//listaFaces.Add("lado6", FacetechoIzq);


//Objeto objeto = new Objeto(listaFaces);

//objeto.dibujar();

//var options = new JsonSerializerOptions { WriteIndented = true };
//string jsonString = System.Text.Json.JsonSerializer.Serialize(objeto, options);
//Console.WriteLine(jsonString);

