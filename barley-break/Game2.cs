using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    class Game2:Game
    {
        public Game2(params int[] mass) :base(mass) { }
        public void Random()
        {
            Random gen = new Random();
            for (int i =0; i < FieldGame.Length; i++ )
            {
                base.Shift(gen.Next(1, PointGame.Length - 1));
            }
        }
        public bool IsEnd()
        {
            int k = 1;
            for (int x = 0; x < FieldGame.GetLength(0); x++)
            {
                for (int y = 0; y < FieldGame.GetLength(1); y++)
                {
                    if (FieldGame[x, y] != k&& k < FieldGame.Length)
                    {
                        return false;
                    }
                    k++;
                }
            }
            return true;
        }

    }
}
