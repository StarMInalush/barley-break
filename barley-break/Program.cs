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
            int[] arguments = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            Game game = new Game(arguments);
            int[] coord = game.GetLocation(2);
            Console.WriteLine("Координаты 2: " + coord[0] + "," + coord[1]);
            Console.WriteLine("Для управления методом Shift используйте клавиши W, A, D, S");
            game.Shift(8);
            Console.ReadLine();
        }
    }
}
