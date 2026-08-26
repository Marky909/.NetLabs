using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileOperatins
{
    public class  WritingToFile
        {
        public void WriteStudentData(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine("My name is Mark!!!");
            writer.WriteLine("The things that i know");
            writer.WriteLine("The things that i dont know");

            writer.Close();
            fs.Close();

        }
    }
}
