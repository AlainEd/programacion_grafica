﻿
using System;
using System.IO;
using System.Collections.Generic;


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
