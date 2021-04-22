
namespace Final_P_Test__21_4_
{
    partial class CPU_Scheduler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPU_Scheduler));
            this.pnumBox = new System.Windows.Forms.TextBox();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.arrivalBox = new System.Windows.Forms.TextBox();
            this.burstBox = new System.Windows.Forms.TextBox();
            this.priorityBox = new System.Windows.Forms.TextBox();
            this.quantemBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnumLabel = new System.Windows.Forms.Label();
            this.arrivalLabel = new System.Windows.Forms.Label();
            this.burstLabel = new System.Windows.Forms.Label();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.quantemLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Enterbutton = new System.Windows.Forms.Button();
            this.Clearbutton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.waintingBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pnumBox
            // 
            this.pnumBox.Location = new System.Drawing.Point(237, 83);
            this.pnumBox.Name = "pnumBox";
            this.pnumBox.Size = new System.Drawing.Size(119, 27);
            this.pnumBox.TabIndex = 0;
            this.pnumBox.Visible = false;
            this.pnumBox.TextChanged += new System.EventHandler(this.pnumBox_TextChanged);
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "None",
            "FCFS",
            "SJF (Preemptive)",
            "SJF (Non Preemptive)",
            "Priority (Preemptive)",
            "Priority (Non Preemptive)",
            "Round Robin"});
            this.typeBox.Location = new System.Drawing.Point(218, 26);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(154, 28);
            this.typeBox.TabIndex = 1;
            this.typeBox.Text = "None";
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // arrivalBox
            // 
            this.arrivalBox.Location = new System.Drawing.Point(237, 127);
            this.arrivalBox.Name = "arrivalBox";
            this.arrivalBox.Size = new System.Drawing.Size(119, 27);
            this.arrivalBox.TabIndex = 0;
            this.arrivalBox.Visible = false;
            // 
            // burstBox
            // 
            this.burstBox.Location = new System.Drawing.Point(237, 170);
            this.burstBox.Name = "burstBox";
            this.burstBox.Size = new System.Drawing.Size(119, 27);
            this.burstBox.TabIndex = 0;
            this.burstBox.Visible = false;
            // 
            // priorityBox
            // 
            this.priorityBox.Location = new System.Drawing.Point(237, 213);
            this.priorityBox.Name = "priorityBox";
            this.priorityBox.Size = new System.Drawing.Size(119, 27);
            this.priorityBox.TabIndex = 0;
            this.priorityBox.Visible = false;
            // 
            // quantemBox
            // 
            this.quantemBox.Location = new System.Drawing.Point(237, 213);
            this.quantemBox.Name = "quantemBox";
            this.quantemBox.Size = new System.Drawing.Size(119, 27);
            this.quantemBox.TabIndex = 0;
            this.quantemBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(40, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type of scheduler";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnumLabel
            // 
            this.pnumLabel.AutoSize = true;
            this.pnumLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnumLabel.Location = new System.Drawing.Point(40, 85);
            this.pnumLabel.Name = "pnumLabel";
            this.pnumLabel.Size = new System.Drawing.Size(190, 25);
            this.pnumLabel.TabIndex = 2;
            this.pnumLabel.Text = "Number of processes";
            this.pnumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnumLabel.Visible = false;
            // 
            // arrivalLabel
            // 
            this.arrivalLabel.AutoSize = true;
            this.arrivalLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.arrivalLabel.Location = new System.Drawing.Point(40, 129);
            this.arrivalLabel.Name = "arrivalLabel";
            this.arrivalLabel.Size = new System.Drawing.Size(113, 25);
            this.arrivalLabel.TabIndex = 2;
            this.arrivalLabel.Text = "Arrival Time";
            this.arrivalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.arrivalLabel.Visible = false;
            // 
            // burstLabel
            // 
            this.burstLabel.AutoSize = true;
            this.burstLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.burstLabel.Location = new System.Drawing.Point(40, 172);
            this.burstLabel.Name = "burstLabel";
            this.burstLabel.Size = new System.Drawing.Size(101, 25);
            this.burstLabel.TabIndex = 2;
            this.burstLabel.Text = "Burst Time";
            this.burstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.burstLabel.Visible = false;
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.priorityLabel.Location = new System.Drawing.Point(40, 215);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(73, 25);
            this.priorityLabel.TabIndex = 2;
            this.priorityLabel.Text = "Priority";
            this.priorityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.priorityLabel.Visible = false;
            // 
            // quantemLabel
            // 
            this.quantemLabel.AutoSize = true;
            this.quantemLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.quantemLabel.Location = new System.Drawing.Point(40, 215);
            this.quantemLabel.Name = "quantemLabel";
            this.quantemLabel.Size = new System.Drawing.Size(90, 25);
            this.quantemLabel.TabIndex = 2;
            this.quantemLabel.Text = "Quantem";
            this.quantemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.quantemLabel.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(50, 322);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.ForeColor = System.Drawing.Color.Black;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(50, 352);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(300, 20);
            this.flowLayoutPanel2.TabIndex = 3;
            this.flowLayoutPanel2.Visible = false;
            // 
            // Enterbutton
            // 
            this.Enterbutton.Enabled = false;
            this.Enterbutton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Enterbutton.Location = new System.Drawing.Point(439, 101);
            this.Enterbutton.Name = "Enterbutton";
            this.Enterbutton.Size = new System.Drawing.Size(100, 39);
            this.Enterbutton.TabIndex = 4;
            this.Enterbutton.Text = "Enter";
            this.Enterbutton.UseVisualStyleBackColor = true;
            this.Enterbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Clearbutton
            // 
            this.Clearbutton.Enabled = false;
            this.Clearbutton.Location = new System.Drawing.Point(572, 101);
            this.Clearbutton.Name = "Clearbutton";
            this.Clearbutton.Size = new System.Drawing.Size(100, 39);
            this.Clearbutton.TabIndex = 4;
            this.Clearbutton.Text = "Clear";
            this.Clearbutton.UseVisualStyleBackColor = true;
            this.Clearbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(423, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Avg Waiting time";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waintingBox
            // 
            this.waintingBox.Location = new System.Drawing.Point(621, 25);
            this.waintingBox.Name = "waintingBox";
            this.waintingBox.ReadOnly = true;
            this.waintingBox.Size = new System.Drawing.Size(119, 27);
            this.waintingBox.TabIndex = 0;
            this.waintingBox.TextChanged += new System.EventHandler(this.pnumBox_TextChanged);
            // 
            // CPU_Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(802, 458);
            this.Controls.Add(this.Clearbutton);
            this.Controls.Add(this.Enterbutton);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.quantemLabel);
            this.Controls.Add(this.priorityLabel);
            this.Controls.Add(this.burstLabel);
            this.Controls.Add(this.arrivalLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnumLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.quantemBox);
            this.Controls.Add(this.priorityBox);
            this.Controls.Add(this.burstBox);
            this.Controls.Add(this.arrivalBox);
            this.Controls.Add(this.waintingBox);
            this.Controls.Add(this.pnumBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CPU_Scheduler";
            this.Text = "CPU Scheduler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pnumBox;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.TextBox arrivalBox;
        private System.Windows.Forms.TextBox burstBox;
        private System.Windows.Forms.TextBox priorityBox;
        private System.Windows.Forms.TextBox quantemBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pnumLabel;
        private System.Windows.Forms.Label arrivalLabel;
        private System.Windows.Forms.Label burstLabel;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.Label quantemLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button Enterbutton;
        private System.Windows.Forms.Button Clearbutton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox waintingBox;
    }
}

