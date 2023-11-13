using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInitialize
{
    public class Customer
    {
        public string FirstName;
        public string LastName;
        public override bool Equals(object? obj)
        {
            Customer otherCustomerObject = obj as Customer;
            if (otherCustomerObject == null)
                return false;
            return this.FirstName==otherCustomerObject.FirstName&&
                this.LastName==otherCustomerObject.LastName;
        }
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode();
        }
    }
}
