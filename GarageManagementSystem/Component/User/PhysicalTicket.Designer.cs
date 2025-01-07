namespace GarageManagementSystem.Component
{
    partial class PhysicalTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhysicalTicket));
            this.pBQrCode = new System.Windows.Forms.PictureBox();
            this.lbTicketId = new System.Windows.Forms.Label();
            this.pbDownload = new System.Windows.Forms.PictureBox();
            this.lbFromToStop = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lbDepartTimeStop = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lbSeatNumber = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lbFromStop = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbTotalFare = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbTimeError = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbShare = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBQrCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDownload)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTimeError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShare)).BeginInit();
            this.SuspendLayout();
            // 
            // pBQrCode
            // 
            this.pBQrCode.Location = new System.Drawing.Point(52, 41);
            this.pBQrCode.Name = "pBQrCode";
            this.pBQrCode.Size = new System.Drawing.Size(202, 190);
            this.pBQrCode.TabIndex = 0;
            this.pBQrCode.TabStop = false;
            // 
            // lbTicketId
            // 
            this.lbTicketId.AutoSize = true;
            this.lbTicketId.BackColor = System.Drawing.Color.Transparent;
            this.lbTicketId.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTicketId.Location = new System.Drawing.Point(111, 9);
            this.lbTicketId.Name = "lbTicketId";
            this.lbTicketId.Size = new System.Drawing.Size(88, 23);
            this.lbTicketId.TabIndex = 16;
            this.lbTicketId.Text = "Mã vé 001";
            // 
            // pbDownload
            // 
            this.pbDownload.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDownload.Image = ((System.Drawing.Image)(resources.GetObject("pbDownload.Image")));
            this.pbDownload.Location = new System.Drawing.Point(12, 8);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(30, 30);
            this.pbDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDownload.TabIndex = 17;
            this.pbDownload.TabStop = false;
            this.pbDownload.Click += new System.EventHandler(this.pbDownload_Click);
            // 
            // lbFromToStop
            // 
            this.lbFromToStop.AutoSize = true;
            this.lbFromToStop.BackColor = System.Drawing.Color.Transparent;
            this.lbFromToStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFromToStop.ForeColor = System.Drawing.Color.Black;
            this.lbFromToStop.Location = new System.Drawing.Point(87, 242);
            this.lbFromToStop.MaximumSize = new System.Drawing.Size(220, 0);
            this.lbFromToStop.Name = "lbFromToStop";
            this.lbFromToStop.Size = new System.Drawing.Size(75, 20);
            this.lbFromToStop.TabIndex = 40;
            this.lbFromToStop.Text = "From - To";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label21.Location = new System.Drawing.Point(8, 242);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 20);
            this.label21.TabIndex = 39;
            this.label21.Text = "Tuyến xe";
            // 
            // lbDepartTimeStop
            // 
            this.lbDepartTimeStop.AutoSize = true;
            this.lbDepartTimeStop.BackColor = System.Drawing.Color.Transparent;
            this.lbDepartTimeStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDepartTimeStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(61)))));
            this.lbDepartTimeStop.Location = new System.Drawing.Point(87, 285);
            this.lbDepartTimeStop.Name = "lbDepartTimeStop";
            this.lbDepartTimeStop.Size = new System.Drawing.Size(167, 20);
            this.lbDepartTimeStop.TabIndex = 45;
            this.lbDepartTimeStop.Text = "HH/MM MM/DD/YYYY";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label25.Location = new System.Drawing.Point(8, 285);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(73, 20);
            this.label25.TabIndex = 44;
            this.label25.Text = "Thời gian";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label23.Location = new System.Drawing.Point(8, 315);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 20);
            this.label23.TabIndex = 46;
            this.label23.Text = "Số ghế";
            // 
            // lbSeatNumber
            // 
            this.lbSeatNumber.AutoSize = true;
            this.lbSeatNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbSeatNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeatNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(61)))));
            this.lbSeatNumber.Location = new System.Drawing.Point(87, 315);
            this.lbSeatNumber.Name = "lbSeatNumber";
            this.lbSeatNumber.Size = new System.Drawing.Size(16, 20);
            this.lbSeatNumber.TabIndex = 47;
            this.lbSeatNumber.Text = "?";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label26.Location = new System.Drawing.Point(8, 345);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 20);
            this.label26.TabIndex = 48;
            this.label26.Text = "Điểm xe";
            // 
            // lbFromStop
            // 
            this.lbFromStop.AutoSize = true;
            this.lbFromStop.BackColor = System.Drawing.Color.Transparent;
            this.lbFromStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFromStop.ForeColor = System.Drawing.Color.Black;
            this.lbFromStop.Location = new System.Drawing.Point(87, 345);
            this.lbFromStop.Name = "lbFromStop";
            this.lbFromStop.Size = new System.Drawing.Size(24, 20);
            this.lbFromStop.TabIndex = 49;
            this.lbFromStop.Text = "At";
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.BackColor = System.Drawing.Color.Transparent;
            this.lbAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lbAddress.Location = new System.Drawing.Point(8, 373);
            this.lbAddress.MaximumSize = new System.Drawing.Size(280, 0);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(63, 20);
            this.lbAddress.TabIndex = 50;
            this.lbAddress.Text = "Address";
            // 
            // lbTotalFare
            // 
            this.lbTotalFare.AutoSize = true;
            this.lbTotalFare.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalFare.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalFare.ForeColor = System.Drawing.Color.Black;
            this.lbTotalFare.Location = new System.Drawing.Point(87, 440);
            this.lbTotalFare.Name = "lbTotalFare";
            this.lbTotalFare.Size = new System.Drawing.Size(43, 20);
            this.lbTotalFare.TabIndex = 52;
            this.lbTotalFare.Text = "Price";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label28.Location = new System.Drawing.Point(8, 440);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(51, 20);
            this.label28.TabIndex = 51;
            this.label28.Text = "Giá vé";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Location = new System.Drawing.Point(4, 497);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(300, 45);
            this.guna2Panel1.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(61)))));
            this.label2.Location = new System.Drawing.Point(8, 2);
            this.label2.MaximumSize = new System.Drawing.Size(300, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 40);
            this.label2.TabIndex = 54;
            this.label2.Text = "Mang mã vé đến văn phòng để đổi vé lên xe trước giờ xuất bến ít nhất 60 phút";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel2.BorderThickness = 3;
            this.guna2Panel2.Controls.Add(this.pbTimeError);
            this.guna2Panel2.Controls.Add(this.lbFromToStop);
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(310, 545);
            this.guna2Panel2.TabIndex = 54;
            // 
            // pbTimeError
            // 
            this.pbTimeError.Image = ((System.Drawing.Image)(resources.GetObject("pbTimeError.Image")));
            this.pbTimeError.Location = new System.Drawing.Point(81, 5);
            this.pbTimeError.Name = "pbTimeError";
            this.pbTimeError.ShadowDecoration.Parent = this.pbTimeError;
            this.pbTimeError.Size = new System.Drawing.Size(30, 30);
            this.pbTimeError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTimeError.TabIndex = 41;
            this.pbTimeError.TabStop = false;
            this.pbTimeError.Visible = false;
            // 
            // pbShare
            // 
            this.pbShare.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbShare.Image = ((System.Drawing.Image)(resources.GetObject("pbShare.Image")));
            this.pbShare.Location = new System.Drawing.Point(267, 9);
            this.pbShare.Name = "pbShare";
            this.pbShare.Size = new System.Drawing.Size(30, 30);
            this.pbShare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShare.TabIndex = 18;
            this.pbShare.TabStop = false;
            // 
            // PhysicalTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lbTotalFare);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.lbFromStop);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lbSeatNumber);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.lbDepartTimeStop);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.pbShare);
            this.Controls.Add(this.pbDownload);
            this.Controls.Add(this.lbTicketId);
            this.Controls.Add(this.pBQrCode);
            this.Controls.Add(this.guna2Panel2);
            this.Name = "PhysicalTicket";
            this.Size = new System.Drawing.Size(340, 576);
            this.Load += new System.EventHandler(this.PhysicalTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBQrCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDownload)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTimeError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBQrCode;
        private System.Windows.Forms.Label lbTicketId;
        private System.Windows.Forms.PictureBox pbDownload;
        private System.Windows.Forms.Label lbFromToStop;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lbDepartTimeStop;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lbSeatNumber;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lbFromStop;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbTotalFare;
        private System.Windows.Forms.Label label28;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2PictureBox pbTimeError;
        private System.Windows.Forms.PictureBox pbShare;
    }
}
