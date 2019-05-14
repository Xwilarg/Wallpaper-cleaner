using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Wallpaper_cleaner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Make sure that this program is stored in the same folder as the one containing your wallpapers.");
            Console.WriteLine("You are currently in " + AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            foreach (string f in Directory.GetFiles("."))
            {
                string extension = f.Split('.').Last();
                if (extension == "png" || extension == "jpg" || extension == "jpeg")
                {
                    Image img = Image.FromFile(f);
                }
            }
            Console.ReadKey();
        }
    }
}
