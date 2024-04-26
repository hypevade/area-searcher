using AreaSearcher.AreaSearchers;
using FluentAssertions;
using NUnit.Framework;

namespace AreaSearcher.Tests;

public class TrianglesTests
{
    [TestCase(0, 1, 1)]
    [TestCase(1, 0, 1)]
    [TestCase(1, 1, 0)]
    [TestCase(-1, 1, 1)]
    [TestCase(1, -1, 1)]
    [TestCase(1, 1, -1)]
    [TestCase(10, 1, 1)]
    [TestCase(1, 10, 1)]
    [TestCase(1, 1, 10)]
    public void GetArea_Should_throw_when_triangle_is_not_real(double a, double b, double c)
    {
        var exception = Assert.Throws<ArgumentException>(() => TriangleAreaSearcher
            .GetArea(a, b, c));
        exception.Should().NotBeNull();
        exception?.Message.Should().Be("Triangle cannot be formed");
    }

    [TestCase(5, 5, 5, 10.83)]
    [TestCase(3, 4, 5, 6)]
    [TestCase(2, 3, 4, 2.905)]
    [TestCase(7, 8, 9, 26.83)]
    public void GetArea_Should_return_area_of_triangle(double a, double b, double c, double expectedArea)
    {
        var area = TriangleAreaSearcher
            .GetArea(a, b, c);
        area.Should().BeApproximately(expectedArea, 0.01);
    }

    [TestCase(3, 4, 5)]
    [TestCase(5, 12, 13)]
    public void TriangleIsRectangular_Should_return_true_for_rectangular(double a, double b, double c)
    {
        var isRectangular = TriangleAreaSearcher.TriangleIsRectangular(a, b, c);
        isRectangular.Should().BeTrue();
    }

    [Test]
    public void TriangleIsRectangular_Should_return_false_for_not_rectangular()
    {
        var isRectangular = TriangleAreaSearcher.TriangleIsRectangular(3, 4, 6);
        isRectangular.Should().BeFalse();
    }

    [TestCase(0, 1, 1)]
    [TestCase(1, 0, 1)]
    [TestCase(1, 1, 0)]
    public void TriangleIsRectangular_Should_return_false_for_not_real(double a, double b, double c)
    {
        var isRectangular = TriangleAreaSearcher.TriangleIsRectangular(a, b, c);
        isRectangular.Should().BeFalse();
    }
}