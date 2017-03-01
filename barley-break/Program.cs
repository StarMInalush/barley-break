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
            Game game = new Game(1, 2, 8, 5, 7, 0, 6, 3, 4);
            Point coord = game.GetLocation(2);
            string path = "C:\\Users\\user\\Desktop\\GameFromFile.csv";
            Game.GameFromCSV(path);
            Console.WriteLine("Координаты 2: " + coord.X + "," + coord.Y);
            game.Shift(8);
           // game.Shift(2);
            Console.ReadLine();
        }
    }
}
