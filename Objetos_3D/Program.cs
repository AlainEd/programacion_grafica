using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos_3D
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new Game(1260, 700, "Objetos en 3D"))
            {
                game.Run(60.0);
            }
        }
    }
}
