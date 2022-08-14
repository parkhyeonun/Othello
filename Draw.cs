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
            for (int i = 0; i < 8; i++)
            {
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
