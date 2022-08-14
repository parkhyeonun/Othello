using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    class BoardCheck
    {
        

        public int x = 0;
        public int y = 0;
        public String voctor;
        public int count = 0;

        public void init( int x , int y , int count ,String voctor)
        {
            this.x = x;
            this.y = y;
            this.count = count;
            this.voctor = voctor;
        }




    }
}
