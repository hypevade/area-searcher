using AreaSearcher.AreaSearchers;
using AreaSearcher.Models;

namespace AreaSearcher;

public static class AreaSearch
{
    private static readonly Dictionary<string, IAreaSearcher> AreaSearchers = new()
    {
        { "circle", new CircleAreaSearcher() },
        { "triangle", new TriangleAreaSearcher() }
    };
    
    public static double GetArea(Figure figure)
    {
        var figureTitle = figure.Title.ToLower().Trim();
        var searcherExist = AreaSearchers.TryGetValue(figureTitle, out var areaSearcher);
        if(!searcherExist || areaSearcher is null)
            throw new ArgumentException($"Area searcher for {figureTitle} not found");
        
        return areaSearcher.GetArea(figure);
    }
    
    public static bool TriangleIsRectangular(Triangle triangle)
    {
        return TriangleAreaSearcher.TriangleIsRectangular(triangle.Side1, triangle.Side2, triangle.Side3);
    }
}