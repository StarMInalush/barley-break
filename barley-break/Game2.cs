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
            for (int i = 0; i < 100; i++)
            {
                Point zero = GetLocation(0);
                if (zero.Y == 0 && (zero.X >= 0 && zero.X < FieldGame.GetLength(0)))
                {
                    Shift(FieldGame[zero.X, zero.Y + 1]);
                    break;
                }
                else {
                    if (zero.X == FieldGame.GetLength(0) - 1 && (zero.Y > 0 && zero.Y < FieldGame.GetLength(1)))
                    {
                        Shift(FieldGame[zero.X, zero.Y - 1]);
                        break;
                    }

                    else
                    {
                        if (zero.X == 0 && (zero.Y > 0 && zero.Y < FieldGame.GetLength(1)))
                        {
                            Shift(FieldGame[zero.X + 1, zero.Y]);
                        }
                        else
                        {
                            Shift(FieldGame[zero.X - 1, zero.Y]);
                            break;
                        }
                    }

                }

            }
        }
               

            
        public bool IsEnd()
        {
            int value = 1;
            for (int x = 0; x < FieldGame.GetLength(0); x++)
            {
                for (int y = 0; y < FieldGame.GetLength(1); y++)
                {
                    if (FieldGame[x, y] != value&& value < FieldGame.Length)
                    {
                        return false;
                    }
                    value++;
                }
            }
            return true;
        }

    }
}
