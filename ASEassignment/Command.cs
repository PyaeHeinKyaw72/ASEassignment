using System;
using System.Collections.Generic;
using System.Drawing;
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
        private bool inWhileBlock;

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

            commands CommandType = CommandParser.parseCommand(commandText, out int x, out int y,out int width, out int height, out int radius, out Color penColor, out bool colorFillEnabled, out string variableName);
            try
            {
                // Check if the condition is false and the command is not an EndIf, skip the execution
                if (!CommandParser.GetCondition() && CommandType != commands.EndIf)
                    return;

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

                    case commands.Circle:
                        drawingTool.Circle(radius);
                        break;

                    case commands.Triangle:
                        drawingTool.Triangle(x, y, width);
                        break;

                    case commands.PenColor:
                        drawingTool.SetPenColor(penColor);
                        break;
                    case commands.ColorFill:
                        drawingTool.SetColorFill(colorFillEnabled);
                        break;

                    case commands.Clear:
                        drawingTool.Clear();
                        break;

                    case commands.Reset:
                        drawingTool.ResetPosition();
                        break;

                    case commands.If:
                        CommandParser.SetCondition(CommandParser.EvaluateCondition(commandText.Split(' ')));
                        break;
                    case commands.EndIf:
                        CommandParser.SetCondition(true);
                        break;

                    case commands.While:
                        // Get the condition and loop start position
                        bool whileCondition = CommandParser.EvaluateCondition(commandText.Split(' '));
                        int loopStartPosition = programBox.GetLineFromCharIndex(programBox.Text.IndexOf("while"));

                        // Set the condition using CommandParser.SetCondition
                        CommandParser.SetCondition(whileCondition);

                        // Set the flag to indicate whether in the while block
                        inWhileBlock = whileCondition;

                        // Loop only if the condition is currently true
                        while (inWhileBlock && whileCondition)
                        {
                            // Execute each command within the while block
                            for (int i = loopStartPosition + 1; i < programBox.Lines.Length; i++)
                            {
                                string line = programBox.Lines[i];

                                // Break the loop if encountering "endloop"
                                if (line.Trim().ToLower() == "endloop")
                                    break;

                                // Skip execution if not in the while block or condition is false
                                if (!inWhileBlock || !whileCondition)
                                    break;

                                // If the condition becomes false during execution, break out of the loop
                                if (!CommandParser.EvaluateCondition(commandText.Split(' ')))
                                {
                                    inWhileBlock = false;
                                    break;
                                }
                                Run(line);
                            }
                        }
                        break;

                    case commands.EndLoop:
                        // The EndLoop command is handled inside the While case
                        inWhileBlock = false;
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
            
