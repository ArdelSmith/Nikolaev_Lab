using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator;

namespace Project.Core
{
    public class FileWriter
    {
        private string FileName = "data";
        private string FileExtension = ".csv";
        public FileWriter()
        {
            if (!File.Exists(FileName + FileExtension)) File.WriteAllText(FileName + FileExtension,
                Generator.ArrayGenerator.GenerateArray(Generator.ArrayGenerator.GenerateArray()));
            else
            {
                string data = File.ReadAllText(FileName + FileExtension);
                File.WriteAllText(FileName + FileExtension,data + "\n" +
                Generator.ArrayGenerator.GenerateArray(Generator.ArrayGenerator.GenerateArray()));
            }
        }
    }
}
