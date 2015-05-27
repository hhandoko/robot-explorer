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
                ConsoleWriteHeader("Input");
                // Get Terrain's boundary input and create it!
                // TODO: Terrain's boundary checks when robot moves
                var terrainBoundaryInput = Console.ReadLine();
                var terrainBoundary = terrainBoundaryInput.TryParseTerrainBoundary();
                var terrain = new Terrain(terrainBoundary);

                // Get Robot #1 landing position and create it!
                var robot1LandingInput = Console.ReadLine();
                var robot1Position = robot1LandingInput.TryParseRobotLandingPosition();
                var robot1 = new Robot(robot1Position);

                // Move Robot #1
                var robot1Commands = Console.ReadLine();
                robot1.Move(robot1Commands);
                
                // Get Robot #2 landing position and create it!
                var robot2LandingInput = Console.ReadLine();
                var robot2Position = robot2LandingInput.TryParseRobotLandingPosition();
                var robot2 = new Robot(robot2Position);

                // Move Robot #2
                var robot2Commands = Console.ReadLine();
                robot2.Move(robot2Commands);

                // Write results
                Console.WriteLine();
                ConsoleWriteHeader("Output");
                Console.WriteLine("{0} {1} {2}", robot1.XPos, robot1.YPos, robot1.Direction);
                Console.WriteLine("{0} {1} {2}", robot2.XPos, robot2.YPos, robot2.Direction);

                // TODO: Refactor robot 1 & 2 into common methods
            }
            catch (Exception e)
            {
                ConsoleWriteHeader("Error", ConsoleColor.Red);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Write formatted section header.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="color">The text color.</param>
        private static void ConsoleWriteHeader(string input, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("[{0}]", input.ToUpperInvariant());
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    /// <summary>
    /// The console application method extensions.
    /// </summary>
    internal static class ProgramExtension
    {
        /// <summary>
        /// Validate the terrain boundary input and parse to X, Y coordinates.
        /// </summary>
        /// <param name="input">The input.</param>
        public static Tuple<int, int> TryParseTerrainBoundary(this string input)
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
            return Tuple.Create(
                Convert.ToInt32(coordinates[0]),
                Convert.ToInt32(coordinates[1]));
        }

        /// <summary>
        /// Validate the robot's landing position input and parse to X, Y coordinates and direction.
        /// </summary>
        /// <param name="input">The input.</param>
        public static Tuple<int, int, Direction> TryParseRobotLandingPosition(this string input)
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
            return Tuple.Create(
                Convert.ToInt32(coordinates[0]),
                Convert.ToInt32(coordinates[1]),
                coordinates[2].ToDirection());
        }
    }
}
