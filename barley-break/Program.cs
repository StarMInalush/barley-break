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
            ConsoleGameUI gui2 = new ConsoleGameUI((IPlayable) new Game2(0, 1, 2, 3));
            ConsoleGameUI gui3 = new ConsoleGameUI((IPlayable) new Game3(3, 2, 1, 0));
            gui2.Show();
            gui3.Show();
            Console.WriteLine("Введите число: ");
            gui.Play();
            gui.Show();
            Console.ReadLine();
        }

        
    }
}
