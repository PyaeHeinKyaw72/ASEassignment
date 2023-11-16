using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEassignment
{
    public class CircleShape : Shape
    {
        private Point center;
        private int radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleShape"/> class.
        /// </summary>
        /// <param name="center">The center point of the circle.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="color">The color of the circle.</param>
        /// <param name="colorFilled">Whether the circle is filled with color.</param>
        public CircleShape(Point center, int radius, Color color, bool colorFilled)
        {
            this.center = center;
            this.radius = radius;
            this.color = color;
            this.colorFilled = colorFilled;
        }

        /// <summary>
        /// Draws the circle shape.
        /// </summary>
        /// <param name="graphics">The graphics object used for drawing.</param>
        public override void Draw(Graphics graphics)
        {
            using (var pen = new Pen(color, 3))
            {
                if (colorFilled)
                {
                    using (var brush = new SolidBrush(color))
                    {
                        graphics.FillEllipse(brush, center.X - radius, center.Y - radius, radius * 2, radius * 2);
                    }
                }
                graphics.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
            }
        }
    }
}
