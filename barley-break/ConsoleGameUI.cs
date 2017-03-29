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

        protected void Show() // обращать только к интерфейу и вынести длину массива и поле через индекстатор
        {
            for (int i = 0; i < game.Size; i++)
            {
                for (int j = 0; j < game.Size; j++)
                {
                    Console.Write(game[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Play()//проверить ввод try parse
        {
            game.Randomize();
            int temp;

            do
            {
                Show();
                Console.WriteLine("Введите число: ");
                bool sucessConvert = int.TryParse(Console.ReadLine(), out temp);
                if (sucessConvert)
                {
                    game.Shift(temp);
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите число!");
                    Play();
                }
                Console.Clear();
                
            } while (!game.IsFinished());
            Console.WriteLine("Игра окончена!");
        }
    }
}
