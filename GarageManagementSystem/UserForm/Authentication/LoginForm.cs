using GarageManagementSystem.FormUser.Pages;
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

namespace GarageManagementSystem
{
    public partial class LoginForm : Form
    {
        public BusManageContext _context;
        private Timer fadeTimer; // Dùng cho chuyển trang
        public string UserFullName{get;set;}
        public int UserId { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            _context = new BusManageContext();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //Load SaveUsername
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SavedPhoneNumber))
            {
                txtPhoneNumber.Text = Properties.Settings.Default.SavedPhoneNumber;
                toggleRememberme.Checked = true;
            }
        }
        private string HashPassword(string password)
        {
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

        public string GetUserFullName(string phoneNumber)
        {
            var user = _context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
            return user?.FullName ?? string.Empty; // Return the full name, or an empty string if not found
        }
        public int GetUserId(string phoneNumber)
        {
            var user = _context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
            return user.UserID; 
        }
        public string GetUserEmail(string phoneNumber)
        {
            var user = _context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
            return user.Email;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text;
            string password = txtPassword.Text;

            // Validate input fields
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both phone number and password.");
                return;
            }

            // Validate phone number format (only digits, 10-11 digits allowed)
            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Invalid phone number format. Please enter a valid phone number.");
                return;
            }

            // Hash the entered password
            string hashedPassword = HashPassword(password);

            // Check if the phone number and password match a user in the database
            var user = _context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber && u.PasswordHash == hashedPassword);

            if (user != null)
            {
                UserFullName = GetUserFullName(phoneNumber); // Set the full name
                UserId = GetUserId(phoneNumber);
                UserSession.UserId = UserId;
                UserSession.FullName = UserFullName;
                UserSession.Email = GetUserEmail(phoneNumber);
                UserSession.PhoneNumber = user.PhoneNumber;
                // Remember Me functionality
                if (toggleRememberme.Checked)
                {
                    Properties.Settings.Default.SavedPhoneNumber = phoneNumber;
                }
                else
                {
                    Properties.Settings.Default.SavedPhoneNumber = string.Empty;
                }

                Properties.Settings.Default.Save();
                MessageBox.Show("Login successful!");
                if (user.Role == "UserRole")
                {
                    NavigateToMainPage();
                }
                else if (user.Role == "AdminRole")
                {
                    NavigateToAdminMainPage();
                }
                else
                {
                    MessageBox.Show("Role error");
                }
            }
            else
            {
                MessageBox.Show("Invalid phone number or password.");
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d{10,11}$");
        }




        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            if(txtPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '*';
                txtPassword.IconRight = Image.FromFile(@"..\..\Resources\Closed_Eye.png");
            }
            else
            {
                txtPassword.PasswordChar = '\0';
                txtPassword.IconRight = Image.FromFile(@"..\..\Resources\Eye.png");
            }
        }

        private void controlboxTurnOff_Click(object sender, EventArgs e)
        {
            if (!toggleRememberme.Checked)
            {
                Properties.Settings.Default.SavedPhoneNumber = string.Empty;
                Properties.Settings.Default.Save();
            }
        }
        private bool isNavigatingSignUp = false; // Prevent repeated navigation
        private void btnSignup_Click(object sender, EventArgs e)
        {
            NavigateToSignupForm();
        }
        private void NavigateToSignupForm()
        {
            if (isNavigatingSignUp) return; // Prevent multiple triggers
            isNavigatingSignUp = true; // Set flag to prevent subsequent triggers

            // Initialize the Timer for fade-out
            fadeTimer = new Timer();
            fadeTimer.Interval = 10; // Faster updates for smoother fade
            fadeTimer.Tick += FadeToSignup;
            fadeTimer.Start();
        }
        private void FadeToSignup(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.1; // Faster fade with larger decrement
            }
            else
            {
                fadeTimer.Stop();
                fadeTimer.Dispose();

                // Hide the current form before opening the SignupForm
                this.Hide();

                // Open SignupForm
                RegisterForm signupForm = new RegisterForm();
                signupForm.StartPosition = FormStartPosition.CenterScreen;
                signupForm.Location = this.Location;
                signupForm.ShowDialog();  // Show the new form

                // After showing the new form, dispose of the current form
                this.Close(); // Close the form
                this.Dispose(); // Dispose of the form's resources

                // Ensure the old form is completely removed from memory and taskbar
                Application.DoEvents(); // Allow UI to refresh and clear pending events
            }
        }
        private bool isNavigatingMainPage = false; // Prevent repeated navigation
        private void NavigateToMainPage()
        {
            if (isNavigatingMainPage) return; // Prevent multiple triggers
            isNavigatingMainPage = true; // Set flag to prevent subsequent triggers
            // Initialize the Timer for fade-out
            fadeTimer = new Timer();
            fadeTimer.Interval = 10; // Faster updates for smoother fade
            fadeTimer.Tick += FadeToMainPage;
            fadeTimer.Start();
        }
        private void FadeToMainPage(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.1; // Faster fade with larger decrement
            }
            else
            {
                fadeTimer.Stop();
                fadeTimer.Dispose();

                // Hide the current form before opening the SignupForm
                this.Hide();

                // Open SignupForm
                MainForm mainPage = new MainForm(this.UserId, this.UserFullName);
                mainPage.StartPosition = FormStartPosition.CenterScreen;
                mainPage.Location = this.Location;
                mainPage.ShowDialog();  // Show the new form

                // After showing the new form, dispose of the current form
                this.Close(); // Close the form
                this.Dispose(); // Dispose of the form's resources

                // Ensure the old form is completely removed from memory and taskbar
                Application.DoEvents(); // Allow UI to refresh and clear pending events
            }
        }
        private bool isNavigatingAdminMainPage = false; // Prevent repeated navigation
        private void NavigateToAdminMainPage()
        {
            if (isNavigatingAdminMainPage) return; // Prevent multiple triggers
            isNavigatingAdminMainPage = true; // Set flag to prevent subsequent triggers
            // Initialize the Timer for fade-out
            fadeTimer = new Timer();
            fadeTimer.Interval = 10; // Faster updates for smoother fade
            fadeTimer.Tick += FadeToAdminMainPage;
            fadeTimer.Start();
        }
        private void FadeToAdminMainPage(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.1; // Faster fade with larger decrement
            }
            else
            {
                fadeTimer.Stop();
                fadeTimer.Dispose();

                // Hide the current form before opening the SignupForm
                this.Hide();

                // Open SignupForm
                AdminMainForm mainPage = new AdminMainForm(this.UserId, this.UserFullName);
                mainPage.StartPosition = FormStartPosition.CenterScreen;
                mainPage.Location = this.Location;
                mainPage.ShowDialog();  // Show the new form

                // After showing the new form, dispose of the current form
                this.Close(); // Close the form
                this.Dispose(); // Dispose of the form's resources

                // Ensure the old form is completely removed from memory and taskbar
                Application.DoEvents(); // Allow UI to refresh and clear pending events
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string phoneNumber = txtPhoneNumber.Text;
                string password = txtPassword.Text;

                // Validate input fields
                if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both phone number and password.");
                    return;
                }

                // Validate phone number format (only digits, 10-11 digits allowed)
                if (!IsValidPhoneNumber(phoneNumber))
                {
                    MessageBox.Show("Invalid phone number format. Please enter a valid phone number.");
                    return;
                }

                // Hash the entered password
                string hashedPassword = HashPassword(password);

                // Check if the phone number and password match a user in the database
                var user = _context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber && u.PasswordHash == hashedPassword);

                if (user != null)
                {
                    UserFullName = GetUserFullName(phoneNumber); // Set the full name
                    UserId = GetUserId(phoneNumber);
                    UserSession.UserId = UserId;
                    UserSession.FullName = UserFullName;
                    UserSession.Email = GetUserEmail(phoneNumber);
                    UserSession.PhoneNumber = user.PhoneNumber;
                    // Remember Me functionality
                    if (toggleRememberme.Checked)
                    {
                        Properties.Settings.Default.SavedPhoneNumber = phoneNumber;
                    }
                    else
                    {
                        Properties.Settings.Default.SavedPhoneNumber = string.Empty;
                    }

                    Properties.Settings.Default.Save();
                    MessageBox.Show("Login successful!");
                    NavigateToMainPage();
                }
                else
                {
                    MessageBox.Show("Invalid phone number or password.");
                }
            }
        }
    }
    public static class UserSession
    {
        public static string FullName { get; set; }
        public static string PhoneNumber { get; set; }
        public static string Email { get; set; }
        public static int UserId { get; set; }
    }
}
