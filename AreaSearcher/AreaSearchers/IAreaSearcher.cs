using AreaSearcher.Models;

namespace AreaSearcher.AreaSearchers;

public interface IAreaSearcher
{
    double GetArea(Figure figure);
}