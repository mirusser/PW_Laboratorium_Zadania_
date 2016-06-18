namespace PW_4_1
{
    partial class Form1
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxPermutations = new System.Windows.Forms.TextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.labeln = new System.Windows.Forms.Label();
            this.labelFactorialn = new System.Windows.Forms.Label();
            this.labelNumberOfSwaps = new System.Windows.Forms.Label();
            this.textBoxNumberOfSwaps = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPassedTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(52, 17);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(241, 17);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxPermutations
            // 
            this.textBoxPermutations.Location = new System.Drawing.Point(52, 47);
            this.textBoxPermutations.Name = "textBoxPermutations";
            this.textBoxPermutations.Size = new System.Drawing.Size(120, 20);
            this.textBoxPermutations.TabIndex = 4;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(15, 166);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(169, 20);
            this.textBox.TabIndex = 5;
            // 
            // labeln
            // 
            this.labeln.AutoSize = true;
            this.labeln.Location = new System.Drawing.Point(12, 17);
            this.labeln.Name = "labeln";
            this.labeln.Size = new System.Drawing.Size(16, 13);
            this.labeln.TabIndex = 6;
            this.labeln.Text = "n:";
            // 
            // labelFactorialn
            // 
            this.labelFactorialn.AutoSize = true;
            this.labelFactorialn.Location = new System.Drawing.Point(12, 47);
            this.labelFactorialn.Name = "labelFactorialn";
            this.labelFactorialn.Size = new System.Drawing.Size(19, 13);
            this.labelFactorialn.TabIndex = 7;
            this.labelFactorialn.Text = "n!:";
            // 
            // labelNumberOfSwaps
            // 
            this.labelNumberOfSwaps.AutoSize = true;
            this.labelNumberOfSwaps.Location = new System.Drawing.Point(12, 91);
            this.labelNumberOfSwaps.Name = "labelNumberOfSwaps";
            this.labelNumberOfSwaps.Size = new System.Drawing.Size(94, 13);
            this.labelNumberOfSwaps.TabIndex = 8;
            this.labelNumberOfSwaps.Text = "Number of Swaps:";
            // 
            // textBoxNumberOfSwaps
            // 
            this.textBoxNumberOfSwaps.Location = new System.Drawing.Point(15, 118);
            this.textBoxNumberOfSwaps.Name = "textBoxNumberOfSwaps";
            this.textBoxNumberOfSwaps.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumberOfSwaps.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 202);
            this.progressBar1.Maximum = 1000000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(367, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 10;
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(241, 58);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 11;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(241, 102);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Swaps:";
            // 
            // labelPassedTime
            // 
            this.labelPassedTime.AutoSize = true;
            this.labelPassedTime.Location = new System.Drawing.Point(19, 240);
            this.labelPassedTime.Name = "labelPassedTime";
            this.labelPassedTime.Size = new System.Drawing.Size(48, 13);
            this.labelPassedTime.TabIndex = 14;
            this.labelPassedTime.Text = "Passed: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 262);
            this.Controls.Add(this.labelPassedTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBoxNumberOfSwaps);
            this.Controls.Add(this.labelNumberOfSwaps);
            this.Controls.Add(this.labelFactorialn);
            this.Controls.Add(this.labeln);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.textBoxPermutations);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.numericUpDown1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Permutation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxPermutations;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label labeln;
        private System.Windows.Forms.Label labelFactorialn;
        private System.Windows.Forms.Label labelNumberOfSwaps;
        private System.Windows.Forms.TextBox textBoxNumberOfSwaps;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPassedTime;
    }
}

