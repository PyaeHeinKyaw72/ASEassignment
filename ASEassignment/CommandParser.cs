using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEassignment
{
    public enum commands
    {
        DrawTo,
        Invalid
    }
    public class CommandParser
    {
        public static commands parseCommand(string input, out int x, out int y)
        {
            x = 0;
            y = 0;

            string[] command = input.ToLower().Split(' ', ',');

            if (command.Length >= 1)
            {
                string Input = command[0];

                switch (Input)
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
