
using Abstract_Figuras.Entities;
using Abstract_Figuras.Entities.Enums;
using System.Collections.Generic;
using System.Globalization;

namespace Abstract_Figuras {
    class Program {
        static void Main(string[] args) {

            List<Shape> list = new List<Shape>();

            Console.Write("Enter the number of shapes: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) {

                Console.Write($"Shape ${i} data:");
                
                Console.Write("Rectangle or Circle (r/c)? ");
                char response = char.Parse(Console.ReadLine());

                Console.Write("Color (Black/Blue/Red): ");
                Color color = Enum.Parse<Color>(Console.ReadLine());

                if(response == 'r') {
                    Console.Write("Width: ");
                    double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Console.Write("Height: ");
                    double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Rectangle rectangle = new Rectangle(color, width, height);
                    list.Add(rectangle);
                } else if(response == 'c') {
                    Console.Write("Radius: ");
                    double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Circle circle = new Circle(color, radius);
                    list.Add(circle);
                }
            }

            Console.WriteLine();
            Console.WriteLine("SHAPE AREAS: ");
            foreach (Shape a in list) {
                Console.WriteLine(a.Area().ToString("F2"), CultureInfo.InvariantCulture);
            }


        }
    }
}