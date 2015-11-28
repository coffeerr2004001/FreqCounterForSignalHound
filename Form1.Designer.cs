namespace freq_counter
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_reference = new System.Windows.Forms.Button();
            this.tb_freq = new System.Windows.Forms.TextBox();
            this.tb_pwr = new System.Windows.Forms.TextBox();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_range = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_reference
            // 
            this.btn_reference.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reference.ForeColor = System.Drawing.Color.White;
            this.btn_reference.Location = new System.Drawing.Point(243, 12);
            this.btn_reference.Name = "btn_reference";
            this.btn_reference.Size = new System.Drawing.Size(128, 27);
            this.btn_reference.TabIndex = 0;
            this.btn_reference.Text = "Internal ref";
            this.btn_reference.UseVisualStyleBackColor = true;
            this.btn_reference.Click += new System.EventHandler(this.btn_reference_Click);
            // 
            // tb_freq
            // 
            this.tb_freq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_freq.BackColor = System.Drawing.Color.MediumAquamarine;
            this.tb_freq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_freq.Font = new System.Drawing.Font("Agency FB", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_freq.Location = new System.Drawing.Point(12, 77);
            this.tb_freq.Name = "tb_freq";
            this.tb_freq.ReadOnly = true;
            this.tb_freq.Size = new System.Drawing.Size(362, 79);
            this.tb_freq.TabIndex = 1;
            this.tb_freq.Text = "100,000,000 Hz";
            this.tb_freq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_pwr
            // 
            this.tb_pwr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_pwr.BackColor = System.Drawing.Color.MediumAquamarine;
            this.tb_pwr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_pwr.Font = new System.Drawing.Font("Agency FB", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pwr.Location = new System.Drawing.Point(12, 180);
            this.tb_pwr.Name = "tb_pwr";
            this.tb_pwr.ReadOnly = true;
            this.tb_pwr.Size = new System.Drawing.Size(362, 79);
            this.tb_pwr.TabIndex = 2;
            this.tb_pwr.Text = "-10.0 dbm";
            this.tb_pwr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rtb_log
            // 
            this.rtb_log.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_log.Cursor = System.Windows.Forms.Cursors.No;
            this.rtb_log.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.rtb_log.Location = new System.Drawing.Point(12, 277);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(358, 245);
            this.rtb_log.TabIndex = 3;
            this.rtb_log.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "PeakPower";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Frequency";
            // 
            // btn_range
            // 
            this.btn_range.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_range.ForeColor = System.Drawing.Color.White;
            this.btn_range.Location = new System.Drawing.Point(131, 12);
            this.btn_range.Name = "btn_range";
            this.btn_range.Size = new System.Drawing.Size(106, 27);
            this.btn_range.TabIndex = 6;
            this.btn_range.Text = "1MHz - 1GHz";
            this.btn_range.UseVisualStyleBackColor = true;
            this.btn_range.Click += new System.EventHandler(this.bt_range_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(12, 529);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fangbo 2015.11.12";
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Location = new System.Drawing.Point(314, 529);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(56, 18);
            this.lb_status.TabIndex = 8;
            this.lb_status.Text = "Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(382, 553);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_range);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_log);
            this.Controls.Add(this.tb_pwr);
            this.Controls.Add(this.tb_freq);
            this.Controls.Add(this.btn_reference);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frequency Counter For SignalHound SA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_reference;
        private System.Windows.Forms.TextBox tb_freq;
        private System.Windows.Forms.TextBox tb_pwr;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_range;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_status;
    }
}

