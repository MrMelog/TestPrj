using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Render_Prj
{
    
    class RenderObj
    {
        private string _fullname = "";
        private Int64 _lenght;
        private string _extension = "";
        private string _name = "";

        public FileInfo _file;

        public void Inform()
        {
            _lenght = _file.Length;
            _fullname = _file.FullName;
            _extension = _file.Extension;
            _name = _file.Name;
        }

        public void Printer()
        {
            Console.Write(
                "Name: {0} \n" +
                "Path: {1} \n" +
                "Format: {2} \n" +
                "Size: {3} byte" , _name, _fullname , _extension , _lenght );
        }

        public void FilInf(FileInfo inf)
        {
            _file = inf;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(@"Enter the Path(like: C:\Users\tomfitz )");
            //string path = Console.ReadLine();
            DirectoryInfo direct;
            FileInfo[] dirF;
            while (true) 
            {
                try
                {
                    string path = @Console.ReadLine();
                    direct = new DirectoryInfo(path);
                    dirF = direct.GetFiles();
                    break;
                }
                catch
                {
                    Console.WriteLine("Pls try again.");
                }
            }
            if (dirF.Length > 0)
            { 
                RenderObj[] Files = new RenderObj[dirF.Length];
                int i = 0;
                foreach (var fi in dirF)
                {
                    Console.WriteLine("{0}- {1}",i,fi);
                    Files[i] = new RenderObj();
                    Files[i]._file = fi;
                    i++;
                }
                Console.WriteLine("Enter the number of file.");
                var try_i = Console.ReadLine();
                int num = -1;
                while (!((int.TryParse(try_i, out num)) && num >= 0 && num <= dirF.Length-1))
                {
                    Console.WriteLine("Pls try again.");
                    try_i = Console.ReadLine();
                }
                Files[num].Inform();
                Files[num].Printer();
            }

            Console.ReadLine();
        }
    }
}
