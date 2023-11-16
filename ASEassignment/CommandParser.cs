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

        /// For changing pen color
        PenColor,

        /// 
        ColorFill,

        /// For invalid command
        Invalid
    }

    /// Parses user input to determine the command and its parameters
    public class CommandParser
    {
        /// <param name="input">The input command string.</param>
        /// <param name="x">The X-coordinate value.</param>
        /// <param name="y">The Y-coordinate value.</param>
        /// <param name="width">The width value </param>
        /// <param name="height">The height value.</param>
        /// <param name="penColor">The color value.</param>
        /// <param name="colorFillEnabled">The fill status.</param>
        public static commands parseCommand(string input, out int x, out int y,out int width, out int height, out Color penColor, out bool colorFillEnabled)
        {
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            penColor = Color.Black;
            colorFillEnabled = false;

            string[] command = input.ToLower().Split(' ', ',');

            if (command.Length >= 1)
            {
                string inputCommand = command[0];

                switch (inputCommand)
                {
                    case "drawto":
                        if (command.Length == 3 && int.TryParse(command[1], out x) && int.TryParse(command[2], out y))
                        {
                            return commands.DrawTo;
                        }
                        break;

                    case "moveto":
                        if (command.Length == 3 && int.TryParse(command[1], out x) && int.TryParse(command[2], out y))
                        {
                            return commands.MoveTo;
                        }
                        break;

                    case "rectangle":
                        if (command.Length == 3 && int.TryParse(command[1], out width) && int.TryParse(command[2], out height))
                        {
                            return commands.Rectangle;
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
                        return commands.Run;
                }
            }

            return commands.Invalid;
        }
    }
}

