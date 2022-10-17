using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Part1
{

    public class FileReader
    {
        private string path = Environment.CurrentDirectory;
        private string ext;
        public FileReader(string path, string ext)
        {
            this.path = path;
            this.ext = ext;
        }
    }
}
