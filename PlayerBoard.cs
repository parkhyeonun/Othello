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
            splayerboard[3, 4] = "W";
            splayerboard[4, 3] = "W";
            splayerboard[4, 4] = "B";

        }


        //컴퓨터가 수를 두었을때 내 보드 업데이트 

        //둘 수 있는 곳 셋팅
        public void SettingBoard()
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
                GoBoardCheck(bc.y, bc.x, bc);
            }

            System.Console.WriteLine("TEST");

        }

        //스택 쌓기 
        void CreateBoardCheck(int y , int x )
        {
            if (splayerboard[y - 1, x - 1] == "W")
            {
                //↖ 
                BoardCheck bc = new BoardCheck();
                bc.init(y - 1, x - 1, 1, "LEFT_UP");
                stackBoardChecks.Push(bc);
            }
            if (splayerboard[y, x - 1] == "W")
            {
                //←
                BoardCheck bc = new BoardCheck();
                bc.init(y, x - 1, 1, "LEFT");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[y + 1, x - 1] == "W")
            {
                //↙
                BoardCheck bc = new BoardCheck();
                bc.init(y + 1, x - 1, 1, "LEFT_DOWN");
                stackBoardChecks.Push(bc);
            }
            if (splayerboard[y - 1, x] == "W")
            {
                //↑
                BoardCheck bc = new BoardCheck();
                bc.init(y - 1, x, 1, "UP");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[y + 1, x] == "W")
            {
                //↓
                BoardCheck bc = new BoardCheck();
                bc.init(y + 1, x, 1, "DOWN");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[y - 1, x + 1] == "W")
            {
                //↗
                BoardCheck bc = new BoardCheck();
                bc.init(y - 1, x + 1, 1, "RIGHT_UP");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[y, x + 1] == "W")
            {
                //→
                BoardCheck bc = new BoardCheck();
                bc.init(y, x + 1, 1, "RIGHT");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[y + 1, x + 1] == "W")
            {
                //↘
                BoardCheck bc = new BoardCheck();
                bc.init(y + 1, x + 1, 1, "RIGHT_DOWN");
                stackBoardChecks.Push(bc);

            }
        }



        //정해진 방향에 하얀돌이 있는가?
        public void GoBoardCheck(int y , int x , BoardCheck bch)
        {
            switch (bch.voctor)
            {
                case "LEFT_UP" :

                    if (splayerboard[y - 1, x - 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y - 1, x - 1, bc.count++, "LEFT_UP");
                        stackBoardChecks.Push(bc);
                    }
                    else if(splayerboard[y - 1, x - 1] == "B")
                    {
                        break;
                    }
                    else
                    {
                        splayerboard[y - 1, x - 1] = Convert.ToString(bch.count);
                    }
                    break;

                case "LEFT":
                    if (splayerboard[y, x - 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y, x - 1, bc.count++, "LEFT");
                        stackBoardChecks.Push(bc);
                    }
                    else if (splayerboard[y, x - 1] == "B")
                    {
                        break;
                    }
                    else
                    {
                        splayerboard[y, x - 1] = Convert.ToString(bch.count);
                    }
                    break;

                case "LEFT_DOWN":
                    if (splayerboard[y + 1, x - 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y + 1, x - 1, bc.count++, "LEFT_DOWN");
                        stackBoardChecks.Push(bc);
                    }
                    else if (splayerboard[y + 1, x - 1] == "B")
                    {
                        break;
                    }
                    else
                    {
                        splayerboard[y + 1, x - 1] = Convert.ToString(bch.count);
                    }
                    break;

                case "UP":
                    if (splayerboard[y - 1, x] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y - 1, x, bc.count++, "UP");
                        stackBoardChecks.Push(bc);
                    }
                    else if (splayerboard[y - 1, x] == "B")
                    {
                        break;
                    }
                    else
                    {
                        splayerboard[y - 1, x] = Convert.ToString(bch.count);
                    }
                    break;

                case "DOWN":
                    if (splayerboard[y + 1, x] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y + 1, x, bc.count++, "DOWN");
                        stackBoardChecks.Push(bc);
                    }
                    else if (splayerboard[y + 1, x] == "B")
                    {
                        break;
                    }
                    else
                    {
                        splayerboard[y + 1, x] = Convert.ToString(bch.count);
                    }
                    break;

                case "RIGHT_UP":
                    if (splayerboard[y - 1, x + 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y - 1, x + 1, bc.count++, "RIGHT_UP");
                        stackBoardChecks.Push(bc);
                    }
                    else if (splayerboard[y - 1, x + 1] == "B")
                    {
                        break;
                    }
                    else
                    {
                        splayerboard[y - 1, x + 1] = Convert.ToString(bch.count);
                    }
                    break;

                case "RIGHT":
                    if (splayerboard[y, x + 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y, x - 1, bc.count++, "RIGHT");
                        stackBoardChecks.Push(bc);
                    }
                    else if (splayerboard[y, x + 1] == "B")
                    {
                        break;
                    }
                    else
                    {
                        splayerboard[y, x + 1] = Convert.ToString(bch.count);
                    }
                    break;

                case "RIGHT_DOWN":
                    if (splayerboard[y + 1, x + 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y + 1, x + 1, bc.count++, "RIGHT_DOWN");
                        stackBoardChecks.Push(bc);
                    }
                    else if (splayerboard[y + 1, x + 1] == "B")
                    {
                        break;
                    }
                    else
                    {
                        splayerboard[y + 1, x + 1] = Convert.ToString(bch.count);
                    }
                    break;

                default:
                    break;
            }

        }



        public void ReverseStone(int y, int x)
        {
            if (splayerboard[y - 1, x - 1] == "W")
            {
                //↖ 
                BoardCheck bc = new BoardCheck();
                bc.init(y - 1, x - 1, 1, "LEFT_UP");
                stackBoardChecks.Push(bc);
            }
            if (splayerboard[y, x - 1] == "W")
            {
                //←
                BoardCheck bc = new BoardCheck();
                bc.init(y, x - 1, 1, "LEFT");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[y + 1, x - 1] == "W")
            {
                //↙
                BoardCheck bc = new BoardCheck();
                bc.init(y + 1, x - 1, 1, "LEFT_DOWN");
                stackBoardChecks.Push(bc);
            }
            if (splayerboard[y - 1, x] == "W")
            {
                //↑
                BoardCheck bc = new BoardCheck();
                bc.init(y - 1, x, 1, "UP");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[y + 1, x] == "W")
            {
                //↓
                BoardCheck bc = new BoardCheck();
                bc.init(y + 1, x, 1, "DOWN");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[y - 1, x + 1] == "W")
            {
                //↗
                BoardCheck bc = new BoardCheck();
                bc.init(y - 1, x + 1, 1, "RIGHT_UP");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[y, x + 1] == "W")
            {
                //→
                BoardCheck bc = new BoardCheck();
                bc.init(y, x + 1, 1, "RIGHT");
                stackBoardChecks.Push(bc);

            }
            if (splayerboard[y + 1, x + 1] == "W")
            {
                //↘
                BoardCheck bc = new BoardCheck();
                bc.init(y + 1, x + 1, 1, "RIGHT_DOWN");
                stackBoardChecks.Push(bc);

            }


            while (stackBoardChecks.Count > 0)
            {
                BoardCheck bc;
                bc = stackBoardChecks.Pop();
                GoReversCheck(bc.y, bc.x, bc);
            }

        }

        public void GoReversCheck(int y, int x, BoardCheck bch)
        {
            splayerboard[y, x] = "B";

            switch (bch.voctor)
            {
                case "LEFT_UP":

                    if (splayerboard[y - 1, x - 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y - 1, x - 1, bc.count++, "LEFT_UP");
                        splayerboard[y, x] = "B";
                        stackBoardChecks.Push(bc);
                    }
                    break;

                case "LEFT":
                    
                    if (splayerboard[y, x - 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y, x - 1, bc.count++, "LEFT");
                        stackBoardChecks.Push(bc);
                    }
                    break;

                case "LEFT_DOWN":
                    if (splayerboard[y + 1, x - 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y + 1, x - 1, bc.count++, "LEFT_DOWN");
                        splayerboard[y, x] = "B";
                        stackBoardChecks.Push(bc);
                    }
                    break;

                case "UP":
                    if (splayerboard[y - 1, x] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y - 1, x, bc.count++, "UP");
                        splayerboard[y, x] = "B";
                        stackBoardChecks.Push(bc);
                    }
                    break;

                case "DOWN":
                    if (splayerboard[y + 1, x] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y + 1, x, bc.count++, "DOWN");
                        splayerboard[y, x] = "B";
                        stackBoardChecks.Push(bc);
                    }
                    break;

                case "RIGHT_UP":
                    if (splayerboard[y - 1, x + 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y - 1, x + 1, bc.count++, "RIGHT_UP");
                        splayerboard[y, x] = "B";
                        stackBoardChecks.Push(bc);
                    }
                    break;

                case "RIGHT":
                    if (splayerboard[y, x + 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y, x - 1, bc.count++, "RIGHT");
                        splayerboard[y, x] = "B";
                        stackBoardChecks.Push(bc);
                    }
                    break;

                case "RIGHT_DOWN":
                    if (splayerboard[y + 1, x + 1] == "W")
                    {
                        //↖ 
                        BoardCheck bc = new BoardCheck();
                        bc.init(y + 1, x + 1, bc.count++, "RIGHT_DOWN");
                        splayerboard[y, x] = "B";
                        stackBoardChecks.Push(bc);
                    }
                    break;

                default:
                    break;
            }
        }
        //돌이 뒤집어짐

        //get , set


    }
}
