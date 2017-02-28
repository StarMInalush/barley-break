using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    class Game
    {
        private int[,] FieldGame;
        private int[,] Coordinates;
        public Game(params int[] mass)
        {
            double size = mass.Length;
            int sizeField = 0;
            if (size % 1 == 0)
            {
                sizeField = (int)Math.Sqrt(size);
            }
            else
            {
                throw new ArgumentException("Недостаточно чисел для построения поля!");
            }
            if (sizeField <= 1)
            {
                throw new ArgumentException("Размер поля не может быть меньше или равным 1!");
            }
            FieldGame = new int[sizeField, sizeField];
            Coordinates = new int[mass.Length, 2];
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < sizeField; j++)
                {
                    for (int k = 0; k < sizeField; k++)
                    {
                        FieldGame[j, k] = mass[i];
                        Coordinates[mass[i], 0] = j;
                        Coordinates[mass[i], 1] = k;
                        i++;
                    }
                }
            }
            Show();

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

        public int[] GetLocation(int value)
        {
            if (value < 0 || value >= FieldGame.Length)
            {
                throw new ArgumentException("Такого элемента нет в поле!");
            }
            int[] coord = new int[2];
            coord[0] = Coordinates[value, 0];
            coord[1] = Coordinates[value, 1];
            return coord;
        }
        public void Shift(int value)
        {
            int[] valueCoordinates = GetLocation(value);
            int[] zeroCoordinates = GetLocation(0);
                if (Math.Abs(zeroCoordinates[1] - valueCoordinates[1]) == 1 && zeroCoordinates[0] == valueCoordinates[0] || Math.Abs(zeroCoordinates[0] - valueCoordinates[0]) == 1 && zeroCoordinates[1] == valueCoordinates[1])
                {
                    Coordinates[value, 0] = zeroCoordinates[0];
                    Coordinates[value, 1] = zeroCoordinates[1];
                    Coordinates[0, 0] = valueCoordinates[0];
                    Coordinates[0, 1] = valueCoordinates[1];
                    FieldGame[zeroCoordinates[0], zeroCoordinates[1]] = value;
                    FieldGame[valueCoordinates[0], valueCoordinates[1]] = 0;
                    Show();
                }
                else
                {
                throw new ArgumentException("Невозможно переместить клетку!");
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadLine();
                Shift(value);
        }

        //Не могу решить, какая из функций Shift лучше
        //public void Shift(int value)
        //{
        //    int[] massCoordinates = GetLocation(value);
        //    int[] temp = GetLocation(0);
        //    char letter = Console.ReadKey().KeyChar;
        //    switch (letter)
        //    {
        //        case 'A':
        //            try
        //            {
        //                if (FieldGame[massCoordinates[0], massCoordinates[1] - 1] == 0)
        //                {
        //                    Move(value, "влево", massCoordinates, temp);
        //                }
        //                else
        //                {
        //                    Console.WriteLine(" Невозможно переместить клетку влево, так как там нет 0");
        //                }
        //            }
        //            catch (IndexOutOfRangeException)
        //            {
        //                Console.WriteLine(" Вы не можете передвинуть клетку за пределы поля!");
        //            }
        //            Shift(value);
        //            break;
        //        case 'W':
        //            try
        //            {
        //                if (FieldGame[massCoordinates[0] - 1, massCoordinates[1]] == 0)
        //                {
        //                    Move(value, "вверх", massCoordinates, temp);
        //                }
        //                else
        //                {
        //                    Console.WriteLine(" Невозможно переместить клетку вверх, так как там нет 0");
        //                }
        //            }
        //            catch (IndexOutOfRangeException)
        //            {
        //                Console.WriteLine(" Вы не можете передвинуть клетку за пределы поля!");
        //            }
        //            Shift(value);
        //            break;
        //        case 'S':
        //            try
        //            {
        //                if (FieldGame[massCoordinates[0] + 1, massCoordinates[1]] == 0)
        //                {
        //                    Move(value, "вниз", massCoordinates, temp);
        //                }
        //                else
        //                {
        //                    Console.WriteLine(" Невозможно переместить клетку вниз, так как там нет 0");
        //                }
        //            }
        //            catch (IndexOutOfRangeException)
        //            {
        //                Console.WriteLine(" Вы не можете передвинуть клетку за пределы поля!");
        //            }
        //            Shift(value);
        //            break;
        //        case 'D':
        //            try
        //            {
        //                if (FieldGame[massCoordinates[0], massCoordinates[1] + 1] == 0)
        //                {
        //                    Move(value, "вправо", massCoordinates, temp);
        //                }
        //                else
        //                {
        //                    Console.WriteLine(" Невозможно переместить клетку вправо, так как там нет 0");
        //                }
        //            }
        //            catch (IndexOutOfRangeException)
        //            {
        //                Console.WriteLine(" Вы не можете передвинуть клетку за пределы поля!");
        //            }
        //            Shift(value);
        //            break;
        //    }
        //}
        //private void Move (int value, string direction, int [] massCoordinates, int [] temp)
        //{
        //    Coordinates[value, 0] = temp[0];
        //    Coordinates[value, 1] = temp[1];
        //    Coordinates[0, 0] = massCoordinates[0];
        //    Coordinates[0, 1] = massCoordinates[1];
        //    FieldGame[temp[0], temp[1]] = value;
        //    FieldGame[massCoordinates[0], massCoordinates[1]] = 0;
        //    Console.WriteLine(" Перемещено "+ direction);
        //    Show();
        //}
        private void Show()
        {
            for (int i = 0; i < FieldGame.GetLength(0); i++)
            {
                for (int j = 0; j < FieldGame.GetLength(1);j++)
                {
                    Console.Write(FieldGame[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

