namespace GarageManagementSystem.Component.Admin.AdminTicket
{
    partial class TicketInSpecificDate
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
            this.lbRouteName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbBusType = new System.Windows.Forms.Label();
            this.lbBusNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbRouteName
            // 
            this.lbRouteName.AutoSize = true;
            this.lbRouteName.BackColor = System.Drawing.Color.Transparent;
            this.lbRouteName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRouteName.Location = new System.Drawing.Point(29, 17);
            this.lbRouteName.MaximumSize = new System.Drawing.Size(620, 0);
            this.lbRouteName.Name = "lbRouteName";
            this.lbRouteName.Size = new System.Drawing.Size(106, 23);
            this.lbRouteName.TabIndex = 111;
            this.lbRouteName.Text = "Route Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(-13, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 2);
            this.panel1.TabIndex = 119;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.BackColor = System.Drawing.Color.Transparent;
            this.lbPrice.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(836, 17);
            this.lbPrice.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(47, 23);
            this.lbPrice.TabIndex = 118;
            this.lbPrice.Text = "Price";
            // 
            // lbBusType
            // 
            this.lbBusType.AutoSize = true;
            this.lbBusType.BackColor = System.Drawing.Color.Transparent;
            this.lbBusType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBusType.Location = new System.Drawing.Point(702, 17);
            this.lbBusType.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbBusType.Name = "lbBusType";
            this.lbBusType.Size = new System.Drawing.Size(37, 23);
            this.lbBusType.TabIndex = 117;
            this.lbBusType.Text = "Bus";
            // 
            // lbBusNumber
            // 
            this.lbBusNumber.AutoSize = true;
            this.lbBusNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbBusNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBusNumber.Location = new System.Drawing.Point(480, 17);
            this.lbBusNumber.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbBusNumber.Name = "lbBusNumber";
            this.lbBusNumber.Size = new System.Drawing.Size(100, 23);
            this.lbBusNumber.TabIndex = 120;
            this.lbBusNumber.Text = "BusNumber";
            // 
            // TicketInSpecificDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbBusNumber);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbBusType);
            this.Controls.Add(this.lbRouteName);
            this.Name = "TicketInSpecificDate";
            this.Size = new System.Drawing.Size(1039, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRouteName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbBusType;
        private System.Windows.Forms.Label lbBusNumber;
    }
}
