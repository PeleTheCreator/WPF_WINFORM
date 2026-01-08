using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UserProfile.Application.BL.Interface;

namespace UserProfileManager.WinFormsUI
{
    public partial class FormUserProfile : Form
    {
        

        private class SystemRow
        {
            public int SystemId;
            public Label lbl;
            public ComboBox perm;
            public Dictionary<string, CheckBox> BranchCheckboxes;
        }
        private List<SystemRow> rows = new List<SystemRow>();


        private bool _syncing;
        private bool _isEditing = false;
        private int _currentUserId { get; set; }

        private readonly IAuthorizationService _authorizationService;
        private readonly ICurrentUserContext _currentUserContext;
        public FormUserProfile(IAuthorizationService authorizationService, ICurrentUserContext currentUserContext)
        {
            _authorizationService = authorizationService;
            _currentUserContext = currentUserContext;

            InitializeComponent();
            FormSetup();
            BuildSystemGrid();
            DisableEditing();
            ShowField(userProfileIdLbl, userProfileIdTxt);
        }

        //Build rows dynamically from LocalSystem table
        private void BuildSystemGrid()
        {
            List<string> branchCodes = LoadBranchCodes();

            DataTable systems = DbHelper.GetTable(
                "SELECT LocalSystemId, LocalSystemName FROM LocalSystem WHERE LocalSystemId > 0 ORDER BY LocalSystemId");

            int columnCount = branchCodes.Count + 2;

            tableLayoutPnl.Controls.Clear();
            tableLayoutPnl.ColumnStyles.Clear();
            tableLayoutPnl.RowStyles.Clear();

            tableLayoutPnl.ColumnCount = columnCount;
            tableLayoutPnl.RowCount = systems.Rows.Count + 1; // +1 for header row

            // ------------------------------
            // Header Row
            // ------------------------------
            tableLayoutPnl.Controls.Add(
                new Label()
                {
                    Text = "User Access",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                },
                0, 0);

            int col = 1;

            foreach (string code in branchCodes)
            {
                tableLayoutPnl.Controls.Add(
                    new Label()
                    {
                        Text = code,
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        Anchor = AnchorStyles.None
                    },
                    col,
                    0);

                col++;
            }

            // Permissions header
            tableLayoutPnl.Controls.Add(
                new Label()
                {
                    Text = "Permissions",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Anchor = AnchorStyles.Left
                },
                col,
                0);

            // ------------------------------
            // System Rows
            // ------------------------------
            rows.Clear();

            int rowIndex = 1;

            foreach (DataRow s in systems.Rows)
            {
                int sysId = Convert.ToInt32(s["LocalSystemId"]);
                string sysName = s["LocalSystemName"].ToString();

                SystemRow sr = new SystemRow();
                sr.SystemId = sysId;

                // System label
                sr.lbl = new Label()
                {
                    Text = sysName + ":",
                    AutoSize = true,
                    Anchor = AnchorStyles.Left
                };

                tableLayoutPnl.Controls.Add(sr.lbl, 0, rowIndex);
                sr.BranchCheckboxes = new Dictionary<string, CheckBox>();
                col = 1;

                foreach (string code in branchCodes)
                {
                    CheckBox chk = new CheckBox() { Anchor = AnchorStyles.None };
                    tableLayoutPnl.Controls.Add(chk, col, rowIndex);
                    sr.BranchCheckboxes[code] = chk;
                    col++;
                }

                // Permissions Combo
                sr.perm = new ComboBox()
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right
                };

                DataTable perms = DbHelper.GetTable(
                            "SELECT UserLevelCategoryId, UserLevelCategoryName " +
                            "FROM UserLevelCategory WHERE UserLevelCategoryLocalSystemId=@id AND UserLevelCategoryName IS NOT NULL",
                            new SqlParameter("@id", sysId));

                sr.perm.DataSource = perms;
                sr.perm.DisplayMember = "UserLevelCategoryName";
                sr.perm.ValueMember = "UserLevelCategoryId";
                tableLayoutPnl.Controls.Add(sr.perm, col, rowIndex);
                rows.Add(sr);
                rowIndex++;
            }
        }

