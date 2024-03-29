﻿using ASEassignment;
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
        public TriangleShape triangle;

        /// <summary>
        /// Gets the collection of shapes drawn by the drawing tool.
        /// </summary>
        public Shapes Shapes { get; } = new Shapes();

        /// <summary>
        /// Gets or sets a value indicating whether color filling is enabled.
        /// </summary>
        public bool ColorFillEnabled { get; set; } = false;

        /// <summary>
        /// Gets or sets the color used for drawing.
        /// </summary>
        public Color PenColor { get; set; } = Color.White;

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
            using (var pen = new Pen(PenColor, 3))
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
        /// Add a rectangle with specified width and height to the shape list to draw
        /// </summary>
        public void Rectangle(int width, int height)
        {
            Rectangle rectangle = new Rectangle(penLocation.X, penLocation.Y, width, height);
            Shapes.AddShape(new RectangleShape(rectangle, PenColor, ColorFillEnabled));
            drawingPanel.Invalidate();
        }

        /// <summary>
        /// Add a circle with specified radius to the shape list to draw
        /// </summary>
        public void Circle(int radius)
        {
            Point center = penLocation;
            Shapes.AddShape(new CircleShape(center, radius, PenColor, ColorFillEnabled));
            drawingPanel.Invalidate();
        }

        /// <summary>
        /// Draws a triangle with the specified base, adjacent, and hypotenuse.
        /// </summary>
        public void Triangle(int triangleBase, int adj, int hyp)
        {
            int x1 = penLocation.X;
            int y1 = penLocation.Y;

            int x2 = x1 + triangleBase;
            int y2 = y1;

            int x3 = x1 + adj;
            int y3 = y1 - hyp;

            triangle = new TriangleShape(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3), PenColor, ColorFillEnabled);
            Shapes.AddShape(triangle);

            drawingPanel.Invalidate();
        }

        /// <summary>
        /// Sets the drawing pen color
        /// </summary>
        public void SetPenColor(Color color)
        {
            PenColor = color;
        }

        /// <summary>
        /// Sets the color fill status
        /// </summary>
        public void SetColorFill(bool isColorFillEnabled)
        {
            ColorFillEnabled = isColorFillEnabled;
        }

        public void RefreshPanel()
        {
            drawingPanel.Refresh();
        }
    }
}
