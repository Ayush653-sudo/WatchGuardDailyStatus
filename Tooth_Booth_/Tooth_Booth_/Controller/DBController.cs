using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.database;

namespace Tooth_Booth_.Controller
{
   class  DBController
    {
        static public IDBHandler handler;
      public DBController(IDBHandler obj)
        { 
        
            handler = obj;

        
          }

    }
}
