using System;
using System.Collections.Generic;
using System.Text;

namespace FileOperatins
{
    //First write then Read
    public class WriteAndRead
    {
        public void WriteEmployeeDetails(string path)
        {
            FileStream folpfolo = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter WriteEmployee = new StreamWriter(folpfolo);
            WriteEmployee.WriteLine("My name is Jeff and i am manager");
            WriteEmployee.WriteLine();
            WriteEmployee.WriteLine("My name is Mark and i am the communist");

            WriteEmployee.Close();
            folpfolo.Close();
        }

        public void ReadEmployeeDetails(string path)
        {
            FileStream flowflow = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader ReadEmployee = new StreamReader(flowflow);
            string content = ReadEmployee.ReadToEnd();
            Console.WriteLine(content);

            ReadEmployee.Close();
            flowflow.Close();
        }
    }
}
