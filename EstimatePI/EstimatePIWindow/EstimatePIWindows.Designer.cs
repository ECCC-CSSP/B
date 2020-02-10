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
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblParts = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxParts = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfDarts = new System.Windows.Forms.TextBox();
            this.lblNumberOfDarts = new System.Windows.Forms.Label();
            this.butStartEstimatingPI = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBoxStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 302);
            this.panel1.TabIndex = 4;
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(800, 302);
            this.richTextBoxStatus.TabIndex = 0;
            this.richTextBoxStatus.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblParts);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.textBoxParts);
            this.panel3.Controls.Add(this.textBoxNumberOfDarts);
            this.panel3.Controls.Add(this.lblNumberOfDarts);
            this.panel3.Controls.Add(this.butStartEstimatingPI);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 148);
            this.panel3.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(58, 117);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "No Status at this time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Result Path:";
            // 
            // lblParts
            // 
            this.lblParts.AutoSize = true;
            this.lblParts.Location = new System.Drawing.Point(223, 42);
            this.lblParts.Name = "lblParts";
            this.lblParts.Size = new System.Drawing.Size(36, 15);
            this.lblParts.TabIndex = 1;
            this.lblParts.Text = "Parts:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "C:\\EstimatePI\\EstimatedPIResults.csv";
            // 
            // textBoxParts
            // 
            this.textBoxParts.Location = new System.Drawing.Point(290, 42);
            this.textBoxParts.Name = "textBoxParts";
            this.textBoxParts.Size = new System.Drawing.Size(100, 23);
            this.textBoxParts.TabIndex = 2;
            this.textBoxParts.Text = "10";
            // 
            // textBoxNumberOfDarts
            // 
            this.textBoxNumberOfDarts.Location = new System.Drawing.Point(290, 13);
            this.textBoxNumberOfDarts.Name = "textBoxNumberOfDarts";
            this.textBoxNumberOfDarts.Size = new System.Drawing.Size(100, 23);
            this.textBoxNumberOfDarts.TabIndex = 2;
            this.textBoxNumberOfDarts.Text = "100000";
            // 
            // lblNumberOfDarts
            // 
            this.lblNumberOfDarts.AutoSize = true;
            this.lblNumberOfDarts.Location = new System.Drawing.Point(161, 16);
            this.lblNumberOfDarts.Name = "lblNumberOfDarts";
            this.lblNumberOfDarts.Size = new System.Drawing.Size(98, 15);
            this.lblNumberOfDarts.TabIndex = 1;
            this.lblNumberOfDarts.Text = "Number of Darts:";
            // 
            // butStartEstimatingPI
            // 
            this.butStartEstimatingPI.Location = new System.Drawing.Point(12, 12);
            this.butStartEstimatingPI.Name = "butStartEstimatingPI";
            this.butStartEstimatingPI.Size = new System.Drawing.Size(137, 23);
            this.butStartEstimatingPI.TabIndex = 0;
            this.butStartEstimatingPI.Text = "Start Estimating PI";
            this.butStartEstimatingPI.UseVisualStyleBackColor = true;
            this.butStartEstimatingPI.Click += new System.EventHandler(this.butStartEstimatingPI_Click);
            // 
            // EstimatePIWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "EstimatePIWindows";
            this.Text = "Estimated PI Windows";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxNumberOfDarts;
        private System.Windows.Forms.Label lblNumberOfDarts;
        private System.Windows.Forms.Button butStartEstimatingPI;
        private System.Windows.Forms.Label lblParts;
        private System.Windows.Forms.TextBox textBoxParts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label6;
    }
}

