namespace WindowsFormsApplication1
{
    partial class SerialNumberGenerator
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
            this.CopyToClipBoardButton = new System.Windows.Forms.Button();
            this.serialTextBox = new System.Windows.Forms.TextBox();
            this.GenerateSerialButton = new System.Windows.Forms.Button();
            this.IDInfoTextBox = new System.Windows.Forms.TextBox();
            this.GenerateForIDInfoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CopyToClipBoardButton
            // 
            this.CopyToClipBoardButton.Location = new System.Drawing.Point(256, 40);
            this.CopyToClipBoardButton.Name = "CopyToClipBoardButton";
            this.CopyToClipBoardButton.Size = new System.Drawing.Size(110, 21);
            this.CopyToClipBoardButton.TabIndex = 1;
            this.CopyToClipBoardButton.Text = "Copy To ClipBoard";
            this.CopyToClipBoardButton.UseVisualStyleBackColor = true;
            this.CopyToClipBoardButton.Click += new System.EventHandler(this.CopyToClipBoardButton_Click);
            // 
            // serialTextBox
            // 
            this.serialTextBox.Location = new System.Drawing.Point(12, 12);
            this.serialTextBox.Multiline = true;
            this.serialTextBox.Name = "serialTextBox";
            this.serialTextBox.ReadOnly = true;
            this.serialTextBox.Size = new System.Drawing.Size(238, 71);
            this.serialTextBox.TabIndex = 2;
            // 
            // GenerateSerialButton
            // 
            this.GenerateSerialButton.Location = new System.Drawing.Point(12, 89);
            this.GenerateSerialButton.Name = "GenerateSerialButton";
            this.GenerateSerialButton.Size = new System.Drawing.Size(204, 21);
            this.GenerateSerialButton.TabIndex = 4;
            this.GenerateSerialButton.Text = "Generate Serial for this Machine";
            this.GenerateSerialButton.UseVisualStyleBackColor = true;
            this.GenerateSerialButton.Click += new System.EventHandler(this.GenerateSerialButton_Click);
            // 
            // IDInfoTextBox
            // 
            this.IDInfoTextBox.Location = new System.Drawing.Point(12, 145);
            this.IDInfoTextBox.Multiline = true;
            this.IDInfoTextBox.Name = "IDInfoTextBox";
            this.IDInfoTextBox.Size = new System.Drawing.Size(238, 70);
            this.IDInfoTextBox.TabIndex = 5;
            // 
            // GenerateForIDInfoButton
            // 
            this.GenerateForIDInfoButton.Location = new System.Drawing.Point(12, 116);
            this.GenerateForIDInfoButton.Name = "GenerateForIDInfoButton";
            this.GenerateForIDInfoButton.Size = new System.Drawing.Size(204, 23);
            this.GenerateForIDInfoButton.TabIndex = 6;
            this.GenerateForIDInfoButton.Text = "Generate for ID info";
            this.GenerateForIDInfoButton.UseVisualStyleBackColor = true;
            this.GenerateForIDInfoButton.Click += new System.EventHandler(this.GenerateForIDInfoButton_Click);
            // 
            // SerialNumberGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 222);
            this.Controls.Add(this.GenerateForIDInfoButton);
            this.Controls.Add(this.IDInfoTextBox);
            this.Controls.Add(this.GenerateSerialButton);
            this.Controls.Add(this.serialTextBox);
            this.Controls.Add(this.CopyToClipBoardButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SerialNumberGenerator";
            this.Text = "SerialNumberGenerator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CopyToClipBoardButton;
        private System.Windows.Forms.TextBox serialTextBox;
        private System.Windows.Forms.Button GenerateSerialButton;
        private System.Windows.Forms.TextBox IDInfoTextBox;
        private System.Windows.Forms.Button GenerateForIDInfoButton;
    }
}

