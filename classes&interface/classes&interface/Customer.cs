using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes_interface
{
    internal class Customer
    {
        public int Id=10;
        public string Name;
        public List<Order>Orders;
        public Customer() {
        Orders=new List<Order>();     //This must be done to handle any runtime exception       
        }
        public Customer(int id):this()     //this()->it will call parameterless constructor firstly
        {
            Id = id;
        }
        public Customer(int id,string name):this(id) {
            //Id = id;
            Name = name;
        }
    }
}
