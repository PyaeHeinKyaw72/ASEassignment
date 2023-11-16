using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEassignment
{
    /// <summary>
    /// A collection of shapes for drawing.
    /// </summary>
    public class Shapes
    {
        public List<Shape> shapes = new List<Shape>();

        /// <summary>
        /// Adds a shape to the collection.
        /// </summary>
        /// <param name="shape">The shape to add.</param>
        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }

        /// <summary>
        /// Draws all shapes in the collection.
        /// </summary>
        /// <param name="graphics">The graphics object used for drawing.</param>
        public void DrawShapes(Graphics graphics)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(graphics);
            }
        }

        /// <summary>
        /// Clears all shapes from the list
        /// </summary>
        public void ClearShapes()
        {
            shapes.Clear();
        }
    }

    /// <summary>
    /// Represents an abstract shape for drawing.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Gets or sets the color of the shape.
        /// </summary>
        public Color color;

        /// <summary>
        /// Gets or sets whether the shape is filled with color.
        /// </summary>
        public bool colorFilled;
        public abstract void Draw(Graphics graphics);

    }
}
