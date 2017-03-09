using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    class Game
    {
        protected Point[] PointGame;
        public readonly int[,] FieldGame;
        public Game(params int[] mass)
        {
            int size = (int)Math.Sqrt(mass.Length);
            if (size * size != mass.Length)
            {
                throw new ArgumentException("Недостаточно чисел для построения поля!");
            }
            if (size <= 1)
            {
                throw new ArgumentException("Размер поля не может быть меньше или равным 1!");
            }
            FieldGame = new int[size, size];
            PointGame = new Point[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        FieldGame[j, k] = mass[i];
                        PointGame[mass[i]] = new Point(j, k);
                        i++;
                    }
                }
            }

        }
        public int this[int x, int y]
        {
            get
            {
                return FieldGame[x, y];
            }

            set
            {
                FieldGame[x, y] = value;
            }
        }

        public Point GetLocation(int value)//tuplе или point
        {
            if (value < 0 || value >= PointGame.Length)
            {
                throw new ArgumentException("Такого элемента нет в поле!");
            }
            return PointGame[value];
        }

        public virtual void Shift(int value)
        {
            Point gameValue = GetLocation(value);
            Point gameZero = GetLocation(0);
            if (Math.Abs(gameZero.X - gameValue.X) == 1 && gameZero.Y == gameValue.Y || Math.Abs(gameZero.Y - gameValue.Y) == 1 && gameZero.X == gameValue.X) //reverse
            {
                FieldGame[gameValue.X, gameValue.Y] = 0;
                FieldGame[gameZero.X, gameZero.Y] = value;
                PointGame[0] = gameValue;
                PointGame[value] = gameZero;
            }
            else
            {
                Console.WriteLine("Невозможно передвинуть клетку!");
            }
        }

        public static Game GameFromCSV(string path)
        {
            StreamReader f = new StreamReader(path);
            string s;
            int count = File.ReadAllLines(path).Length;
            int[] a = new int[count * count];
            string[] buf;
            int t = 0;
            int i = 0;
            while ((s = f.ReadLine()) != null)
            {
                buf = s.Split(';');
                if (buf.Length == count)
                {
                    for (int j = 0; j < buf.Length; j++)
                    {
                        t = Convert.ToInt32(buf[j]);
                        a[i] = t;
                        i++;
                    }
                }
            }
            return new Game(a);
        }
    }
}


