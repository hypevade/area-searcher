namespace AreaSearcher.Models;

public class Triangle(double side1, double side2, double side3) : Figure(nameof(Triangle).ToLower())
{
    public double Side3 { get; init; } = side3;

    public double Side2 { get; init; } = side2;

    public double Side1 { get; init; } = side1;
}