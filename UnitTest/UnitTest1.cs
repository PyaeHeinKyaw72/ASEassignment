using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ASEassignment;
using System.Windows.Forms;
using System.Drawing;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Testing the commandLine by running the command drawto command and check its location points
        /// </summary>
        [TestMethod]
        public void commandLine_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            RichTextBox programBox = new RichTextBox();
            Command command = new Command(drawingTool, programBox);

            // Act
            command.Run("drawto 30,40");

            // Assert
            Assert.AreEqual(30, drawingTool.penLocation.X);
            Assert.AreEqual(40, drawingTool.penLocation.Y);
        }

        /// <summary>
        /// Testing if it can run multiple program line  by running multi lines of draw rectangle checking if it's there
        /// </summary>
        [TestMethod]
        public void multiLine_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            RichTextBox richTextBox = new RichTextBox();
            Command command = new Command(drawingTool, richTextBox);

            // Act
            command.RunProgram("rectangle 5,5");
            command.RunProgram("rectangle 5,5");
            command.RunProgram("rectangle 5,5");

            // Assert
            Assert.AreEqual(3, drawingTool.Shapes.shapes.Count);
        }

        // <summary>
        // Testing the validation by using validate moveto command and exception
        // </summary>
        [TestMethod]
        public void valid_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            RichTextBox programBox = new RichTextBox();
            Command command = new Command(drawingTool, programBox);
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
            RichTextBox programBox = new RichTextBox();
            Command command = new Command(drawingTool, programBox);
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

        /// <summary>
        /// Testing invalid parameter by checking if exception is thrown
        /// </summary>
        [TestMethod]
        public void invalidParameter_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            RichTextBox richTextBox = new RichTextBox();
            Command command = new Command(drawingTool, richTextBox);
            string invalidParameter = "circle x";

            // Act and Assert
            try
            {
                command.Run(invalidParameter);

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
        /// Testing the moveTo command by checking the location of the pen
        /// </summary>
        [TestMethod]
        public void moveToCommand_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());

            // Act
            drawingTool.Move(50, 100);

            // Assert
            Assert.AreEqual(50, drawingTool.penLocation.X);
            Assert.AreEqual(100, drawingTool.penLocation.Y);
        }

        /// <summary>
        /// Testing the drawTo command by checking the line starting location and end location
        /// </summary>
        [TestMethod]
        public void drawToCommand_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());

            // Act
            drawingTool.Draw(50, 100);

            // Assert
            Assert.AreEqual(2, drawingTool.linePoints.Count);
            Assert.AreEqual(new Point(0, 0), drawingTool.linePoints[0]);
            Assert.AreEqual(new Point(50, 100), drawingTool.linePoints[1]);
        }

        /// <summary>
        /// Testing the clear command by checking if there's any shapes or line on the panel
        /// </summary>
        [TestMethod]
        public void clearCommand_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());

            // Add some points and shapes to simulate a drawing
            drawingTool.Draw(50, 100);
            drawingTool.Rectangle(30, 40);
            drawingTool.Circle(25);
            drawingTool.Triangle(50, 60, 70);

            // Act
            drawingTool.Clear();

            // Assert
            Assert.AreEqual(0, drawingTool.linePoints.Count);
            Assert.AreEqual(0, drawingTool.Shapes.shapes.Count);
        }

        /// <summary>
        /// Testing the reset command by checking if the pen went back to it's original location
        /// </summary>
        [TestMethod]
        public void resetCommand_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            drawingTool.Move(50, 100);

            // Act
            drawingTool.ResetPosition();

            // Assert
            Assert.AreEqual(new Point(0, 0), drawingTool.penLocation);
        }

        /// <summary>
        /// Testing the rectangle command by checking if the drawn shape is an rectangle
        /// </summary>
        [TestMethod]
        public void rectangleCommand_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            int width = 100;
            int height = 50;

            // Act
            drawingTool.Rectangle(width, height);

            // Assert
            Shapes s = drawingTool.Shapes;
            Assert.AreEqual(1, s.shapes.Count);
            Assert.IsInstanceOfType(s.shapes[0], typeof(RectangleShape));
        }

        /// <summary>
        /// Testing the circle command by checking if the drawn shape is a circle
        /// </summary>
        [TestMethod]
        public void circleCommand_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            int radius = 30;

            // Act
            drawingTool.Circle(radius);

            // Assert
            Shapes s = drawingTool.Shapes;
            Assert.AreEqual(1, s.shapes.Count);
            Assert.IsInstanceOfType(s.shapes[0], typeof(CircleShape));
        }

        /// <summary>
        /// Testing the triangle command by checking if the drawn shape is an triangle
        /// </summary>
        [TestMethod]
        public void triangleCommand_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            int triangleBase = 60;
            int adj = 40;
            int hyp = 50;

            // Act
            drawingTool.Triangle(triangleBase, adj, hyp);

            // Assert
            Shapes s = drawingTool.Shapes;
            Assert.AreEqual(1, s.shapes.Count);
            Assert.IsInstanceOfType(s.shapes[0], typeof(TriangleShape));
        }

        /// <summary>
        /// Testing the color command by checking if the pen color is matching with the color value
        /// </summary>
        [TestMethod]
        public void penColor_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            Color newPenColor = Color.Red;

            // Act
            drawingTool.SetPenColor(newPenColor);

            // Assert
            Assert.AreEqual(newPenColor, drawingTool.PenColor);
        }

        /// <summary>
        /// Testing the fill color command by checking if the fill status is matching with the value
        /// </summary>

        [TestMethod]
        public void fillColor_Test()
        {
            // Arrange
            DrawingTool drawingTool = new DrawingTool(new Panel());
            bool newColorFillStatus = true;

            // Act
            drawingTool.SetColorFill(newColorFillStatus);

            // Assert
            Assert.AreEqual(newColorFillStatus, drawingTool.ColorFillEnabled);
        }
    }
}
