using ASEassignment;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ASEassignment
{
    /// <summary>
    /// Tool for drawing shapes on the panel.
    /// </summary>
    public class DrawingTool
    {
        public Point penLocation = new Point(0, 0);
        public List<Point> linePoints = new List<Point>();
        public Panel drawingPanel;

        /// <summary>
        /// Gets the collection of shapes drawn by the drawing tool.
        /// </summary>
        public Shapes Shapes { get; } = new Shapes();


        /// <param name="panel">The panel to draw on.</param>
        public DrawingTool(Panel panel)
        {
            drawingPanel = panel;
        }

        /// <summary>
        /// Moves the pen to the specified coordinates.
        /// </summary>
        public void Move(int x, int y)
        {
            penLocation = new Point(x, y);
        }

        /// <summary>
        /// Draws a line from the current pen location to the specified coordinates.
        /// </summary>
        public void Draw(int x, int y)
        {
            linePoints.Add(new Point(penLocation.X, penLocation.Y));
            linePoints.Add(new Point(x, y));

            drawingPanel.Invalidate();
            penLocation = new Point(x, y);
        }

        /// <summary>
        /// Paints the drawn shapes on the specified graphics surface.
        /// </summary>
        public void Paint(Graphics graphics)
        {
            using (var pen = new Pen(Color.Black, 3))
            {
                for (int i = 0; i < linePoints.Count - 1; i += 2)
                {
                    graphics.DrawLine(pen, linePoints[i], linePoints[i + 1]);
                }
            }

            Shapes.DrawShapes(graphics);
        }

        /// <summary>
        /// Clears the drawn shapes and lines.
        /// </summary>
        public void Clear()
        {
            linePoints.Clear();
            Shapes.ClearShapes();
            drawingPanel.Invalidate();
        }

        /// <summary>
        /// Resets the pen position.
        /// </summary>
        public void ResetPosition()
        {
            penLocation = new Point(0, 0);
        }

        /// <summary>
        /// Draws a rectangle with the specified width and height.
        /// </summary>
        public void Rectangle(int width, int height)
        {
            Rectangle rectangle = new Rectangle(penLocation.X, penLocation.Y, width, height);
            Shapes.AddShape(new RectangleShape(rectangle));
            drawingPanel.Invalidate();
        }

        public void RefreshPanel()
        {
            drawingPanel.Refresh();
        }
    }
}
