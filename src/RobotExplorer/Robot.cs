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
    using System;

    /// <summary>
    /// The robot explorer.
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// The robot's current direction.
        /// </summary>
        private static Direction direction = Direction.N;

        /// <summary>
        /// Creates a new instance of <see cref="Robot"/>.
        /// </summary>
        /// <param name="xPos">The robot's initial X coordinate position.</param>
        /// <param name="yPos">The robot's initial Y coordinate position.</param>
        /// <param name="direction">The robot's initial direction.</param>
        public Robot(int xPos, int yPos, Direction direction)
        {
            // TODO: Catch args exception
            this.XPos = xPos;
            this.YPos = yPos;
            this.Direction = direction;
        }

        /// <summary>
        /// Gets the robot's current X coordinate.
        /// </summary>
        public int XPos { get; private set; }

        /// <summary>
        /// Gets the robot's current Y coordinate.
        /// </summary>
        public int YPos { get; private set; }

        /// <summary>
        /// Gets the robot's current direction.
        /// </summary>
        public Direction Direction { get; private set; }

        /// <summary>
        /// Move the robot based on a given command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Move(char command)
        {
            switch (command)
            {
                case 'L':
                    this.FaceLeft();
                    break;

                case 'R':
                    this.FaceRight();
                    break;

                case 'M':
                    this.MoveForward();
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Robot will turn and face left.
        /// </summary>
        public void FaceLeft()
        {
            // Logic simplification. Instead of four ifs / switch case,
            // more concise to reduce the direction angle by 90 degrees
            // and cast back to enum.
            this.Direction =
                this.Direction == Direction.N
                    ? Direction.W
                    : (Direction)((int)this.Direction - 90);
        }

        /// <summary>
        /// Robot will turn and face right.
        /// </summary>
        public void FaceRight()
        {
            // Logic simplification. Instead of four ifs / switch case,
            // more concise to increase the direction angle by 90 degrees
            // and cast back to enum.
            this.Direction =
                this.Direction == Direction.W
                    ? Direction.N
                    : (Direction)((int)this.Direction + 90);
        }

        /// <summary>
        /// Robot will move forward one coordinate point.
        /// </summary>
        public void MoveForward()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.YPos++;
                    break;

                case Direction.S:
                    this.YPos--;
                    break;

                case Direction.E:
                    this.XPos++;
                    break;

                case Direction.W:
                    this.XPos--;
                    break;
            }
        }
    }
}
