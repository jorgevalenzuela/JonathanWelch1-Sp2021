using System;

namespace SquareISARectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle(); //step 1 for jorge
            Square s1 = new Square(); // step2 for jorge
            SquareSquare ss1 = new SquareSquare(); // step 3 for jorge

            Console.WriteLine("Calling the function with rectangle");
            UserOfRectangle(r1);


            Console.WriteLine("Calling the function with square");
            UserOfRectangle(ss1);

            Console.ReadLine();
        }


        static void UserOfRectangle(Rectangle r)
        {
            r.Height = 4;
            r.Width = 5;


            if(r.CalculateArea() != 20)
            {
                throw new Exception("You suck!");
            }
            else
            {
                Console.Write("Hello For the Shape with sidess: " + r.Height + " by " + r.Width + ", ");
                Console.WriteLine("the Area is: " + r.CalculateArea());


            }
        }






    }
}
