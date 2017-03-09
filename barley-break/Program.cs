using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    class Program
    {
        static void Main(string[] args)
        {
            Game3 game = new Game3(1, 2, 8, 5, 7, 0, 6, 3, 4);
            Point coord = game.GetLocation(2);
            //string path = "C:\\Users\\user\\Desktop\\GameFromFile.csv";
            // Game.GameFromCSV(path);
            Show(game);
            Console.WriteLine("Координаты 2: " + coord.X + "," + coord.Y);
            Console.WriteLine("Выберите число, которое хотите передвинуть: ");
            var temp = Convert.ToInt32(Console.ReadLine());
            game.Shift(temp);
            Show(game);
            //game.Shift(2);
            Console.WriteLine("Введите число шагов, на которе хотите откатиться: ");
            var step = Convert.ToInt32(Console.ReadLine());
            game.Reverse(step);
            Show(game);
            Console.ReadLine();
        }

        public static void Show(Game game)
        {
            for (int i = 0; i < game.FieldGame.GetLength(0); i++)
            {
                for (int j = 0; j < game.FieldGame.GetLength(1); j++)
                {
                    Console.Write(game.FieldGame[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}