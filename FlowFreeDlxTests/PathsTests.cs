using FlowFreeDlx;
using NUnit.Framework;

namespace FlowFreeDlxTests
{
    [TestFixture]
    internal class PathsTests
    {
        [Test]
        public void CanDetectWhetherPathsContainsAGivenPath()
        {
            var path1 = new Path();
            path1.AddCoords(new Coords(0, 0));
            path1.AddCoords(new Coords(0, 1));
            path1.AddCoords(new Coords(0, 2));

            var path2 = new Path();
            path2.AddCoords(new Coords(2, 0));
            path2.AddCoords(new Coords(2, 1));
            path2.AddCoords(new Coords(2, 2));

            var paths = new Paths();
            paths.AddPath(path1);

            Assert.That(paths.ContainsPath(path1), Is.True);
            Assert.That(paths.ContainsPath(path2), Is.False);
        }
    }
}
