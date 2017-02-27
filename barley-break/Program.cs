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
            int[] mass = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            Game game = new Game(mass);
           game.GetLocation(2);
            game.Shift(8);
            Console.ReadKey();
        }
    }
}
