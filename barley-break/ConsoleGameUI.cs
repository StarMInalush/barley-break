using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    class ConsoleGameUI
    {
        private IPlayable game;
        
        public ConsoleGameUI(IPlayable game)
        {
            this.game = game;
        }
        
        public void Show()
        {
            Game2 temp = (Game2) game;
            for (int i = 0; i < temp.FieldGame.GetLength(0); i++)
            {
                for (int j = 0; j < temp.FieldGame.GetLength(1); j++)
                {
                    Console.Write(temp.FieldGame[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Play()
        {
            var temp = Convert.ToInt32(Console.ReadLine());
            game.Shift(temp);
        }
    }
}