        //functionality
        public void CreateNewUser()
        {
            userProfileIdTxt.Text = "";
            userAccountTxt.Text = "";
            userDomainTxt.Text = "";
            userNameTxt.Text = "";
            emailAdressTxt.Text = "";
            adminChk.Checked = false;
            HideField(userProfileIdLbl, userProfileIdTxt);
            EnableEditing();
        }
        public void LoadUserProfile(int id)
        {
            userProfileTitleLbl.Text = "User Profile Form";
            _currentUserId = id;
            DataTable dt = DbHelper.GetTable("SELECT * FROM UserProfile WHERE UserProfileId=@id",
                new SqlParameter("@id", id));

            if (dt.Rows.Count == 0) return;

            DataRow r = dt.Rows[0];

            userProfileIdTxt.Text = r["UserProfileId"].ToString();
            userAccountTxt.Text = r["UserProfileAccount"].ToString();
            userDomainTxt.Text = r["UserProfileDomainName"].ToString();
            userNameTxt.Text = userAccountTxt.Text;
            emailAdressTxt.Text = r["UserProfileMailAddress"].ToString();
            adminChk.Checked = r["UserProfileUserLevelToUserAdmin"].ToString() == "Y";

            LoadUserAccess(id);
            LoadBranches(id);
            DisableEditing();
        }



        //event handlers
        private void FormUserProfile_Load(object sender, EventArgs e)
        {
            DisplayCurrentUser();
            ApplyPermissions();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;
            int id = SaveUserProfile();
            SaveAccess(id);
            SaveBranches(id);
            MessageBox.Show("Saved successfully!");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (userProfileIdTxt.Text != "")
            {
                DbHelper.Execute("UPDATE UserProfile SET UserProfileStatus=-1 WHERE UserProfileId=@id",
                    new SqlParameter("@id", userProfileIdTxt.Text));
                MessageBox.Show("Profile marked as deleted.");
            }
        }
       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            _isEditing = true;

            // Enable fields
            userAccountTxt.ReadOnly = false;
            userDomainTxt.ReadOnly = false;
            userNameTxt.ReadOnly = false;
            emailAdressTxt.ReadOnly = false;
            adminChk.Enabled = true;

            // Enable dynamic grid controls
            foreach (var row in rows)
            {
                foreach (var chk in row.BranchCheckboxes.Values)
                    chk.Enabled = true;

                row.perm.Enabled = true;
            }

            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;
            editBtn.Enabled = false;

            MessageBox.Show("Edit mode enabled.");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _isEditing = false;

            // Lock fields
            userAccountTxt.ReadOnly = true;
            userDomainTxt.ReadOnly = true;
            userNameTxt.ReadOnly = true;
            emailAdressTxt.ReadOnly = true;
            adminChk.Enabled = false;

            // Lock dynamic grid
            foreach (var row in rows)
            {
                foreach (var chk in row.BranchCheckboxes.Values)
                    chk.Enabled = false;

                row.perm.Enabled = false;
            }

            // Reload original data
            //LoadUserProfile(_currentUserId);

            saveBtn.Enabled = false;
            cancelBtn.Enabled = false;
            editBtn.Enabled = true;

            MessageBox.Show("Changes discarded,Kindly Click on edit if you want to continue or close the form");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void userAccountTxt_TextChanged(object sender, EventArgs e)
        {
            if (_syncing) return;
            if (!userAccountTxt.Focused) return;

            _syncing = true;
            userNameTxt.Text = userAccountTxt.Text;
            _syncing = false;
        }
        private void userNameTxt_TextChanged(object sender, EventArgs e)
        {
            if (_syncing) return;
            if (!userNameTxt.Focused) return;

            _syncing = true;
            userAccountTxt.Text = userNameTxt.Text;
            _syncing = false;
        }

        
        //db query    
        private void LoadUserAccess(int userId)
        {
            DataTable access = DbHelper.GetTable(
                "SELECT * FROM UserAccess WHERE UserAccessUserProfileId=@id",
                new SqlParameter("@id", userId));

            foreach (SystemRow row in rows)
            {
                DataRow[] a = access.Select("UserAccessLocalSystemId=" + row.SystemId);
                if (a.Length > 0)
                {
                    row.perm.SelectedValue = a[0]["UserAccessUserLevelCategoryId"];
                }
            }
        }
        private void LoadBranches(int userId)
        {
            DataTable dt = DbHelper.GetTable(
                "SELECT * FROM LocalSystemBranch WHERE LocalSystemBranchUserProfileId=@id",
                new SqlParameter("@id", userId));

            foreach (SystemRow row in rows)
            {
                foreach (var kvp in row.BranchCheckboxes)
                {
                    string code = kvp.Key;
                    CheckBox chk = kvp.Value;

                    chk.Checked = dt.Select(
                        $"LocalSystemBranchLocalSystemId={row.SystemId} AND LocalSystemBranchCode='{code}'"
                    ).Length > 0;
                }
            }
        }
        private List<string> LoadBranchCodes()
        {
            DataTable dt = DbHelper.GetTable("SELECT BranchCode FROM Branch WHERE BranchCode IS NOT NULL ORDER BY BranchCode");
            List<string> codes = new List<string>();
            foreach (DataRow r in dt.Rows)
                codes.Add(r["BranchCode"].ToString());

            return codes;
        }
       

