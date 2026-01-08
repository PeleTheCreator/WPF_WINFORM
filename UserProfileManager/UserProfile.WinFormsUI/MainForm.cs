using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserProfile.Application.BL.Interface;
using UserProfile.Application.Utilities;
using UserProfile.BL.Application.Interfaces;
using UserProfile.Domain.Entities;

namespace UserProfileManager.WinFormsUI
{
    public partial class MainForm : Form
    {
        private readonly IUserProfileService _userService;
        private readonly IAuthorizationService _authorizationService;
        private readonly ICurrentUserContext _currentUserContext;

        public MainForm(IUserProfileService userService, IAuthorizationService authorizationService,
            ICurrentUserContext currentUserContext)
        {
            _userService = userService;
            _authorizationService = authorizationService;
            _currentUserContext = currentUserContext;
           
            InitializeComponent();
            SetupGrid();
        }
   

        private async void MainForm_Load(object sender, System.EventArgs e)
        {
            DisplayCurrentUser();
            ApplyPermissions();
            await LoadUsersAsync();
            AddCheckboxColumn();

        }

        //query
        private async Task LoadUsersAsync()
        {
            await Task.Run(() =>
                ExceptionShield.Execute(async () =>
                {
                    var users = await _userService.GetAllActiveAsync();
                    Invoke(new Action(() => userDgv.DataSource = users));
                }, "LoadUsers"));
        }


        //event handlers
        private async void searchBtn_Click(object sender, EventArgs e)
        {
            string term = searchTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(term))
            {
                await LoadUsersAsync();
                return;
            }

            var results = await _userService.SearchAsync(term);
            userDgv.DataSource = results;

        }
        private async void refreshBtn_Click(object sender, EventArgs e)
        {
            searchTxt.Clear();
            await LoadUsersAsync();
        }
        private  void newBtn_Click(object sender, EventArgs e)
        {
            if (!_authorizationService.IsAdmin()) return;

            FormUserProfile frm = new FormUserProfile(_authorizationService,_currentUserContext);
            frm.CreateNewUser();
            frm.ShowDialog();
        }
        private void viewUserProfileBtn_Click(object sender, EventArgs e)
        {
            if (!_authorizationService.IsAdmin()) return;

            var id = GetSelectedRowId();

            if (id == null)
            {
                MessageBox.Show("Please select a row using the checkbox.");
                return;
            }

            FormUserProfile frm = new FormUserProfile(_authorizationService, _currentUserContext);
            frm.LoadUserProfile(id.Value);
            frm.ShowDialog();
        }
        private void userDgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (userDgv.IsCurrentCellDirty)
                userDgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void userDgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == userDgv.Columns["Select"].Index)
            {
                foreach (DataGridViewRow row in userDgv.Rows)
                {
                    if (row.Index != e.RowIndex)
                        row.Cells["Select"].Value = false;
                }
            }
        }

        
        
        //layout
        private void ApplyPermissions()
        {
            bool isAdmin = _authorizationService.IsAdmin();
            newBtn.Enabled = isAdmin;
            viewUserProfileBtn.Enabled = isAdmin;
            bottomPnl.Visible = isAdmin;
        }
        private void SetupGrid()
        {
            userDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            userDgv.MultiSelect = false;
            userDgv.ReadOnly = false;      
            userDgv.AllowUserToAddRows = false;
            userDgv.AllowUserToDeleteRows = false;
            userDgv.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            userDgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            foreach (DataGridViewColumn col in userDgv.Columns)
            {
                if (col.Name == "Select")
                    col.ReadOnly = false;
                else
                    col.ReadOnly = true;
            }
        }
        private void AddCheckboxColumn()
        {
            if (userDgv.Columns.Contains("Select")) return;

            var checkColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Select",
                HeaderText = "",
                Width = 30,
                ReadOnly = false
            };

            userDgv.Columns.Insert(0, checkColumn);

            AddCheckBoxEventConfig();
        }
        private void AddCheckBoxEventConfig()
        {
            userDgv.CurrentCellDirtyStateChanged += userDgv_CurrentCellDirtyStateChanged;
            userDgv.CellValueChanged += userDgv_CellValueChanged;
        }

        
        
        //helper
        private void DisplayCurrentUser()
        {
            logginLbl.Text = $"Logged in: {_currentUserContext.Current.DisplayName}";

        }

        private int? GetSelectedRowId()
        {
            foreach (DataGridViewRow row in userDgv.Rows)
            {
                if (row.Cells["Select"].Value is bool isChecked && isChecked)
                {
                    return row.Cells[1].Value as int?;
                }
            }

            return null;
        }

       
    }
}
