namespace SatSolver.Reports
{
    partial class ReportForm
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
            this.lbRelation = new System.Windows.Forms.Label();
            this.lbPracticSatisfiability = new System.Windows.Forms.Label();
            this.lbTeoreticSatisfiability = new System.Windows.Forms.Label();
            this.lbExperimentRepeat = new System.Windows.Forms.Label();
            this.lbFreeMembers = new System.Windows.Forms.Label();
            this.lbKonyncCount = new System.Windows.Forms.Label();
            this.lbVariableCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(9, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(865, 338);
            this.zedGraphControl1.TabIndex = 29;
            // 
            // lbRelation
            // 
            this.lbRelation.AutoSize = true;
            this.lbRelation.Location = new System.Drawing.Point(662, 426);
            this.lbRelation.Name = "lbRelation";
            this.lbRelation.Size = new System.Drawing.Size(41, 13);
            this.lbRelation.TabIndex = 28;
            this.lbRelation.Text = "label14";
            // 
            // lbPracticSatisfiability
            // 
            this.lbPracticSatisfiability.AutoSize = true;
            this.lbPracticSatisfiability.Location = new System.Drawing.Point(620, 393);
            this.lbPracticSatisfiability.Name = "lbPracticSatisfiability";
            this.lbPracticSatisfiability.Size = new System.Drawing.Size(41, 13);
            this.lbPracticSatisfiability.TabIndex = 27;
            this.lbPracticSatisfiability.Text = "label13";
            // 
            // lbTeoreticSatisfiability
            // 
            this.lbTeoreticSatisfiability.AutoSize = true;
            this.lbTeoreticSatisfiability.Location = new System.Drawing.Point(620, 364);
            this.lbTeoreticSatisfiability.Name = "lbTeoreticSatisfiability";
            this.lbTeoreticSatisfiability.Size = new System.Drawing.Size(41, 13);
            this.lbTeoreticSatisfiability.TabIndex = 26;
            this.lbTeoreticSatisfiability.Text = "label12";
            // 
            // lbExperimentRepeat
            // 
            this.lbExperimentRepeat.AutoSize = true;
            this.lbExperimentRepeat.Location = new System.Drawing.Point(303, 459);
            this.lbExperimentRepeat.Name = "lbExperimentRepeat";
            this.lbExperimentRepeat.Size = new System.Drawing.Size(41, 13);
            this.lbExperimentRepeat.TabIndex = 25;
            this.lbExperimentRepeat.Text = "label11";
            // 
            // lbFreeMembers
            // 
            this.lbFreeMembers.AutoSize = true;
            this.lbFreeMembers.Location = new System.Drawing.Point(226, 427);
            this.lbFreeMembers.Name = "lbFreeMembers";
            this.lbFreeMembers.Size = new System.Drawing.Size(41, 13);
            this.lbFreeMembers.TabIndex = 24;
            this.lbFreeMembers.Text = "label10";
            // 
            // lbKonyncCount
            // 
            this.lbKonyncCount.AutoSize = true;
            this.lbKonyncCount.Location = new System.Drawing.Point(226, 392);
            this.lbKonyncCount.Name = "lbKonyncCount";
            this.lbKonyncCount.Size = new System.Drawing.Size(35, 13);
            this.lbKonyncCount.TabIndex = 23;
            this.lbKonyncCount.Text = "label9";
            // 
            // lbVariableCount
            // 
            this.lbVariableCount.AutoSize = true;
            this.lbVariableCount.Location = new System.Drawing.Point(223, 364);
            this.lbVariableCount.Name = "lbVariableCount";
            this.lbVariableCount.Size = new System.Drawing.Size(35, 13);
            this.lbVariableCount.TabIndex = 22;
            this.lbVariableCount.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(299, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Погрешность теоретической в процентах к практической";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(357, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Практическое значение выполнимости";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(354, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Теоретическое значение выоплнимости";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Количество повторений эксперимента";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Количество свободных членов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Количество минтермов";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Количество переменнных";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 491);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.lbRelation);
            this.Controls.Add(this.lbPracticSatisfiability);
            this.Controls.Add(this.lbTeoreticSatisfiability);
            this.Controls.Add(this.lbExperimentRepeat);
            this.Controls.Add(this.lbFreeMembers);
            this.Controls.Add(this.lbKonyncCount);
            this.Controls.Add(this.lbVariableCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label lbRelation;
        private System.Windows.Forms.Label lbPracticSatisfiability;
        private System.Windows.Forms.Label lbTeoreticSatisfiability;
        private System.Windows.Forms.Label lbExperimentRepeat;
        private System.Windows.Forms.Label lbFreeMembers;
        private System.Windows.Forms.Label lbKonyncCount;
        private System.Windows.Forms.Label lbVariableCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}