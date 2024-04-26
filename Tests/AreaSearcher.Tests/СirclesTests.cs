using AreaSearcher.AreaSearchers;
using FluentAssertions;
using NUnit.Framework;

namespace AreaSearcher.Tests;

public class СirclesTests
{
    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(double.MinValue)]
    public void GetArea_Should_throw_when_circle_is_not_real(double radius)
    {
        var exception = Assert.Throws<ArgumentException>(() => CircleAreaSearcher.GetArea(radius));
        exception.Should().NotBeNull();
        exception?.Message.Should().Be("Circle cannot be formed");
    }

    [TestCase(1, 3.14)]
    [TestCase(10, 314.15)]
    [TestCase(1000, 3141592.65)]
    public void GetArea_Should_return_area_of_circle(double radius, double expectedArea)
    {
        var area = CircleAreaSearcher.GetArea(radius);
        area.Should().BeApproximately(expectedArea, 0.01);
    }
}