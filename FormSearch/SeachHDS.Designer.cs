namespace QL_XuatKhauGao
{
    partial class SeachHDS
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.showSearchPanel = new Sunny.UI.UIPanel();
            this.uiSymbolButton3 = new Sunny.UI.UISymbolButton();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.uiSymbolButton3);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.RectColor = System.Drawing.Color.Empty;
            this.uiPanel1.Size = new System.Drawing.Size(238, 568);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // showSearchPanel
            // 
            this.showSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showSearchPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.showSearchPanel.Location = new System.Drawing.Point(238, 0);
            this.showSearchPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showSearchPanel.MinimumSize = new System.Drawing.Size(1, 1);
            this.showSearchPanel.Name = "showSearchPanel";
            this.showSearchPanel.RectColor = System.Drawing.Color.Gray;
            this.showSearchPanel.Size = new System.Drawing.Size(841, 568);
            this.showSearchPanel.Style = Sunny.UI.UIStyle.Custom;
            this.showSearchPanel.TabIndex = 1;
            this.showSearchPanel.Text = null;
            this.showSearchPanel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiSymbolButton3
            // 
            this.uiSymbolButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiSymbolButton3.FillColor = System.Drawing.Color.White;
            this.uiSymbolButton3.FillColor2 = System.Drawing.Color.Gray;
            this.uiSymbolButton3.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiSymbolButton3.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiSymbolButton3.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiSymbolButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uiSymbolButton3.ForeColor = System.Drawing.Color.Black;
            this.uiSymbolButton3.ForeHoverColor = System.Drawing.Color.Black;
            this.uiSymbolButton3.ForePressColor = System.Drawing.Color.Gray;
            this.uiSymbolButton3.ForeSelectedColor = System.Drawing.Color.Gray;
            this.uiSymbolButton3.Image = global::QL_XuatKhauGao.Properties.Resources.bill_invoice_icon_179550;
            this.uiSymbolButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton3.Location = new System.Drawing.Point(0, 0);
            this.uiSymbolButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton3.Name = "uiSymbolButton3";
            this.uiSymbolButton3.Padding = new System.Windows.Forms.Padding(10, 0, 8, 0);
            this.uiSymbolButton3.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiSymbolButton3.RectSelectedColor = System.Drawing.Color.Gray;
            this.uiSymbolButton3.Size = new System.Drawing.Size(238, 67);
            this.uiSymbolButton3.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton3.StyleCustomMode = true;
            this.uiSymbolButton3.TabIndex = 9;
            this.uiSymbolButton3.Text = "Đơn Hàng";
            this.uiSymbolButton3.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiSymbolButton3.Click += new System.EventHandler(this.uiSymbolButton3_Click);
            // 
            // SeachHDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 568);
            this.Controls.Add(this.showSearchPanel);
            this.Controls.Add(this.uiPanel1);
            this.Name = "SeachHDS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeachHDS";
            this.uiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UISymbolButton uiSymbolButton3;
        private Sunny.UI.UIPanel showSearchPanel;
    }
}