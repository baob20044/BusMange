namespace GarageManagementSystem.Component
{
    partial class ScheduleComp
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
            this.lbFromTo = new System.Windows.Forms.Label();
            this.lbDepartTime = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFromTo
            // 
            this.lbFromTo.AutoSize = true;
            this.lbFromTo.BackColor = System.Drawing.Color.Transparent;
            this.lbFromTo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFromTo.Location = new System.Drawing.Point(34, 41);
            this.lbFromTo.Name = "lbFromTo";
            this.lbFromTo.Size = new System.Drawing.Size(168, 46);
            this.lbFromTo.TabIndex = 7;
            this.lbFromTo.Text = "From - To";
            // 
            // lbDepartTime
            // 
            this.lbDepartTime.AutoSize = true;
            this.lbDepartTime.BackColor = System.Drawing.Color.Transparent;
            this.lbDepartTime.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDepartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(61)))));
            this.lbDepartTime.Location = new System.Drawing.Point(717, 41);
            this.lbDepartTime.Name = "lbDepartTime";
            this.lbDepartTime.Size = new System.Drawing.Size(373, 46);
            this.lbDepartTime.TabIndex = 8;
            this.lbDepartTime.Text = "HH/MM MM/DD/YYYY";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 5;
            this.guna2Panel1.Controls.Add(this.lbDepartTime);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1113, 138);
            this.guna2Panel1.TabIndex = 9;
            // 
            // ScheduleComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbFromTo);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ScheduleComp";
            this.Size = new System.Drawing.Size(1113, 138);
            this.Load += new System.EventHandler(this.ScheduleComp_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFromTo;
        private System.Windows.Forms.Label lbDepartTime;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
