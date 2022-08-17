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
        public int intScore = 0;    // 현재스코어
        public int intMaxScore = 0; // 최대스코어 
        public int intMaxY = 0;     // 최대값 Y
        public int intMaxX = 0;     // 최대값 X

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
        public void PutStone(ComputerBoard cb)
        {
            //"W" , "B"
            intMaxScore = 0;

            for (int y = 0; y < 8; y++)
            {

                for (int x = 0; x < 8; x++)
                {

                    if (cb.splayerboard[y, x] == "W" || cb.splayerboard[y, x] == "B")
                    {
                        intScore = 0;
                    }
                    else
                    {
                        intScore = int.Parse(cb.splayerboard[y, x]);
                    }

                    if (intMaxScore < intScore)
                    {
                        intMaxScore = intScore;
                        intMaxY = y;
                        intMaxX = x;
                    }

                }
            }

            cb.splayerboard[intMaxY, intMaxX] = "W";

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
