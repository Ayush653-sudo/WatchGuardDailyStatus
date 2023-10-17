using Experiments_Intermediate_course;

class IA
{
    private int _accc;

    // public  void f();
    private int h;
   public string AssetName
    {
        get
        {
            // AssetName = "hi";
            // return AssetName;
            //Console.WriteLine(AssetName);
           return "dd";
        }
          set
         {
        //  Console.WriteLine("hi");
        AssetName = value;
        //Console.WriteLine(AssetName);
        //Console.WriteLine("ss" + value);
        //_accc = AssetName;


        // return;
         }
    }
  //  public string name;

    public void cc()
    {
        Console.WriteLine("HI");
        IA obj = new IA();
        Console.WriteLine(obj.AssetName);
       // obj.AssetName = "aa";
    }

}
class B : IA
{

    //public string AssetName
    //{
    //    set
    //    {
    //        AssetName = value;
    //    }
    //    get
    //    {
    //        return AssetName;
    //    }
    //}
    public void f()
    {
        Console.WriteLine("f");
    }

    public static void Main()
    {  IA obj= new IA();
        obj.cc();
       // Console.WriteLine(obj.AssetName);


        IA.AssetName = "Ayush";


        //Console.WriteLine(x);
        //Console.Write( IA.AssetName= "test");
        //   Abstract_Class obj = new Derived();
        /// obj.Func();

    }

}


