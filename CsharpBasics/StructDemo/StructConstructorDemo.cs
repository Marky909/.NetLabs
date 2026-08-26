using System;
using System.Collections.Generic;
using System.Text;

namespace StructDemo
{
    struct Rectangle
    {
        public int Length;
        public int Width;

        public Rectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }

        public int Area()
        {
            return Length * Width;
        }
    }

}