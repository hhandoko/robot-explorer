// -----------------------------------------------------------------------
// <copyright file="Direction.cs">
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
    /// The robot's compass direction.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Facing North.
        /// </summary>
        N = 0,

        /// <summary>
        /// Facing East.
        /// </summary>
        E = 90,

        /// <summary>
        /// Facing South.
        /// </summary>
        S = 180,

        /// <summary>
        /// Facing West.
        /// </summary>
        W = 270
    }
}
