using AreaSearcher.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AreaSearcher.Tests;

public class AreaSearchTests
{
    private class Rectangle() : Figure(nameof(Rectangle).ToLower());

    [Test]
    public void GetArea_Should_throw_when_area_searcher_is_not_found()
    {
        var exception = Assert.Throws<ArgumentException>(() => AreaSearch.GetArea(new Rectangle()));
        exception.Should().NotBeNull();
        exception?.Message.Should().Be("Area searcher for rectangle not found");
    }

    [TestCase(double.MinValue)]
    public void GetAreaCircle_Should_throw_when_circle_is_not_real(double radius)
    {
        var exception = Assert.Throws<ArgumentException>(() => AreaSearch.GetArea(new Circle(radius)));
        exception.Should().NotBeNull();
        exception?.Message.Should().Be("Circle cannot be formed");
    }

    [TestCase(1, 3.14)]
    public void GetAreaCircle_Should_return_area_of_circle(double radius, double expectedArea)
    {
        var area = AreaSearch.GetArea(new Circle(radius));
        area.Should().BeApproximately(expectedArea, 0.01);
    }

    [TestCase(1, 1, 10)]
    public void GetAreaTriangle_Should_throw_when_triangle_is_not_real(double a, double b, double c)
    {
        var exception = Assert.Throws<ArgumentException>(() => AreaSearch
            .GetArea(new Triangle(a, b, c)));
        exception.Should().NotBeNull();
        exception?.Message.Should().Be("Triangle cannot be formed");
    }


    [TestCase(3, 4, 5, 6)]
    public void GetAreaTriangle_Should_return_area_of_triangle(double a, double b, double c, double expectedArea)
    {
        var area = AreaSearch
            .GetArea(new Triangle(a, b, c));
        area.Should().BeApproximately(expectedArea, 0.01);
    }

    [TestCase(3, 4, 5)]
    [TestCase(5, 12, 13)]
    public void TriangleIsRectangular_Should_return_true_for_rectangular(double a, double b, double c)
    {
        var isRectangular = AreaSearch.TriangleIsRectangular(new Triangle(a, b, c));
        isRectangular.Should().BeTrue();
    }

    [Test]
    public void TriangleIsRectangular_Should_return_false_for_not_rectangular()
    {
        var isRectangular = AreaSearch.TriangleIsRectangular(new Triangle(3, 4, 6));
        isRectangular.Should().BeFalse();
    }
}