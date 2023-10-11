

using upcasting_and_downcasting;
public class Shape
{
    protected int m_xpos;
    protected int m_ypos;
    public Shape()
    {
    }
    public Shape(int x, int y)
    {
        m_xpos = x;
        m_ypos = y;
    }
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a SHAPE at {0},{1}", m_xpos, m_ypos);
    }
    //public virtual void FillCircle()
    //{
    //    Console.WriteLine("Filling Shape at {0},{1}", m_xpos, m_ypos);
    //}
}
public class Square : Shape
{
    public Square()
    {
    }
    public Square(int x, int y) : base(x, y)
    {
    }
    public override void Draw()
    {
        Console.WriteLine("Drawing a SQUARE at {0},{1}", m_xpos, m_ypos);
    }
}
public class Circle : Shape
{
    public Circle()
    {
    }
    public Circle(int x, int y) : base(x, y)
    {
    }
    public override void Draw()
    {
        Console.WriteLine("Drawing a CIRCLE at {0},{1}", m_xpos, m_ypos);
    }
    public void FillCircle()
    {
        Console.WriteLine("Filling CIRCLE at {0},{1}", m_xpos, m_ypos);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Shape s = new Circle(100, 100);//upcasting
        s.Draw();
        Circle c;
        c = (Circle)s;
        c.FillCircle();
        obj_memory_test obj=new obj_memory_test();
        obj.s1 = "ayush";
        obj.s2 = "ayush";
        obj_memory_test obj2= new obj_memory_test();
        obj2.s1 = "ayush";
        Console.WriteLine(object.ReferenceEquals(obj.s1, obj2.s1));
    }
}
