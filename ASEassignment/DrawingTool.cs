using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEassignment
{
    /// <summary> drawing related stuff for the panel </summary>
    public class DrawingTool
    {
        public Point penLocation = new Point(0, 0);
        public List<Point> linePoints = new List<Point>();
        public Panel drawingPanel;

        /// <param name="panel">The drawing panel</param>
        public DrawingTool(Panel panel)
        {
            drawingPanel = panel;
        }

        /// <summary> Drawing a line (drawTo) </summary>
        /// <param name="x"> The x-coordinate </param>
        /// <param name="y"> The y-coordinate </param>
        public void Draw(int x, int y)
        {
            
            linePoints.Add(new Point(penLocation.X, penLocation.Y)); /// Add the current pen location to the list of points
            linePoints.Add(new Point(x, y)); /// Add the specified coordinates to the list of points
            
            drawingPanel.Invalidate(); /// Invalidate the panel to trigger a repaint
            penLocation = new Point(x, y); /// Update the pen location to the specified coordinates
        }

        /// <summary> Move pen location (moveTo) </summary>
        /// <param name="x"> The x-coordinate </param>
        /// <param name="y"> The y-coordinate </param>
        public void Move(int x, int y)
        {
            penLocation = new Point(x, y);
        }

        /// <param name="graphics">The graphics object to paint </param>
        public void Paint(Graphics graphics)
        {
            using (var pen = new Pen(Color.Black, 3))
            {
                // Iterate through the list of points and draw lines between consecutive points
                for (int i = 0; i < linePoints.Count - 1; i += 2)
                {
                    graphics.DrawLine(pen, linePoints[i], linePoints[i + 1]);
                }
            }
        }

        /// <summary>
        /// Clears the panel
        /// </summary>
        public void Clear()
        {
            linePoints.Clear();
            drawingPanel.Invalidate();
        }

        /// <summary>
        /// Resets the pen position
        /// </summary>
        public void ResetPosition()
        {
            penLocation = new Point(0, 0);
        }
    }
}
