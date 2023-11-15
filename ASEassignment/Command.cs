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
        private RichTextBox programBox;

        /// <param name="drawingTool">The drawing tool to be used for executing commands</param>
        public Command(DrawingTool drawingTool, RichTextBox programBox)
        {
            this.drawingTool = drawingTool;
            this.programBox = programBox;
        }

        /// <summary> Executes a command based on the inputed text </summary>
        /// <param name="commandText">The command text to be executed</param>
        public void Run(string commandText)
        {
            if (commandText.Trim().ToLower() == "run")
            {
                RunProgram(programBox.Text);
                return;
            }

            commands CommandType = CommandParser.parseCommand(commandText, out int x, out int y,out int width, out int height);
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

                    case commands.Rectangle:
                        drawingTool.Rectangle(width, height);
                        break;

                    case commands.Clear:
                        drawingTool.Clear();
                        break;

                    case commands.Reset:
                        drawingTool.ResetPosition();
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
        public void RunProgram(string programText)
        {
            // Split the programText into individual commands
            string[] commands = programText.Split('\n', '\r');

            // Execute each command
            foreach (string commandLine in commands)
            {
                Run(commandLine);
            }

            // Refresh the panel to update the drawings
            drawingTool.RefreshPanel();
        }
    }
}
            
