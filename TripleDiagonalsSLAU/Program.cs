﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleDiagonalsSLAU
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            //создание слау
            float[][] SLAU = new float[6][];
            SLAU[0] = new float[2];
            SLAU[0][0] = random.Next(10, 99);
            SLAU[0][1] = random.Next(-99, -10);

            SLAU[1] = new float[3];
            SLAU[1][0] = random.Next(-99, -10);
            SLAU[1][1] = random.Next(10, 99);
            SLAU[1][2] = random.Next(-99, -10);

            SLAU[2] = new float[3];
            SLAU[2][0] = random.Next(-99, -10);
            SLAU[2][1] = random.Next(10, 99);
            SLAU[2][2] = random.Next(-99, -10);

            SLAU[3] = new float[3];
            SLAU[3][0] = random.Next(-99, -10);
            SLAU[3][1] = random.Next(10, 99);
            SLAU[3][2] = random.Next(-99, -10);

            SLAU[4] = new float[3];
            SLAU[4][0] = random.Next(-99, -10);
            SLAU[4][1] = random.Next(10, 99);
            SLAU[4][2] = random.Next(-99, -10);

            SLAU[5] = new float[2];
            SLAU[5][0] = random.Next(-99, -10);
            SLAU[5][1] = random.Next(10, 99);

            //Результаты уравнений
            float[] f = new float[6];
            for (int i = 0; i < f.Length; i++) f[i] = random.Next(-99, 99);

            //Вывод СЛАУ
            for (int i = 0; i < SLAU.Length; i++)
            {
                for (int space = 0; space < i - 1; space++) Console.Write("    ");

                for (int j = 0; j < SLAU[i].Length; j++) Console.Write($" {SLAU[i][j]}");

                Console.WriteLine($"  =  {f[i]}");
            }


            //Поиск альфа и бета
            float[] alpha = new float[5];
            float[] beta = new float[5];

            alpha[0] = (SLAU[0][1] / SLAU[0][0]);
            beta[0] = (f[0] / SLAU[0][0]);
            for (int i = 1; i < SLAU.Length - 1; i++)
            {
                alpha[i] = 
                    SLAU[i][2] / 
                        (SLAU[i][1] - (SLAU[i][0] * alpha[i - 1]));

                beta[i] = 
                    (f[i] + (SLAU[i][0] * beta[i - 1])) / 
                        (SLAU[i][1] - (SLAU[i][0] * alpha[i - 1]));
            }


            //Поиск х
            float[] x = new float[6];
            x[5] = 
                (f[5] + (SLAU[5][0] * beta[beta.Length - 1])) / 
                    (SLAU[5][1] - (SLAU[5][0] * alpha[alpha.Length - 1]));
            for (int i = 4; i >= 0; i--)
            {
                x[i] = alpha[i] * x[i + 1] + beta[i];
            }

            //Вывод
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine($"x{i} = {x[i]}");
            }

            Console.ReadKey();
        }
    }
}
