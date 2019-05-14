using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;

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
            Console.WriteLine();
            if (!Directory.Exists("Wastebin"))
                Directory.CreateDirectory("Wastebin");
            double width = SystemParameters.VirtualScreenWidth;
            double height = SystemParameters.VirtualScreenHeight;
            double wh = width / height;
            int counter = 0;
            int i = 0;
            string[] files = Directory.GetFiles(".");
            Console.Write("Please wait... 0%");
            foreach (string f in files)
            {
                string extension = f.Split('.').Last();
                if (extension == "png" || extension == "jpg" || extension == "jpeg")
                {
                    FileInfo fi = new FileInfo(f);
                    Image img;
                    using (FileStream stream = new FileStream(f, FileMode.Open))
                    {
                        img = Image.FromStream(stream);
                    }
                    if (Math.Abs((double)img.Width / img.Height - wh) > 0.6
                        || (img.Width < (width / 2) && img.Height < (height / 2)))
                    {
                        File.Move(f, "Wastebin/" + fi.Name);
                        counter++;
                    }
                }
                i++;
                Console.Write("\rPlease wait... " + (i * 100 / files.Length) + "%");
            }
            Console.WriteLine();
            Console.WriteLine("Operation complete, " + counter + " file" + (counter > 1 ? "s" : "") + " were moved to " + AppDomain.CurrentDomain.BaseDirectory + "Wastebin");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
