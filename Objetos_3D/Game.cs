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
        Escenario escenario;
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            string des = File.ReadAllText("Casa.json");
            var obj = JsonConvert.DeserializeObject<Objeto>(des);
            var obj2 = JsonConvert.DeserializeObject<Objeto>(des);
            var obj3 = JsonConvert.DeserializeObject<Objeto>(des);
            var obj4 = JsonConvert.DeserializeObject<Objeto>(des);
            var obj5 = JsonConvert.DeserializeObject<Objeto>(des);
            var obj6 = JsonConvert.DeserializeObject<Objeto>(des);
            var obj7 = JsonConvert.DeserializeObject<Objeto>(des);
            var obj8 = JsonConvert.DeserializeObject<Objeto>(des);
            var obj9 = JsonConvert.DeserializeObject<Objeto>(des);
            var obj10 = JsonConvert.DeserializeObject<Objeto>(des);

            string des2 = File.ReadAllText("Camino.json");
            var camino = JsonConvert.DeserializeObject<Objeto>(des2);
            var camino2 = JsonConvert.DeserializeObject<Objeto>(des2);
            var camino3 = JsonConvert.DeserializeObject<Objeto>(des2);
            var camino4 = JsonConvert.DeserializeObject<Objeto>(des2);

            obj.dimensionarObjeto(5, 5, 7);
            obj2.dimensionarObjeto(5, 5, 7);
            obj3.dimensionarObjeto(5, 5, 7);
            obj4.dimensionarObjeto(5, 5, 7);
            obj5.dimensionarObjeto(5, 5, 7);
            obj6.dimensionarObjeto(5, 5, 7);
            obj7.dimensionarObjeto(5, 5, 7);
            obj8.dimensionarObjeto(5, 5, 7);
            obj9.dimensionarObjeto(5, 5, 7);
            obj10.dimensionarObjeto(5, 5, 7);

            camino.dimensionarObjeto(5, 5, 7);
            camino2.dimensionarObjeto(5, 5, 7);
            camino3.dimensionarObjeto(5, 5, 7);
            camino4.dimensionarObjeto(5, 5, 7);


            obj2.establecerOrigen(new Vector3d(100,0,0));
            obj3.establecerOrigen(new Vector3d(-100, 0, 0));
            obj4.establecerOrigen(new Vector3d(200, 0, 0));
            obj5.establecerOrigen(new Vector3d(-200, 0, 0));

            obj6.establecerOrigen(new Vector3d(0, 0, 200));
            obj7.establecerOrigen(new Vector3d(100, 0, 200));
            obj8.establecerOrigen(new Vector3d(-100, 0, 200));
            obj9.establecerOrigen(new Vector3d(200, 0, 200));
            obj10.establecerOrigen(new Vector3d(-200, 0, 200));


            camino.establecerOrigen(new Vector3d(0, 0, 100));
            camino2.establecerOrigen(new Vector3d(50, 0, 100));
            camino3.establecerOrigen(new Vector3d(100, 0, 100));
            camino4.establecerOrigen(new Vector3d(150, 0, 100));

            escenario = new Escenario();
            escenario.agregarObjeto("casa", obj);
            escenario.agregarObjeto("casa2", obj2);
            escenario.agregarObjeto("casa3", obj3);
            escenario.agregarObjeto("casa4", obj4);
            escenario.agregarObjeto("casa5", obj5);
            escenario.agregarObjeto("casa6", obj6);
            escenario.agregarObjeto("casa7", obj7);
            escenario.agregarObjeto("casa8", obj8);
            escenario.agregarObjeto("casa9", obj9);
            escenario.agregarObjeto("casa10", obj10);

            escenario.agregarObjeto("camino", camino);
            escenario.agregarObjeto("camino2", camino2);
            escenario.agregarObjeto("camino3", camino3);
            escenario.agregarObjeto("camino4", camino4);

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
            //GL.LoadIdentity();
            GL.Ortho(-300, 300, -300, 300, -300, 300);
            
            base.OnLoad(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Rotate(arriba, abajo, derecha, izquierda);

            escenario.dibujar();

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

