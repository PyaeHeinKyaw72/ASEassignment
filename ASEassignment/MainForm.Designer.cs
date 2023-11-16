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
            this.syntaxButton = new System.Windows.Forms.Button();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.programBox = new System.Windows.Forms.RichTextBox();
            this.comandBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.SystemColors.Menu;
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.ForeColor = System.Drawing.Color.Black;
            this.runButton.Location = new System.Drawing.Point(42, 418);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(165, 38);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // syntaxButton
            // 
            this.syntaxButton.BackColor = System.Drawing.SystemColors.Menu;
            this.syntaxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.syntaxButton.Location = new System.Drawing.Point(203, 418);
            this.syntaxButton.Name = "syntaxButton";
            this.syntaxButton.Size = new System.Drawing.Size(177, 38);
            this.syntaxButton.TabIndex = 2;
            this.syntaxButton.Text = "Syntax";
            this.syntaxButton.UseVisualStyleBackColor = false;
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.SystemColors.GrayText;
            this.drawingPanel.ForeColor = System.Drawing.Color.Black;
            this.drawingPanel.Location = new System.Drawing.Point(436, 42);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(348, 392);
            this.drawingPanel.TabIndex = 4;
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            // 
            // programBox
            // 
            this.programBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.programBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.programBox.ForeColor = System.Drawing.Color.Transparent;
            this.programBox.Location = new System.Drawing.Point(42, 83);
            this.programBox.Name = "programBox";
            this.programBox.Size = new System.Drawing.Size(338, 336);
            this.programBox.TabIndex = 5;
            this.programBox.Text = "";
            this.programBox.ZoomFactor = 1.15F;
            // 
            // comandBox
            // 
            this.comandBox.BackColor = System.Drawing.SystemColors.Window;
            this.comandBox.Location = new System.Drawing.Point(436, 433);
            this.comandBox.Name = "comandBox";
            this.comandBox.Size = new System.Drawing.Size(348, 22);
            this.comandBox.TabIndex = 6;
            this.comandBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comandBox_KeyDown);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.Menu;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.Black;
            this.saveButton.Location = new System.Drawing.Point(43, 36);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(89, 32);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.SystemColors.Menu;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.ForeColor = System.Drawing.Color.Black;
            this.loadButton.Location = new System.Drawing.Point(127, 36);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(91, 32);
            this.loadButton.TabIndex = 8;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(850, 508);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.programBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.comandBox);
            this.Controls.Add(this.syntaxButton);
            this.Controls.Add(this.runButton);
            this.Name = "mainForm";
            this.Text = "GPL Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button syntaxButton;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.RichTextBox programBox;
        private System.Windows.Forms.TextBox comandBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
    }
}

