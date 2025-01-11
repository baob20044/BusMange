namespace GarageManagementSystem.Component.Admin.AdminTicket
{
    partial class StaffComp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffComp));
            this.lbPhoneNumber = new System.Windows.Forms.Label();
            this.lbRole = new System.Windows.Forms.Label();
            this.lbFullName = new System.Windows.Forms.Label();
            this.lbStaffId = new System.Windows.Forms.Label();
            this.btnDelete = new Guna.UI2.WinForms.Guna2ImageButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lbPhoneNumber
            // 
            this.lbPhoneNumber.AutoSize = true;
            this.lbPhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhoneNumber.Location = new System.Drawing.Point(664, 8);
            this.lbPhoneNumber.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbPhoneNumber.Name = "lbPhoneNumber";
            this.lbPhoneNumber.Size = new System.Drawing.Size(127, 23);
            this.lbPhoneNumber.TabIndex = 119;
            this.lbPhoneNumber.Text = "Phone Number";
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.BackColor = System.Drawing.Color.Transparent;
            this.lbRole.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRole.Location = new System.Drawing.Point(470, 8);
            this.lbRole.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(43, 23);
            this.lbRole.TabIndex = 117;
            this.lbRole.Text = "Role";
            // 
            // lbFullName
            // 
            this.lbFullName.AutoSize = true;
            this.lbFullName.BackColor = System.Drawing.Color.Transparent;
            this.lbFullName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFullName.Location = new System.Drawing.Point(124, 8);
            this.lbFullName.MaximumSize = new System.Drawing.Size(620, 0);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(82, 23);
            this.lbFullName.TabIndex = 116;
            this.lbFullName.Text = "FullName";
            // 
            // lbStaffId
            // 
            this.lbStaffId.AutoSize = true;
            this.lbStaffId.BackColor = System.Drawing.Color.Transparent;
            this.lbStaffId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStaffId.Location = new System.Drawing.Point(11, 8);
            this.lbStaffId.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbStaffId.Name = "lbStaffId";
            this.lbStaffId.Size = new System.Drawing.Size(60, 23);
            this.lbStaffId.TabIndex = 115;
            this.lbStaffId.Text = "StaffID";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.CheckedState.Parent = this.btnDelete;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.HoverState.ImageSize = new System.Drawing.Size(22, 22);
            this.btnDelete.HoverState.Parent = this.btnDelete;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(857, 2);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PressedState.Parent = this.btnDelete;
            this.btnDelete.Size = new System.Drawing.Size(30, 30);
            this.btnDelete.TabIndex = 118;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(-131, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 2);
            this.panel1.TabIndex = 120;
            // 
            // StaffComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbPhoneNumber);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lbRole);
            this.Controls.Add(this.lbFullName);
            this.Controls.Add(this.lbStaffId);
            this.Name = "StaffComp";
            this.Size = new System.Drawing.Size(900, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbPhoneNumber;
        private Guna.UI2.WinForms.Guna2ImageButton btnDelete;
        private System.Windows.Forms.Label lbRole;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.Label lbStaffId;
        private System.Windows.Forms.Panel panel1;
    }
}
