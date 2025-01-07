using GarageManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagementSystem.FormUser.Pages
{
    public partial class ProfilePage : UserControl
    {
        BusManageContext _context;
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void ProfilePage_Load(object sender, EventArgs e)
        {
            using (var _context = new BusManageContext())
            {
                // Assuming `UserSession.UserID` holds the ID of the logged-in user
                int userId = UserSession.UserId;

                // Fetch the user details from the database
                var user = _context.Users
                    .Where(u => u.UserID == userId)
                    .FirstOrDefault();

                if (user != null)
                {
                    // Populate the text boxes with user details
                    txtFullName.Text = user.FullName;
                    txtEmail.Text = user.Email;
                    txtPhoneNumber.Text = user.PhoneNumber;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            lb1Group2.Visible = false;
            lb2Group2.Visible = false;
            lb3Group2.Visible = false;
            txtNewPassword.Visible = false;
            txtOldPassword.Visible = false;
            txtComfirmNewPassword.Visible = false;

            lb1Group1.Visible = true;
            lb2Group1.Visible = true;
            lb3Group1.Visible = true;
            txtEmail.Visible = true;
            txtPhoneNumber.Visible = true;
            txtFullName.Visible = true;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            lb1Group1.Visible = false;
            lb2Group1.Visible = false;
            lb3Group1.Visible = false;
            txtEmail.Visible = false;
            txtPhoneNumber.Visible = false;
            txtFullName.Visible = false;

            lb1Group2.Visible = true;
            lb2Group2.Visible = true;
            lb3Group2.Visible = true;
            txtNewPassword.Visible = true;
            txtOldPassword.Visible = true;
            txtComfirmNewPassword.Visible = true;
        }

        private void txtEmail_IconRightClick(object sender, EventArgs e)
        {
            txtEmail.Enabled = true;
        }

        private void txtFullName_IconRightClick(object sender, EventArgs e)
        {
            //txtFullName.Enabled = true;
        }

        private void txtPhoneNumber_IconRightClick(object sender, EventArgs e)
        {
            txtPhoneNumber.Enabled = true;
        }

        private void txtComfirmNewPassword_IconRightClick(object sender, EventArgs e)
        {
            if (txtComfirmNewPassword.PasswordChar == '\0')
            {
                txtComfirmNewPassword.PasswordChar = '*';
                txtComfirmNewPassword.IconRight = Image.FromFile(@"..\..\Resources\Closed_Eye.png");
            }
            else
            {
                txtComfirmNewPassword.PasswordChar = '\0';
                txtComfirmNewPassword.IconRight = Image.FromFile(@"..\..\Resources\Eye.png");
            }
        }

        private void txtNewPassword_IconRightClick(object sender, EventArgs e)
        {
            if (txtComfirmNewPassword.PasswordChar == '\0')
            {
                txtNewPassword.PasswordChar = '*';
                txtNewPassword.IconRight = Image.FromFile(@"..\..\Resources\Closed_Eye.png");
            }
            else
            {
                txtNewPassword.PasswordChar = '\0';
                txtNewPassword.IconRight = Image.FromFile(@"..\..\Resources\Eye.png");
            }
        }

        private void txtOldPassword_IconRightClick(object sender, EventArgs e)
        {
            if (txtOldPassword.PasswordChar == '\0')
            {
                txtOldPassword.PasswordChar = '*';
                txtOldPassword.IconRight = Image.FromFile(@"..\..\Resources\Closed_Eye.png");
            }
            else
            {
                txtOldPassword.PasswordChar = '\0';
                txtOldPassword.IconRight = Image.FromFile(@"..\..\Resources\Eye.png");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var _context = new BusManageContext())
                {
                    int userId = UserSession.UserId;

                    // Fetch the current user from the database
                    var user = _context.Users
                        .Where(u => u.UserID == userId)
                        .FirstOrDefault();

                    if (user != null)
                    {
                        // ** Email Validation **
                        string email = txtEmail.Text.Trim();
                        var emailRegex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

                        if (!emailRegex.IsMatch(email))
                        {
                            MessageBox.Show("Địa chỉ email không hợp lệ. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Check if the Email or PhoneNumber already exists in the database
                        bool isEmailExist = _context.Users
                            .Any(u => u.Email == email && u.UserID != userId);
                        bool isPhoneExist = _context.Users
                            .Any(u => u.PhoneNumber == txtPhoneNumber.Text.Trim() && u.UserID != userId);

                        if (isEmailExist)
                        {
                            MessageBox.Show("Email này đã được sử dụng. Vui lòng chọn email khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (isPhoneExist)
                        {
                            MessageBox.Show("Số điện thoại này đã được sử dụng. Vui lòng chọn số điện thoại khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // ** Update User Info **
                        if (txtFullName.Visible)
                        {
                            user.FullName = txtFullName.Text.Trim();
                        }

                        if (txtEmail.Visible)
                        {
                            user.Email = email;
                        }

                        if (txtPhoneNumber.Visible)
                        {
                            user.PhoneNumber = txtPhoneNumber.Text.Trim();
                        }

                        // ** Change Password **
                        if (txtOldPassword.Visible)
                        {
                            // Check if the old password matches the password stored in the database
                            if (user.PasswordHash != PasswordHasher.HashPassword(txtOldPassword.Text.Trim()))
                            {
                                MessageBox.Show("Mật khẩu cũ không đúng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Check if the new password and confirm new password match
                            if (txtNewPassword.Text.Trim() != txtComfirmNewPassword.Text.Trim())
                            {
                                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Password Validation: Uppercase, Number, and Special Character
                            string newPassword = txtNewPassword.Text.Trim();

                            // Regex to check password strength (uppercase, number, special character)
                            var passwordRegex = new System.Text.RegularExpressions.Regex(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

                            if (!passwordRegex.IsMatch(newPassword))
                            {
                                MessageBox.Show("Mật khẩu mới phải có ít nhất một chữ cái viết hoa, một số và một ký tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Hash and update password if valid
                            user.PasswordHash = PasswordHasher.HashPassword(newPassword);
                        }

                        // Save changes to the database
                        _context.SaveChanges();

                        // Update session and main page
                        UserSession.FullName = user.FullName;
                        var mainPage = this.FindForm() as MainForm;
                        mainPage.lbUsername.Text = UserSession.FullName.ToUpper();
                        mainPage.CenterLabel(mainPage.lbUsername, mainPage.panel1);

                        // Show success message
                        MessageBox.Show("Thông tin đã được cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"Đã xảy ra lỗi khi cập nhật thông tin: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






    }
    public static class PasswordHasher
    {
        // Hashes the password using SHA256
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashStringBuilder.Append(b.ToString("x2"));
                }
                return hashStringBuilder.ToString();
            }
        }
    }
}
