namespace GarageManagementSystem.Component.Admin.AdminSchedule
{
    partial class ScheduleStopEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleStopEdit));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnEditScheduleStop = new Guna.UI2.WinForms.Guna2Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStopName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 5;
            this.guna2Panel1.Controls.Add(this.btnEditScheduleStop);
            this.guna2Panel1.Controls.Add(this.dateTimePicker1);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.cbStopName);
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(856, 308);
            this.guna2Panel1.TabIndex = 4;
            // 
            // btnEditScheduleStop
            // 
            this.btnEditScheduleStop.BackColor = System.Drawing.Color.Transparent;
            this.btnEditScheduleStop.CheckedState.Parent = this.btnEditScheduleStop;
            this.btnEditScheduleStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditScheduleStop.CustomImages.Parent = this.btnEditScheduleStop;
            this.btnEditScheduleStop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditScheduleStop.ForeColor = System.Drawing.Color.White;
            this.btnEditScheduleStop.HoverState.Parent = this.btnEditScheduleStop;
            this.btnEditScheduleStop.Location = new System.Drawing.Point(637, 210);
            this.btnEditScheduleStop.Name = "btnEditScheduleStop";
            this.btnEditScheduleStop.ShadowDecoration.Parent = this.btnEditScheduleStop;
            this.btnEditScheduleStop.Size = new System.Drawing.Size(117, 36);
            this.btnEditScheduleStop.TabIndex = 104;
            this.btnEditScheduleStop.Text = "Chỉnh sửa";
            this.btnEditScheduleStop.Click += new System.EventHandler(this.btnEditScheduleStop_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(447, 161);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(307, 34);
            this.dateTimePicker1.TabIndex = 103;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(63, 46);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(300, 200);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 4;
            this.guna2PictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(443, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 102;
            this.label2.Text = "Giờ đến";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(443, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 93;
            this.label1.Text = "Trạm dừng";
            // 
            // cbStopName
            // 
            this.cbStopName.BackColor = System.Drawing.Color.Transparent;
            this.cbStopName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStopName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopName.Enabled = false;
            this.cbStopName.FocusedColor = System.Drawing.Color.Empty;
            this.cbStopName.FocusedState.Parent = this.cbStopName;
            this.cbStopName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbStopName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbStopName.FormattingEnabled = true;
            this.cbStopName.HoverState.Parent = this.cbStopName;
            this.cbStopName.ItemHeight = 30;
            this.cbStopName.ItemsAppearance.Parent = this.cbStopName;
            this.cbStopName.Location = new System.Drawing.Point(447, 89);
            this.cbStopName.Name = "cbStopName";
            this.cbStopName.ShadowDecoration.Parent = this.cbStopName;
            this.cbStopName.Size = new System.Drawing.Size(307, 36);
            this.cbStopName.TabIndex = 92;
            // 
            // btnClose
            // 
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(803, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedState.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(38, 23);
            this.btnClose.TabIndex = 89;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ScheduleStopEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ScheduleStopEdit";
            this.Size = new System.Drawing.Size(856, 309);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnEditScheduleStop;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbStopName;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
    }
}
