// -----------------------------------------------------------------------
// <copyright file="Program.cs">
//   Copyright (c) 2015 Herdy Handoko
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// -----------------------------------------------------------------------

namespace RobotExplorer
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The console program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                // Prepare terrain
                var terrainBoundaryInput = Console.ReadLine();

                Tuple<int, int> terrainBoundary;
                TryParseTerrainBoundary(terrainBoundaryInput, out terrainBoundary);
                var terrain = new Terrain(terrainBoundary.Item1, terrainBoundary.Item2);
                // TODO: Terrain's boundary checks when robot moves

                // Robot #1
                var robot1LandingInput = Console.ReadLine();
                var robot1Commands = Console.ReadLine();

                Tuple<int, int, Direction> robot1LandingPosition;
                TryParseRobotLandingPosition(robot1LandingInput, out robot1LandingPosition);
                var robot1 = new Robot(
                    robot1LandingPosition.Item1,
                    robot1LandingPosition.Item2,
                    robot1LandingPosition.Item3);
                robot1.Move(robot1Commands);
                
                // Robot #2
                var robot2LandingInput = Console.ReadLine();
                var robot2Commands = Console.ReadLine();

                Tuple<int, int, Direction> robot2LandingPosition;
                TryParseRobotLandingPosition(robot2LandingInput, out robot2LandingPosition);
                var robot2 = new Robot(
                    robot2LandingPosition.Item1,
                    robot2LandingPosition.Item2,
                    robot2LandingPosition.Item3);
                robot2.Move(robot2Commands);

                // Write output
                Console.WriteLine("{0} {1} {2}", robot1.XPos, robot1.YPos, robot1.Direction);
                Console.WriteLine("{0} {1} {2}", robot2.XPos, robot2.YPos, robot2.Direction);

                // TODO: Refactor robot 1 & 2 into common methods
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Validate the terrain boundary input and parse to X, Y coordinates.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="boundary">The terrain boundary.</param>
        private static void TryParseTerrainBoundary(string input, out Tuple<int, int> boundary)
        {
            // Validate against empty input
            if (input == null || input.Length <= 0)
            {
                throw new ArgumentNullException();
            }

            // Validate against expected input format
            var pattern = new Regex(@"^([0-9]+)\s([0-9]+)$");
            if (!pattern.IsMatch(input))
            {
                throw new ArgumentException();
            }

            var coordinates = input.Trim().Split(' ');
            boundary = Tuple.Create(
                Convert.ToInt32(coordinates[0]),
                Convert.ToInt32(coordinates[1]));
        }

        /// <summary>
        /// Validate the robot's landing position input and parse to X, Y coordinates and direction.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="position">The robot's landing position.</param>
        private static void TryParseRobotLandingPosition(string input, out Tuple<int, int, Direction> position)
        {
            // Validate against empty input
            if (input == null || input.Length <= 0)
            {
                throw new ArgumentNullException();
            }

            // Validate against expected input format
            var pattern = new Regex(@"^([0-9]+)\s([0-9]+)\s([NESW])$");
            if (!pattern.IsMatch(input))
            {
                throw new ArgumentException();
            }

            var coordinates = input.Trim().Split(' ');
            position = Tuple.Create(
                Convert.ToInt32(coordinates[0]),
                Convert.ToInt32(coordinates[1]),
                coordinates[2].ToDirection());
        }
    }
}
