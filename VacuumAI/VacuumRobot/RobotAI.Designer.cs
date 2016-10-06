namespace VacuumRobot
{
    public partial class RobotAI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RobotAI));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxGoal = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDust = new System.Windows.Forms.TextBox();
            this.textBoxJewel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPosition = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Goal of the robot";
            // 
            // comboBoxGoal
            // 
            this.comboBoxGoal.Enabled = false;
            this.comboBoxGoal.FormattingEnabled = true;
            this.comboBoxGoal.Location = new System.Drawing.Point(104, 6);
            this.comboBoxGoal.Name = "comboBoxGoal";
            this.comboBoxGoal.Size = new System.Drawing.Size(159, 21);
            this.comboBoxGoal.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dust on current square ?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Jewel on current square ?";
            // 
            // textBoxDust
            // 
            this.textBoxDust.Enabled = false;
            this.textBoxDust.Location = new System.Drawing.Point(163, 33);
            this.textBoxDust.Name = "textBoxDust";
            this.textBoxDust.Size = new System.Drawing.Size(100, 20);
            this.textBoxDust.TabIndex = 4;
            // 
            // textBoxJewel
            // 
            this.textBoxJewel.Enabled = false;
            this.textBoxJewel.Location = new System.Drawing.Point(163, 59);
            this.textBoxJewel.Name = "textBoxJewel";
            this.textBoxJewel.Size = new System.Drawing.Size(100, 20);
            this.textBoxJewel.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Current points count";
            // 
            // textBoxPoint
            // 
            this.textBoxPoint.Enabled = false;
            this.textBoxPoint.Location = new System.Drawing.Point(163, 85);
            this.textBoxPoint.Name = "textBoxPoint";
            this.textBoxPoint.Size = new System.Drawing.Size(100, 20);
            this.textBoxPoint.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Current position";
            // 
            // textBoxPosition
            // 
            this.textBoxPosition.Enabled = false;
            this.textBoxPosition.Location = new System.Drawing.Point(163, 111);
            this.textBoxPosition.Name = "textBoxPosition";
            this.textBoxPosition.Size = new System.Drawing.Size(100, 20);
            this.textBoxPosition.TabIndex = 9;
            // 
            // RobotAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 142);
            this.Controls.Add(this.textBoxPosition);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPoint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxJewel);
            this.Controls.Add(this.textBoxDust);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxGoal);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RobotAI";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxGoal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDust;
        private System.Windows.Forms.TextBox textBoxJewel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPosition;
    }
}