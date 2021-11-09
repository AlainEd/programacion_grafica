using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos_3D
{
    class Matriz 
    {
        private double[,] matriz;
        public byte dimMatriz = 4;
        public byte nroFil;
        public byte nroCol;

        public Matriz()
        {
            matriz = new double[dimMatriz, dimMatriz];
            this.nroFil = this.nroCol = dimMatriz;
            matrizIdentidad();
        }

        public Matriz(byte fil, byte col)
        {
            matriz = new double[fil, col];
            this.nroFil = fil;
            this.nroCol = col;
        }

        public Matriz(float[] vertices)
        {
            this.nroFil = 1;
            this.nroCol = (byte)(vertices.Length + 1);
            matriz = new double[nroFil, nroCol];
            for (int i = 0; i < vertices.Length; i++)
            {
                matriz[nroFil - 1, i] = vertices[i];
            }
            matriz[nroFil - 1, nroCol - 1] = 1;
        }

        public void matrizIdentidad()
        {
            for (int i = 0; i < nroFil; i++)
            {
                for (int j = 0; j < nroCol; j++)
                {
                    if (i == j)
                        matriz[i, j] = 1;
                    else
                        matriz[i, j] = 0;
                }
            }
        }

        public double getCelda(int i, int j)
        {
            if (i < 0 | i >= nroFil | j < 0 | j >= nroCol)
                throw new Exception("Error: Index fuera de rango");
            return matriz[i, j];

        }

        public void setCelda(int i, int j, double elem)
        {
            matriz[i, j] = elem;
        }

        public void rotacionX(int angulo)
        {
            double angR = Math.PI * angulo / 180;
            matrizIdentidad();
            matriz[1, 1] = Math.Cos(angR);
            matriz[2, 1] = -Math.Sin(angR);
            matriz[1, 2] = Math.Sin(angR);
            matriz[2, 2] = Math.Cos(angR);
        }

        public void rotacionY(int angulo)
        {
            double angR = Math.PI * angulo / 180;
            matrizIdentidad();
            matriz[0, 0] = Math.Cos(angR);
            matriz[0, 2] = -Math.Sin(angR);
            matriz[2, 0] = Math.Sin(angR);
            matriz[2, 2] = Math.Cos(angR);
        }

        public void rotacionZ(int angulo)
        {
            double angR = Math.PI * angulo / 180;
            matrizIdentidad();
            matriz[0, 0] = Math.Cos(angR);
            matriz[1, 0] = -Math.Sin(angR);
            matriz[0, 1] = Math.Sin(angR);
            matriz[1, 1] = Math.Cos(angR);
        }

        public void escalacion(double ancho, double alto, double largo)
        {
            matrizIdentidad();
            matriz[0, 0] = ancho;
            matriz[1, 1] = alto;
            matriz[2, 2] = largo;
        }

        public void traslacion(double x, double y, double z)
        {
            matrizIdentidad();
            matriz[3, 0] = x;
            matriz[3, 1] = y;
            matriz[3, 2] = z;
        }

        public Matriz multiplicarMatrices(Matriz A, Matriz B)
        {
            if (A.nroCol != B.nroFil)
                throw new Exception("Error: No se puede multiplicar las matrices.");

            Matriz R = new Matriz(A.nroFil, B.nroCol);
            for (int i = 0; i < A.nroFil; i++)
            {
                for (int j = 0; j < B.nroCol; j++)
                {
                    double elem = 0;
                    for (int k = 0; k < A.nroCol; k++)
                    {
                        elem += A.getCelda(i, k) * B.getCelda(k, j);
                    }
                    R.setCelda(i, j, elem);
                }
            }
            return R;
        }

        public void printMatriz()
        {
            
            for (int i = 0; i < nroFil; i++)
            {
                string fil = "";
                for (int j = 0; j < nroCol; j++)
                {
                    fil += getCelda(i, j) + "   ";
                }
                Console.WriteLine(fil);
            }
        }
    }
}
