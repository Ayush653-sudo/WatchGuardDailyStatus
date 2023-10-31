using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
   public class Linq
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book(){Title="ASP .NET",Price=5},
                new Book(){Title="ASP .NET MVC",Price=99.9f},

            };
        }
    }
}
