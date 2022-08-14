﻿using System;
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
        public void YourTrun(Player computer)
        {
            computer.Setborder(true);

        }

        //수를 두다

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