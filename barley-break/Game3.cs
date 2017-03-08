using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    class Game3 : Game2
    {
        private Stack<int> Journal;
        public Game3(params int[] mass) : base(mass)
        {
            Journal = new Stack<int>();
        }
        public override void Shift(int value)
        {
            Journal.Push(value);
            base.Shift(value);
        }
        public void Reverse(int value)
        {
            if (value > Journal.Count)
            {
                throw new ArgumentException("Вы не можете откатиться на заданное число шагов!");
            }
            for (int i = 0; i < value; i++)
            {
                base.Shift(Journal.Pop());
            }
        }

    }
}
