using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOut
{
    internal class staticCheck
    {
        public static int i;
        public static int j;
        public int k;
        static staticCheck()
        {
            i = 9;
            j = 10;
         // k = 7;

        }
        //private staticCheck()
        //{

        //}
        private staticCheck()
        {

        }

        public staticCheck(int l)
        {
            this.k = k;
        }
    }
}
