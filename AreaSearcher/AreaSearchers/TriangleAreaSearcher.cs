using AreaSearcher.Models;

namespace AreaSearcher.AreaSearchers;

public class TriangleAreaSearcher : IAreaSearcher
{
    public double GetArea(Figure figure)
    {
        if (figure is not Triangle triangle)
            throw new ArgumentException("Figure is not Triangle", nameof(figure));
        return GetArea(triangle.Side1, triangle.Side2, triangle.Side3);
    }

    public static double GetArea(double side1, double side2, double side3)
    {
        if (!CanFormTriangle(side1, side2, side3)) 
            throw new ArgumentException("Triangle cannot be formed");
        
        var p = (side1 + side2 + side3) / 2;
        return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
    }

    public static bool TriangleIsRectangular(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            return false;

        var sides = new List<double> { a, b, c };
        sides.Sort();
        
        var max = sides[2];
        var side1 = sides[0];
        var side2 = sides[1];
        
        return Math.Abs(max * max - (side1 * side1 + side2 * side2)) < 0.000001;
    }

    private static bool CanFormTriangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            return false;
        
        return a + b > c && a + c > b && b + c > a;
    }
}