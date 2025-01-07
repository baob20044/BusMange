namespace GarageManagementSystem.FormUser.Pages
{
    partial class TicketHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketHistory));
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.DateTimePicker = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel.Location = new System.Drawing.Point(74, 129);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1092, 550);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 50);
            this.label2.TabIndex = 7;
            this.label2.Text = "Vé đã mua";
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.BackColor = System.Drawing.Color.Transparent;
            this.DateTimePicker.BorderRadius = 1;
            this.DateTimePicker.Color = System.Drawing.Color.Silver;
            this.DateTimePicker.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.DateTimePicker.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.DateTimePicker.DisabledColor = System.Drawing.Color.Gray;
            this.DateTimePicker.DisplayWeekNumbers = false;
            this.DateTimePicker.DPHeight = 0;
            this.DateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DateTimePicker.FillDatePicker = false;
            this.DateTimePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DateTimePicker.ForeColor = System.Drawing.Color.Black;
            this.DateTimePicker.Icon = ((System.Drawing.Image)(resources.GetObject("DateTimePicker.Icon")));
            this.DateTimePicker.IconColor = System.Drawing.Color.Gray;
            this.DateTimePicker.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.DateTimePicker.LeftTextMargin = 5;
            this.DateTimePicker.Location = new System.Drawing.Point(286, 71);
            this.DateTimePicker.MinimumSize = new System.Drawing.Size(4, 32);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(268, 32);
            this.DateTimePicker.TabIndex = 9;
            this.DateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // TicketHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.DateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "TicketHistory";
            this.Size = new System.Drawing.Size(1241, 755);
            this.Load += new System.EventHandler(this.TicketHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuDatePicker DateTimePicker;
    }
}
