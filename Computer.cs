using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    class Computer
    {
        //선공 후공
        bool border = true; // border : true , border : false 차례

        //내 차례는 끝났어 
        public void TrunEnd()
        {
            border = false;
        }
        //너의 턴이야 
        public void YourTrun(Player player)
        {
            player.Setborder(true);

        }
        //돌을 둘수 있는 자리가 없어
        public bool IsCheckPutStone(ComputerBoard cb)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (!(cb.splayerboard[y, x] == "0" || cb.splayerboard[y, x] == "B" || cb.splayerboard[y, x] == "W"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        //돌을 두다
        public void PutStone(PlayerBoard pb)
        {
            /*
            System.Console.Write("돌을 둘 곳 : xy "); putXY = System.Console.ReadLine();
            
            while (IsCheckPlayerBoard(int.Parse(putXY.Substring(0, 1)), int.Parse(putXY.Substring(1, 1)), pb))
            {
                System.Console.Write("그곳은 둘 수 없습니다. 다시 입력해주세요. : xy "); putXY = System.Console.ReadLine();
            }
            
            pb.splayerboard[int.Parse(putXY.Substring(0, 1)), int.Parse(putXY.Substring(1, 1))] = "B";
            */

        }


        //get , set
        public bool Getborder()
        {
            return border;
        }

        public void Setborder(bool border)
        {
            this.border = border;
        }
    }
}