        //db commands
        private int SaveUserProfile()
        {
            var username = $"{userDomainTxt.Text}\\{userNameTxt.Text}";

            if (string.IsNullOrWhiteSpace(userProfileIdTxt.Text))
            {
                string sql = @"
                INSERT INTO UserProfile
                (UserProfileStatus, UserProfileAccount, UserProfileDomainName, UserProfileName,
                    UserProfileMailAddress, UserProfileUserLevelToUserAdmin, UserProfileOperatorId, UserProfileTimeStamp)
                VALUES
                (0, @acc, @dom, @name, @mail, @adm, 1, GETDATE());
                SELECT SCOPE_IDENTITY();";

                int newId = Convert.ToInt32(DbHelper.ExecuteScalar(sql,
                    new SqlParameter("@acc", userAccountTxt.Text),
                new SqlParameter("@dom", userDomainTxt.Text),
                    new SqlParameter("@name", username),
                    new SqlParameter("@mail", emailAdressTxt.Text),
                    new SqlParameter("@adm", adminChk.Checked ? "Y" : "N")
                ));

                userProfileIdTxt.Text = newId.ToString();
                return newId;
            }
            else
            {
                DbHelper.Execute(@"
                UPDATE UserProfile SET
                    UserProfileAccount=@acc,
                    UserProfileDomainName=@dom,
                    UserProfileName=@name,
                    UserProfileMailAddress=@mail,
                    UserProfileUserLevelToUserAdmin=@adm
                WHERE UserProfileId=@id"
                ,
                    new SqlParameter("@acc", userAccountTxt.Text),
                    new SqlParameter("@dom", userDomainTxt.Text),
                    new SqlParameter("@name", username),
                    new SqlParameter("@mail", emailAdressTxt.Text),
                    new SqlParameter("@adm", adminChk.Checked ? "Y" : "N"),
                    new SqlParameter("@id", userProfileIdTxt.Text));

                return int.Parse(userProfileIdTxt.Text);
            }
     
          
        }
        private void SaveAccess(int userId)
        {
            DbHelper.Execute("DELETE FROM UserAccess WHERE UserAccessUserProfileId=@id",
                new SqlParameter("@id", userId));

            foreach (SystemRow row in rows)
            {
                DbHelper.Execute(
                    @"INSERT INTO UserAccess 
                  (UserAccessStatus,UserAccessUserProfileId,UserAccessLocalSystemId,UserAccessUserLevelCategoryId)
                  VALUES(0,@uid,@sid,@perm)",
                    new SqlParameter("@uid", userId),
                    new SqlParameter("@sid", row.SystemId),
                    new SqlParameter("@perm", row.perm.SelectedValue));
            }
        }
        private void SaveBranches(int userId)
        {
            DbHelper.Execute("DELETE FROM LocalSystemBranch WHERE LocalSystemBranchUserProfileId=@id",
                new SqlParameter("@id", userId));

            foreach (SystemRow row in rows)
            {
                foreach (var kvp in row.BranchCheckboxes)
                {
                    string code = kvp.Key;
                    CheckBox chk = kvp.Value;

                    if (chk.Checked)
                    {
                        DbHelper.Execute(
                            @"INSERT INTO LocalSystemBranch 
                      (LocalSystemBranchStatus,LocalSystemBranchUserProfileId,
                       LocalSystemBranchLocalSystemId,LocalSystemBranchCode)
                      VALUES(0,@uid,@sid,@code)",
                            new SqlParameter("@uid", userId),
                            new SqlParameter("@sid", row.SystemId),
                            new SqlParameter("@code", code));
                    }
                }
            }
        }


