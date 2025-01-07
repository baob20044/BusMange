namespace GarageManagementSystem.Component.Admin.AdminScheduleComp
{
    partial class ScheduleStopComp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleStopComp));
            this.lbStopAddress = new System.Windows.Forms.Label();
            this.lbStopName = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbDepartTime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbStopAddress
            // 
            this.lbStopAddress.AutoSize = true;
            this.lbStopAddress.BackColor = System.Drawing.Color.Transparent;
            this.lbStopAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStopAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lbStopAddress.Location = new System.Drawing.Point(43, 29);
            this.lbStopAddress.MaximumSize = new System.Drawing.Size(620, 0);
            this.lbStopAddress.Name = "lbStopAddress";
            this.lbStopAddress.Size = new System.Drawing.Size(142, 23);
            this.lbStopAddress.TabIndex = 16;
            this.lbStopAddress.Text = "Bus Stop Address";
            // 
            // lbStopName
            // 
            this.lbStopName.AutoSize = true;
            this.lbStopName.BackColor = System.Drawing.Color.Transparent;
            this.lbStopName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStopName.Location = new System.Drawing.Point(42, 1);
            this.lbStopName.Name = "lbStopName";
            this.lbStopName.Size = new System.Drawing.Size(152, 28);
            this.lbStopName.TabIndex = 15;
            this.lbStopName.Text = "Bus Stop Name";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(665, 1);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(20, 20);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 13;
            this.guna2PictureBox1.TabStop = false;
            // 
            // lbDepartTime
            // 
            this.lbDepartTime.AutoSize = true;
            this.lbDepartTime.BackColor = System.Drawing.Color.Transparent;
            this.lbDepartTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDepartTime.Location = new System.Drawing.Point(690, 29);
            this.lbDepartTime.Name = "lbDepartTime";
            this.lbDepartTime.Size = new System.Drawing.Size(220, 28);
            this.lbDepartTime.TabIndex = 12;
            this.lbDepartTime.Text = "HH/MM MM/DD/YYYY";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(674, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 78);
            this.panel1.TabIndex = 14;
            // 
            // btnEdit
            // 
            this.btnEdit.BorderThickness = 1;
            this.btnEdit.CheckedState.Parent = this.btnEdit;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.CustomImages.Parent = this.btnEdit;
            this.btnEdit.FillColor = System.Drawing.Color.White;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.HoverState.Parent = this.btnEdit;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageSize = new System.Drawing.Size(30, 30);
            this.btnEdit.Location = new System.Drawing.Point(909, 24);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ShadowDecoration.Parent = this.btnEdit;
            this.btnEdit.Size = new System.Drawing.Size(48, 38);
            this.btnEdit.TabIndex = 17;
            // 
            // btnDelete
            // 
            this.btnDelete.BorderThickness = 1;
            this.btnDelete.CheckedState.Parent = this.btnDelete;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.CustomImages.Parent = this.btnDelete;
            this.btnDelete.FillColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.HoverState.Parent = this.btnDelete;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDelete.Location = new System.Drawing.Point(972, 24);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShadowDecoration.Parent = this.btnDelete;
            this.btnDelete.Size = new System.Drawing.Size(48, 38);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ScheduleStopComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lbStopAddress);
            this.Controls.Add(this.lbStopName);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.lbDepartTime);
            this.Controls.Add(this.panel1);
            this.Name = "ScheduleStopComp";
            this.Size = new System.Drawing.Size(1055, 87);
            this.Load += new System.EventHandler(this.ScheduleStopComp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbStopAddress;
        private System.Windows.Forms.Label lbStopName;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label lbDepartTime;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
    }
}
