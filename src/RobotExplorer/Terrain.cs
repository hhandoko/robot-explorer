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
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The exploration's terrain / grid.
    /// </summary>
    public class Terrain
    {
        /// <summary>
        /// Creates a new instance of <see cref="Terrain"/>.
        /// </summary>
        /// <param name="xCoord">The terrain's X coordinate boundary.</param>
        /// <param name="yCoord">The terrain's Y coordinate boundary.</param>
        public Terrain(int xCoord, int yCoord)
        {
            // TODO: Catch args exception
            this.XBoundary = xCoord;
            this.YBoundary = yCoord;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Terrain"/>.
        /// </summary>
        /// <param name="boundary">The terrain's X, Y coordinates as a double.</param>
        public Terrain(Tuple<int, int> boundary)
        {
            this.XBoundary = boundary.Item1;
            this.YBoundary = boundary.Item2;
        }

        /// <summary>
        /// Gets or sets the X coordinate boundary.
        /// </summary>
        public int XBoundary { get; private set; }

        /// <summary>
        /// Gets or sets the Y coordinate boundary.
        /// </summary>
        public int YBoundary { get; private set; }

        /// <summary>
        /// The terrain's robots.
        /// </summary>
        public Dictionary<int, Robot> Robots { get; set; }
    }
}
