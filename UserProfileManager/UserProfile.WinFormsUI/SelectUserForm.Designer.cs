namespace UserProfileManager.WinFormsUI
{
    partial class SelectUserForm
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
            this.usersCmb = new System.Windows.Forms.ComboBox();
            this.continueBtn = new System.Windows.Forms.Button();
            this.headerPnl = new System.Windows.Forms.Panel();
            this.titleLbl = new System.Windows.Forms.Label();
            this.Instructionlbl = new System.Windows.Forms.Label();
            this.buttonPnl = new System.Windows.Forms.Panel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.headerPnl.SuspendLayout();
            this.buttonPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // usersCmb
            // 
            this.usersCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.usersCmb.FormattingEnabled = true;
            this.usersCmb.ItemHeight = 16;
            this.usersCmb.Location = new System.Drawing.Point(160, 117);
            this.usersCmb.Margin = new System.Windows.Forms.Padding(4);
            this.usersCmb.Name = "usersCmb";
            this.usersCmb.Size = new System.Drawing.Size(352, 24);
            this.usersCmb.TabIndex = 0;
            // 
            // continueBtn
            // 
            this.continueBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.continueBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.continueBtn.Location = new System.Drawing.Point(160, 7);
            this.continueBtn.Margin = new System.Windows.Forms.Padding(4);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(137, 49);
            this.continueBtn.TabIndex = 1;
            this.continueBtn.Text = "Continue";
            this.continueBtn.UseVisualStyleBackColor = true;
            this.continueBtn.Click += new System.EventHandler(this.continueBtn_Click);
            // 
            // headerPnl
            // 
            this.headerPnl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.headerPnl.Controls.Add(this.titleLbl);
            this.headerPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPnl.Location = new System.Drawing.Point(0, 0);
            this.headerPnl.Name = "headerPnl";
            this.headerPnl.Size = new System.Drawing.Size(673, 50);
            this.headerPnl.TabIndex = 2;
            // 
            // titleLbl
            // 
            this.titleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.Location = new System.Drawing.Point(267, 9);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(209, 25);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "Select Application User";
            this.titleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Instructionlbl
            // 
            this.Instructionlbl.AutoSize = true;
            this.Instructionlbl.Location = new System.Drawing.Point(23, 86);
            this.Instructionlbl.Name = "Instructionlbl";
            this.Instructionlbl.Size = new System.Drawing.Size(223, 16);
            this.Instructionlbl.TabIndex = 3;
            this.Instructionlbl.Text = "Choose your user from the list below:";
            // 
            // buttonPnl
            // 
            this.buttonPnl.Controls.Add(this.cancelBtn);
            this.buttonPnl.Controls.Add(this.continueBtn);
            this.buttonPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPnl.Location = new System.Drawing.Point(0, 390);
            this.buttonPnl.Name = "buttonPnl";
            this.buttonPnl.Size = new System.Drawing.Size(673, 60);
            this.buttonPnl.TabIndex = 4;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(345, 7);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(131, 49);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // SelectUserForm
            // 
            this.AcceptButton = this.continueBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(673, 450);
            this.Controls.Add(this.buttonPnl);
            this.Controls.Add(this.Instructionlbl);
            this.Controls.Add(this.headerPnl);
            this.Controls.Add(this.usersCmb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectUserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Application User";
            this.Load += new System.EventHandler(this.SelectUserForm_Load);
            this.headerPnl.ResumeLayout(false);
            this.headerPnl.PerformLayout();
            this.buttonPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox usersCmb;
        private System.Windows.Forms.Button continueBtn;
        private System.Windows.Forms.Panel headerPnl;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label Instructionlbl;
        private System.Windows.Forms.Panel buttonPnl;
        private System.Windows.Forms.Button cancelBtn;
    }
}