        //helper
        private void FormSetup()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;          
            this.ShowInTaskbar = true;
            this.Text = "Manage User";
        }
        private void ApplyPermissions()
        {
            bool isAdmin = _authorizationService.IsAdmin();
            saveBtn.Enabled = isAdmin;
            cancelBtn.Enabled = isAdmin;
            editBtn.Enabled = isAdmin;
        }
        private void DisableEditing()
        {
            userAccountTxt.ReadOnly = true;
            userDomainTxt.ReadOnly = true;
            userNameTxt.ReadOnly = true;
            emailAdressTxt.ReadOnly = true;
            adminChk.Enabled = false;

            // Disable all dynamic branch checkboxes + permissions dropdowns
            foreach (var row in rows)
            {
                // Disable all branch checkboxes dynamically
                foreach (var chk in row.BranchCheckboxes.Values)
                    chk.Enabled = false;

                row.perm.Enabled = false;
            }

            saveBtn.Enabled = false;
            cancelBtn.Enabled = false;
            editBtn.Enabled = true;
        }
        private void EnableEditing()
        {
            //hide the id
            _isEditing = true;
            // Enable editing mode
            userAccountTxt.ReadOnly = false;
            userDomainTxt.ReadOnly = false;
            userNameTxt.ReadOnly = false;
            emailAdressTxt.ReadOnly = false;
            adminChk.Enabled = true;

            // Clear and enable dynamic system rows
            foreach (var row in rows)
            {
                foreach (var chk in row.BranchCheckboxes.Values)
                    chk.Enabled = true;

                row.perm.Enabled = true;
            }

            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;
            editBtn.Enabled = false;
        }
        private void DisplayCurrentUser()
        {
            userlogginLbl.Text = $"Logged in: {_currentUserContext.Current.DisplayName}";

        }
        void ShowField(Label lbl, TextBox txt)
        {
            lbl.Visible = true;
            txt.Visible = true;
        }

        void HideField(Label lbl, TextBox txt)
        {
            lbl.Visible = false;
            txt.Visible = false;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(userAccountTxt.Text))
            {
                MessageBox.Show("User Account is required.", "Validation Error");
                userAccountTxt.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(userDomainTxt.Text))
            {
                MessageBox.Show("User Domain is required.", "Validation Error");
                userDomainTxt.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(userNameTxt.Text))
            {
                MessageBox.Show("User Name is required.", "Validation Error");
                userNameTxt.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(emailAdressTxt.Text))
            {
                MessageBox.Show("Email Address is required.", "Validation Error");
                emailAdressTxt.Focus();
                return false;
            }

            string email = emailAdressTxt.Text.Trim();
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email Address is not valid.", "Validation Error");
                emailAdressTxt.Focus();
                return false;
            }


            // Dynamic Rows Branch & Permission validation
            if (rows == null || rows.Count == 0)
            {
                MessageBox.Show("Branch permissions could not be loaded.");
                return false;
            }

            // Check if at least ONE branch checkbox is selected
            bool anyBranchSelected =
                rows.Any(r => r.BranchCheckboxes.Values.Any(chk => chk.Checked));

            if (!anyBranchSelected)
            {
                MessageBox.Show("Please select at least one branch.", "Validation Error");
                return false;
            }

            // Check each selected branch also has a permission chosen
            foreach (var row in rows)
            {
                bool thisRowSelected = row.BranchCheckboxes.Values.Any(chk => chk.Checked);

                if (thisRowSelected)
                {
                    // Permission combo cannot be empty or “Select”
                    if (row.perm.SelectedItem == null ||
                        string.IsNullOrWhiteSpace(row.perm.SelectedItem.ToString()))
                    {
                        MessageBox.Show("Please select permission for all chosen branches.",
                                        "Validation Error");
                        row.perm.Focus();
                        return false;
                    }
                }
            }

            return true; 
        }

    }
}