namespace SatSolver
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStopCalculate = new System.Windows.Forms.Button();
            this.lbCalculateProcess = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.numBorderSatisfiability = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numExperimentCount = new System.Windows.Forms.NumericUpDown();
            this.numFreeMembers = new System.Windows.Forms.NumericUpDown();
            this.numKonyncCount = new System.Windows.Forms.NumericUpDown();
            this.numMembersCount = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numBorderRepeatCount = new System.Windows.Forms.NumericUpDown();
            this.numBorderFreeMember = new System.Windows.Forms.NumericUpDown();
            this.numBorderVariableCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderSatisfiability)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExperimentCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFreeMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKonyncCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMembersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderRepeatCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderFreeMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderVariableCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStopCalculate
            // 
            this.btnStopCalculate.Enabled = false;
            this.btnStopCalculate.Location = new System.Drawing.Point(227, 322);
            this.btnStopCalculate.Name = "btnStopCalculate";
            this.btnStopCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnStopCalculate.TabIndex = 25;
            this.btnStopCalculate.Text = "Остановить";
            this.btnStopCalculate.UseVisualStyleBackColor = true;
            this.btnStopCalculate.Click += new System.EventHandler(this.btnStopCalculate_Click);
            // 
            // lbCalculateProcess
            // 
            this.lbCalculateProcess.AutoSize = true;
            this.lbCalculateProcess.Location = new System.Drawing.Point(104, 361);
            this.lbCalculateProcess.Name = "lbCalculateProcess";
            this.lbCalculateProcess.Size = new System.Drawing.Size(150, 13);
            this.lbCalculateProcess.TabIndex = 24;
            this.lbCalculateProcess.Text = "Идет процесс вычисления...";
            this.lbCalculateProcess.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 383);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(377, 23);
            this.progressBar1.TabIndex = 23;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(82, 322);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 18;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // numBorderSatisfiability
            // 
            this.numBorderSatisfiability.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numBorderSatisfiability.Location = new System.Drawing.Point(21, 203);
            this.numBorderSatisfiability.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBorderSatisfiability.Name = "numBorderSatisfiability";
            this.numBorderSatisfiability.Size = new System.Drawing.Size(120, 20);
            this.numBorderSatisfiability.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(401, 300);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numExperimentCount);
            this.tabPage1.Controls.Add(this.numFreeMembers);
            this.tabPage1.Controls.Add(this.numKonyncCount);
            this.tabPage1.Controls.Add(this.numMembersCount);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(393, 274);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Расчет выполнимости";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.numBorderRepeatCount);
            this.tabPage2.Controls.Add(this.numBorderFreeMember);
            this.tabPage2.Controls.Add(this.numBorderVariableCount);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.numBorderSatisfiability);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(393, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Пороговый расчет";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numExperimentCount
            // 
            this.numExperimentCount.Location = new System.Drawing.Point(229, 105);
            this.numExperimentCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numExperimentCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numExperimentCount.Name = "numExperimentCount";
            this.numExperimentCount.Size = new System.Drawing.Size(120, 20);
            this.numExperimentCount.TabIndex = 31;
            this.numExperimentCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numFreeMembers
            // 
            this.numFreeMembers.Location = new System.Drawing.Point(229, 75);
            this.numFreeMembers.Name = "numFreeMembers";
            this.numFreeMembers.Size = new System.Drawing.Size(120, 20);
            this.numFreeMembers.TabIndex = 30;
            // 
            // numKonyncCount
            // 
            this.numKonyncCount.Location = new System.Drawing.Point(229, 41);
            this.numKonyncCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numKonyncCount.Name = "numKonyncCount";
            this.numKonyncCount.Size = new System.Drawing.Size(120, 20);
            this.numKonyncCount.TabIndex = 29;
            // 
            // numMembersCount
            // 
            this.numMembersCount.Location = new System.Drawing.Point(229, 15);
            this.numMembersCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMembersCount.Name = "numMembersCount";
            this.numMembersCount.Size = new System.Drawing.Size(120, 20);
            this.numMembersCount.TabIndex = 28;
            this.numMembersCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(48, 144);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(227, 17);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "использовать формулу с логарифмами";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Количество повторений";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Количество свободных членов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Количество коньюнкций";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Количество переменных";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(361, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Останавливать вычисления если выполнимость достигнет значения:";
            // 
            // numBorderRepeatCount
            // 
            this.numBorderRepeatCount.Location = new System.Drawing.Point(229, 80);
            this.numBorderRepeatCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numBorderRepeatCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBorderRepeatCount.Name = "numBorderRepeatCount";
            this.numBorderRepeatCount.Size = new System.Drawing.Size(120, 20);
            this.numBorderRepeatCount.TabIndex = 39;
            this.numBorderRepeatCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numBorderFreeMember
            // 
            this.numBorderFreeMember.Location = new System.Drawing.Point(229, 50);
            this.numBorderFreeMember.Name = "numBorderFreeMember";
            this.numBorderFreeMember.Size = new System.Drawing.Size(120, 20);
            this.numBorderFreeMember.TabIndex = 38;
            // 
            // numBorderVariableCount
            // 
            this.numBorderVariableCount.Location = new System.Drawing.Point(229, 21);
            this.numBorderVariableCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBorderVariableCount.Name = "numBorderVariableCount";
            this.numBorderVariableCount.Size = new System.Drawing.Size(120, 20);
            this.numBorderVariableCount.TabIndex = 36;
            this.numBorderVariableCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Количество повторений";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Количество свободных членов";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Количество переменных";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 418);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnStopCalculate);
            this.Controls.Add(this.lbCalculateProcess);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCalculate);
            this.Name = "Form1";
            this.Text = "SatSolver";
            ((System.ComponentModel.ISupportInitialize)(this.numBorderSatisfiability)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExperimentCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFreeMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKonyncCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMembersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderRepeatCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderFreeMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderVariableCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStopCalculate;
        private System.Windows.Forms.Label lbCalculateProcess;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.NumericUpDown numBorderSatisfiability;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown numExperimentCount;
        private System.Windows.Forms.NumericUpDown numFreeMembers;
        private System.Windows.Forms.NumericUpDown numKonyncCount;
        private System.Windows.Forms.NumericUpDown numMembersCount;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numBorderRepeatCount;
        private System.Windows.Forms.NumericUpDown numBorderFreeMember;
        private System.Windows.Forms.NumericUpDown numBorderVariableCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;

    }
}

