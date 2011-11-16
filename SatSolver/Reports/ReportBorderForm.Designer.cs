namespace SatSolver.Reports
{
    partial class ReportBorderForm
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.lbExperimentRepeat = new System.Windows.Forms.Label();
            this.lbFreeMembers = new System.Windows.Forms.Label();
            this.lbKonyncCount = new System.Windows.Forms.Label();
            this.lbVariableCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(944, 386);
            this.zedGraphControl1.TabIndex = 44;
            // 
            // lbExperimentRepeat
            // 
            this.lbExperimentRepeat.AutoSize = true;
            this.lbExperimentRepeat.Location = new System.Drawing.Point(306, 459);
            this.lbExperimentRepeat.Name = "lbExperimentRepeat";
            this.lbExperimentRepeat.Size = new System.Drawing.Size(41, 13);
            this.lbExperimentRepeat.TabIndex = 40;
            this.lbExperimentRepeat.Text = "label11";
            // 
            // lbFreeMembers
            // 
            this.lbFreeMembers.AutoSize = true;
            this.lbFreeMembers.Location = new System.Drawing.Point(229, 427);
            this.lbFreeMembers.Name = "lbFreeMembers";
            this.lbFreeMembers.Size = new System.Drawing.Size(41, 13);
            this.lbFreeMembers.TabIndex = 39;
            this.lbFreeMembers.Text = "label10";
            // 
            // lbKonyncCount
            // 
            this.lbKonyncCount.AutoSize = true;
            this.lbKonyncCount.Location = new System.Drawing.Point(599, 401);
            this.lbKonyncCount.Name = "lbKonyncCount";
            this.lbKonyncCount.Size = new System.Drawing.Size(35, 13);
            this.lbKonyncCount.TabIndex = 38;
            this.lbKonyncCount.Text = "label9";
            // 
            // lbVariableCount
            // 
            this.lbVariableCount.AutoSize = true;
            this.lbVariableCount.Location = new System.Drawing.Point(229, 401);
            this.lbVariableCount.Name = "lbVariableCount";
            this.lbVariableCount.Size = new System.Drawing.Size(35, 13);
            this.lbVariableCount.TabIndex = 37;
            this.lbVariableCount.Text = "label8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Количество повторений эксперимента";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Количество свободных членов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Среднее количество минтермов";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Количество переменнных";
            // 
            // ReportBorderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 487);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.lbExperimentRepeat);
            this.Controls.Add(this.lbFreeMembers);
            this.Controls.Add(this.lbKonyncCount);
            this.Controls.Add(this.lbVariableCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReportBorderForm";
            this.Text = "ReportBorderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label lbExperimentRepeat;
        private System.Windows.Forms.Label lbFreeMembers;
        private System.Windows.Forms.Label lbKonyncCount;
        private System.Windows.Forms.Label lbVariableCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}