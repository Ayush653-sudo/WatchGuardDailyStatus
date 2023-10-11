


using System.Collections.Generic;


//using Data_Hiding;
public class Class1
{
    public void print()
    {
        Console.WriteLine("Base Class Fuction called");
   }
}
public class term : Class1
{
    public  void print()
    {
        Console.WriteLine("Derived class Function callled");
    }
}
class Stack
{
    List<object>Liso;
    public int cap;
    public int top;
    Stack()
    {
        Liso = new List<object>();
        Console.WriteLine("Ener the capacity of a stack ");
        cap=int.
            Parse(Console.ReadLine());
        top = -1;
    }
 public void push(object obj)
    {
      if(obj == null)
        {
            throw new ArgumentNullException("Please Provide a Valid Argument. ");

        }
        if (top >= cap)
        {
            Console.WriteLine("Stack Size is full");
            return;
        }
        top++;
        Liso.Add(obj);
    } 
    public void pop()
    {   if (top == -1)
            Console.WriteLine("Hey your stack is empty");
        return;
        top--;
        Console.WriteLine("top element is deleted");
        Liso.RemoveAt(top);

    }
    public void clear()
    {
        Console.WriteLine("Clearing all objects!!");
        Liso.Clear();
    }



    public static void Main(string[] args)
    {
        Stack s = new Stack();
        s.push(1);
        s.push("ayush");
        s.pop();
        s.clear();
        int demo1 = 90;
        object obj = demo1;
        Console.WriteLine(obj.ToString());
        term cl=new term();
        cl.print();
    }
}
