using System.Linq;
using FlowFreeDlx;
using NUnit.Framework;

namespace FlowFreeDlxTests
{
    [TestFixture]
    public class PathFinderTests
    {
        [Test]
        public void CanFindAllPathsOfSimpleGrid()
        {
            var startCoords = new Coords(0, 1);
            var endCoords = new Coords(1, 0);

            // "A "
            // " A"
            var grid = new Grid(2, 2, new ColourPair(startCoords, endCoords, "A"));

            var paths = PathFinder.FindAllPaths(grid, startCoords, endCoords);
            var pathList = paths.PathList.ToList();

            Assert.That(pathList.Count, Is.EqualTo(2));

            var expectedPath1 = new Path();
            expectedPath1.AddCoords(startCoords);
            expectedPath1.AddCoords(new Coords(0, 0));
            expectedPath1.AddCoords(endCoords);

            var expectedPath2 = new Path();
            expectedPath2.AddCoords(startCoords);
            expectedPath2.AddCoords(new Coords(1, 1));
            expectedPath2.AddCoords(endCoords);

            Assert.That(paths.ContainsPath(expectedPath1), Is.True);
            Assert.That(paths.ContainsPath(expectedPath2), Is.True);
        }
    }
}
