using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEassignment
{

    /// Represents a set of commands for the drawing tool
    public enum commands
    {
        /// Command to draw a line
        DrawTo,
        
        ///  For moving pen location
        MoveTo,

        /// Clear the drawing
        Clear,

        /// Reset the position to the pen
        Reset,

        /// To run a program
        Run,

        /// Draw a rectangle with specified width and height
        Rectangle,

        /// Draw a circle with specified radius
        Circle,

        /// Draw a triangle with specified three points
        Triangle,

        /// For changing pen color
        PenColor,

        /// For filling shape color
        ColorFill,

        /// For variable assignment
        VariableAssignment,

        /// For invalid command
        Invalid
    }

    /// Parses user input to determine the command and its parameters
    public class CommandParser
    {
        public static Dictionary<string, int> assignedVariables { get; private set; } = new Dictionary<string, int>();

        /// <param name="input">The input command string.</param>
        /// <param name="x">The X-coordinate value.</param>
        /// <param name="y">The Y-coordinate value.</param>
        /// <param name="width">The width value </param>
        /// <param name="height">The height value.</param>
        /// <param name="penColor">The color value.</param>
        /// <param name="colorFillEnabled">The fill status.</param>
        public static commands parseCommand(string input, out int x, out int y,out int width, out int height, out int radius, out Color penColor, out bool colorFillEnabled, out string variableName)
        {
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            radius = 0;
            penColor = Color.White;
            colorFillEnabled = false;
            variableName = null;

            string[] command = input.ToLower().Split(' ', ',');

            if (command.Length >= 1)
            {
                string inputCommand = command[0];

                switch (inputCommand)
                {
                    case "drawto":
                        if (command.Length == 3)
                        {
                            if ((int.TryParse(command[1], out x) || assignedVariables.TryGetValue(command[1].ToLower(), out x)) &&
                                (int.TryParse(command[2], out y) || assignedVariables.TryGetValue(command[2].ToLower(), out y)))
                            {
                                return commands.DrawTo;
                            }
                        }
                        break;

                    case "moveto":
                        if (command.Length == 3)
                        {
                            if ((int.TryParse(command[1], out x) || assignedVariables.TryGetValue(command[1].ToLower(), out x)) &&
                                (int.TryParse(command[2], out y) || assignedVariables.TryGetValue(command[2].ToLower(), out y)))
                            {
                                return commands.MoveTo;
                            }
                        }
                        break;

                    case "rectangle":
                        if (command.Length == 3)
                        {
                            if ((int.TryParse(command[1], out width) || assignedVariables.TryGetValue(command[1].ToLower(), out width)) && (int.TryParse(command[2], out height) || assignedVariables.TryGetValue(command[2].ToLower(), out height)))
                            {
                                return commands.Rectangle;
                            }
                        }
                        break;

                    case "circle":
                        if (command.Length == 2)
                        {
                            if (int.TryParse(command[1], out radius) || assignedVariables.TryGetValue(command[1].ToLower(), out radius))
                            {
                                return commands.Circle;
                            }
                        }
                        break;

                    case "triangle":
                        if (command.Length == 4)
                        {
                            if ((int.TryParse(command[1], out x) || assignedVariables.TryGetValue(command[1].ToLower(), out x)) &&
                                (int.TryParse(command[2], out y) || assignedVariables.TryGetValue(command[2].ToLower(), out y)) &&
                                (int.TryParse(command[3], out width) || assignedVariables.TryGetValue(command[3].ToLower(), out width)))
                            {
                                return commands.Triangle;
                            }
                        }
                        break;

                    case "pen":
                        if (command.Length == 2)
                        {
                            string color = command[1].ToLower();
                            string[] colorList = { "black", "red", "green", "blue", "yellow", "pink", "white" };

                            if (colorList.Contains(color))
                            {
                                penColor = Color.FromName(color);
                                return commands.PenColor;
                            }
                        }
                        break;

                    case "fill":
                        if (command.Length == 2)
                        {
                            string fillStatus = command[1].ToLower();
                            if (fillStatus == "on" || fillStatus == "off")
                            {
                                colorFillEnabled = fillStatus == "on";
                                return commands.ColorFill;
                            }
                        }
                        break;

                    case "clear":
                        if (command.Length == 1)
                        {
                            return commands.Clear;
                        }
                        break;

                    case "reset":
                        if (command.Length == 1)
                        {
                            return commands.Reset;
                        }
                        break;

                    case "run":
                        if (command.Length == 1)
                        {
                            return commands.Run;
                        }
                        break;
                    case "let":
                        if (command.Length >= 4 && command[2] == "=")
                        {
                            variableName = command[1].ToLower();

                            // Check if the right-hand side is a simple integer value
                            if (int.TryParse(command[3], out int variableValue))
                            {
                                assignedVariables[variableName] = variableValue;
                            }
                            else
                            {
                                // If not, it's treated as an expression
                                string expression = string.Join(" ", command.Skip(3));

                                // Initialize the ExpressionEvaluator with the current assigned variables
                                ExpressionEvaluator expressionEvaluator = new ExpressionEvaluator(assignedVariables);

                                // Evaluate the expression to get the variable value
                                variableValue = expressionEvaluator.Evaluate(expression);

                                // Assign the variable with the specified value
                                assignedVariables[variableName] = variableValue;
                            }

                            x = variableValue;
                            y = variableValue;
                            width = variableValue;
                            height = variableValue;
                            radius = variableValue;

                            return commands.VariableAssignment;
                        }
                        break;
                }
            }

            return commands.Invalid;
        }
        internal static bool EvaluateCondition(string[] command)
        {
            ConditionEvaluator conditionEvaluator = new ConditionEvaluator(assignedVariables);
            return conditionEvaluator.EvaluateCondition(command);
        }
    }
}

