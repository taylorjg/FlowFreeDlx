using FlowFreeDlx;
using NUnit.Framework;

namespace FlowFreeDlxTests
{
    [TestFixture]
    internal class GridTests
    {
        [Test]
        public void CanConstructSimpleGridFromInitStrings()
        {
            var initStrings = new[]
                {
                    "A  ",
                    "  A"
                };

            var grid = new Grid(initStrings);

            Assert.That(grid.IsCellOccupied(new Coords(0, 0)), Is.False);
            Assert.That(grid.IsCellOccupied(new Coords(1, 0)), Is.False);
            Assert.That(grid.IsCellOccupied(new Coords(2, 0)), Is.True);
            Assert.That(grid.IsCellOccupied(new Coords(0, 1)), Is.True);
            Assert.That(grid.IsCellOccupied(new Coords(1, 1)), Is.False);
            Assert.That(grid.IsCellOccupied(new Coords(2, 1)), Is.False);
        }
    }
}
