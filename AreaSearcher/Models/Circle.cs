namespace AreaSearcher.Models;

public class Circle(double radius) : Figure(nameof(Circle).ToLower())
{
    public double Radius { get; init; } = radius;
}