namespace GarageManagementSystem.Component.Admin.AdminSchedule
{
    partial class RouteNameAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteNameAdd));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.cBTo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBFrom = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDistance = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEstimatedTime = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimatedTime)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 5;
            this.guna2Panel1.Controls.Add(this.label6);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.txtEstimatedTime);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.txtDistance);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.cBTo);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.cBFrom);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.btnAdd);
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(856, 308);
            this.guna2Panel1.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.CheckedState.Parent = this.btnAdd;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.CustomImages.Parent = this.btnAdd;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverState.Parent = this.btnAdd;
            this.btnAdd.Location = new System.Drawing.Point(709, 257);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShadowDecoration.Parent = this.btnAdd;
            this.btnAdd.Size = new System.Drawing.Size(117, 36);
            this.btnAdd.TabIndex = 104;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            // cBTo
            // 
            this.cBTo.Animated = true;
            this.cBTo.BackColor = System.Drawing.Color.Transparent;
            this.cBTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cBTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cBTo.DropDownHeight = 175;
            this.cBTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBTo.FocusedColor = System.Drawing.Color.Empty;
            this.cBTo.FocusedState.Parent = this.cBTo;
            this.cBTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cBTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cBTo.FormattingEnabled = true;
            this.cBTo.HoverState.Parent = this.cBTo;
            this.cBTo.IntegralHeight = false;
            this.cBTo.ItemHeight = 35;
            this.cBTo.Items.AddRange(new object[] {
            "Hà Nội",
            "Hải Phòng",
            "Quảng Ninh",
            "Hải Dương",
            "Hưng Yên",
            "Bắc Ninh",
            "Hà Nam",
            "Nam Định",
            "Thái Bình",
            "Vĩnh Phúc",
            "Phú Thọ",
            "Bắc Giang",
            "Bắc Kạn",
            "Thái Nguyên",
            "Lạng Sơn",
            "Tuyên Quang",
            "Hà Giang",
            "Cao Bằng",
            "Lào Cai",
            "Yên Bái",
            "Điện Biên",
            "Lai Châu",
            "Sơn La",
            "Hòa Bình",
            "Ninh Bình",
            "Thanh Hóa",
            "Nghệ An",
            "Hà Tĩnh",
            "Đà Nẵng",
            "Quảng Nam",
            "Quảng Ngãi",
            "Bình Định",
            "Phú Yên",
            "Khánh Hòa",
            "Ninh Thuận",
            "Bình Thuận",
            "Thừa Thiên Huế",
            "Quảng Trị",
            "Quảng Bình",
            "Kon Tum",
            "Gia Lai",
            "Đắk Lắk",
            "Đắk Nông",
            "Lâm Đồng",
            "TP. Hồ Chí Minh",
            "Đồng Nai",
            "Bình Dương",
            "Tây Ninh",
            "Bình Phước",
            "Bà Rịa - Vũng Tàu",
            "Long An",
            "Tiền Giang",
            "Bến Tre",
            "Trà Vinh",
            "Vĩnh Long",
            "Đồng Tháp",
            "An Giang",
            "Kiên Giang",
            "Cần Thơ",
            "Hậu Giang",
            "Sóc Trăng",
            "Bạc Liêu",
            "Cà Mau"});
            this.cBTo.ItemsAppearance.Parent = this.cBTo;
            this.cBTo.Location = new System.Drawing.Point(79, 162);
            this.cBTo.MaxDropDownItems = 1;
            this.cBTo.Name = "cBTo";
            this.cBTo.ShadowDecoration.Parent = this.cBTo;
            this.cBTo.Size = new System.Drawing.Size(223, 41);
            this.cBTo.TabIndex = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 107;
            this.label1.Text = "Điểm đến";
            // 
            // cBFrom
            // 
            this.cBFrom.Animated = true;
            this.cBFrom.BackColor = System.Drawing.Color.Transparent;
            this.cBFrom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cBFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cBFrom.DropDownHeight = 175;
            this.cBFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBFrom.FocusedColor = System.Drawing.Color.Empty;
            this.cBFrom.FocusedState.Parent = this.cBFrom;
            this.cBFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cBFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cBFrom.FormattingEnabled = true;
            this.cBFrom.HoverState.Parent = this.cBFrom;
            this.cBFrom.IntegralHeight = false;
            this.cBFrom.ItemHeight = 35;
            this.cBFrom.Items.AddRange(new object[] {
            "Hà Nội",
            "Hải Phòng",
            "Quảng Ninh",
            "Hải Dương",
            "Hưng Yên",
            "Bắc Ninh",
            "Hà Nam",
            "Nam Định",
            "Thái Bình",
            "Vĩnh Phúc",
            "Phú Thọ",
            "Bắc Giang",
            "Bắc Kạn",
            "Thái Nguyên",
            "Lạng Sơn",
            "Tuyên Quang",
            "Hà Giang",
            "Cao Bằng",
            "Lào Cai",
            "Yên Bái",
            "Điện Biên",
            "Lai Châu",
            "Sơn La",
            "Hòa Bình",
            "Ninh Bình",
            "Thanh Hóa",
            "Nghệ An",
            "Hà Tĩnh",
            "Đà Nẵng",
            "Quảng Nam",
            "Quảng Ngãi",
            "Bình Định",
            "Phú Yên",
            "Khánh Hòa",
            "Ninh Thuận",
            "Bình Thuận",
            "Thừa Thiên Huế",
            "Quảng Trị",
            "Quảng Bình",
            "Kon Tum",
            "Gia Lai",
            "Đắk Lắk",
            "Đắk Nông",
            "Lâm Đồng",
            "TP. Hồ Chí Minh",
            "Đồng Nai",
            "Bình Dương",
            "Tây Ninh",
            "Bình Phước",
            "Bà Rịa - Vũng Tàu",
            "Long An",
            "Tiền Giang",
            "Bến Tre",
            "Trà Vinh",
            "Vĩnh Long",
            "Đồng Tháp",
            "An Giang",
            "Kiên Giang",
            "Cần Thơ",
            "Hậu Giang",
            "Sóc Trăng",
            "Bạc Liêu",
            "Cà Mau"});
            this.cBFrom.ItemsAppearance.Parent = this.cBFrom;
            this.cBFrom.Location = new System.Drawing.Point(76, 62);
            this.cBFrom.MaxDropDownItems = 1;
            this.cBFrom.Name = "cBFrom";
            this.cBFrom.ShadowDecoration.Parent = this.cBFrom;
            this.cBFrom.Size = new System.Drawing.Size(223, 41);
            this.cBFrom.TabIndex = 106;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 105;
            this.label2.Text = "Điểm đi";
            // 
            // txtDistance
            // 
            this.txtDistance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDistance.DefaultText = "";
            this.txtDistance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDistance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDistance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDistance.DisabledState.Parent = this.txtDistance;
            this.txtDistance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDistance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDistance.FocusedState.Parent = this.txtDistance;
            this.txtDistance.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDistance.HoverState.Parent = this.txtDistance;
            this.txtDistance.Location = new System.Drawing.Point(413, 62);
            this.txtDistance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.PasswordChar = '\0';
            this.txtDistance.PlaceholderText = "";
            this.txtDistance.SelectedText = "";
            this.txtDistance.ShadowDecoration.Parent = this.txtDistance;
            this.txtDistance.Size = new System.Drawing.Size(236, 35);
            this.txtDistance.TabIndex = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(409, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 23);
            this.label3.TabIndex = 109;
            this.label3.Text = "Khoảng cách";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(409, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 23);
            this.label4.TabIndex = 111;
            this.label4.Text = "Ước tính thời gian";
            // 
            // txtEstimatedTime
            // 
            this.txtEstimatedTime.Location = new System.Drawing.Point(413, 168);
            this.txtEstimatedTime.Name = "txtEstimatedTime";
            this.txtEstimatedTime.Size = new System.Drawing.Size(44, 22);
            this.txtEstimatedTime.TabIndex = 113;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(463, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 23);
            this.label5.TabIndex = 114;
            this.label5.Text = "giờ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(656, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 23);
            this.label6.TabIndex = 115;
            this.label6.Text = "km";
            // 
            // RouteNameAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "RouteNameAdd";
            this.Size = new System.Drawing.Size(858, 310);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimatedTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private Guna.UI2.WinForms.Guna2ComboBox cBTo;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cBFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtDistance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtEstimatedTime;
        private System.Windows.Forms.Label label6;
    }
}
