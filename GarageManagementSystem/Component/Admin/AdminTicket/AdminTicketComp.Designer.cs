namespace GarageManagementSystem.Component.Admin.AdminTicket
{
    partial class AdminTicketComp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminTicketComp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbRouteName = new System.Windows.Forms.Label();
            this.lbTicketId = new System.Windows.Forms.Label();
            this.btnViewDetail = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lbBusType = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(-7, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 2);
            this.panel1.TabIndex = 112;
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.BackColor = System.Drawing.Color.Transparent;
            this.lbDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(862, 13);
            this.lbDate.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(46, 23);
            this.lbDate.TabIndex = 111;
            this.lbDate.Text = "Date";
            // 
            // lbRouteName
            // 
            this.lbRouteName.AutoSize = true;
            this.lbRouteName.BackColor = System.Drawing.Color.Transparent;
            this.lbRouteName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRouteName.Location = new System.Drawing.Point(112, 13);
            this.lbRouteName.MaximumSize = new System.Drawing.Size(620, 0);
            this.lbRouteName.Name = "lbRouteName";
            this.lbRouteName.Size = new System.Drawing.Size(106, 23);
            this.lbRouteName.TabIndex = 110;
            this.lbRouteName.Text = "Route Name";
            // 
            // lbTicketId
            // 
            this.lbTicketId.AutoSize = true;
            this.lbTicketId.BackColor = System.Drawing.Color.Transparent;
            this.lbTicketId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTicketId.Location = new System.Drawing.Point(4, 13);
            this.lbTicketId.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbTicketId.Name = "lbTicketId";
            this.lbTicketId.Size = new System.Drawing.Size(71, 23);
            this.lbTicketId.TabIndex = 109;
            this.lbTicketId.Text = "TicketID";
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.BackColor = System.Drawing.Color.Transparent;
            this.btnViewDetail.CheckedState.Parent = this.btnViewDetail;
            this.btnViewDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewDetail.HoverState.ImageSize = new System.Drawing.Size(22, 22);
            this.btnViewDetail.HoverState.Parent = this.btnViewDetail;
            this.btnViewDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnViewDetail.Image")));
            this.btnViewDetail.Location = new System.Drawing.Point(1086, 6);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.PressedState.Parent = this.btnViewDetail;
            this.btnViewDetail.Size = new System.Drawing.Size(30, 30);
            this.btnViewDetail.TabIndex = 113;
            // 
            // lbBusType
            // 
            this.lbBusType.AutoSize = true;
            this.lbBusType.BackColor = System.Drawing.Color.Transparent;
            this.lbBusType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBusType.Location = new System.Drawing.Point(517, 13);
            this.lbBusType.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbBusType.Name = "lbBusType";
            this.lbBusType.Size = new System.Drawing.Size(37, 23);
            this.lbBusType.TabIndex = 115;
            this.lbBusType.Text = "Bus";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.BackColor = System.Drawing.Color.Transparent;
            this.lbPrice.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(645, 13);
            this.lbPrice.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(47, 23);
            this.lbPrice.TabIndex = 116;
            this.lbPrice.Text = "Price";
            // 
            // AdminTicketComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbBusType);
            this.Controls.Add(this.btnViewDetail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbRouteName);
            this.Controls.Add(this.lbTicketId);
            this.Name = "AdminTicketComp";
            this.Size = new System.Drawing.Size(1126, 53);
            this.Load += new System.EventHandler(this.AdminTicketComp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ImageButton btnViewDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbRouteName;
        private System.Windows.Forms.Label lbTicketId;
        private System.Windows.Forms.Label lbBusType;
        private System.Windows.Forms.Label lbPrice;
    }
}
