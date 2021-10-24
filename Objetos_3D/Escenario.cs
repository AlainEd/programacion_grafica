using System.Collections.Generic;


namespace Objetos_3D
{
    class Escenario
    {
        
        public List<Objeto> listaObj { get; set; }
        

        public Escenario(List<Objeto> listaObj)
        {
            this.listaObj = listaObj;
        }

        public void dibujar()
        {
            if (listaObj != null)
            {
                foreach (Objeto obj in listaObj)
                {
                    obj.dibujar();
                }
            }
            
        }

        
    }
}