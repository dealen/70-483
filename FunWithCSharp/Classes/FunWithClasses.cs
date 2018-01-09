using System;

namespace FunWithCSharp.Classes
{
    class PointRef
    {
        public PointRef(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;

        public void Increment()
        {
            X++; Y++;
        }

        public void Decrement()
        {
            X--; Y--;
        }

        public void Display()
        {
            Console.WriteLine($"X = {X}, Y + {Y}");
        }
    }
}
