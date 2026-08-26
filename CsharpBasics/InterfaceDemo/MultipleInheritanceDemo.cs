using System;


namespace InterfaceDemo
{
    interface IDrawable
    {
        void Draw();
    }
    interface IPrintable
    { 
        void Print();
    }

    public class Document:IDrawable,IPrintable
    {
        public void Draw()
        {
            Console.WriteLine("This is Draw!!");
        }

        public void Print()
        {
            Console.WriteLine("This is Print!!");
        }
        public void ShowDocument()
        {
            Console.WriteLine("This is gonna be fun reading the details of the document!!");
        }
    }
}
