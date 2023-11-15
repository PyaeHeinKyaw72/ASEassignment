using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ASEassignment;
using System.Windows.Forms;
using System.Drawing;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testing the commandLine by running the command drawto command and check its location points
        /// </summary>
        [TestMethod]
        public void commandLine_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            Command command = new Command(drawingTool);

            // Act
            command.Run("drawto 30,40");

            // Assert
            Assert.AreEqual(30, drawingTool.penLocation.X);
            Assert.AreEqual(40, drawingTool.penLocation.Y);
        }

        // <summary>
        // Testing the validation by using validate moveto command and exception
        // </summary>
        [TestMethod]
        public void valid_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            Command command = new Command(drawingTool);
            string validCommand = "drawto 10,20";

            // Act and Assert
            try
            {
                command.Run(validCommand);

                // If no exception is thrown, the test passes
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                // If an exception is thrown, the test fails
                Assert.Fail();
            }
        }

        /// <summary>
        /// Testing the validation method by using invalid command and exception
        /// </summary>
        [TestMethod]
        public void invalidCommand_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            Command command = new Command(drawingTool);
            string invalidCommand = "drto 10,20";

            // Act and Assert
            try
            {
                command.Run(invalidCommand);

                // If no exception is thrown, the test passes
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                // If an exception is thrown, the test fails
                Assert.Fail();
            }
        }
    }
}
