
using Sealed_Class;
using Abstract_class;

namespace AbstractClass
{
   public abstract class Shape
    {
        public abstract void draw(); 
    }
    public class Circle : Shape
    {
        public override void draw()
        {
            Console.WriteLine("Draw a Circle");
        }

    }
    class Program:Interface_
    {
        public void display()
        {
            Console.WriteLine("Hey Tomar");
        }
        public static void Main(string[] args)
        {
            var C1 = new Circle();
            C1.draw();

            Printer p = new Printer();
            p.show();
            p.print();

            Printer ls = new LaserJet();
            ls.show();
            ls.print();

            Printer of = new Officejet();
            of.show();
            of.print();
           Program t = new Program();

            
            t.display();

        }
    }
}