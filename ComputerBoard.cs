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
        Stack<BoardCheck> stackBoardChecks = new Stack<BoardCheck>();
        List<BoardCheck> ListLeftUpBoard = new List<BoardCheck>();
        List<BoardCheck> ListLeftBoard = new List<BoardCheck>();
        List<BoardCheck> ListLeftDownBoard = new List<BoardCheck>();
        List<BoardCheck> ListUpBoard = new List<BoardCheck>();
        List<BoardCheck> ListDownBoard = new List<BoardCheck>();
        List<BoardCheck> ListRightUpBoard = new List<BoardCheck>();
        List<BoardCheck> ListRightBoard = new List<BoardCheck>();
        List<BoardCheck> ListRightDownBoard = new List<BoardCheck>();

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
            splayerboard[3, 4] = "W";
            splayerboard[4, 3] = "W";
            splayerboard[4, 4] = "B";

        }
        //플레이어가 수를 두었을때 ComputerBoard 보드 업데이트 
        public void ComputerBoardUpdqte(PlayerBoard pb)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (pb.splayerboard[y, x] == "B" || pb.splayerboard[y, x] == "W")
                    {
                        splayerboard[y, x] = pb.splayerboard[y, x];
                    }
                    else
                    {
                        splayerboard[y, x] = "0";
                    }
                }
            }
        }


        //둘 수 있는 곳 셋팅
        public void SettingBoard()
        {

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (splayerboard[y, x] == "W")
                    {
                        CreateBoardCheck(y, x);
                    }
                }
            }

            while (stackBoardChecks.Count > 0)
            {
                BoardCheck bc;
                bc = stackBoardChecks.Pop();
                GoBoardCheck(bc.y, bc.x, bc);
            }

            System.Console.WriteLine("TEST");

        }

        //스택 쌓기 
        void CreateBoardCheck(int y, int x)
        {

            if(y - 1 > -1 && x - 1 > -1 )
            {
                if (splayerboard[y - 1, x - 1] == "B")
                {
                    //↖ 
                    BoardCheck bc = new BoardCheck();
                    bc.init(y - 1, x - 1, 1, "LEFT_UP");
                    stackBoardChecks.Push(bc);
                }

            }

            if(x - 1 > -1)
            {
                if (splayerboard[y, x - 1] == "B")
                {
                    //←
                    BoardCheck bc = new BoardCheck();
                    bc.init(y, x - 1, 1, "LEFT");
                    stackBoardChecks.Push(bc);

                }

            }

            if( y + 1 < 8 && x - 1 > - 1)
            {
                if (splayerboard[y + 1, x - 1] == "B")
                {
                    //↙
                    BoardCheck bc = new BoardCheck();
                    bc.init(y + 1, x - 1, 1, "LEFT_DOWN");
                    stackBoardChecks.Push(bc);
                }
            }

            if(y - 1 > -1)
            {
                if (splayerboard[y - 1, x] == "B")
                {
                    //↑
                    BoardCheck bc = new BoardCheck();
                    bc.init(y - 1, x, 1, "UP");
                    stackBoardChecks.Push(bc);

                }

            }

            if(y + 1 < 8)
            {
                if (splayerboard[y + 1, x] == "B")
                {
                    //↓
                    BoardCheck bc = new BoardCheck();
                    bc.init(y + 1, x, 1, "DOWN");
                    stackBoardChecks.Push(bc);

                }

            }

            if(y - 1 > -1 && x + 1 < 8)
            {
                if (splayerboard[y - 1, x + 1] == "B")
                {
                    //↗
                    BoardCheck bc = new BoardCheck();
                    bc.init(y - 1, x + 1, 1, "RIGHT_UP");
                    stackBoardChecks.Push(bc);

                }

            }

            if(x + 1 < 8)
            {
                if (splayerboard[y, x + 1] == "B")
                {
                    //→
                    BoardCheck bc = new BoardCheck();
                    bc.init(y, x + 1, 1, "RIGHT");
                    stackBoardChecks.Push(bc);

                }

            }

            if(y + 1 < 8 && x + 1 < 8)
            {
                if (splayerboard[y + 1, x + 1] == "B")
                {
                    //↘
                    BoardCheck bc = new BoardCheck();
                    bc.init(y + 1, x + 1, 1, "RIGHT_DOWN");
                    stackBoardChecks.Push(bc);

                }

            }

        }



        //정해진 방향에 하얀돌이 있는가?
        public void GoBoardCheck(int y, int x, BoardCheck bch)
        {
            switch (bch.voctor)
            {
                case "LEFT_UP":

                    if(y - 1 > -1 && x - 1 > -1)
                    {
                        if (splayerboard[y - 1, x - 1] == "B")
                        {
                            //↖ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y - 1, x - 1, bch.count + 1, "LEFT_UP");
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y - 1, x - 1] == "W")
                        {
                            break;
                        }
                        else
                        {
                            splayerboard[y - 1, x - 1] = Convert.ToString(bch.count);
                        }
                    }

                    break;

                case "LEFT":
                    if(x - 1 > -1)
                    {
                        if (splayerboard[y, x - 1] == "B")
                        {
                            //↖ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y, x - 1, bch.count + 1, "LEFT");
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y, x - 1] == "W")
                        {
                            break;
                        }
                        else
                        {
                            splayerboard[y, x - 1] = Convert.ToString(bch.count);
                        }
                    }
                    break;

                case "LEFT_DOWN":
                    
                    if(y + 1 < 8 && x - 1 > -1)
                    {
                        if (splayerboard[y + 1, x - 1] == "B")
                        {
                            //↖ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y + 1, x - 1, bch.count + 1, "LEFT_DOWN");
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y + 1, x - 1] == "W")
                        {
                            break;
                        }
                        else
                        {
                            splayerboard[y + 1, x - 1] = Convert.ToString(bch.count);
                        }

                    }
                    break;

                case "UP":

                    if(y - 1 > -1)
                    {
                        if (splayerboard[y - 1, x] == "B")
                        {
                            //↖ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y - 1, x, bch.count + 1, "UP");
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y - 1, x] == "W")
                        {
                            break;
                        }
                        else
                        {
                            splayerboard[y - 1, x] = Convert.ToString(bch.count);
                        }
                    }

                    break;

                case "DOWN":

                    if( y + 1 < 8 )
                    {
                        if (splayerboard[y + 1, x] == "B")
                        {
                            //↖ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y + 1, x, bch.count + 1, "DOWN");
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y + 1, x] == "W")
                        {
                            break;
                        }
                        else
                        {
                            splayerboard[y + 1, x] = Convert.ToString(bch.count);
                        }
                    }

                    break;

                case "RIGHT_UP":

                    if(y - 1 > -1 && x + 1 < 8)
                    {
                        if (splayerboard[y - 1, x + 1] == "B")
                        {
                            //↗ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y - 1, x + 1, bch.count + 1, "RIGHT_UP");
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y - 1, x + 1] == "W")
                        {
                            break;
                        }
                        else
                        {
                            splayerboard[y - 1, x + 1] = Convert.ToString(bch.count);
                        }
                    }

                    break;

                case "RIGHT":

                    if(x + 1 < 8)
                    {
                        if (splayerboard[y, x + 1] == "B")
                        {
                            //↖ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y, x + 1, bch.count + 1, "RIGHT");
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y, x + 1] == "W")
                        {
                            break;
                        }
                        else
                        {
                            splayerboard[y, x + 1] = Convert.ToString(bch.count);
                        }
                    }

                    break;

                case "RIGHT_DOWN":

                    if(y + 1 < 8 && x + 1 < 8)
                    {
                        if (splayerboard[y + 1, x + 1] == "B")
                        {
                            //↖ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y + 1, x + 1, bch.count + 1, "RIGHT_DOWN");
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y + 1, x + 1] == "W")
                        {
                            break;
                        }
                        else
                        {
                            splayerboard[y + 1, x + 1] = Convert.ToString(bch.count);
                        }
                    }
 
                    break;

                default:
                    break;
            }

        }

        //돌이 뒤집어짐
        public void ReverseStone(int y, int x)
        {
            if(y - 1 > -1 && x - 1 > -1)
            {
                if (splayerboard[y - 1, x - 1] == "B")
                {
                    //↖ 
                    BoardCheck bc = new BoardCheck();
                    bc.init(y - 1, x - 1, 1, "LEFT_UP");
                    ListLeftUpBoard.Add(bc);
                    stackBoardChecks.Push(bc);
                }
            }    

            if (x - 1 > -1)
            {
                if (splayerboard[y, x - 1] == "B")
                {
                    //←
                    BoardCheck bc = new BoardCheck();
                    bc.init(y, x - 1, 1, "LEFT");
                    ListLeftBoard.Add(bc);
                    stackBoardChecks.Push(bc);

                }

            }

            if( y + 1 < 8 && x - 1 > -1)
            {
                if (splayerboard[y + 1, x - 1] == "B")
                {
                    //↙
                    BoardCheck bc = new BoardCheck();
                    bc.init(y + 1, x - 1, 1, "LEFT_DOWN");
                    ListLeftDownBoard.Add(bc);
                    stackBoardChecks.Push(bc);
                }

            }

            if(y - 1 > - 1)
            {
                if (splayerboard[y - 1, x] == "B")
                {
                    //↑
                    BoardCheck bc = new BoardCheck();
                    bc.init(y - 1, x, 1, "UP");
                    ListUpBoard.Add(bc);
                    stackBoardChecks.Push(bc);

                }

            }

            if(y + 1 < 8)
            {
                if (splayerboard[y + 1, x] == "B")
                {
                    //↓
                    BoardCheck bc = new BoardCheck();
                    bc.init(y + 1, x, 1, "DOWN");
                    ListDownBoard.Add(bc);
                    stackBoardChecks.Push(bc);

                }

            }

            if(y - 1 > -1 && x + 1 < 8)
            {
                if (splayerboard[y - 1, x + 1] == "B")
                {
                    //↗
                    BoardCheck bc = new BoardCheck();
                    bc.init(y - 1, x + 1, 1, "RIGHT_UP");
                    ListRightUpBoard.Add(bc);
                    stackBoardChecks.Push(bc);

                }
            }
 
            if(x + 1 < 8)
            {
                if (splayerboard[y, x + 1] == "B")
                {
                    //→
                    BoardCheck bc = new BoardCheck();
                    bc.init(y, x + 1, 1, "RIGHT");
                    ListRightBoard.Add(bc);
                    stackBoardChecks.Push(bc);

                }
            }
 
            if(y + 1 < 8 && x + 1 < 8)
            {
                if (splayerboard[y + 1, x + 1] == "B")
                {
                    //↘
                    BoardCheck bc = new BoardCheck();
                    bc.init(y + 1, x + 1, 1, "RIGHT_DOWN");
                    ListRightDownBoard.Add(bc);
                    stackBoardChecks.Push(bc);

                }

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

            switch (bch.voctor)
            {
                case "LEFT_UP":

                    if(y - 1 > -1 && x - 1 > -1 )
                    {
                        if (splayerboard[y - 1, x - 1] == "B")
                        {
                            //↖ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y - 1, x - 1, bc.count++, "LEFT_UP");
                            ListLeftUpBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y - 1, x - 1] == "W")
                        {
                            System.Console.Write("Computer LEFT_UP ");
                            for (int i = 0; i < ListLeftUpBoard.Count; i++)
                            {
                                splayerboard[ListLeftUpBoard[i].y, ListLeftUpBoard[i].x] = "W";
                                System.Console.Write(" ({0},{1}) ", ListLeftUpBoard[i].y, ListLeftUpBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }
                    }

                    break;

                case "LEFT":

                    if(x - 1 > -1)
                    {
                        if (splayerboard[y, x - 1] == "B")
                        {
                            //← 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y, x - 1, bc.count++, "LEFT");
                            ListLeftBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y, x - 1] == "W")
                        {
                            System.Console.Write("Computer LEFT ");
                            for (int i = 0; i < ListLeftBoard.Count; i++)
                            {
                                splayerboard[ListLeftBoard[i].y, ListLeftBoard[i].x] = "W";
                                System.Console.Write(" ({0},{1}) ", ListLeftBoard[i].y, ListLeftBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }
                    }
 
                    break;

                case "LEFT_DOWN":
                    
                    if(y + 1 < 8 && x - 1 > -1)
                    {
                        if (splayerboard[y + 1, x - 1] == "B")
                        {
                            //↙ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y + 1, x - 1, bc.count++, "LEFT_DOWN");
                            ListLeftDownBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y + 1, x - 1] == "W")
                        {
                            System.Console.Write("Computer LEFT_DOWN ");
                            for (int i = 0; i < ListLeftDownBoard.Count; i++)
                            {
                                splayerboard[ListLeftDownBoard[i].y, ListLeftDownBoard[i].x] = "W";
                                System.Console.Write(" ({0},{1}) ", ListLeftDownBoard[i].y, ListLeftDownBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }
                    }

                    break;

                case "UP":

                    if(y - 1 > -1)
                    {
                        if (splayerboard[y - 1, x] == "B")
                        {
                            //↑
                            BoardCheck bc = new BoardCheck();
                            bc.init(y - 1, x, bc.count++, "UP");
                            ListUpBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y - 1, x] == "W")
                        {
                            System.Console.Write("Computer UP ");
                            for (int i = 0; i < ListUpBoard.Count; i++)
                            {
                                splayerboard[ListUpBoard[i].y, ListUpBoard[i].x] = "W";
                                System.Console.Write(" ({0},{1}) ", ListUpBoard[i].y, ListUpBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }
                    }
 
                    break;

                case "DOWN":
                    
                    if(y + 1 < 8)
                    {
                        if (splayerboard[y + 1, x] == "B")
                        {
                            //↖ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y + 1, x, bc.count++, "DOWN");
                            ListDownBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y + 1, x] == "W")
                        {
                            System.Console.Write("Computer DOWN ");
                            for (int i = 0; i < ListDownBoard.Count; i++)
                            {
                                splayerboard[ListDownBoard[i].y, ListDownBoard[i].x] = "W";
                                System.Console.Write(" ({0},{1}) ", ListDownBoard[i].y, ListDownBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }
                    }

                    break;

                case "RIGHT_UP":

                    if(y - 1 > -1 && x + 1 < 8)
                    {
                        if (splayerboard[y - 1, x + 1] == "B")
                        {
                            //↗ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y - 1, x + 1, bc.count++, "RIGHT_UP");
                            ListRightUpBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y - 1, x + 1] == "W")
                        {
                            System.Console.Write("Computer RIGHT_UP ");
                            for (int i = 0; i < ListRightUpBoard.Count; i++)
                            {
                                splayerboard[ListRightUpBoard[i].y, ListRightUpBoard[i].x] = "W";
                                System.Console.Write(" ({0},{1}) ", ListRightUpBoard[i].y, ListRightUpBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }
                    }

                    break;

                case "RIGHT":

                    if(x + 1 < 8)
                    {
                        if (splayerboard[y, x + 1] == "B")
                        {
                            //→ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y, x + 1, bc.count++, "RIGHT");
                            ListRightBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y, x + 1] == "W")
                        {
                            System.Console.Write("Computer RIGHT ");
                            for (int i = 0; i < ListRightBoard.Count; i++)
                            {
                                splayerboard[ListRightBoard[i].y, ListRightBoard[i].x] = "W";
                                System.Console.Write(" ({0},{1}) ", ListRightBoard[i].y, ListRightBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }
                    }
 
                    break;

                case "RIGHT_DOWN":

                    if(y + 1 < 8 && x + 1 < 8)
                    {
                        if (splayerboard[y + 1, x + 1] == "B")
                        {
                            //↘ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y + 1, x + 1, bc.count++, "RIGHT_DOWN");
                            ListRightDownBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y + 1, x + 1] == "W")
                        {
                            System.Console.Write("Computer RIGHT_DOWN ");
                            for (int i = 0; i < ListRightDownBoard.Count; i++)
                            {
                                splayerboard[ListRightDownBoard[i].y, ListRightDownBoard[i].x] = "W";
                                System.Console.Write(" ({0},{1}) ", ListRightDownBoard[i].y, ListRightDownBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }
                    }


                    break;

                default:
                    break;
            }
        }
    
    

        public void ReSetBoardList()
        {
            ListLeftUpBoard.Clear();
            ListLeftBoard.Clear();
            ListLeftDownBoard.Clear();
            ListUpBoard.Clear();
            ListDownBoard.Clear();
            ListRightUpBoard.Clear();
            ListRightBoard.Clear();
            ListRightDownBoard.Clear();
        }
    
    }
}
