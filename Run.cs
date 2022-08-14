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
            //whlie(true)
            draw.DrawBoard(playerboard);

            //선인 사람 돌 두기
            if (player.Getborder())
            {
                //player 
                playerboard.SettingBoard(0);
                //둘 곳이 있는지 없는지 확인(없으면 차례를 넘김)
                //readLine - 좌표값 입력 

                player.YourTrun(computer);
            }
            else if(computer.Getborder())
            {
                //computer
                //둘 곳이 있는지 없는지 확인(없으면 차례를 넘김)
                //점수 높은 곳만 두자! (탐욕의 오델로)

                computer.YourTrun(player);
            }
            else
            {
                System.Console.WriteLine("이 문구가 뜬다면 무엇인가 잘못된겁니다.");
            }

            //더이상 둘 곳이 없는지 판단하기 - Loop
            //종료시 스코어 계산 승퍠 가리기


            System.Console.WriteLine("1111");
        }

        
        //서로 차레 돌 두기
        //더이상 둘 곳이 없는지 판단하기 - Loop
        //종료시 스코어 계산 승퍠 가리기


    }
}
