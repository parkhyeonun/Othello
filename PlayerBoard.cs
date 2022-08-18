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
        List<BoardCheck> ListLeftUpBoard = new List<BoardCheck>();
        List<BoardCheck> ListLeftBoard = new List<BoardCheck>();
        List<BoardCheck> ListLeftDownBoard = new List<BoardCheck>();
        List<BoardCheck> ListUpBoard = new List<BoardCheck>();
        List<BoardCheck> ListDownBoard = new List<BoardCheck>();
        List<BoardCheck> ListRightUpBoard = new List<BoardCheck>();
        List<BoardCheck> ListRightBoard = new List<BoardCheck>();
        List<BoardCheck> ListRightDownBoard = new List<BoardCheck>();

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

        public void PlayerBoardUpdqte(ComputerBoard cb)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (cb.splayerboard[y, x] == "B" || cb.splayerboard[y, x] == "W")
                    {
                        splayerboard[y, x] = cb.splayerboard[y, x];
                    }
                    else
                    {
                        splayerboard[y, x] = "0";
                    }
                }
            }
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

        }

        //스택 쌓기 
        void CreateBoardCheck(int y , int x )
        {
            if(y - 1 > -1 && x - 1 > -1)
            {
                if (splayerboard[y - 1, x - 1] == "W")
                {
                    //↖ 
                    BoardCheck bc = new BoardCheck();
                    bc.init(y - 1, x - 1, 1, "LEFT_UP");
                    stackBoardChecks.Push(bc);
                }
            }

            if(x - 1 > -1)
            {
                if (splayerboard[y, x - 1] == "W")
                {
                    //←
                    BoardCheck bc = new BoardCheck();
                    bc.init(y, x - 1, 1, "LEFT");
                    stackBoardChecks.Push(bc);

                }

            }

            if(y + 1 < 8 && x -1 > - 1)
            {
                if (splayerboard[y + 1, x - 1] == "W")
                {
                    //↙
                    BoardCheck bc = new BoardCheck();
                    bc.init(y + 1, x - 1, 1, "LEFT_DOWN");
                    stackBoardChecks.Push(bc);
                }
            }

            if(y - 1 > -1 )
            {
                if (splayerboard[y - 1, x] == "W")
                {
                    //↑
                    BoardCheck bc = new BoardCheck();
                    bc.init(y - 1, x, 1, "UP");
                    stackBoardChecks.Push(bc);

                }
            }

            if(y + 1 < 8)
            {
                if (splayerboard[y + 1, x] == "W")
                {
                    //↓
                    BoardCheck bc = new BoardCheck();
                    bc.init(y + 1, x, 1, "DOWN");
                    stackBoardChecks.Push(bc);

                }
            }

            if(y - 1 > -1 && x + 1 < 8 )
            {
                if (splayerboard[y - 1, x + 1] == "W")
                {
                    //↗
                    BoardCheck bc = new BoardCheck();
                    bc.init(y - 1, x + 1, 1, "RIGHT_UP");
                    stackBoardChecks.Push(bc);

                }
            }

            if(x + 1 < 8)
            {
                if (splayerboard[y, x + 1] == "W")
                {
                    //→
                    BoardCheck bc = new BoardCheck();
                    bc.init(y, x + 1, 1, "RIGHT");
                    stackBoardChecks.Push(bc);

                }

            }

            if(y + 1 < 8 && x + 1 < 8)
            {
                if (splayerboard[y + 1, x + 1] == "W")
                {
                    //↘
                    BoardCheck bc = new BoardCheck();
                    bc.init(y + 1, x + 1, 1, "RIGHT_DOWN");
                    stackBoardChecks.Push(bc);

                }
            }

        }



        //정해진 방향에 하얀돌이 있는가?
        public void GoBoardCheck(int y , int x , BoardCheck bch)
        {
            switch (bch.voctor)
            {
                case "LEFT_UP" :

                    if(y - 1 > -1 && x - 1 > - 1)
                    {
                        if (splayerboard[y - 1, x - 1] == "W")
                        {
                            //↖ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y - 1, x - 1, bch.count + 1, "LEFT_UP");
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y - 1, x - 1] == "B")
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
                    
                    if(x-1 > -1)
                    {
                        if (splayerboard[y, x - 1] == "W")
                        {
                            //←
                            BoardCheck bc = new BoardCheck();
                            bc.init(y, x - 1, bch.count + 1, "LEFT");
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

                    }

                    break;

                case "LEFT_DOWN":

                    if(y+1 < 8 && x -1 > -1 )
                    {
                        if (splayerboard[y + 1, x - 1] == "W")
                        {
                            //↙ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y + 1, x - 1, bch.count + 1, "LEFT_DOWN");
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
                    }
                    break;

                case "UP":
                    if( y - 1 > -1)
                    {
                        if (splayerboard[y - 1, x] == "W")
                        {
                            //↑ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y - 1, x, bch.count + 1, "UP");
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

                    }
                    break;

                case "DOWN":
                    if( y + 1 < 8)
                    {
                        if (splayerboard[y + 1, x] == "W")
                        {
                            //↓ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y + 1, x, bch.count + 1, "DOWN");
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

                    }
                    break;

                case "RIGHT_UP":
                    if(y - 1 > -1 && x + 1 < 8)
                    {
                        if (splayerboard[y - 1, x + 1] == "W")
                        {
                            //↗ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y - 1, x + 1, bch.count + 1, "RIGHT_UP");
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
                    }
                    break;

                case "RIGHT":
                    if(x + 1 < 8)
                    {
                        if (splayerboard[y, x + 1] == "W")
                        {
                            //→ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y, x + 1, bch.count + 1, "RIGHT");
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
                    }
                    break;

                case "RIGHT_DOWN":
                    if(y + 1 < 8 && x + 1 < 8 )
                    {
                        if (splayerboard[y + 1, x + 1] == "W")
                        {
                            //↖ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y + 1, x + 1, bch.count + 1, "RIGHT_DOWN");
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
                    }
                    break;

                default:
                    break;
            }

        }



        public void ReverseStone(int y, int x)
        {
            if(y - 1 > -1 && x - 1 > -1)
            {
                if (splayerboard[y - 1, x - 1] == "W")
                {
                    //↖ 
                    BoardCheck bc = new BoardCheck();
                    bc.init(y - 1, x - 1, 1, "LEFT_UP");
                    ListLeftUpBoard.Add(bc);
                    stackBoardChecks.Push(bc);
                }

            }

            if(x - 1 > - 1)
            {
                if (splayerboard[y, x - 1] == "W")
                {
                    //←
                    BoardCheck bc = new BoardCheck();
                    bc.init(y, x - 1, 1, "LEFT");
                    ListLeftBoard.Add(bc);
                    stackBoardChecks.Push(bc);

                }

            }


            if( y + 1 < 8 && x - 1 > -1 )
            {
                if (splayerboard[y + 1, x - 1] == "W")
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
                if (splayerboard[y - 1, x] == "W")
                {
                    //↑
                    BoardCheck bc = new BoardCheck();
                    bc.init(y - 1, x, 1, "UP");
                    ListUpBoard.Add(bc);
                    stackBoardChecks.Push(bc);

                }

            }


            if (y + 1 < 8)
            {
                if (splayerboard[y + 1, x] == "W")
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
                if (splayerboard[y - 1, x + 1] == "W")
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
                if (splayerboard[y, x + 1] == "W")
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
                if (splayerboard[y + 1, x + 1] == "W")
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
                    
                    if(y - 1 > -1 && x - 1 > -1)
                    {
                        if (splayerboard[y - 1, x - 1] == "W")
                        {
                            //↖ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y - 1, x - 1, bc.count++, "LEFT_UP");
                            ListLeftUpBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y - 1, x - 1] == "B")
                        {
                            System.Console.Write("Player LEFT_UP ");
                            for (int i = 0; i < ListLeftUpBoard.Count; i++)
                            {
                                splayerboard[ListLeftUpBoard[i].y, ListLeftUpBoard[i].x] = "B";
                                System.Console.Write(" ({0},{1}) ", ListLeftUpBoard[i].y, ListLeftUpBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }
                    }
                    break;

                case "LEFT":
                    
                    if(x - 1 > -1)
                    {
                        if (splayerboard[y, x - 1] == "W")
                        {
                            //← 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y, x - 1, bc.count++, "LEFT");
                            ListLeftBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y, x - 1] == "B")
                        {
                            System.Console.Write("Player LEFT ");
                            for (int i = 0; i < ListLeftBoard.Count; i++)
                            {
                                splayerboard[ListLeftBoard[i].y, ListLeftBoard[i].x] = "B";
                                System.Console.Write(" ({0},{1}) ", ListLeftBoard[i].y, ListLeftBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }

                    }
                    break;

                case "LEFT_DOWN":

                    if(y + 1 < 8 && x - 1 > -1)
                    {
                        if (splayerboard[y + 1, x - 1] == "W")
                        {
                            //↙ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y + 1, x - 1, bc.count++, "LEFT_DOWN");
                            ListLeftDownBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y + 1, x - 1] == "B")
                        {
                            System.Console.Write("Player LEFT_DOWN ");
                            for (int i = 0; i < ListLeftDownBoard.Count; i++)
                            {
                                splayerboard[ListLeftDownBoard[i].y, ListLeftDownBoard[i].x] = "B";
                                System.Console.Write(" ({0},{1}) ", ListLeftDownBoard[i].y, ListLeftDownBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }

                    }
                    break;

                case "UP":
                    
                    if (y - 1 > - 1)
                    {
                        if (splayerboard[y - 1, x] == "W")
                        {
                            //↑ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y - 1, x, bc.count++, "UP");
                            ListUpBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y - 1, x] == "B")
                        {
                            System.Console.Write("Player UP ");
                            for (int i = 0; i < ListUpBoard.Count; i++)
                            {
                                splayerboard[ListUpBoard[i].y, ListUpBoard[i].x] = "B";
                                System.Console.Write(" ({0},{1}) ", ListUpBoard[i].y, ListUpBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }

                    }
                    break;

                case "DOWN":

                    if(y + 1 < 8)
                    {
                        if (splayerboard[y + 1, x] == "W")
                        {
                            //↓ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y + 1, x, bc.count++, "DOWN");
                            ListDownBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y + 1, x] == "B")
                        {
                            System.Console.Write("Player DOWN ");
                            for (int i = 0; i < ListDownBoard.Count; i++)
                            {
                                splayerboard[ListDownBoard[i].y, ListDownBoard[i].x] = "B";
                                System.Console.Write(" ({0},{1}) ", ListDownBoard[i].y, ListDownBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }

                    }
                    break;

                case "RIGHT_UP":

                    if(y - 1 > - 1 && x + 1 < 8)
                    {
                        if (splayerboard[y - 1, x + 1] == "W")
                        {
                            //↗ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y - 1, x + 1, bc.count++, "RIGHT_UP");
                            ListRightUpBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y - 1, x + 1] == "B")
                        {
                            System.Console.Write("Player RIGHT_UP ");
                            for (int i = 0; i < ListRightUpBoard.Count; i++)
                            {
                                splayerboard[ListRightUpBoard[i].y, ListRightUpBoard[i].x] = "B";
                                System.Console.Write(" ({0},{1}) ", ListRightUpBoard[i].y, ListRightUpBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }

                    }
                    break;

                case "RIGHT":
                    
                    if(x + 1 < 8)
                    {
                        if (splayerboard[y, x + 1] == "W")
                        {
                            //→ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y, x + 1, bc.count++, "RIGHT");
                            ListRightBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y, x + 1] == "B")
                        {
                            System.Console.Write("Player RIGHT ");
                            for (int i = 0; i < ListRightBoard.Count; i++)
                            {
                                splayerboard[ListRightBoard[i].y, ListRightBoard[i].x] = "B";
                                System.Console.Write(" ({0},{1}) ", ListRightBoard[i].y, ListRightBoard[i].x);
                            }
                            System.Console.WriteLine();
                        }

                    }
                    break;

                case "RIGHT_DOWN":
                    
                    if(y + 1 < 8 && x + 1 < 8)
                    {
                        if (splayerboard[y + 1, x + 1] == "W")
                        {
                            //↘ 
                            BoardCheck bc = new BoardCheck();
                            bc.init(y + 1, x + 1, bc.count++, "RIGHT_DOWN");
                            ListRightDownBoard.Add(bc);
                            stackBoardChecks.Push(bc);
                        }
                        else if (splayerboard[y + 1, x + 1] == "B")
                        {
                            System.Console.Write("Player RIGHT_DOWN ");
                            for (int i = 0; i < ListRightDownBoard.Count; i++)
                            {
                                splayerboard[ListRightDownBoard[i].y, ListRightDownBoard[i].x] = "B";
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
        
        //컴퓨터 판때기 그리기




        //get , set
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
