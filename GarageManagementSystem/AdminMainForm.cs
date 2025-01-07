using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagementSystem
{
    public partial class AdminMainForm : Form
    {
        private Timer fadeTimer; // Dùng cho chuyển trang
        private bool isNavigatingToLogin = false; // Prevent repeated navigation
        private ScheduleManage scheduleManage;
        public string UserFullName { get; set; }
        public AdminMainForm(int userId = 0, string userFullName ="")
        {
            InitializeComponent();
            this.UserFullName = userFullName;  // Set UserFullName
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
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

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnBus_Click(object sender, EventArgs e)
        {

        }

        private void btnRoute_Click(object sender, EventArgs e)
        {

        }

        private void btnBusStop_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {

        }

        private void btnTicket_Click(object sender, EventArgs e)
        {

        }

        private void btnBooking_Click(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }
        public void refreshSchedule()
        {
            scheduleManage = new ScheduleManage();
            flowLayoutPanel.Controls.Clear();
            flowLayoutPanel.Controls.Add(scheduleManage);
        }
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            refreshSchedule();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {

        }
    }
}
