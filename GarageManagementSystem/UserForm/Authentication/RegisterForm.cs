using GarageManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagementSystem
{

    public partial class RegisterForm : Form
    {
        public BusManageContext _context;
        private Timer fadeTimer; // Declare Timer globally - Dùng cho chuyển trang 
        public RegisterForm()
        {
            InitializeComponent();
            _context = new BusManageContext();
        }

        private void lbLoginHere_Click(object sender, EventArgs e)
        {
            NavigateToLoginForm();
        }
        private bool isNavigatingToLogin = false; // Prevent repeated navigation

        private void NavigateToLoginForm()
        {
            if (isNavigatingToLogin) return; // Prevent multiple triggers
            isNavigatingToLogin = true; // Set flag to prevent subsequent triggers

            // Initialize the Timer for fade-out
            fadeTimer = new Timer();
            fadeTimer.Interval = 10; // Faster updates for smoother fade
            fadeTimer.Tick += FadeToLogin;
            fadeTimer.Start();
        }

        private void FadeToLogin(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.05; // Faster fade with larger decrement
            }
            else
            {
                fadeTimer.Stop();
                fadeTimer.Dispose();

                // Hide the current form before opening the LoginForm
                this.Hide(); // Hide to prevent gaps or visual issues during transition

                // Open the LoginForm after fading out
                LoginForm loginForm = new LoginForm();
                loginForm.StartPosition = FormStartPosition.CenterScreen;
                loginForm.Location = this.Location; // Preserve the form's position
                loginForm.ShowDialog(); // Show LoginForm modally

                // Properly close the current form after showing the LoginForm
                this.Close(); // Close the current form
                this.Dispose(); // Dispose of the form to free resources

                // Ensure the old form is removed from memory and taskbar
                Application.DoEvents(); // Force UI to update and remove the old form from taskbar

                // Reset the flag after the navigation is complete
                isNavigatingToLogin = false;
            }
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Method to validate phone number format
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^(0[1-9][0-9]{8,9})$"; // Example: Vietnamese phone numbers start with '0' and have 10-11 digits
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        private string HashPassword(string password) {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert to hexadecimal
                }
                return builder.ToString();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string fullname = txtFullName.Text;
                string email = txtEmail.Text;
                string phoneNumber = txtPhoneNumber.Text;
                string password = txtPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;

                // Validate input
                if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ tất cả các trường.");
                    return;
                }

                // Validate email format
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ.");
                    return;
                }

                // Validate phone number format
                if (!IsValidPhoneNumber(phoneNumber))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ.");
                    return;
                }

                // Check if password and confirm password match
                if (password != confirmPassword)
                {
                    MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.");
                    return;
                }

                // Validate password strength
                if (!IsValidPassword(password))
                {
                    MessageBox.Show("Mật khẩu phải chứa ít nhất một chữ hoa, một ký tự đặc biệt và một số.");
                    return;
                }

                // Check if email already exists
                var existingEmail = _context.Users.FirstOrDefault(u => u.Email == email);
                if (existingEmail != null)
                {
                    MessageBox.Show("Email đã tồn tại.");
                    return;
                }

                // Check if phone number already exists
                var existingPhone = _context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
                if (existingPhone != null)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại.");
                    return;
                }

                // Create new user
                var newUser = new User
                {
                    FullName = fullname,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    PasswordHash = HashPassword(password),
                    CreatedAt = DateTime.Now,
                    Role = "UserRole"
                };

                // Add user to database
                _context.Users.Add(newUser);

                // Save changes to database
                _context.SaveChanges();

                // Show success message
                MessageBox.Show("Đăng ký thành công!");

                // Navigate to login form
                NavigateToLoginForm();
            }
            catch (Exception ex)
            {
                // Display the error message for debugging
                MessageBox.Show($"An error occurred: {ex.Message}\n{ex.StackTrace}");
            }
        }


        // Method to validate the password
        private bool IsValidPassword(string password)
        {
            // Regular expression for password validation
            // At least 1 uppercase, 1 lowercase, 1 number, and 1 special character
            string pattern = @"^(?=.*[A-Z])(?=.*[0-9])(?=.*[\W_]).{6,}$";

            return System.Text.RegularExpressions.Regex.IsMatch(password, pattern);
        }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '*'; // Ẩn mật khẩu
                txtPassword.IconRight = Image.FromFile("../../Resources/Closed_Eye.png"); // Biểu tượng nhắm mắt
            }
            else
            {
                txtPassword.PasswordChar = '\0'; // Hiển thị mật khẩu
                txtPassword.IconRight = Image.FromFile("../../Resources/Eye.png"); // Biểu tượng mở mắt
            }
        }

        private void txtConfirmPassword_IconRightClick(object sender, EventArgs e)
        {
            if (txtConfirmPassword.PasswordChar == '\0')
            {
                txtConfirmPassword.PasswordChar = '*'; // Ẩn mật khẩu
                txtConfirmPassword.IconRight = Image.FromFile("../../Resources/Closed_Eye.png"); // Biểu tượng nhắm mắt
            }
            else
            {
                txtConfirmPassword.PasswordChar = '\0'; // Hiển thị mật khẩu
                txtConfirmPassword.IconRight = Image.FromFile("../../Resources/Eye.png"); // Biểu tượng mở mắt
            }
        }
    }
}
