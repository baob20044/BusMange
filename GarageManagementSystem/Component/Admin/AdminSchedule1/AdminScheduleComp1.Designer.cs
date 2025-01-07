namespace GarageManagementSystem.Component.Admin
{
    partial class AdminScheduleComp1
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
            this.lbScheduleId = new System.Windows.Forms.Label();
            this.lbRouteName = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lbScheduleId
            // 
            this.lbScheduleId.AutoSize = true;
            this.lbScheduleId.BackColor = System.Drawing.Color.Transparent;
            this.lbScheduleId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScheduleId.Location = new System.Drawing.Point(9, 10);
            this.lbScheduleId.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbScheduleId.Name = "lbScheduleId";
            this.lbScheduleId.Size = new System.Drawing.Size(94, 23);
            this.lbScheduleId.TabIndex = 8;
            this.lbScheduleId.Text = "ScheduleId";
            // 
            // lbRouteName
            // 
            this.lbRouteName.AutoSize = true;
            this.lbRouteName.BackColor = System.Drawing.Color.Transparent;
            this.lbRouteName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRouteName.Location = new System.Drawing.Point(117, 10);
            this.lbRouteName.MaximumSize = new System.Drawing.Size(620, 0);
            this.lbRouteName.Name = "lbRouteName";
            this.lbRouteName.Size = new System.Drawing.Size(106, 23);
            this.lbRouteName.TabIndex = 9;
            this.lbRouteName.Text = "Route Name";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.BackColor = System.Drawing.Color.Transparent;
            this.lbDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(755, 10);
            this.lbDate.MaximumSize = new System.Drawing.Size(360, 0);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(46, 23);
            this.lbDate.TabIndex = 10;
            this.lbDate.Text = "Date";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(-1, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 2);
            this.panel1.TabIndex = 52;
            // 
            // AdminScheduleComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbRouteName);
            this.Controls.Add(this.lbScheduleId);
            this.Name = "AdminScheduleComp";
            this.Size = new System.Drawing.Size(1130, 49);
            this.Load += new System.EventHandler(this.ScheduleComp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbScheduleId;
        private System.Windows.Forms.Label lbRouteName;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Panel panel1;
    }
}
