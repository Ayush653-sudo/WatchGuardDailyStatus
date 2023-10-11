using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace access_modifier
{
    internal class Experiments_Access_modifiers
    {
        private int id;
        protected int distinction;
        public void check()
        {
            Experiments_Access_modifiers obj= new Experiments_Access_modifiers();
            obj.id = 9;
           

        }

    }
    class Demo {
        int y;
        public void display()
        {
            Experiments_Access_modifiers obj = new Experiments_Access_modifiers();
            obj.distinction = 9;
        }

    
    }
}
