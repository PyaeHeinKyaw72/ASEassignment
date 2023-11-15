using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEassignment
{
    internal class Command
    {
        private DrawingTool drawingTool;

        public Command(DrawingTool drawingTool)
        {
            this.drawingTool = drawingTool;
        }
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
            
