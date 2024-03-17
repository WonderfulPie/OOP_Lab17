using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_OOP_Danylko
{
    public abstract class Triangle
    {
        protected double Side1;
        protected double Side2;
        protected double Angle;

        public Triangle(double side1, double side2, double angle)
        {
            Side1 = side1;
            Side2 = side2;
            Angle = angle;
        }
        public abstract double Area();
        public abstract double Perimeter();
    }
    public class RightTriangle : Triangle
    {
        public RightTriangle(double side1, double side2) : base(side1, side2, 90)
        {
        }
        public override double Area()
        {
            return Math.Round((Side1 * Side2) / 2, 2);
        }

        public override double Perimeter()
        {
            return Math.Round(Side1 + Side2 + Hypotenuse(), 2);
        }
        private double Hypotenuse()
        {
            return Math.Sqrt(Math.Pow(Side1, 2) + Math.Pow(Side2, 2));
        }
    }
    public class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(double side1, double side2, double angle) : base(side1, side2, angle)
        {
        }

        public override double Perimeter()
        {
            return 2 * Side1 + Side2;
        }

        public override double Area()
        {
            double baseLength = Side2;
            double height = Side1 * Math.Sin(Angle * Math.PI / 180);
            return 0.5 * baseLength * height;
        }
    }
    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(double side) : base(side, side, 60)
        {
        }

        public override double Perimeter()
        {
            return 3 * Side1;
        }

        public override double Area()
        {
            return (Math.Sqrt(3) / 4) * Side1 * Side1;
        }
    }

    public class ArbitraryTriangle : Triangle
    {
        public ArbitraryTriangle(double side1, double side2, double angle) : base(side1, side2, angle)
        {
        }
        public override double Perimeter()
        {
            double side3 = Math.Sqrt(Math.Pow(Side1, 2) + Math.Pow(Side2, 2) - 2 * Side1 * Side2 * Math.Cos(Angle));
            return Side1 + Side2 + side3;
        }

        public override double Area()
        {
            double s = Perimeter() / 2;
            double side3 = Math.Sqrt(Math.Pow(Side1, 2) + Math.Pow(Side2, 2) - 2 * Side1 * Side2 * Math.Cos(Angle));
            return Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - side3));
        }
    }
}
