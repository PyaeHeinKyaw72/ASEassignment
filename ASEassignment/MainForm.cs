using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ASEassignment
{
    /// The main form of the app
    public partial class mainForm : Form
    {
        private DrawingTool drawingTool;
        private Command command;

        public mainForm()
        {
            InitializeComponent();

            drawingTool = new DrawingTool(drawingPanel);
            drawingPanel.Paint += drawingPanel_Paint;
            command = new Command(drawingTool);
        }

        /// The Paint event of the drawing panel
        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            drawingTool.Paint(e.Graphics);
        }

        /// The KeyDown event of the command box
        private void comandBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Get the trimmed text from the command box
            string commandText = comandBox.Text.Trim().ToLower();

            // Check if the Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Run the command with the entered text
                command.Run(comandBox.Text);
            }
        }
    }
}
