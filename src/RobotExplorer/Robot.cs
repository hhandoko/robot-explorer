// -----------------------------------------------------------------------
// <copyright file="Robot.cs">
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
    /// <summary>
    /// The robot explorer.
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// The robot's current X coordinates.
        /// </summary>
        private static int xPos = 0;

        /// <summary>
        /// The robot's current Y coordinates.
        /// </summary>
        private static int yPos = 0;

        /// <summary>
        /// The robot's current direction.
        /// </summary>
        private static Direction direction = Direction.N;

        /// <summary>
        /// Creates a new instance of <see cref="Robot"/>.
        /// </summary>
        /// <param name="xCoord">The robot's initial X coordinates position.</param>
        /// <param name="yCoord">The robot's initial Y coordinates position.</param>
        /// <param name="dir">The robot's initial direction.</param>
        public Robot(int xCoord, int yCoord, Direction dir)
        {
            // TODO: Catch args exception
            xPos = xCoord;
            yPos = yCoord;
            direction = dir;
        }
    }
}
