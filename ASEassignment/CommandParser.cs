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
        /// Command to draw to a specific position
        DrawTo,

        /// Represents an invalid command
        Invalid
    }

    /// Parses user input to determine the command and its parameters.
    public class CommandParser
    {
        /// <param name="input">The input command string.</param>
        /// <param name="x">The X-coordinate value.</param>
        /// <param name="y">The Y-coordinate value.</param>
        public static commands parseCommand(string input, out int x, out int y)
        {
            x = 0;
            y = 0;

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
                }
            }

            return commands.Invalid;
        }
    }
}

