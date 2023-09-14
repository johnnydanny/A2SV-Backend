namespace Classes
{
    class Shape 
    {
        protected string? name;

        public string? Name
        {
            get { return name; }
            protected set { name = value; }
        }

        public virtual double CalculateArea() => 0.0;
    }

    class Circle : Shape 
    {
        public double Radius { get; }

        public Circle(double radius) 
        {
            Radius = radius;
            Name = "Circle";
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
   
    class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height) 
        {
            Width = width;
            Height = height;
            Name = "Rectangle";
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    class Triangle : Shape
    {
        public double Base { get; }
        public double TriangleHeight { get; } 

        public Triangle(double triangleBase, double height) 
        {
            Base = triangleBase;
            TriangleHeight = height; 
            Name = "Triangle";
        }

        public override double CalculateArea()
        {
            return 0.5 * Base * TriangleHeight;
        }
    }

    class Program
    {
        static void PrintShapeArea(Shape shape)
        {
            Console.WriteLine($"Area of {shape.Name} = {shape.CalculateArea()}");
        }

        static void Main()
        {
            Circle circle = new Circle(5.0);
            Rectangle rectangle = new Rectangle(4.0, 3.0);
            Triangle triangle = new Triangle(6.0, 4.0);
          
            PrintShapeArea(circle);
            PrintShapeArea(rectangle);
            PrintShapeArea(triangle);
        }
    }
}
