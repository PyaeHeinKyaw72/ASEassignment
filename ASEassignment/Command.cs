using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEassignment
{
    ///Represents a command to be executed on a drawing tool
    public class Command
    {
        private DrawingTool drawingTool;

        /// <param name="drawingTool">The drawing tool to be used for executing commands</param>
        public Command(DrawingTool drawingTool)
        {
            this.drawingTool = drawingTool;
        }

        /// <summary> Executes a command based on the inputed text </summary>
        /// <param name="commandText">The command text to be executed</param>
        public void Run(string commandText)
        {
            commands CommandType = CommandParser.parseCommand(commandText, out int x, out int y);
            try
            {
                switch (CommandType)
                {
                    case commands.DrawTo:
                        drawingTool.Draw(x, y);
                        break;

                    case commands.MoveTo:
                        drawingTool.Move(x, y);
                        break;

                    case commands.Invalid:
                        throw new InvalidOperationException();
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid command or parameter!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
            
