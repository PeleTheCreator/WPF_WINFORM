namespace UserProfileManager.WinFormsUI
{
    partial class MainForm
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
            this.headerPnl = new System.Windows.Forms.Panel();
            this.logginLbl = new System.Windows.Forms.Label();
            this.titlelbl = new System.Windows.Forms.Label();
            this.searchPnl = new System.Windows.Forms.Panel();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.newBtn = new System.Windows.Forms.Button();
            this.searchlbl = new System.Windows.Forms.Label();
            this.userDgv = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDomain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bottomPnl = new System.Windows.Forms.Panel();
            this.viewUserProfileBtn = new System.Windows.Forms.Button();
            this.headerPnl.SuspendLayout();
            this.searchPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).BeginInit();
            this.bottomPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPnl
            // 
            this.headerPnl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.headerPnl.Controls.Add(this.logginLbl);
            this.headerPnl.Controls.Add(this.titlelbl);
            this.headerPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPnl.Location = new System.Drawing.Point(0, 0);
            this.headerPnl.Name = "headerPnl";
            this.headerPnl.Size = new System.Drawing.Size(700, 42);
            this.headerPnl.TabIndex = 0;
            // 
            // logginLbl
            // 
            this.logginLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logginLbl.AutoSize = true;
            this.logginLbl.Location = new System.Drawing.Point(564, 19);
            this.logginLbl.Name = "logginLbl";
            this.logginLbl.Size = new System.Drawing.Size(132, 17);
            this.logginLbl.TabIndex = 1;
            this.logginLbl.Text = "Logged in: Domain\\X";
            // 
            // titlelbl
            // 
            this.titlelbl.AutoSize = true;
            this.titlelbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelbl.Location = new System.Drawing.Point(28, 14);
            this.titlelbl.Name = "titlelbl";
            this.titlelbl.Size = new System.Drawing.Size(122, 23);
            this.titlelbl.TabIndex = 0;
            this.titlelbl.Text = "User List Page";
            // 
            // searchPnl
            // 
            this.searchPnl.Controls.Add(this.refreshBtn);
            this.searchPnl.Controls.Add(this.searchBtn);
            this.searchPnl.Controls.Add(this.searchTxt);
            this.searchPnl.Controls.Add(this.newBtn);
            this.searchPnl.Controls.Add(this.searchlbl);
            this.searchPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPnl.Location = new System.Drawing.Point(0, 42);
            this.searchPnl.Name = "searchPnl";
            this.searchPnl.Size = new System.Drawing.Size(700, 40);
            this.searchPnl.TabIndex = 1;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Location = new System.Drawing.Point(360, 6);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 3;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.Location = new System.Drawing.Point(279, 8);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchTxt
            // 
            this.searchTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTxt.Location = new System.Drawing.Point(70, 8);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(200, 25);
            this.searchTxt.TabIndex = 1;
            // 
            // newBtn
            // 
            this.newBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBtn.Location = new System.Drawing.Point(586, 0);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(111, 37);
            this.newBtn.TabIndex = 0;
            this.newBtn.Text = "New User";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Location = new System.Drawing.Point(10, 12);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(47, 17);
            this.searchlbl.TabIndex = 0;
            this.searchlbl.Text = "Search";
            // 
            // userDgv
            // 
            this.userDgv.AllowUserToAddRows = false;
            this.userDgv.AllowUserToDeleteRows = false;
            this.userDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDomain,
            this.colAccount,
            this.colUserName,
            this.colEmail,
            this.colAdmin});
            this.userDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDgv.Location = new System.Drawing.Point(0, 82);
            this.userDgv.MultiSelect = false;
            this.userDgv.Name = "userDgv";
            this.userDgv.ReadOnly = true;
            this.userDgv.RowHeadersWidth = 51;
            this.userDgv.RowTemplate.Height = 24;
            this.userDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userDgv.Size = new System.Drawing.Size(700, 399);
            this.userDgv.TabIndex = 2;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;
            // 
            // colDomain
            // 
            this.colDomain.DataPropertyName = "DomainName";
            this.colDomain.HeaderText = "Domain";
            this.colDomain.MinimumWidth = 6;
            this.colDomain.Name = "colDomain";
            this.colDomain.ReadOnly = true;
            this.colDomain.Width = 90;
            // 
            // colAccount
            // 
            this.colAccount.DataPropertyName = "Account";
            this.colAccount.HeaderText = "Account";
            this.colAccount.MinimumWidth = 6;
            this.colAccount.Name = "colAccount";
            this.colAccount.ReadOnly = true;
            this.colAccount.Width = 125;
            // 
            // colUserName
            // 
            this.colUserName.DataPropertyName = "DisplayName";
            this.colUserName.HeaderText = "User Name";
            this.colUserName.MinimumWidth = 6;
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            this.colUserName.Width = 150;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 180;
            // 
            // colAdmin
            // 
            this.colAdmin.DataPropertyName = "IsAdmin";
            this.colAdmin.HeaderText = "Admin";
            this.colAdmin.MinimumWidth = 6;
            this.colAdmin.Name = "colAdmin";
            this.colAdmin.ReadOnly = true;
            this.colAdmin.Width = 80;
            // 
            // bottomPnl
            // 
            this.bottomPnl.Controls.Add(this.viewUserProfileBtn);
            this.bottomPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPnl.Location = new System.Drawing.Point(0, 436);
            this.bottomPnl.Name = "bottomPnl";
            this.bottomPnl.Size = new System.Drawing.Size(700, 45);
            this.bottomPnl.TabIndex = 3;
            // 
            // viewUserProfileBtn
            // 
            this.viewUserProfileBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewUserProfileBtn.Location = new System.Drawing.Point(12, 3);
            this.viewUserProfileBtn.Name = "viewUserProfileBtn";
            this.viewUserProfileBtn.Size = new System.Drawing.Size(181, 39);
            this.viewUserProfileBtn.TabIndex = 1;
            this.viewUserProfileBtn.Text = "View User Profile";
            this.viewUserProfileBtn.UseVisualStyleBackColor = true;
            this.viewUserProfileBtn.Click += new System.EventHandler(this.viewUserProfileBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(700, 481);
            this.Controls.Add(this.bottomPnl);
            this.Controls.Add(this.userDgv);
            this.Controls.Add(this.searchPnl);
            this.Controls.Add(this.headerPnl);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(10, 10);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Profile Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.headerPnl.ResumeLayout(false);
            this.headerPnl.PerformLayout();
            this.searchPnl.ResumeLayout(false);
            this.searchPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).EndInit();
            this.bottomPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPnl;
        private System.Windows.Forms.Label titlelbl;
        private System.Windows.Forms.Label logginLbl;
        private System.Windows.Forms.Panel searchPnl;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.DataGridView userDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDomain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdmin;
        private System.Windows.Forms.Panel bottomPnl;
        private System.Windows.Forms.Button viewUserProfileBtn;
        private System.Windows.Forms.Button newBtn;
    }
}

