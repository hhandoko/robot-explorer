// -----------------------------------------------------------------------
// <copyright file="RobotTests.cs">
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
namespace RobotExplorerTest
{
    using System;

    using NUnit.Framework;

    using RobotExplorer;

    /// <summary>
    /// The robot's tests.
    /// </summary>
    public class RobotTests
    {
        /// <summary>
        /// Test if the robot can process left turn commands successfully.
        /// </summary>
        /// <param name="initialDirection">The initial direction.</param>
        /// <param name="expectedResult">The expected final direction / result.</param>
        [TestCase(Direction.N, Direction.W)]
        [TestCase(Direction.E, Direction.N)]
        [TestCase(Direction.S, Direction.E)]
        [TestCase(Direction.W, Direction.S)]
        public void CanTurnLeft(Direction initialDirection, Direction expectedResult)
        {
            // Arrange
            var robot = new Robot(0, 0, initialDirection);

            // Act
            robot.FaceLeft();

            // Assert
            Assert.AreEqual(robot.Direction, expectedResult);
        }

        /// <summary>
        /// Test if the robot can process right turn commands successfully.
        /// </summary>
        /// <param name="initialDirection">The initial direction.</param>
        /// <param name="expectedResult">The expected final direction / result.</param>
        [TestCase(Direction.N, Direction.E)]
        [TestCase(Direction.E, Direction.S)]
        [TestCase(Direction.S, Direction.W)]
        [TestCase(Direction.W, Direction.N)]
        public void CanTurnRight(Direction initialDirection, Direction expectedResult)
        {
            // Arrange
            var robot = new Robot(0, 0, initialDirection);

            // Act
            robot.FaceRight();

            // Assert
            Assert.AreEqual(robot.Direction, expectedResult);
        }

        /// <summary>
        /// Test if the robot can process forward move commands successfully.
        /// </summary>
        /// <param name="initialDirection">The initial direction.</param>
        /// <param name="initPos">The initial X, Y coordinate as array.</param>
        /// <param name="expectedPos">The expected X, Y coordinate as array result.</param>
        [TestCase(Direction.N, new[] { 2, 2 }, new[] { 2, 3 })]
        [TestCase(Direction.E, new[] { 2, 2 }, new[] { 3, 2 })]
        [TestCase(Direction.S, new[] { 2, 2 }, new[] { 2, 1 })]
        [TestCase(Direction.W, new[] { 2, 2 }, new[] { 1, 2 })]
        public void CanMoveForward(Direction initialDirection, int[] initPos, int[] expectedPos)
        {
            // Arrange
            var robot = new Robot(initPos[0], initPos[1], initialDirection);

            // Act
            robot.MoveForward();

            // Assert
            Assert.AreEqual(new[] { robot.XPos, robot.YPos}, expectedPos);
        }
        
        /// <summary>
        /// Test if the robot can process command successfully.
        /// </summary>
        /// <param name="initialDirection">The initial direction.</param>
        /// <param name="initPos">The initial X, Y coordinate as array.</param>
        /// <param name="command">The move command.</param>
        /// <param name="expectedDirection">The expected direction.</param>
        /// <param name="expectedPos">The expected X, Y coordinate as array.</param>
        [TestCase(Direction.N, new[] { 2, 2 }, 'L', Direction.W, new[] { 2, 2 })]
        [TestCase(Direction.N, new[] { 2, 2 }, 'R', Direction.E, new[] { 2, 2 })]
        [TestCase(Direction.N, new[] { 2, 2 }, 'M', Direction.N, new[] { 2, 3 })]
        public void CanMoveOnCommand(Direction initialDirection, int[] initPos, char command, Direction expectedDirection, int[] expectedPos)
        {
            // Arrange
            var initialState = new Robot(initPos[0], initPos[1], initialDirection);
            var expectedState = new Robot(expectedPos[0], expectedPos[1], expectedDirection);

            // Act
            initialState.Move(command);

            // Assert
            Assert.AreEqual(
                new[] { initialState.XPos, initialState.YPos, (int)initialState.Direction },
                new[] { expectedState.XPos, expectedState.YPos, (int)expectedState.Direction });
        }

        /// <summary>
        /// Test if an exception will be thrown on invalid move command.
        /// </summary>
        /// <param name="command">The move command.</param>
        [TestCase('X')]
        [TestCase('c')]
        [TestCase('1')]
        [TestCase('#')]
        public void ThrowExceptionOnInvalidCommand(char command)
        {
            // Arrange
            var robot = new Robot(0, 0, Direction.N);

            // Act + Assert
            Assert.Throws<ArgumentException>(delegate
            {
                robot.Move(command);
            });
        }
    }
}
