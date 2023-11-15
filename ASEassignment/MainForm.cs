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
        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            // Paint the drawings using the DrawingTool
            drawingTool.Paint(e.Graphics);
        }

        private void comandBox_KeyDown(object sender, KeyEventArgs e)
        {
            string commandText = comandBox.Text.Trim();
            if (e.KeyCode == Keys.Enter)
            {
                command.Run(comandBox.Text);
            }
        }
    }
}
