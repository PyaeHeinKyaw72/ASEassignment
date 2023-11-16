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
            command = new Command(drawingTool, programBox);
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

        private void runButton_Click(object sender, EventArgs e)
        {
            command.RunProgram(programBox.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the file path
                string filePath = saveFileDialog.FileName;

                // Save the program lines of the programBox
                System.IO.File.WriteAllText(filePath, programBox.Text);
                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string filePath = openFileDialog.FileName;

                try
                {
                    // Read the content of the file
                    string fileContent = System.IO.File.ReadAllText(filePath);

                    // Load the content of the file to programBox
                    programBox.Text = fileContent;

                    MessageBox.Show("File loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
