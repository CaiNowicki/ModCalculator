namespace Calculator
{
    partial class OpenScreen
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
            this.openCalculatorButton = new System.Windows.Forms.Button();
            this.openConverterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openCalculatorButton
            // 
            this.openCalculatorButton.Location = new System.Drawing.Point(99, 70);
            this.openCalculatorButton.Name = "openCalculatorButton";
            this.openCalculatorButton.Size = new System.Drawing.Size(75, 28);
            this.openCalculatorButton.TabIndex = 0;
            this.openCalculatorButton.Text = "Calculator";
            this.openCalculatorButton.UseVisualStyleBackColor = true;
            this.openCalculatorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // openConverterButton
            // 
            this.openConverterButton.Location = new System.Drawing.Point(97, 135);
            this.openConverterButton.Name = "openConverterButton";
            this.openConverterButton.Size = new System.Drawing.Size(77, 37);
            this.openConverterButton.TabIndex = 1;
            this.openConverterButton.Text = "Base Conversion";
            this.openConverterButton.UseVisualStyleBackColor = true;
            this.openConverterButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // OpenScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 254);
            this.Controls.Add(this.openConverterButton);
            this.Controls.Add(this.openCalculatorButton);
            this.Name = "OpenScreen";
            this.Text = "OpenScreen";
            this.Load += new System.EventHandler(this.OpenScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openCalculatorButton;
        private System.Windows.Forms.Button openConverterButton;
    }
}