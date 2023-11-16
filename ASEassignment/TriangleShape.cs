using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEassignment
{
    public class TriangleShape : Shape
    {
        private Point p1;
        private Point p2;
        private Point p3;


        /// <param name="p1">The first point of the triangle.</param>
        /// <param name="p2">The second point of the triangle.</param>
        /// <param name="p3">The third point of the triangle.</param>
        /// <param name="color">The color of the triangle.</param>
        /// <param name="colorFilled">Specifies whether the triangle should be filled with color.</param>
        public TriangleShape(Point p1, Point p2, Point p3, Color color, bool colorFilled)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.color = color;
            this.colorFilled = colorFilled;
        }

        /// <summary>
        /// Draws the triangle on the specified graphics surface.
        /// </summary>
        /// <param name="graphics">The graphics surface to draw the triangle on.</param>
        public override void Draw(Graphics graphics)
        {
            // Create a pen with the specified color and width
            using (var pen = new Pen(color, 3))
            {
                // Draw the three sides of the triangle
                graphics.DrawLine(pen, p1, p2);
                graphics.DrawLine(pen, p2, p3);
                graphics.DrawLine(pen, p3, p1);

                // If colorFilled is true, fill the triangle with the specified color
                if (colorFilled)
                {
                    using (var brush = new SolidBrush(color))
                    {
                        Point[] points = { p1, p2, p3 };
                        graphics.FillPolygon(brush, points);
                    }
                }
            }
        }
    }
}
