using GarageManagementSystem.FormUser.Pages;
using GarageManagementSystem.FormUser.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagementSystem
{
    public partial class MainForm : Form
    {
        private Timer fadeTimer; // Dùng cho chuyển trang
        private bool isNavigatingToLogin = false; // Prevent repeated navigation
        public HomePage homeInterface { get; set; }
        public TicketHistory ticketHistory { get; set; }
        public OrderHistory orderHistory { get; set; }
        public ProfilePage profilePage { get; set; }
        public SchedulePage schedulePage { get; set; }
        public string UserFullName { get; set; }
        public MainForm(int UserId=0, string userFullName="")
        {
            InitializeComponent();
            this.UserFullName = userFullName;  // Set UserFullName

            homeInterface = new HomePage();
            flowLayoutPanel.Controls.Add(homeInterface);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lbUsername.Text = UserFullName.ToUpper();

            // Center the label dynamically
            CenterLabel(lbUsername, panel1);
        }
        public void CenterLabel(Label label, Panel panel)
        {
            // Calculate the new X position to center the label inside the panel
            int newX = (panel.ClientSize.Width - label.Width) / 2;

            // Update the label's position
            label.Location = new Point(newX, label.Location.Y);

            // Optional: Ensure the label's text is adjusted properly
            label.TextAlign = ContentAlignment.MiddleCenter;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Clear();
            flowLayoutPanel.Controls.Add(homeInterface);
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            ticketHistory = new TicketHistory();
            flowLayoutPanel.Controls.Clear();
            flowLayoutPanel.Controls.Add(ticketHistory);
        }
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            schedulePage = new SchedulePage();
            flowLayoutPanel.Controls.Clear();
            flowLayoutPanel.Controls.Add(schedulePage);
        }
        private void lbOrderHistory_Click(object sender, EventArgs e)
        {
            orderHistory = new OrderHistory();
            flowLayoutPanel.Controls.Clear();
            flowLayoutPanel.Controls.Add(orderHistory);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            profilePage = new ProfilePage();
            flowLayoutPanel.Controls.Clear();
            flowLayoutPanel.Controls.Add(profilePage);
        }

        private void lbLogOut_Click(object sender, EventArgs e)
        {
            NavigateToLoginForm();
        }
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
    }
}
