using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    class ComputerBoard
    {

        public String[,] splayerboard = new String[8, 8];

        //컴퓨터 보는 것
        //00000000
        //00000000
        //00000100
        //000bw100
        //000bw100
        //00000100
        //00000000
        //00000000

        public void CreateBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    splayerboard[i, j] = "0";
                }
            }

            splayerboard[3, 3] = "B";
            splayerboard[3, 4] = "B";
            splayerboard[4, 3] = "W";
            splayerboard[4, 4] = "W";

        }
        //플레이어가 수를 두었을때 내 보드 업데이트 

        //둘 수 있는 곳 셋팅

        //돌이 뒤집어짐

    }
}
