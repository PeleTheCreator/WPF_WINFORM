namespace myFirstAoo
{
    partial class checkBoxExample
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
            this.label1 = new System.Windows.Forms.Label();
            this.interCB = new System.Windows.Forms.CheckBox();
            this.lunchCB = new System.Windows.Forms.CheckBox();
            this.SwimCB = new System.Windows.Forms.CheckBox();
            this.newsCB = new System.Windows.Forms.CheckBox();
            this.servicesLB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.billLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Services";
            // 
            // interCB
            // 
            this.interCB.AutoSize = true;
            this.interCB.Location = new System.Drawing.Point(15, 81);
            this.interCB.Name = "interCB";
            this.interCB.Size = new System.Drawing.Size(114, 17);
            this.interCB.TabIndex = 1;
            this.interCB.Text = "Internet     Rs. 500";
            this.interCB.UseVisualStyleBackColor = true;
            this.interCB.CheckedChanged += new System.EventHandler(this.interCB_CheckedChanged);
            // 
            // lunchCB
            // 
            this.lunchCB.AutoSize = true;
            this.lunchCB.Location = new System.Drawing.Point(15, 105);
            this.lunchCB.Name = "lunchCB";
            this.lunchCB.Size = new System.Drawing.Size(114, 17);
            this.lunchCB.TabIndex = 2;
            this.lunchCB.Text = "Lunch       Rs. 450";
            this.lunchCB.UseVisualStyleBackColor = true;
            this.lunchCB.CheckedChanged += new System.EventHandler(this.lunchCB_CheckedChanged);
            // 
            // SwimCB
            // 
            this.SwimCB.AutoSize = true;
            this.SwimCB.Location = new System.Drawing.Point(15, 152);
            this.SwimCB.Name = "SwimCB";
            this.SwimCB.Size = new System.Drawing.Size(119, 17);
            this.SwimCB.TabIndex = 4;
            this.SwimCB.Text = "Swimming Rs. 1000";
            this.SwimCB.UseVisualStyleBackColor = true;
            this.SwimCB.CheckedChanged += new System.EventHandler(this.SwimCB_CheckedChanged);
            // 
            // newsCB
            // 
            this.newsCB.AutoSize = true;
            this.newsCB.Location = new System.Drawing.Point(15, 128);
            this.newsCB.Name = "newsCB";
            this.newsCB.Size = new System.Drawing.Size(109, 17);
            this.newsCB.TabIndex = 3;
            this.newsCB.Text = "Newpaper Rs. 30";
            this.newsCB.UseVisualStyleBackColor = true;
            this.newsCB.CheckedChanged += new System.EventHandler(this.newsCB_CheckedChanged);
            // 
            // servicesLB
            // 
            this.servicesLB.FormattingEnabled = true;
            this.servicesLB.Location = new System.Drawing.Point(197, 81);
            this.servicesLB.Name = "servicesLB";
            this.servicesLB.Size = new System.Drawing.Size(120, 95);
            this.servicesLB.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Selected Services";
            // 
            // billLabel
            // 
            this.billLabel.AutoSize = true;
            this.billLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billLabel.Location = new System.Drawing.Point(191, 179);
            this.billLabel.Name = "billLabel";
            this.billLabel.Size = new System.Drawing.Size(52, 31);
            this.billLabel.TabIndex = 7;
            this.billLabel.Text = "0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(155, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bill ";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 9;
            this.backBtn.Text = "back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // checkBoxExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 261);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.billLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.servicesLB);
            this.Controls.Add(this.SwimCB);
            this.Controls.Add(this.newsCB);
            this.Controls.Add(this.lunchCB);
            this.Controls.Add(this.interCB);
            this.Controls.Add(this.label1);
            this.Name = "checkBoxExample";
            this.Text = "checkBoxExample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox interCB;
        private System.Windows.Forms.CheckBox lunchCB;
        private System.Windows.Forms.CheckBox SwimCB;
        private System.Windows.Forms.CheckBox newsCB;
        private System.Windows.Forms.ListBox servicesLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label billLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button backBtn;
    }
}