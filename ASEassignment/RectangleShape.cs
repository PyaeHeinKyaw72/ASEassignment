using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEassignment
{
    /// <summary>
    /// rectangle shape for drawing
    /// </summary>
    public class RectangleShape : Shape
    {
        private Rectangle rectangle;

        /// <param name="rectangle">The rectangle to represent the shape</param>
        /// // <param name="color">The color of the shape</param>
        /// <param name="colorFilled">Whether the shape is filled with color</param>
        public RectangleShape(Rectangle rectangle, Color color, bool colorFilled)
        {
            this.rectangle = rectangle;
            this.color = color;
            this.colorFilled = colorFilled;
        }

        /// <summary>
        /// Draw rectangle shape
        /// </summary>
        /// <param name="graphics">The graphics object used for drawing</param>
        public override void Draw(Graphics graphics)
        {
            using (var pen = new Pen(color, 3))
            {
                if (colorFilled)
                {
                    using (var brush = new SolidBrush(color))
                    {
                        graphics.FillRectangle(brush, rectangle);
                    }
                }
                graphics.DrawRectangle(pen, rectangle);
            }
        }
    }
}
