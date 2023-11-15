using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEassignment
{
    public class DrawingTool
    {
        public Point penLocation = new Point(0, 0);
        public List<Point> linePoints = new List<Point>();
        public Panel drawingPanel;

        public DrawingTool(Panel panel)
        {
            drawingPanel = panel;
        }

        public void Draw(int x, int y)
        {
            linePoints.Add(new Point(penLocation.X, penLocation.Y));
            linePoints.Add(new Point(x, y));

            drawingPanel.Invalidate();
            penLocation = new Point(x, y);
        }

        public void Paint(Graphics graphics)
        {
            using (var pen = new Pen(Color.Black, 3))
            {
                for (int i = 0; i < linePoints.Count - 1; i += 2)
                {
                    graphics.DrawLine(pen, linePoints[i], linePoints[i + 1]);
                }
            }
        }
    }
}
