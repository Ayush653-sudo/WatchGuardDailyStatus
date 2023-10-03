using System;
using System.Collections;
using System.Text;

namespace experiments
{
    class exp
    {
        
            static void Main(string[] args)
            {
            int y = 90;
     
            var list = new List<int>();
            //Console.WriteLine(list.Capacity);
            char[] k=new char[] {'1','3' };
            Console.WriteLine(k[1]);
                list.Add(1);
                list.Add(2);
                list.Add(3);
            unsafe
            {
                int* ptr = (int*)&list;
               Console.WriteLine(*(ptr));
                Console.WriteLine(Convert.ToString((long)ptr, 16));
            }
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
            list.Add(4);
                list.Add(5);
                list.Add(6);
            unsafe
            {
                int* ptr = (int*)&list;
                Console.WriteLine(Convert.ToString((long)ptr, 16));
            }
            list.Add(7);
                list.Add(8);
            //list.Add(int.Parse('A'));
            string a = "ayush";
            unsafe
            {    
                int* ptr = (int*)&a;
                Console.WriteLine(*(ptr));
                Console.WriteLine("string wala case: "+Convert.ToString((long)ptr, 16));
            }
            a = "Tomar";
            unsafe
            {
                int* ptr = (int*)&a;
                Console.WriteLine(*(ptr));
                Console.WriteLine(Convert.ToString((long)ptr, 16));
            }

            //  Console.WriteLine(a); //A
            // int b = int.Parse(a);
            //Console.WriteLine(int.Parse(b));
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}



            //Console.WriteLine(list.Capacity); // 8



            //list.Remove('1');
            //list.Remove('2');
            //list.Remove('3');
            //list.Remove('4');
            //Console.WriteLine(list.Capacity); // 8
            //list.TrimExcess(); // USE TO OPTIMIZE MEMORY MANUALLY.....
            //Console.WriteLine(list.Capacity); // 4
            //list.Add('Z');
            //list.TrimExcess();
            //Console.WriteLine(list.Capacity); //
            //   Array sak=new Array();
            //    ArrayList sak = new ArrayList();
            //    sak.Add(1);
            //    sak.Add("2");
            //    sak.AddRange(new List<int>{ 1,2,3,4});
            //    foreach (var item in sak)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    var st=new StringBuilder();

            //st.Append("hi");
            //st.AppendLine();
            //unsafe
            //{
            //    int* ptr = (int*)&st;
            //    Console.WriteLine(Convert.ToString((long)ptr,16));
            //}
            //st.Append("HelloHowareyouiamfinethanku");
            //unsafe
            //{
            //    int* ptr = (int*)&st;
            //    Console.WriteLine(Convert.ToString((long)ptr, 16));
            //}
            //Console.WriteLine(st.Capacity);

            //  Console.WriteLine(st.ToString().IndexOf('l'));
            //   var Path1 = @"C:\Users\atomar\OneDrive - WatchGuard Technologies Inc\Desktop\New folder\dummy.txt";
            ////   var str=new List<string>();
            // var str=File.ReadAllLines(Path1);
            //   var temp = File.ReadAllText(Path1);
            //   var ttemp_lines=temp.Split('\n');
            //   foreach(var item in str)
            //   {
            //       Console.WriteLine(item);
            //   }




            var Path2 = @"C:\Users\atomar\OneDrive - WatchGuard Technologies Inc\Desktop\New folder";
            var files = Directory.GetFiles(Path2, "*", SearchOption.AllDirectories);//by default top directory only
            foreach (var file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
                Console.WriteLine(Path.GetFileNameWithoutExtension(file));
            }

            //string k = "ayush";
            //int i = 0;
            //while(k[i] != '\0'){
            //    Console.WriteLine(k[i]);
            //    i++;
            //}


        }
        }
    }



