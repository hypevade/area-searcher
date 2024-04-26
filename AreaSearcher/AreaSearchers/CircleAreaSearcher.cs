using AreaSearcher.Models;

namespace AreaSearcher.AreaSearchers;

public class CircleAreaSearcher : IAreaSearcher
{
    public double GetArea(Figure figure)
    {
        if (figure is not Circle circle)
            throw new ArgumentException("Figure is not Circle", nameof(figure));
        return GetArea(circle.Radius);
    }

    public static double GetArea(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Circle cannot be formed");
        return Math.PI * Math.Pow(radius, 2);
    }
}