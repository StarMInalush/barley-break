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
            Show();
            do
            { 
                int temp = getValue();
                game.Shift(temp);
                Show();
                
            } while (!game.IsFinished());
            Console.WriteLine("Игра окончена!");
        }
        private int getValue()
        {
            int value = 0;
            Console.WriteLine("Введите число от 1 до " + (game.Size * game.Size - 1) + " : ");
            bool sucessConvert = int.TryParse(Console.ReadLine(), out value);
            if (!sucessConvert || value < 1 || value >= game.Size * game.Size)
            {
                Console.WriteLine("Неверный ввод! Попробуйте еще раз!");
                return getValue();
               
            }
            return value;
        }
    
    }
}
