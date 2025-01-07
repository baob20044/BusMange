namespace GarageManagementSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbLogOut = new System.Windows.Forms.Label();
            this.controlboxMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.controlboxTurnOff = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lbOrderHistory = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnProfile = new Guna.UI2.WinForms.Guna2Button();
            this.btnHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnSchedule = new Guna.UI2.WinForms.Guna2Button();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLogOut
            // 
            this.lbLogOut.AutoSize = true;
            this.lbLogOut.BackColor = System.Drawing.Color.Transparent;
            this.lbLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLogOut.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogOut.ForeColor = System.Drawing.Color.Red;
            this.lbLogOut.Location = new System.Drawing.Point(3, 776);
            this.lbLogOut.Name = "lbLogOut";
            this.lbLogOut.Size = new System.Drawing.Size(60, 19);
            this.lbLogOut.TabIndex = 24;
            this.lbLogOut.Text = "Log out";
            this.lbLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLogOut.Click += new System.EventHandler(this.lbLogOut_Click);
            // 
            // controlboxMinimize
            // 
            this.controlboxMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlboxMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.controlboxMinimize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(42)))), ((int)(((byte)(133)))));
            this.controlboxMinimize.HoverState.Parent = this.controlboxMinimize;
            this.controlboxMinimize.IconColor = System.Drawing.Color.White;
            this.controlboxMinimize.Location = new System.Drawing.Point(1402, 12);
            this.controlboxMinimize.Name = "controlboxMinimize";
            this.controlboxMinimize.ShadowDecoration.Parent = this.controlboxMinimize;
            this.controlboxMinimize.Size = new System.Drawing.Size(32, 27);
            this.controlboxMinimize.TabIndex = 17;
            // 
            // controlboxTurnOff
            // 
            this.controlboxTurnOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlboxTurnOff.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(42)))), ((int)(((byte)(133)))));
            this.controlboxTurnOff.HoverState.FillColor = System.Drawing.Color.Red;
            this.controlboxTurnOff.HoverState.Parent = this.controlboxTurnOff;
            this.controlboxTurnOff.IconColor = System.Drawing.Color.White;
            this.controlboxTurnOff.Location = new System.Drawing.Point(1440, 12);
            this.controlboxTurnOff.Name = "controlboxTurnOff";
            this.controlboxTurnOff.ShadowDecoration.Parent = this.controlboxTurnOff;
            this.controlboxTurnOff.Size = new System.Drawing.Size(32, 27);
            this.controlboxTurnOff.TabIndex = 16;
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(66)))), ((int)(((byte)(61)))));
            this.lbUsername.Location = new System.Drawing.Point(37, 153);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(146, 23);
            this.lbUsername.TabIndex = 12;
            this.lbUsername.Text = "ĐINH QUỐC BẢO";
            this.lbUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel.Location = new System.Drawing.Point(229, 48);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1241, 755);
            this.flowLayoutPanel.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.lbUsername);
            this.panel1.Controls.Add(this.lbOrderHistory);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lbLogOut);
            this.panel1.Controls.Add(this.btnProfile);
            this.panel1.Controls.Add(this.btnHistory);
            this.panel1.Controls.Add(this.btnSchedule);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 803);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(22, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 1);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(220, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1263, 803);
            this.panel3.TabIndex = 19;
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(223, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1260, 803);
            this.mainPanel.TabIndex = 19;
            // 
            // lbOrderHistory
            // 
            this.lbOrderHistory.CheckedState.Parent = this.lbOrderHistory;
            this.lbOrderHistory.CustomImages.Parent = this.lbOrderHistory;
            this.lbOrderHistory.FillColor = System.Drawing.Color.Transparent;
            this.lbOrderHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrderHistory.ForeColor = System.Drawing.Color.White;
            this.lbOrderHistory.HoverState.Parent = this.lbOrderHistory;
            this.lbOrderHistory.Image = ((System.Drawing.Image)(resources.GetObject("lbOrderHistory.Image")));
            this.lbOrderHistory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.lbOrderHistory.Location = new System.Drawing.Point(16, 442);
            this.lbOrderHistory.Name = "lbOrderHistory";
            this.lbOrderHistory.PressedColor = System.Drawing.Color.Navy;
            this.lbOrderHistory.ShadowDecoration.Parent = this.lbOrderHistory;
            this.lbOrderHistory.Size = new System.Drawing.Size(181, 45);
            this.lbOrderHistory.TabIndex = 25;
            this.lbOrderHistory.Text = "History";
            this.lbOrderHistory.Click += new System.EventHandler(this.lbOrderHistory_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(40, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // btnProfile
            // 
            this.btnProfile.CheckedState.Parent = this.btnProfile;
            this.btnProfile.CustomImages.Parent = this.btnProfile;
            this.btnProfile.FillColor = System.Drawing.Color.Transparent;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.HoverState.Parent = this.btnProfile;
            this.btnProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnProfile.Image")));
            this.btnProfile.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProfile.Location = new System.Drawing.Point(16, 510);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.PressedColor = System.Drawing.Color.Navy;
            this.btnProfile.ShadowDecoration.Parent = this.btnProfile;
            this.btnProfile.Size = new System.Drawing.Size(181, 45);
            this.btnProfile.TabIndex = 20;
            this.btnProfile.Text = "Profile";
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.CheckedState.Parent = this.btnHistory;
            this.btnHistory.CustomImages.Parent = this.btnHistory;
            this.btnHistory.FillColor = System.Drawing.Color.Transparent;
            this.btnHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.HoverState.Parent = this.btnHistory;
            this.btnHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnHistory.Image")));
            this.btnHistory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHistory.Location = new System.Drawing.Point(16, 374);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.PressedColor = System.Drawing.Color.Navy;
            this.btnHistory.ShadowDecoration.Parent = this.btnHistory;
            this.btnHistory.Size = new System.Drawing.Size(180, 45);
            this.btnHistory.TabIndex = 18;
            this.btnHistory.Text = "Inventory";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.CheckedState.Parent = this.btnSchedule;
            this.btnSchedule.CustomImages.Parent = this.btnSchedule;
            this.btnSchedule.FillColor = System.Drawing.Color.Transparent;
            this.btnSchedule.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSchedule.HoverState.Parent = this.btnSchedule;
            this.btnSchedule.Image = ((System.Drawing.Image)(resources.GetObject("btnSchedule.Image")));
            this.btnSchedule.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSchedule.Location = new System.Drawing.Point(16, 306);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.PressedColor = System.Drawing.Color.Navy;
            this.btnSchedule.ShadowDecoration.Parent = this.btnSchedule;
            this.btnSchedule.Size = new System.Drawing.Size(181, 45);
            this.btnSchedule.TabIndex = 15;
            this.btnSchedule.Text = "Schedule";
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnHome
            // 
            this.btnHome.CheckedState.Parent = this.btnHome;
            this.btnHome.CustomImages.Parent = this.btnHome;
            this.btnHome.FillColor = System.Drawing.Color.Transparent;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.HoverState.Parent = this.btnHome;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHome.Location = new System.Drawing.Point(16, 238);
            this.btnHome.Name = "btnHome";
            this.btnHome.PressedColor = System.Drawing.Color.Navy;
            this.btnHome.ShadowDecoration.Parent = this.btnHome;
            this.btnHome.Size = new System.Drawing.Size(161, 45);
            this.btnHome.TabIndex = 14;
            this.btnHome.Text = "Home";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1482, 800);
            this.Controls.Add(this.controlboxMinimize);
            this.Controls.Add(this.controlboxTurnOff);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbLogOut;
        private Guna.UI2.WinForms.Guna2Button btnProfile;
        private Guna.UI2.WinForms.Guna2Button btnHistory;
        private Guna.UI2.WinForms.Guna2ControlBox controlboxMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox controlboxTurnOff;
        private Guna.UI2.WinForms.Guna2Button btnSchedule;
        public System.Windows.Forms.Label lbUsername;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button lbOrderHistory;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel mainPanel;
    }
}