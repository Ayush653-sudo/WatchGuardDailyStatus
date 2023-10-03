using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strings_and_files
{
    internal class files
    {   
        //we have two methods for dealing with files 
        //fileInfo:- provide instance methods.
        //File:- provide static methods bit it has one drawback that every time 
        //it has to go with initial check of validity by operating system
        //They have following functions like:-
        //1)create 2)copy 3)delete 4)exists 5)GetAttributes 6)Move 7)ReadAllText



  //Directory and DirectoryInfo:-
  //1)createDirectory 2)Delete 3)Exists 4)GetCurrentDirectory 5)GetFiles 6)GetLogicalDrives


//path
//GetDirectoryName(),GetFileName(),GetExtension(),GetTempPath()
public void fileOpen()
        {
            //var path = @"c:\somefile.jpg";
            //File.Copy(@"c:\temp\myfile.jpg", @"d:\temp\myfile.jpg");
            //File.Delete(path);
            //if (File.Exists(path))
            //{
            //    Console.WriteLine("Our file is present at given location");
            //}
            //var content=File.ReadAllText(path);
            //var fileInfo=new FileInfo(content);
            //fileInfo.CopyTo("destination file name");
            //fileInfo.Delete();
            //if(fileInfo.Exists)
            //{
            //    Console.WriteLine("Our file is present at given location");
            //}
            //Directory.CreateDirectory(@"c:\temp\folder1");
            //var files = Directory.GetFiles(@"c:\temp\folder1", "*.*", SearchOption.AllDirectories);
            //var dic = Directory.GetDirectories(@"c:\temp", "*.*", SearchOption.AllDirectories); 
            //foreach ( var f in dic )
            //{
            //    Console.WriteLine(f);
            //}
            //var directoryInfo1 = new DirectoryInfo("..");
            //directoryInfo1.GetFiles();
            //directoryInfo1.GetDirectories();
            //var path1 = @"c:\Projects\strings_and_files";
            //var dotIndex = path.IndexOf('.');
            //var extension = path.Substring(dotIndex);
            //Console.WriteLine("Extension: "+Path.GetExtension(path1));
            //Console.WriteLine("File Name:"+Path.GetFileName(path1));
            var path = @"C:\Users\atomar\OneDrive - WatchGuard Technologies Inc\Desktop\New folder\dummy.txt";
            if (File.Exists(path))
            {
                var content= File.ReadAllText(path);
                var words= content.Split(' ');
                int count = 0;
                int ma = 0;
                foreach (var item in words)
                {
                    int h = item.Length;
                    if (ma < h)
                        ma = h;
                    count++;
                }

                Console.WriteLine("Number of words:"+count);
                Console.WriteLine("Word of maximum lenght: " + ma);
            }


        }

    }
}
