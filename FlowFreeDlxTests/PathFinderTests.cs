using FlowFreeDlx;
using NUnit.Framework;

namespace FlowFreeDlxTests
{
    [TestFixture]
    class PathFinderTests
    {
        [Test]
        public void CanFindAllPathsOfSimpleGrid()
        {
            var initStrings = new[]
                {
                    "A ",
                    " A"
                };

            var grid = new Grid(initStrings);
            var paths = PathFinder.FindAllPaths(grid, new Coords(0, 1), new Coords(1, 0));
            Assert.That(paths.Count, Is.EqualTo(2));
            Assert.That(paths, Contains.Item(new[]{ new Coords(0, 1), new Coords(0, 0), new Coords(1, 0)}));
            Assert.That(paths, Contains.Item(new[]{ new Coords(0, 1), new Coords(1, 1), new Coords(1, 0)}));
        }
    }
}
