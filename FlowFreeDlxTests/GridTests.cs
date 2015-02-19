using FlowFreeDlx;
using NUnit.Framework;

namespace FlowFreeDlxTests
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        public void CanConstructSimpleGridFromColourPairs()
        {
            // "A  "
            // "  A"
            var grid = new Grid(3, 2, new[]
                {
                    new ColourPair(new Coords(0, 1), new Coords(2, 0), "A")
                });

            Assert.That(grid.IsCellOccupied(new Coords(0, 0)), Is.False);
            Assert.That(grid.IsCellOccupied(new Coords(1, 0)), Is.False);
            Assert.That(grid.IsCellOccupied(new Coords(2, 0)), Is.True);
            Assert.That(grid.IsCellOccupied(new Coords(0, 1)), Is.True);
            Assert.That(grid.IsCellOccupied(new Coords(1, 1)), Is.False);
            Assert.That(grid.IsCellOccupied(new Coords(2, 1)), Is.False);
        }
    }
}
