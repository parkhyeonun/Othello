using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    class Draw
    {

        //플레이어 기준 그리기
        public void DrawBoard(PlayerBoard board)
        {
            System.Console.WriteLine(" 0 1 2 3 4 5 6 7");
            for (int i = 0; i < 8; i++)
            {
                System.Console.Write(i);
                for (int j = 0; j < 8; j++)
                {
                    switch (board.splayerboard[i,j])
                    {
                        case "B":
                            System.Console.Write("●");
                            break;
                        case "W":
                            System.Console.Write("○");
                            break;
                        default:
                            System.Console.Write("□");
                            break;
                    }
                }
                System.Console.WriteLine();
            }
        }
    
    }
}
