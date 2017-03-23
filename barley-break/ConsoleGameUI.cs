using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    class ConsoleGameUI
    {
        IPlayable game = new Game3();

        public static void Show(Game3 game)
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

        public static void Play(Game3 game)
        {
            var temp = Convert.ToInt32(Console.ReadLine());
            game.Shift(temp);
        }
    }
}
