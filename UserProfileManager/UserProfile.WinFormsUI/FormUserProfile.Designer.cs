namespace UserProfileManager.WinFormsUI
{
    partial class FormUserProfile
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
            this.userProfileIdLbl = new System.Windows.Forms.Label();
            this.userAccountLbl = new System.Windows.Forms.Label();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.emailAdressLbl = new System.Windows.Forms.Label();
            this.useradminLbl = new System.Windows.Forms.Label();
            this.userProfileIdTxt = new System.Windows.Forms.TextBox();
            this.userAccountTxt = new System.Windows.Forms.TextBox();
            this.userDomainTxt = new System.Windows.Forms.TextBox();
            this.userNameTxt = new System.Windows.Forms.TextBox();
            this.emailAdressTxt = new System.Windows.Forms.TextBox();
            this.adminChk = new System.Windows.Forms.CheckBox();
            this.tableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.userProfileTitleLbl = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bottomPnl = new System.Windows.Forms.Panel();
            this.userlogginLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userProfileIdLbl
            // 
            this.userProfileIdLbl.AutoSize = true;
            this.userProfileIdLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userProfileIdLbl.Location = new System.Drawing.Point(46, 75);
            this.userProfileIdLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userProfileIdLbl.Name = "userProfileIdLbl";
            this.userProfileIdLbl.Size = new System.Drawing.Size(143, 24);
            this.userProfileIdLbl.TabIndex = 0;
            this.userProfileIdLbl.Text = "User Profile Id:";
            // 
            // userAccountLbl
            // 
            this.userAccountLbl.AutoSize = true;
            this.userAccountLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountLbl.Location = new System.Drawing.Point(46, 124);
            this.userAccountLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userAccountLbl.Name = "userAccountLbl";
            this.userAccountLbl.Size = new System.Drawing.Size(133, 24);
            this.userAccountLbl.TabIndex = 1;
            this.userAccountLbl.Text = "User Account:";
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLbl.Location = new System.Drawing.Point(46, 177);
            this.userNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(115, 24);
            this.userNameLbl.TabIndex = 2;
            this.userNameLbl.Text = "User Name:";
            // 
            // emailAdressLbl
            // 
            this.emailAdressLbl.AutoSize = true;
            this.emailAdressLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailAdressLbl.Location = new System.Drawing.Point(46, 236);
            this.emailAdressLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailAdressLbl.Name = "emailAdressLbl";
            this.emailAdressLbl.Size = new System.Drawing.Size(147, 24);
            this.emailAdressLbl.TabIndex = 3;
            this.emailAdressLbl.Text = "E-Mail Address:";
            // 
            // useradminLbl
            // 
            this.useradminLbl.AutoSize = true;
            this.useradminLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useradminLbl.Location = new System.Drawing.Point(46, 290);
            this.useradminLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.useradminLbl.Name = "useradminLbl";
            this.useradminLbl.Size = new System.Drawing.Size(112, 24);
            this.useradminLbl.TabIndex = 4;
            this.useradminLbl.Text = "User Admin";
            // 
            // userProfileIdTxt
            // 
            this.userProfileIdTxt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userProfileIdTxt.Location = new System.Drawing.Point(216, 75);
            this.userProfileIdTxt.Margin = new System.Windows.Forms.Padding(4);
            this.userProfileIdTxt.Name = "userProfileIdTxt";
            this.userProfileIdTxt.ReadOnly = true;
            this.userProfileIdTxt.Size = new System.Drawing.Size(116, 32);
            this.userProfileIdTxt.TabIndex = 5;
            // 
            // userAccountTxt
            // 
            this.userAccountTxt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountTxt.Location = new System.Drawing.Point(216, 126);
            this.userAccountTxt.Margin = new System.Windows.Forms.Padding(4);
            this.userAccountTxt.Name = "userAccountTxt";
            this.userAccountTxt.Size = new System.Drawing.Size(155, 32);
            this.userAccountTxt.TabIndex = 6;
            this.userAccountTxt.TextChanged += new System.EventHandler(this.userAccountTxt_TextChanged);
            // 
            // userDomainTxt
            // 
            this.userDomainTxt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userDomainTxt.Location = new System.Drawing.Point(216, 181);
            this.userDomainTxt.Margin = new System.Windows.Forms.Padding(4);
            this.userDomainTxt.Name = "userDomainTxt";
            this.userDomainTxt.Size = new System.Drawing.Size(116, 32);
            this.userDomainTxt.TabIndex = 7;
            // 
            // userNameTxt
            // 
            this.userNameTxt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameTxt.Location = new System.Drawing.Point(340, 181);
            this.userNameTxt.Margin = new System.Windows.Forms.Padding(4);
            this.userNameTxt.Name = "userNameTxt";
            this.userNameTxt.Size = new System.Drawing.Size(294, 32);
            this.userNameTxt.TabIndex = 8;
            this.userNameTxt.TextChanged += new System.EventHandler(this.userNameTxt_TextChanged);
            // 
            // emailAdressTxt
            // 
            this.emailAdressTxt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailAdressTxt.Location = new System.Drawing.Point(216, 238);
            this.emailAdressTxt.Margin = new System.Windows.Forms.Padding(4);
            this.emailAdressTxt.Name = "emailAdressTxt";
            this.emailAdressTxt.Size = new System.Drawing.Size(417, 32);
            this.emailAdressTxt.TabIndex = 9;
            // 
            // adminChk
            // 
            this.adminChk.AutoSize = true;
            this.adminChk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminChk.Location = new System.Drawing.Point(216, 295);
            this.adminChk.Margin = new System.Windows.Forms.Padding(4);
            this.adminChk.Name = "adminChk";
            this.adminChk.Size = new System.Drawing.Size(18, 17);
            this.adminChk.TabIndex = 10;
            this.adminChk.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPnl
            // 
            this.tableLayoutPnl.AutoSize = true;
            this.tableLayoutPnl.ColumnCount = 6;
            this.tableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.28571F));
            this.tableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.71428F));
            this.tableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 284F));
            this.tableLayoutPnl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPnl.Location = new System.Drawing.Point(52, 375);
            this.tableLayoutPnl.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPnl.Name = "tableLayoutPnl";
            this.tableLayoutPnl.RowCount = 1;
            this.tableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPnl.Size = new System.Drawing.Size(648, 47);
            this.tableLayoutPnl.TabIndex = 11;
            // 
            // userProfileTitleLbl
            // 
            this.userProfileTitleLbl.AutoSize = true;
            this.userProfileTitleLbl.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userProfileTitleLbl.Location = new System.Drawing.Point(269, 9);
            this.userProfileTitleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userProfileTitleLbl.Name = "userProfileTitleLbl";
            this.userProfileTitleLbl.Size = new System.Drawing.Size(334, 33);
            this.userProfileTitleLbl.TabIndex = 12;
            this.userProfileTitleLbl.Text = "User Profile Entry Form";
            this.userProfileTitleLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // editBtn
            // 
            this.editBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Location = new System.Drawing.Point(61, 763);
            this.editBtn.Margin = new System.Windows.Forms.Padding(4);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(109, 45);
            this.editBtn.TabIndex = 19;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(194, 763);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(109, 45);
            this.saveBtn.TabIndex = 20;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(309, 763);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(109, 45);
            this.deleteBtn.TabIndex = 21;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(427, 763);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(109, 45);
            this.cancelBtn.TabIndex = 22;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(550, 763);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(109, 45);
            this.closeBtn.TabIndex = 23;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userlogginLbl);
            this.panel1.Controls.Add(this.userProfileTitleLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 53);
            this.panel1.TabIndex = 24;
            // 
            // bottomPnl
            // 
            this.bottomPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPnl.Location = new System.Drawing.Point(0, 745);
            this.bottomPnl.Name = "bottomPnl";
            this.bottomPnl.Size = new System.Drawing.Size(879, 100);
            this.bottomPnl.TabIndex = 25;
            // 
            // userlogginLbl
            // 
            this.userlogginLbl.AutoSize = true;
            this.userlogginLbl.Location = new System.Drawing.Point(718, 21);
            this.userlogginLbl.Name = "userlogginLbl";
            this.userlogginLbl.Size = new System.Drawing.Size(132, 17);
            this.userlogginLbl.TabIndex = 13;
            this.userlogginLbl.Text = "Logged in: Domain\\X";
            // 
            // FormUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 845);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.tableLayoutPnl);
            this.Controls.Add(this.adminChk);
            this.Controls.Add(this.emailAdressTxt);
            this.Controls.Add(this.userNameTxt);
            this.Controls.Add(this.userDomainTxt);
            this.Controls.Add(this.userAccountTxt);
            this.Controls.Add(this.userProfileIdTxt);
            this.Controls.Add(this.useradminLbl);
            this.Controls.Add(this.emailAdressLbl);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.userAccountLbl);
            this.Controls.Add(this.userProfileIdLbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bottomPnl);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormUserProfile";
            this.Text = "Manage User";
            this.Load += new System.EventHandler(this.FormUserProfile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userProfileIdLbl;
        private System.Windows.Forms.Label userAccountLbl;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Label emailAdressLbl;
        private System.Windows.Forms.Label useradminLbl;
        private System.Windows.Forms.TextBox userProfileIdTxt;
        private System.Windows.Forms.TextBox userAccountTxt;
        private System.Windows.Forms.TextBox userDomainTxt;
        private System.Windows.Forms.TextBox userNameTxt;
        private System.Windows.Forms.TextBox emailAdressTxt;
        private System.Windows.Forms.CheckBox adminChk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPnl;
        private System.Windows.Forms.Label userProfileTitleLbl;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel bottomPnl;
        private System.Windows.Forms.Label userlogginLbl;
    }
}

