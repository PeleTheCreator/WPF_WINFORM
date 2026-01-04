namespace LearningWinform
{
    partial class CheckboxControlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.CheckBox checkBoxFileA;
        private System.Windows.Forms.CheckBox checkBoxFileB;
        private System.Windows.Forms.CheckBox checkBoxFileC;
        private System.Windows.Forms.Panel panelFiles;
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
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.checkBoxFileA = new System.Windows.Forms.CheckBox();
            this.checkBoxFileB = new System.Windows.Forms.CheckBox();
            this.checkBoxFileC = new System.Windows.Forms.CheckBox();
            this.panelFiles = new System.Windows.Forms.Panel();
            this.panelFiles.SuspendLayout();
            this.SuspendLayout();

            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(20, 20);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(74, 19);
            this.checkBoxSelectAll.TabIndex = 0;
            this.checkBoxSelectAll.Text = "Select All";
            this.checkBoxSelectAll.ThreeState = true;
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckStateChanged +=
                new System.EventHandler(this.checkBoxSelectAll_CheckStateChanged);

            // 
            // panelFiles
            // 
            this.panelFiles.Controls.Add(this.checkBoxFileA);
            this.panelFiles.Controls.Add(this.checkBoxFileB);
            this.panelFiles.Controls.Add(this.checkBoxFileC);
            this.panelFiles.Location = new System.Drawing.Point(20, 55);
            this.panelFiles.Name = "panelFiles";
            this.panelFiles.Size = new System.Drawing.Size(200, 100);
            this.panelFiles.TabIndex = 1;

            // 
            // checkBoxFileA
            // 
            this.checkBoxFileA.AutoSize = true;
            this.checkBoxFileA.Location = new System.Drawing.Point(3, 3);
            this.checkBoxFileA.Name = "checkBoxFileA";
            this.checkBoxFileA.Size = new System.Drawing.Size(58, 19);
            this.checkBoxFileA.TabIndex = 0;
            this.checkBoxFileA.Text = "File A";
            this.checkBoxFileA.UseVisualStyleBackColor = true;
            this.checkBoxFileA.CheckedChanged +=
                new System.EventHandler(this.Child_CheckedChanged);

            // 
            // checkBoxFileB
            // 
            this.checkBoxFileB.AutoSize = true;
            this.checkBoxFileB.Location = new System.Drawing.Point(3, 28);
            this.checkBoxFileB.Name = "checkBoxFileB";
            this.checkBoxFileB.Size = new System.Drawing.Size(57, 19);
            this.checkBoxFileB.TabIndex = 1;
            this.checkBoxFileB.Text = "File B";
            this.checkBoxFileB.UseVisualStyleBackColor = true;
            this.checkBoxFileB.CheckedChanged +=
                new System.EventHandler(this.Child_CheckedChanged);

            // 
            // checkBoxFileC
            // 
            this.checkBoxFileC.AutoSize = true;
            this.checkBoxFileC.Location = new System.Drawing.Point(3, 53);
            this.checkBoxFileC.Name = "checkBoxFileC";
            this.checkBoxFileC.Size = new System.Drawing.Size(58, 19);
            this.checkBoxFileC.TabIndex = 2;
            this.checkBoxFileC.Text = "File C";
            this.checkBoxFileC.UseVisualStyleBackColor = true;
            this.checkBoxFileC.CheckedChanged +=
                new System.EventHandler(this.Child_CheckedChanged);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 190);
            this.Controls.Add(this.panelFiles);
            this.Controls.Add(this.checkBoxSelectAll);
            this.Name = "CheckboxControlForm";
            this.Text = "Select All Example";
            this.panelFiles.ResumeLayout(false);
            this.panelFiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
    }
}