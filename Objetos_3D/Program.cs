
using System;
using System.IO;


namespace Objetos_3D
{
    class Program
    {
        public static string path = @"C:\Users\Edson\source\repos\Objetos_3D\Objetos_3D\appsetings.json";
        static void Main(string[] args)
        {
            using (Game game = new Game(1260, 700, "Objetos en 3D"))
            {
                game.Run(60.0);
            }

        }
    }
}
