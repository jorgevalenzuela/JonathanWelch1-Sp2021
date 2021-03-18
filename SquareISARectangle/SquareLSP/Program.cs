using System;

namespace SquareLSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle();
            r1.Height = 5;
            r1.Width = 4;
            Square s1 = new Square();
            s1.Side = 5;

            g2(r1);
            g2(s1);

            Console.ReadLine();

        }


        static void g(Rectangle r)
        {
            if(r.CalcArea() != 20)
            {
                throw new Exception("You suck!");
            }

            else
            {
                Console.WriteLine("The Area is: " + r.CalcArea());
            }
        }

        static void g2(Shape s)
        {
            Console.WriteLine("The Area is: " + s.CalcArea());
        }
    }
}
