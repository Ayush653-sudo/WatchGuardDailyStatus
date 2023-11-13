using System.Xml.Linq;

class Program
{
    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
     private   set
        {
            _name = value;
        }
    }
    public static  void Main(string[] args)
    {
        Program p = new Program();
        p.Name = "ayush";
      //  p._name = "ff";
        //callMethod();
        //Console.WriteLine("Ayush");
    }

    public static async void callMethod()
    {
        Method2();
        var count = await Method1();
        Method3(count);
    }

    public static async Task<int> Method1()
    {
        int count = 0;
        await Task.Run(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(" Method 1");
                count += 1;
            }
        });
        return count;
    }

    public static void Method2()
    {
        for (int i = 0; i < 25; i++)
        {
            Console.WriteLine(" Method 2");
        }
    }

    public static void Method3(int count)
    {
        Console.WriteLine("Total count is " + count);
    }
}
class c : Program
{
    public void fun()
    {
        c k = new c();
        Console.WriteLine(k.Name);
    }
}
