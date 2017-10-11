namespace _216310962
{
    partial class Report
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
            this.lblProblemPriority = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblProblemStatus = new System.Windows.Forms.Label();
            this.lblProblemCategory = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblProblemPriority
            // 
            this.lblProblemPriority.AutoSize = true;
            this.lblProblemPriority.Location = new System.Drawing.Point(64, 63);
            this.lblProblemPriority.Name = "lblProblemPriority";
            this.lblProblemPriority.Size = new System.Drawing.Size(79, 13);
            this.lblProblemPriority.TabIndex = 0;
            this.lblProblemPriority.Text = "Problem Priority";
            this.lblProblemPriority.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(65, 183);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 1;
            this.lblComment.Text = "Comment";
            // 
            // lblProblemStatus
            // 
            this.lblProblemStatus.AutoSize = true;
            this.lblProblemStatus.Location = new System.Drawing.Point(65, 281);
            this.lblProblemStatus.Name = "lblProblemStatus";
            this.lblProblemStatus.Size = new System.Drawing.Size(78, 13);
            this.lblProblemStatus.TabIndex = 2;
            this.lblProblemStatus.Text = "Problem Status";
            // 
            // lblProblemCategory
            // 
            this.lblProblemCategory.AutoSize = true;
            this.lblProblemCategory.Location = new System.Drawing.Point(64, 123);
            this.lblProblemCategory.Name = "lblProblemCategory";
            this.lblProblemCategory.Size = new System.Drawing.Size(90, 13);
            this.lblProblemCategory.TabIndex = 3;
            this.lblProblemCategory.Text = "Problem Category";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 210);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 57);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(67, 79);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "HW",
            "SW",
            "INS",
            "Q"});
            this.comboBox2.Location = new System.Drawing.Point(67, 148);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(67, 297);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "Open";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(67, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(68, 342);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 377);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblProblemCategory);
            this.Controls.Add(this.lblProblemStatus);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblProblemPriority);
            this.Name = "Report";
            this.Text = "Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProblemPriority;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblProblemStatus;
        private System.Windows.Forms.Label lblProblemCategory;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnReport;
    }
}