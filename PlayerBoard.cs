using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    class PlayerBoard
    {
        public String[,] splayerboard = new String[8, 8];
        bool[] visited = new bool[8];
        List<int> listIntX = new List<int>();
        List<int> listIntY = new List<int>();
        Stack<BoardCheck> stackBoardChecks = new Stack<BoardCheck>();

        //사람이 보는 것
        //00000000
        //00000000
        //00100000
        //001bw000
        //001bw000
        //00100000
        //00000000
        //00000000

        //오델로 판 만들기
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
            splayerboard[4, 3] = "B";
            splayerboard[3, 4] = "W";
            splayerboard[4, 4] = "W";

        }

        //컴퓨터가 수를 두었을때 내 보드 업데이트 

        //둘 수 있는 곳 셋팅
        public void SettingBoard(int num)
        { 

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(splayerboard[i, j] == "B")
                    {
                        CreateBoardCheck(i, j);
                    }
                }
            }

            while(stackBoardChecks.Count > 0)
            {                
                BoardCheck bc;
                bc = stackBoardChecks.Pop();
                GoBoardCheck(bc.x, bc.y, bc);
            }

            System.Console.WriteLine("TEST");

        }

        //스택 쌓기 
        void CreateBoardCheck(int x , int y)
        {
            if (splayerboard[x - 1, y - 1] == "W")
            {
                //↖ 
                BoardCheck bc = new BoardCheck();
                bc.init(x - 1, y - 1, 1, "LEFT_UP");
                stackBoardChecks.Push(bc);
            }
            if (splayerboard[x, y - 1] == "W")
            {
                //←
                BoardCheck bc = new BoardCheck();
                bc.init(x, y - 1, 1, "LEFT");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[x + 1, y - 1] == "W")
            {
                //↙
                BoardCheck bc = new BoardCheck();
                bc.init(x, y - 1, 1, "LEFT_DOWN");
                stackBoardChecks.Push(bc);
            }
            if (splayerboard[x - 1, y] == "W")
            {
                //↑
                BoardCheck bc = new BoardCheck();
                bc.init(x, y - 1, 1, "UP");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[x + 1, y] == "W")
            {
                //↓
                BoardCheck bc = new BoardCheck();
                bc.init(x, y - 1, 1, "DOWN");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[x - 1, y + 1] == "W")
            {
                //↗
                BoardCheck bc = new BoardCheck();
                bc.init(x, y - 1, 1, "RIGHT_UP");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[x, y + 1] == "W")
            {
                //→
                BoardCheck bc = new BoardCheck();
                bc.init(x, y - 1, 1, "RIGHT");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[x + 1, y + 1] == "W")
            {
                //↘
                BoardCheck bc = new BoardCheck();
                bc.init(x, y - 1, 1, "RIGHT_DOWN");
                stackBoardChecks.Push(bc);

            }
        }

        //정해진 방향에 하얀돌이 있는가?
        public void GoBoardCheck(int x , int y , BoardCheck bch)
        {
            switch (bch.voctor)
            {
                case "LEFT_UP" :

                    if (splayerboard[x - 1, y - 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(x - 1, y - 1, bc.count++, "LEFT_UP");
                        stackBoardChecks.Push(bc);
                    }
                    else if(splayerboard[x - 1, y - 1] == "B")
                    {
                        break;
                    }
                    else
                    {
                        splayerboard[x - 1, y - 1] = Convert.ToString(bch.count);
                    }
                    break;

                case "LEFT":
                    break;

                case "LEFT_DOWN":
                    break;

                case "UP":
                    break;

                case "DOWN":
                    break;

                case "RIGHT_UP":
                    break;

                case "RIGHT":
                    break;

                case "RIGHT_DOWN":
                    break;

                default:
                    break;
            }
        }




        //돌이 뒤집어짐

        //get , set


    }
}
