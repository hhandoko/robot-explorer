// -----------------------------------------------------------------------
// <copyright file="Terrain.cs">
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
    /// The exploration's terrain / grid.
    /// </summary>
    public class Terrain
    {
        /// <summary>
        /// The terrain's X coordinate boundary.
        /// </summary>
        private static int xBound = 10;

        /// <summary>
        /// The terrain's Y coordinate boundary.
        /// </summary>
        private static int yBound = 10;

        /// <summary>
        /// Creates a new instance of <see cref="Terrain"/>.
        /// </summary>
        /// <param name="xCoord">The terrain's X coordinate boundary.</param>
        /// <param name="yCoord">The terrain's Y coordinate boundary.</param>
        public Terrain(int xCoord, int yCoord)
        {
            // TODO: Catch args exception
            xBound = xCoord;
            yBound = yCoord;
        }
    }
}
