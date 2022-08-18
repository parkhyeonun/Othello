using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    class Run
    {


        //시작
        public void StartGame()
        {
            int iSwtich = 0;
            Player player = new Player();
            Computer computer = new Computer();
            PlayerBoard playerboard = new PlayerBoard();
            ComputerBoard computerboard = new ComputerBoard();
            Draw draw = new Draw();

            //보드게임 판 만들기 ( Player , Computer)
            playerboard.CreateBoard();
            computerboard.CreateBoard();

            //선공 후공은 일단 고정 ( 플레이어 우선 )
            player.Setborder(true);
            computer.Setborder(false);  

            //판을 그려준다(Player 기준?).  - while 
            while((iSwtich % 2 == 0) ? true : false)
            { 
                draw.DrawBoard(playerboard);

                //선인 사람 돌 두기
                if (player.Getborder())
                {
                    //player 
                    playerboard.SettingBoard();
                    //디버깅 보드판
                    //draw.PlayerBoard(playerboard);
                    //둘 곳이 있는지 없는지 확인(없으면 차례를 넘김)
                    if (player.IsCheckPutStone(playerboard))
                    {
                        //readLine - 좌표값 입력(돌을 둘수 없는 곳이면 재입력) 
                        player.PutStone(playerboard);
                        //iSwtich 2가되면 종료
                        if (iSwtich - 1 < 0)
                        {
                            iSwtich = 0;
                        }
                        else
                        {
                            iSwtich--;
                        }
                    }
                    else
                    {
                        iSwtich++;
                    }

                    //내 차례는 끝났어
                    player.TrunEnd();
                    //컴퓨터 차례야
                    player.YourTrun(computer);

                    //보드판을 뒤집음 
                    playerboard.ReverseStone(int.Parse(player.putXY.Substring(0, 1)), int.Parse(player.putXY.Substring(1, 1)));

                    //컴퓨터 보드 업데이트
                    computerboard.ComputerBoardUpdqte(playerboard);
               
                    playerboard.ReSetBoardList();
                    System.Console.WriteLine(iSwtich);
                }
                else if(computer.Getborder())
                {
                    //computer
                    computerboard.SettingBoard();
                    //디버깅 보드판
                    //draw.ComputerBoard(computerboard);
                    //둘 곳이 있는지 없는지 확인(없으면 차례를 넘김)
                    if (computer.IsCheckPutStone(computerboard))
                    {
                        //점수 높은 곳만 두자! (탐욕의 오델로)
                        computer.PutStone(computerboard);
                        //2가 되면 종료
                        if (iSwtich - 1 < 0)
                        {
                            iSwtich = 0;
                        }
                        else
                        {
                            iSwtich--;
                        }
                    }
                    else
                    {
                        iSwtich++;
                    }
                    //컴퓨터차례는 끝났어
                    computer.TrunEnd();
                    //사람의 차례야
                    computer.YourTrun(player);

                    //보드판을 뒤집음 
                    computerboard.ReverseStone(computer.intMaxY, computer.intMaxX);

                    //컴퓨터 보드 업데이트
                    playerboard.PlayerBoardUpdqte(computerboard);

                    computerboard.ReSetBoardList();
                    System.Console.WriteLine(iSwtich);
                }
                else
                {
                    System.Console.WriteLine("이 문구가 뜬다면 무엇인가 잘못된겁니다.");
                }

                //더이상 둘 곳이 없는지 판단하기 - Loop
                //종료시 스코어 계산 승퍠 가리기

            }


        }

        
        //서로 차레 돌 두기
        //더이상 둘 곳이 없는지 판단하기 - Loop
        //종료시 스코어 계산 승퍠 가리기


    }
}
