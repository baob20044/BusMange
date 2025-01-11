namespace GarageManagementSystem.Component.Admin.AdminTicket
{
    partial class BusAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusAdd));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.txtBusNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numbericNumber = new System.Windows.Forms.NumericUpDown();
            this.cbBusType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numbericNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 5;
            this.guna2Panel1.Controls.Add(this.numbericNumber);
            this.guna2Panel1.Controls.Add(this.cbBusType);
            this.guna2Panel1.Controls.Add(this.txtBusNumber);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.btnAdd);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(789, 293);
            this.guna2Panel1.TabIndex = 4;
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
            this.btnAdd.Location = new System.Drawing.Point(578, 217);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShadowDecoration.Parent = this.btnAdd;
            this.btnAdd.Size = new System.Drawing.Size(117, 36);
            this.btnAdd.TabIndex = 104;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(64, 53);
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
            this.label2.Location = new System.Drawing.Point(419, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 102;
            this.label2.Text = "Loại xe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 93;
            this.label1.Text = "Biển số xe";
            // 
            // btnClose
            // 
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(708, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedState.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(38, 23);
            this.btnClose.TabIndex = 89;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtBusNumber
            // 
            this.txtBusNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBusNumber.DefaultText = "";
            this.txtBusNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBusNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBusNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBusNumber.DisabledState.Parent = this.txtBusNumber;
            this.txtBusNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBusNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBusNumber.FocusedState.Parent = this.txtBusNumber;
            this.txtBusNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBusNumber.HoverState.Parent = this.txtBusNumber;
            this.txtBusNumber.Location = new System.Drawing.Point(423, 86);
            this.txtBusNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBusNumber.Name = "txtBusNumber";
            this.txtBusNumber.PasswordChar = '\0';
            this.txtBusNumber.PlaceholderText = "";
            this.txtBusNumber.SelectedText = "";
            this.txtBusNumber.ShadowDecoration.Parent = this.txtBusNumber;
            this.txtBusNumber.Size = new System.Drawing.Size(272, 35);
            this.txtBusNumber.TabIndex = 112;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(419, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 23);
            this.label3.TabIndex = 111;
            this.label3.Text = "Số ghế ngồi";
            // 
            // numbericNumber
            // 
            this.numbericNumber.Enabled = false;
            this.numbericNumber.Location = new System.Drawing.Point(423, 230);
            this.numbericNumber.Name = "numbericNumber";
            this.numbericNumber.Size = new System.Drawing.Size(66, 22);
            this.numbericNumber.TabIndex = 115;
            this.numbericNumber.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // cbBusType
            // 
            this.cbBusType.Animated = true;
            this.cbBusType.BackColor = System.Drawing.Color.Transparent;
            this.cbBusType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbBusType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBusType.DropDownHeight = 175;
            this.cbBusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBusType.FocusedColor = System.Drawing.Color.Empty;
            this.cbBusType.FocusedState.Parent = this.cbBusType;
            this.cbBusType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbBusType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbBusType.FormattingEnabled = true;
            this.cbBusType.HoverState.Parent = this.cbBusType;
            this.cbBusType.IntegralHeight = false;
            this.cbBusType.ItemHeight = 35;
            this.cbBusType.Items.AddRange(new object[] {
            "Ghế",
            "Giường",
            "Limousine"});
            this.cbBusType.ItemsAppearance.Parent = this.cbBusType;
            this.cbBusType.Location = new System.Drawing.Point(423, 151);
            this.cbBusType.MaxDropDownItems = 1;
            this.cbBusType.Name = "cbBusType";
            this.cbBusType.ShadowDecoration.Parent = this.cbBusType;
            this.cbBusType.Size = new System.Drawing.Size(272, 41);
            this.cbBusType.TabIndex = 114;
            this.cbBusType.SelectedIndexChanged += new System.EventHandler(this.cbBusType_SelectedIndexChanged);
            // 
            // BusAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "BusAdd";
            this.Size = new System.Drawing.Size(789, 294);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numbericNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private Guna.UI2.WinForms.Guna2TextBox txtBusNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numbericNumber;
        private Guna.UI2.WinForms.Guna2ComboBox cbBusType;
    }
}
