using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kalispera ir8a");
            Console.WriteLine("Geia Xara!");
        
            //var ctx = HttpContext.Current;
            //var root = ctx.Server.MapPath("~/Photos");
            string path = "~/Photos/";
            string filename = "dragonball.jpg";
            string[] array = filename.Split('.');
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
            

            if (File.Exists("C:/Users/Nikos/source/repos/ColorsTNC/Experiments/Photos/dragonball.jpg"))
            {
                Console.WriteLine("File found in the specified directory!");
            }
            else
            {
                Console.WriteLine("File does not exist in the specified directory!");
            }

        }

    }
}

