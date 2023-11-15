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
        public RectangleShape(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        /// <summary>
        /// Draw rectangle shape
        /// </summary>
        /// <param name="graphics">The graphics object used for drawing</param>
        public override void Draw(Graphics graphics)
        {
            using (var pen = new Pen(Color.Red, 3))
            {
                graphics.DrawRectangle(pen, rectangle);
            }
        }
    }
}
