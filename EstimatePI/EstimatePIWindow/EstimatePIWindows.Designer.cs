namespace EstimatePIWindow
{
    partial class EstimatePIWindows
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butStartEstimatingPI = new System.Windows.Forms.Button();
            this.lblNumberOfDarts = new System.Windows.Forms.Label();
            this.textBoxNumberOfDarts = new System.Windows.Forms.TextBox();
            this.lblEstimatedPIText = new System.Windows.Forms.Label();
            this.lblEstimatedPIValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butStartEstimatingPI
            // 
            this.butStartEstimatingPI.Location = new System.Drawing.Point(80, 28);
            this.butStartEstimatingPI.Name = "butStartEstimatingPI";
            this.butStartEstimatingPI.Size = new System.Drawing.Size(137, 23);
            this.butStartEstimatingPI.TabIndex = 0;
            this.butStartEstimatingPI.Text = "Start Estimating PI";
            this.butStartEstimatingPI.UseVisualStyleBackColor = true;
            this.butStartEstimatingPI.Click += new System.EventHandler(this.butStartEstimatingPI_Click);
            // 
            // lblNumberOfDarts
            // 
            this.lblNumberOfDarts.AutoSize = true;
            this.lblNumberOfDarts.Location = new System.Drawing.Point(260, 28);
            this.lblNumberOfDarts.Name = "lblNumberOfDarts";
            this.lblNumberOfDarts.Size = new System.Drawing.Size(98, 15);
            this.lblNumberOfDarts.TabIndex = 1;
            this.lblNumberOfDarts.Text = "Number of Darts:";
            // 
            // textBoxNumberOfDarts
            // 
            this.textBoxNumberOfDarts.Location = new System.Drawing.Point(389, 25);
            this.textBoxNumberOfDarts.Name = "textBoxNumberOfDarts";
            this.textBoxNumberOfDarts.Size = new System.Drawing.Size(100, 23);
            this.textBoxNumberOfDarts.TabIndex = 2;
            this.textBoxNumberOfDarts.Text = "10000";
            // 
            // lblEstimatedPIText
            // 
            this.lblEstimatedPIText.AutoSize = true;
            this.lblEstimatedPIText.Location = new System.Drawing.Point(284, 109);
            this.lblEstimatedPIText.Name = "lblEstimatedPIText";
            this.lblEstimatedPIText.Size = new System.Drawing.Size(75, 15);
            this.lblEstimatedPIText.TabIndex = 3;
            this.lblEstimatedPIText.Text = "Estimated PI:";
            // 
            // lblEstimatedPIValue
            // 
            this.lblEstimatedPIValue.AutoSize = true;
            this.lblEstimatedPIValue.Location = new System.Drawing.Point(380, 109);
            this.lblEstimatedPIValue.Name = "lblEstimatedPIValue";
            this.lblEstimatedPIValue.Size = new System.Drawing.Size(22, 15);
            this.lblEstimatedPIValue.TabIndex = 3;
            this.lblEstimatedPIValue.Text = "---";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEstimatedPIValue);
            this.Controls.Add(this.textBoxNumberOfDarts);
            this.Controls.Add(this.lblEstimatedPIText);
            this.Controls.Add(this.lblNumberOfDarts);
            this.Controls.Add(this.butStartEstimatingPI);
            this.Name = "Form1";
            this.Text = "Estimated PI Windows";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butStartEstimatingPI;
        private System.Windows.Forms.Label lblNumberOfDarts;
        private System.Windows.Forms.TextBox textBoxNumberOfDarts;
        private System.Windows.Forms.Label lblEstimatedPIText;
        private System.Windows.Forms.Label lblEstimatedPIValue;
    }
}

