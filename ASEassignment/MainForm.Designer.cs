namespace ASEassignment
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.runButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.programBox = new System.Windows.Forms.RichTextBox();
            this.comandBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.Transparent;
            this.runButton.Location = new System.Drawing.Point(34, 376);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(99, 34);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(34, 422);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 37);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Syntax";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.DarkGray;
            this.drawingPanel.Location = new System.Drawing.Point(436, 42);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(394, 408);
            this.drawingPanel.TabIndex = 4;
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            // 
            // programBox
            // 
            this.programBox.Location = new System.Drawing.Point(34, 42);
            this.programBox.Name = "programBox";
            this.programBox.Size = new System.Drawing.Size(338, 313);
            this.programBox.TabIndex = 5;
            this.programBox.Text = "";
            // 
            // comandBox
            // 
            this.comandBox.BackColor = System.Drawing.SystemColors.Window;
            this.comandBox.Location = new System.Drawing.Point(149, 382);
            this.comandBox.Name = "comandBox";
            this.comandBox.Size = new System.Drawing.Size(223, 22);
            this.comandBox.TabIndex = 6;
            this.comandBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comandBox_KeyDown);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 481);
            this.Controls.Add(this.comandBox);
            this.Controls.Add(this.programBox);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.runButton);
            this.Name = "mainForm";
            this.Text = "GPL Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.RichTextBox programBox;
        private System.Windows.Forms.TextBox comandBox;
    }
}

