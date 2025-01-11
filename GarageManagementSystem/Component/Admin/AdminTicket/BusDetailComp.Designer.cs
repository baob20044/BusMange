namespace GarageManagementSystem.Component.Admin.AdminTicket
{
    partial class BusDetailComp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusDetailComp));
            this.lbSeat = new System.Windows.Forms.Label();
            this.lbBusNumber = new System.Windows.Forms.Label();
            this.lbBusId = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnViewDetail = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // lbSeat
            // 
            this.lbSeat.AutoSize = true;
            this.lbSeat.BackColor = System.Drawing.Color.Transparent;
            this.lbSeat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeat.Location = new System.Drawing.Point(512, 11);
            this.lbSeat.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbSeat.Name = "lbSeat";
            this.lbSeat.Size = new System.Drawing.Size(43, 23);
            this.lbSeat.TabIndex = 111;
            this.lbSeat.Text = "Seat";
            // 
            // lbBusNumber
            // 
            this.lbBusNumber.AutoSize = true;
            this.lbBusNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbBusNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBusNumber.Location = new System.Drawing.Point(129, 11);
            this.lbBusNumber.MaximumSize = new System.Drawing.Size(620, 0);
            this.lbBusNumber.Name = "lbBusNumber";
            this.lbBusNumber.Size = new System.Drawing.Size(100, 23);
            this.lbBusNumber.TabIndex = 110;
            this.lbBusNumber.Text = "BusNumber";
            // 
            // lbBusId
            // 
            this.lbBusId.AutoSize = true;
            this.lbBusId.BackColor = System.Drawing.Color.Transparent;
            this.lbBusId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBusId.Location = new System.Drawing.Point(16, 11);
            this.lbBusId.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbBusId.Name = "lbBusId";
            this.lbBusId.Size = new System.Drawing.Size(52, 23);
            this.lbBusId.TabIndex = 109;
            this.lbBusId.Text = "BusId";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.BackColor = System.Drawing.Color.Transparent;
            this.lbType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.Location = new System.Drawing.Point(677, 11);
            this.lbType.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(45, 23);
            this.lbType.TabIndex = 114;
            this.lbType.Text = "Type";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(-103, 42);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 2);
            this.panel1.TabIndex = 115;
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.BackColor = System.Drawing.Color.Transparent;
            this.btnViewDetail.CheckedState.Parent = this.btnViewDetail;
            this.btnViewDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewDetail.HoverState.ImageSize = new System.Drawing.Size(22, 22);
            this.btnViewDetail.HoverState.Parent = this.btnViewDetail;
            this.btnViewDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnViewDetail.Image")));
            this.btnViewDetail.Location = new System.Drawing.Point(856, 4);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.PressedState.Parent = this.btnViewDetail;
            this.btnViewDetail.Size = new System.Drawing.Size(30, 30);
            this.btnViewDetail.TabIndex = 112;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // BusDetailComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.btnViewDetail);
            this.Controls.Add(this.lbSeat);
            this.Controls.Add(this.lbBusNumber);
            this.Controls.Add(this.lbBusId);
            this.Name = "BusDetailComp";
            this.Size = new System.Drawing.Size(957, 45);
            this.Load += new System.EventHandler(this.BusDetailComp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ImageButton btnViewDetail;
        private System.Windows.Forms.Label lbSeat;
        private System.Windows.Forms.Label lbBusNumber;
        private System.Windows.Forms.Label lbBusId;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Panel panel1;
    }
}
