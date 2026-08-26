using System;
using System.Collections.Generic;
using System.Text;

namespace FileOperatins
{
    public class ReadingFromFile
    {
        public void ReadStudentData(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            StreamReader reader = new StreamReader(fs);

            string content = reader.ReadToEnd();

            Console.WriteLine(content);

            reader.Close();
            fs.Close();
        }
    }
}
