using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    class Game
    {
        int[,] MassGame;
        public Game(int[] mass)
        {
            int size = (int)Math.Sqrt(mass.Length);
            MassGame = new int[size, size];
            for (int i = 0; i < mass.Length; i++)
            {
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        MassGame[x, y] = mass[i];
                        i++;
                    }
                }
            }
        }
        public int this[int x, int y]
        {
            get
            {
                return MassGame[x, y];
            }

            set
            {
                MassGame[x, y] = value;
            }
        }

        public List<int> GetLocation(int value)
        {
            List<int> points = new List<int>();
            for (int x = 0; x < MassGame.GetLength(0); x++)
            {
                for (int y = 0; y < MassGame.GetLength(1); y++)
                {
                    if (MassGame[x, y] == value)
                    {
                        points.Add(x);
                        points.Add(y);
                    }
                }
            }
            return points;
        }

        public void Shift(int value) //разобраться с исключениями
        {
            List<int> pointsValue = GetLocation(value);
            string temp = Console.ReadLine();
            switch (temp)
            {
                case "a":
                    try
                    {
                        if (MassGame[pointsValue[0], pointsValue[1] - 1] == 0)
                        {
                            MassGame[pointsValue[0], pointsValue[1] - 1] = value;
                            MassGame[pointsValue[0], pointsValue[1]] = 0;
                            Console.WriteLine("Успешно перемещено влево");
                            Shift(value);
                        }
                    }
                    catch (ArgumentException )
                    {
                        Console.WriteLine("Невозможно передвинуть клетку влево");
                    }
                    break;
                case "d":
                    try
                    {
                        if (MassGame[pointsValue[0], pointsValue[1] + 1] == 0)
                        {
                            MassGame[pointsValue[0], pointsValue[1] + 1] = value;
                            MassGame[pointsValue[0], pointsValue[1]] = 0;
                            Console.WriteLine("Успешно перемещено вправо");
                            Shift(value);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Невозможно передвинуть клетку вправо");
                    }
                    break;
                case "w":
                    try
                    {
                        if (MassGame[pointsValue[0] + 1, pointsValue[1]] == 0)
                        {
                            MassGame[pointsValue[0] + 1, pointsValue[1]] = value;
                            MassGame[pointsValue[0], pointsValue[1]] = 0;
                            Console.WriteLine("Успешно перемещено вверх");
                            Shift(value);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Невозможно передвинуть клетку вверх");
                    }
                    break;
                case "s":
                    try
                    {
                        if (MassGame[pointsValue[0] - 1, pointsValue[1]] == 0)
                        {
                            MassGame[pointsValue[0] - 1, pointsValue[1]] = value;
                            MassGame[pointsValue[0], pointsValue[1]] = 0;
                            Console.WriteLine("Успешно перемещено вниз");
                            Shift(value);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Невозможно передвинуть клетку вниз");
                    }
                    break;
            }

        }
    }
}

