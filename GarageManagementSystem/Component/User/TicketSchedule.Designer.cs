namespace GarageManagementSystem.Component
{
    partial class TicketSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketSchedule));
            this.lbDepartTime = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbStopName = new System.Windows.Forms.Label();
            this.lbStopAddress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDepartTime
            // 
            this.lbDepartTime.AutoSize = true;
            this.lbDepartTime.BackColor = System.Drawing.Color.Transparent;
            this.lbDepartTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDepartTime.Location = new System.Drawing.Point(38, 10);
            this.lbDepartTime.Name = "lbDepartTime";
            this.lbDepartTime.Size = new System.Drawing.Size(61, 28);
            this.lbDepartTime.TabIndex = 7;
            this.lbDepartTime.Text = "00:00";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(104, 14);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(20, 20);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 8;
            this.guna2PictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(112, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 57);
            this.panel1.TabIndex = 9;
            // 
            // lbStopName
            // 
            this.lbStopName.AutoSize = true;
            this.lbStopName.BackColor = System.Drawing.Color.Transparent;
            this.lbStopName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStopName.Location = new System.Drawing.Point(142, 8);
            this.lbStopName.Name = "lbStopName";
            this.lbStopName.Size = new System.Drawing.Size(152, 28);
            this.lbStopName.TabIndex = 10;
            this.lbStopName.Text = "Bus Stop Name";
            // 
            // lbStopAddress
            // 
            this.lbStopAddress.AutoSize = true;
            this.lbStopAddress.BackColor = System.Drawing.Color.Transparent;
            this.lbStopAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStopAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lbStopAddress.Location = new System.Drawing.Point(143, 38);
            this.lbStopAddress.Name = "lbStopAddress";
            this.lbStopAddress.Size = new System.Drawing.Size(142, 23);
            this.lbStopAddress.TabIndex = 11;
            this.lbStopAddress.Text = "Bus Stop Address";
            // 
            // TicketSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbStopAddress);
            this.Controls.Add(this.lbStopName);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.lbDepartTime);
            this.Controls.Add(this.panel1);
            this.Name = "TicketSchedule";
            this.Size = new System.Drawing.Size(1035, 80);
            this.Load += new System.EventHandler(this.TicketSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDepartTime;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbStopName;
        private System.Windows.Forms.Label lbStopAddress;
    }
}
