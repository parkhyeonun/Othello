using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    class Player
    {
        //선공 후공
        bool border = true; // border : true , border : false 차례
        public string putXY;

        //내 차례는 끝났어
        public void TrunEnd()
        {
            border = false;
        }
        //너의 턴이야 
        public void YourTrun(Computer computer)
        {
            computer.Setborder(true);

        }


        //돌을 두다.
        public void PutStone(PlayerBoard pb)
        {
            
            System.Console.Write("돌을 둘 곳 : yx "); putXY = System.Console.ReadLine();
            
            while (IsCheckPlayerBoard(int.Parse(putXY.Substring(0, 1)) , int.Parse(putXY.Substring(1, 1)) , pb))
            {
                System.Console.Write("그곳은 둘 수 없습니다. 다시 입력해주세요. : yx "); putXY = System.Console.ReadLine();
            }

            pb.splayerboard[int.Parse(putXY.Substring(0, 1)), int.Parse(putXY.Substring(1, 1))] = "B";

        }

        //돌을 둘수 있는 자리가 없어
        public bool IsCheckPutStone(PlayerBoard pb)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if(!(pb.splayerboard[y, x] == "0" || pb.splayerboard[y, x] == "B" || pb.splayerboard[y, x] == "W"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //그곳엔 돌을 둘 수 없어
        public bool IsCheckPlayerBoard(int y , int x , PlayerBoard pb)
        {
            //0 , B , W 에는 돌을 둘 수 없습니다.
             if(pb.splayerboard[y , x] == "0" || pb.splayerboard[y, x] == "B" || pb.splayerboard[y, x] == "W")
            {
                return true;
            }
                return false;
        }

        //Set , Get 
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
