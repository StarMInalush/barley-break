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
            // Game game = new Game(1, 2, 8, 5, 7, 0, 6, 3, 4);
            // Point coord = game.GetLocation(2);
            // string path = "C:\\Users\\user\\Desktop\\GameFromFile.csv";
            // Game.GameFromCSV(path);
            // Console.WriteLine("Координаты 2: " + coord.X + "," + coord.Y);
            // game.Shift(8);
            //// game.Shift(2);
            Game3 game = new Game3 (1, 2, 3, 4, 5, 6, 7, 8,0);
            game.Random();
            do
            {
                Console.Clear();
                game.Show();
                Console.WriteLine("Введите число: ");
                var temp = Convert.ToInt32(Console.ReadLine());
                game.Shift(temp);
                game.Show();
                Console.WriteLine("Сделать откат:");
                var temp1 = Convert.ToInt32(Console.ReadLine());
                game.Reverse(temp1);
                game.Show();
            } while (!game.IsEnd());
            Console.WriteLine("Вы выиграли!");
            Console.ReadLine();
        }
    }
}
