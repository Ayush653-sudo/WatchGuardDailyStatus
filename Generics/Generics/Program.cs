class Generic
{  
    public static void Main(string[] args)
    {
        bool equal = Calculator.isEqual<int>(10, 10);
        if(equal)
        {
            Console.WriteLine("Number are equal ");
        }
        else
        {
            Console.WriteLine("Number are not equal");
        }
    }

}
//Generic Methods
class Calculator
{
    public static bool isEqual<T>(T value1,T value2)
    {
        return value1.Equals(value2);
    }
}
//Generic Class
//class Calculator<T>
//{
//    public static bool isEqual(T value1, T value2)
//    {
//        return value1.Equals(value2);
//    }
//}
class Calculator<T>where T:IComparable
{
    public static T isEqual(T value1, T value2)
    {
        return value1.CompareTo(value2)>0?value1:value2;
    }
}
public class Product
{
    public int productId;
    public string productName;
}
public class DiscountCalculator<TProduct>where TProduct : Product
{   
    public int getProductId(TProduct product)
    {
        return product.productId;
    } 

}
