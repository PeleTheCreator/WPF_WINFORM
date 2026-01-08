using System;
using System.Windows.Forms;
using UserProfile.Application.BL.Interface;
using UserProfile.BL.Application.Interfaces;

namespace UserProfileManager.WinFormsUI
{
    public partial class SelectUserForm : Form
    {
        private readonly IUserProfileService _userService;
        private readonly ICurrentUserContext _currentUserContext;
        public SelectUserForm(
            IUserProfileService userService,
            ICurrentUserContext currentUserContext)
        {
            InitializeComponent();
            _userService = userService;
            _currentUserContext = currentUserContext;
        }

        private async void SelectUserForm_Load(object sender, System.EventArgs e)
        {
            var users = await _userService.GetAllActiveAsync();
            usersCmb.DataSource = users;
            usersCmb.DisplayMember = "DisplayName";
            usersCmb.ValueMember = "Id";
        }

        private async void continueBtn_Click(object sender, System.EventArgs e)
        {

            if (usersCmb.SelectedValue == null ||
                usersCmb.SelectedValue == DBNull.Value ||
                !int.TryParse(usersCmb.SelectedValue.ToString(), out int userId))
            {
                MessageBox.Show("Select a user.");
                return;
            }

            var user = await _userService.GetByIdAsync(userId);

            _currentUserContext.Current = user;
            DialogResult = DialogResult.OK;
        }
    }
}
