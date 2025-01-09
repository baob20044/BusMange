namespace GarageManagementSystem.Component.Admin.AdminTicket
{
    partial class TicketAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketAdd));
            this.label6 = new System.Windows.Forms.Label();
            this.datepicker1 = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnAddTicket = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(70, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 23);
            this.label6.TabIndex = 101;
            this.label6.Text = "Thời gian";
            // 
            // datepicker1
            // 
            this.datepicker1.BackColor = System.Drawing.Color.White;
            this.datepicker1.BorderRadius = 1;
            this.datepicker1.Checked = false;
            this.datepicker1.Color = System.Drawing.Color.Gainsboro;
            this.datepicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.datepicker1.CustomFormat = "yyyy-MM-dd";
            this.datepicker1.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.datepicker1.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.datepicker1.DisabledColor = System.Drawing.Color.Gray;
            this.datepicker1.DisplayWeekNumbers = false;
            this.datepicker1.DPHeight = 0;
            this.datepicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.datepicker1.FillDatePicker = true;
            this.datepicker1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.datepicker1.ForeColor = System.Drawing.Color.Black;
            this.datepicker1.Icon = ((System.Drawing.Image)(resources.GetObject("datepicker1.Icon")));
            this.datepicker1.IconColor = System.Drawing.SystemColors.Control;
            this.datepicker1.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.datepicker1.LeftTextMargin = 5;
            this.datepicker1.Location = new System.Drawing.Point(74, 54);
            this.datepicker1.MinimumSize = new System.Drawing.Size(4, 32);
            this.datepicker1.Name = "datepicker1";
            this.datepicker1.Size = new System.Drawing.Size(352, 34);
            this.datepicker1.TabIndex = 100;
            this.datepicker1.ValueChanged += new System.EventHandler(this.datepicker1_ValueChanged);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(74, 161);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1061, 572);
            this.flowLayoutPanel.TabIndex = 98;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 32);
            this.label5.TabIndex = 97;
            this.label5.Text = "Chuyến đi theo lịch";
            // 
            // btnClose
            // 
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1156, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedState.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(38, 23);
            this.btnClose.TabIndex = 89;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddTicket
            // 
            this.btnAddTicket.BackColor = System.Drawing.Color.Transparent;
            this.btnAddTicket.CheckedState.Parent = this.btnAddTicket;
            this.btnAddTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTicket.HoverState.ImageSize = new System.Drawing.Size(22, 22);
            this.btnAddTicket.HoverState.Parent = this.btnAddTicket;
            this.btnAddTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTicket.Image")));
            this.btnAddTicket.Location = new System.Drawing.Point(287, 107);
            this.btnAddTicket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddTicket.Name = "btnAddTicket";
            this.btnAddTicket.PressedState.Parent = this.btnAddTicket;
            this.btnAddTicket.Size = new System.Drawing.Size(42, 36);
            this.btnAddTicket.TabIndex = 99;
            this.btnAddTicket.Click += new System.EventHandler(this.btnAddTicket_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 7;
            this.guna2Panel1.Controls.Add(this.label6);
            this.guna2Panel1.Controls.Add(this.datepicker1);
            this.guna2Panel1.Controls.Add(this.flowLayoutPanel);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.btnAddTicket);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 1);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1210, 760);
            this.guna2Panel1.TabIndex = 4;
            // 
            // TicketAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "TicketAdd";
            this.Size = new System.Drawing.Size(1210, 762);
            this.Load += new System.EventHandler(this.TicketAdd_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private Bunifu.UI.WinForms.BunifuDatePicker datepicker1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private Guna.UI2.WinForms.Guna2ImageButton btnAddTicket;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
