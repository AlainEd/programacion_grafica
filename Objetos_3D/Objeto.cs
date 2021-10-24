using System;
using System.Collections.Generic;


namespace Objetos_3D
{
    class Objeto
    {

        /*
         * la clase objeto va permitir al usuaruo agregar, quitar objetos
         * */

        public string nombre { get; set; }
        public List<double> centroMasa { get; set; } 
        public List<Face> listaFaces { get; set; }


        public Objeto(List<Face> listaFaces)
        {
            this.listaFaces = listaFaces;
        }

        public void dibujar()
        {

            if (listaFaces != null)
            {
                foreach (Face face in listaFaces)
                {
                    face.dibujar(centroMasa);
                }
            }
        }
    }
}
