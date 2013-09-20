using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowFreeDlx
{
    public class PathFinder
    {
        public static IList<IList<Coords>> FindAllPaths(Grid grid, Coords startCoords, Coords endCoords)
        {
            var paths = new List<IList<Coords>>();

            FollowPath(grid, paths, new List<Coords> {startCoords}, endCoords, Direction.Up);
            FollowPath(grid, paths, new List<Coords> {startCoords}, endCoords, Direction.Down);
            FollowPath(grid, paths, new List<Coords> {startCoords}, endCoords, Direction.Left);
            FollowPath(grid, paths, new List<Coords> {startCoords}, endCoords, Direction.Right);

            return paths;
        }

        private static void FollowPath(Grid grid, List<IList<Coords>> paths, List<Coords> currentPath, Coords endCoords, Direction direction)
        {
            var line = string.Empty;
            line += "currentPath: ";
            var coordsAsStrings = currentPath.Select(coords => coords.ToString());
            line += string.Join(", ", coordsAsStrings);
            line += "; direction: ";
            line += direction.ToString();
            System.Diagnostics.Debug.WriteLine(line);

            var lastCoords = currentPath.Last();
            Coords nextCoords;

            switch (direction)
            {
                case Direction.Up:
                    nextCoords = new Coords(lastCoords.X, lastCoords.Y + 1);
                    break;
                case Direction.Down:
                    nextCoords = new Coords(lastCoords.X, lastCoords.Y - 1);
                    break;
                case Direction.Left:
                    nextCoords = new Coords(lastCoords.X - 1, lastCoords.Y);
                    break;
                case Direction.Right:
                    nextCoords = new Coords(lastCoords.X + 1, lastCoords.Y);
                    break;
                default:
                    throw new InvalidOperationException("Unknown direction");
            }

            if (nextCoords.Equals(endCoords))
            {
                currentPath.Add(nextCoords);
                // TODO: check for duplicate paths
                paths.Add(currentPath);
                return;
            }

            if (PathContainsCoords(currentPath, nextCoords))
            {
                return;
            }

            if (CoordsAreOffTheGrid(grid, nextCoords))
            {
                return;
            }

            if (grid.IsCellOccupied(nextCoords))
            {
                return;
            }

            currentPath.Add(nextCoords);

            var allDirections = Enum.GetValues(typeof(Direction)).Cast<Direction>();
            var oppositeDirection = direction.Opposite();
            var directionsToTry = allDirections.Where(d => d != oppositeDirection);

            foreach (var directionToTry in directionsToTry)
            {
                var copyOfCurrentPath = new List<Coords>();
                copyOfCurrentPath.AddRange(currentPath);
                FollowPath(grid, paths, copyOfCurrentPath, endCoords, directionToTry);
            }
        }

        private static bool PathContainsCoords(IEnumerable<Coords> path, Coords coords)
        {
            return path.Any(c => c.Equals(coords));
        }

        private static bool CoordsAreOffTheGrid(Grid grid, Coords coords)
        {
            return coords.X < 0 || coords.X >= grid.Width || coords.Y < 0 || coords.Y >= grid.Height;
        }
    }
}
