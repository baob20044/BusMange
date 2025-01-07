namespace GarageManagementSystem.FormUser.Pages
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cBTo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBFrom = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFindBus = new Guna.UI2.WinForms.Guna2Button();
            this.rbTwoway = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rBOneway = new Guna.UI2.WinForms.Guna2RadioButton();
            this.datepickerReturn = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.datepickerDepart = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(151)))), ((int)(((byte)(122)))));
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 5;
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.flowLayoutPanel);
            this.guna2Panel1.Controls.Add(this.datepickerReturn);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.datepickerDepart);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.cBTo);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.cBFrom);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.btnFindBus);
            this.guna2Panel1.Controls.Add(this.rbTwoway);
            this.guna2Panel1.Controls.Add(this.rBOneway);
            this.guna2Panel1.Location = new System.Drawing.Point(84, 303);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1072, 393);
            this.guna2Panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(749, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tìm kiếm gần đây";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flowLayoutPanel.Location = new System.Drawing.Point(736, 109);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(279, 148);
            this.flowLayoutPanel.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(380, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ngày về";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(383, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày đi";
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
            this.cBTo.Location = new System.Drawing.Point(68, 209);
            this.cBTo.MaxDropDownItems = 1;
            this.cBTo.Name = "cBTo";
            this.cBTo.ShadowDecoration.Parent = this.cBTo;
            this.cBTo.Size = new System.Drawing.Size(223, 41);
            this.cBTo.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 6;
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
            this.cBFrom.Location = new System.Drawing.Point(65, 109);
            this.cBFrom.MaxDropDownItems = 1;
            this.cBFrom.Name = "cBFrom";
            this.cBFrom.ShadowDecoration.Parent = this.cBFrom;
            this.cBFrom.Size = new System.Drawing.Size(223, 41);
            this.cBFrom.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Điểm đi";
            // 
            // btnFindBus
            // 
            this.btnFindBus.BorderRadius = 20;
            this.btnFindBus.CheckedState.Parent = this.btnFindBus;
            this.btnFindBus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindBus.CustomImages.Parent = this.btnFindBus;
            this.btnFindBus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(82)))), ((int)(((byte)(34)))));
            this.btnFindBus.Font = new System.Drawing.Font("Segoe UI", 11.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindBus.ForeColor = System.Drawing.Color.White;
            this.btnFindBus.HoverState.Parent = this.btnFindBus;
            this.btnFindBus.Location = new System.Drawing.Point(431, 308);
            this.btnFindBus.Name = "btnFindBus";
            this.btnFindBus.ShadowDecoration.Parent = this.btnFindBus;
            this.btnFindBus.Size = new System.Drawing.Size(210, 54);
            this.btnFindBus.TabIndex = 2;
            this.btnFindBus.Text = "Tìm chuyến xe";
            this.btnFindBus.Click += new System.EventHandler(this.btnFindBus_Click);
            // 
            // rbTwoway
            // 
            this.rbTwoway.AutoSize = true;
            this.rbTwoway.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(82)))), ((int)(((byte)(63)))));
            this.rbTwoway.CheckedState.BorderThickness = 0;
            this.rbTwoway.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(82)))), ((int)(((byte)(63)))));
            this.rbTwoway.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(82)))), ((int)(((byte)(63)))));
            this.rbTwoway.CheckedState.InnerOffset = -4;
            this.rbTwoway.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbTwoway.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTwoway.Location = new System.Drawing.Point(157, 20);
            this.rbTwoway.Name = "rbTwoway";
            this.rbTwoway.Size = new System.Drawing.Size(104, 32);
            this.rbTwoway.TabIndex = 1;
            this.rbTwoway.Text = "Khứ hồi";
            this.rbTwoway.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbTwoway.UncheckedState.BorderThickness = 2;
            this.rbTwoway.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbTwoway.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbTwoway.UseVisualStyleBackColor = true;
            this.rbTwoway.CheckedChanged += new System.EventHandler(this.rbTwoway_CheckedChanged);
            // 
            // rBOneway
            // 
            this.rBOneway.AutoSize = true;
            this.rBOneway.Checked = true;
            this.rBOneway.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(82)))), ((int)(((byte)(63)))));
            this.rBOneway.CheckedState.BorderThickness = 0;
            this.rBOneway.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(82)))), ((int)(((byte)(63)))));
            this.rBOneway.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(82)))), ((int)(((byte)(63)))));
            this.rBOneway.CheckedState.InnerOffset = -4;
            this.rBOneway.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rBOneway.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBOneway.Location = new System.Drawing.Point(23, 20);
            this.rBOneway.Name = "rBOneway";
            this.rBOneway.Size = new System.Drawing.Size(125, 32);
            this.rBOneway.TabIndex = 0;
            this.rBOneway.TabStop = true;
            this.rBOneway.Text = "Một chiều";
            this.rBOneway.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rBOneway.UncheckedState.BorderThickness = 2;
            this.rBOneway.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rBOneway.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rBOneway.UseVisualStyleBackColor = true;
            this.rBOneway.CheckedChanged += new System.EventHandler(this.rbTwoway_CheckedChanged);
            // 
            // datepickerReturn
            // 
            this.datepickerReturn.BackColor = System.Drawing.Color.White;
            this.datepickerReturn.BorderRadius = 1;
            this.datepickerReturn.Checked = false;
            this.datepickerReturn.Color = System.Drawing.Color.White;
            this.datepickerReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.datepickerReturn.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.datepickerReturn.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.datepickerReturn.DisabledColor = System.Drawing.Color.Gray;
            this.datepickerReturn.DisplayWeekNumbers = false;
            this.datepickerReturn.DPHeight = 0;
            this.datepickerReturn.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.datepickerReturn.Enabled = false;
            this.datepickerReturn.FillDatePicker = true;
            this.datepickerReturn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.datepickerReturn.ForeColor = System.Drawing.Color.Black;
            this.datepickerReturn.Icon = ((System.Drawing.Image)(resources.GetObject("datepickerReturn.Icon")));
            this.datepickerReturn.IconColor = System.Drawing.SystemColors.Control;
            this.datepickerReturn.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.datepickerReturn.LeftTextMargin = 5;
            this.datepickerReturn.Location = new System.Drawing.Point(376, 213);
            this.datepickerReturn.MinimumSize = new System.Drawing.Size(4, 32);
            this.datepickerReturn.Name = "datepickerReturn";
            this.datepickerReturn.Size = new System.Drawing.Size(296, 34);
            this.datepickerReturn.TabIndex = 11;
            // 
            // datepickerDepart
            // 
            this.datepickerDepart.BackColor = System.Drawing.Color.White;
            this.datepickerDepart.BorderRadius = 1;
            this.datepickerDepart.Checked = false;
            this.datepickerDepart.Color = System.Drawing.Color.White;
            this.datepickerDepart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.datepickerDepart.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.datepickerDepart.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.datepickerDepart.DisabledColor = System.Drawing.Color.Gray;
            this.datepickerDepart.DisplayWeekNumbers = false;
            this.datepickerDepart.DPHeight = 0;
            this.datepickerDepart.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.datepickerDepart.FillDatePicker = true;
            this.datepickerDepart.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.datepickerDepart.ForeColor = System.Drawing.Color.Black;
            this.datepickerDepart.Icon = ((System.Drawing.Image)(resources.GetObject("datepickerDepart.Icon")));
            this.datepickerDepart.IconColor = System.Drawing.SystemColors.Control;
            this.datepickerDepart.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.datepickerDepart.LeftTextMargin = 5;
            this.datepickerDepart.Location = new System.Drawing.Point(376, 113);
            this.datepickerDepart.MinimumSize = new System.Drawing.Size(4, 32);
            this.datepickerDepart.Name = "datepickerDepart";
            this.datepickerDepart.Size = new System.Drawing.Size(296, 34);
            this.datepickerDepart.TabIndex = 9;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderRadius = 20;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(84, 29);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(1072, 245);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2PictureBox1);
            this.Name = "HomePage";
            this.Size = new System.Drawing.Size(1241, 755);
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2RadioButton rbTwoway;
        private Guna.UI2.WinForms.Guna2RadioButton rBOneway;
        private Guna.UI2.WinForms.Guna2Button btnFindBus;
        private Guna.UI2.WinForms.Guna2ComboBox cBFrom;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cBTo;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuDatePicker datepickerDepart;
        private System.Windows.Forms.Label label3;
        private Bunifu.UI.WinForms.BunifuDatePicker datepickerReturn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label label5;
    }
}
