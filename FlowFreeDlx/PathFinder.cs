using System;
using System.Linq;

namespace FlowFreeDlx
{
    public class PathFinder
    {
        public static Paths FindAllPaths(Grid grid, Coords startCoords, Coords endCoords)
        {
            var paths = new Paths();

            FollowPath(grid, paths, Path.PathWithStartingPoint(startCoords), endCoords, Direction.Up);
            FollowPath(grid, paths, Path.PathWithStartingPoint(startCoords), endCoords, Direction.Down);
            FollowPath(grid, paths, Path.PathWithStartingPoint(startCoords), endCoords, Direction.Left);
            FollowPath(grid, paths, Path.PathWithStartingPoint(startCoords), endCoords, Direction.Right);

            return paths;
        }

        private static void FollowPath(Grid grid, Paths paths, Path currentPath, Coords endCoords, Direction direction)
        {
            var nextCoords = currentPath.GetNextCoords(direction);

            if (nextCoords.Equals(endCoords))
            {
                currentPath.AddCoords(nextCoords);
                paths.AddPath(currentPath);
                return;
            }

            if (currentPath.ContainsCoords(nextCoords))
            {
                return;
            }

            if (grid.CoordsAreOffTheGrid(nextCoords))
            {
                return;
            }

            if (grid.IsCellOccupied(nextCoords))
            {
                return;
            }

            currentPath.AddCoords(nextCoords);

            var allDirections = Enum.GetValues(typeof(Direction)).Cast<Direction>();
            var oppositeDirection = direction.Opposite();
            var directionsToTry = allDirections.Where(d => d != oppositeDirection);

            foreach (var directionToTry in directionsToTry)
            {
                FollowPath(grid, paths, Path.CopyOfPath(currentPath), endCoords, directionToTry);
            }
        }
    }
}
