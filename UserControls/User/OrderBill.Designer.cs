namespace QL_XuatKhauGao.UserControls.Admin
{
    partial class OrderBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.col_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_image = new System.Windows.Forms.DataGridViewImageColumn();
            this.container_grid = new Sunny.UI.UIDataGridView();
            this.col_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.uiMarkLabel2 = new Sunny.UI.UIMarkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiMarkLabel1 = new Sunny.UI.UIMarkLabel();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiButton3 = new Sunny.UI.UIButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.lb_totalPrice = new Sunny.UI.UILabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel_action = new System.Windows.Forms.Panel();
            this.panel_add = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.container_grid)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel_action.SuspendLayout();
            this.panel_add.SuspendLayout();
            this.SuspendLayout();
            // 
            // col_total
            // 
            this.col_total.HeaderText = "Tổng";
            this.col_total.MinimumWidth = 6;
            this.col_total.Name = "col_total";
            this.col_total.ReadOnly = true;
            this.col_total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_price
            // 
            this.col_price.HeaderText = "Giá";
            this.col_price.MinimumWidth = 6;
            this.col_price.Name = "col_price";
            this.col_price.ReadOnly = true;
            this.col_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_name
            // 
            this.col_name.HeaderText = "Tên";
            this.col_name.MinimumWidth = 6;
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            this.col_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_image
            // 
            this.col_image.HeaderText = "#";
            this.col_image.MinimumWidth = 6;
            this.col_image.Name = "col_image";
            this.col_image.ReadOnly = true;
            // 
            // container_grid
            // 
            this.container_grid.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.container_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.container_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.container_grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.container_grid.BackgroundColor = System.Drawing.Color.White;
            this.container_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(161)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.container_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.container_grid.ColumnHeadersHeight = 32;
            this.container_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.container_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_image,
            this.col_name,
            this.col_price,
            this.col_quantity,
            this.col_total});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(161)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.container_grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.container_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container_grid.EnableHeadersVisualStyles = false;
            this.container_grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.container_grid.GridColor = System.Drawing.Color.White;
            this.container_grid.Location = new System.Drawing.Point(8, 8);
            this.container_grid.Margin = new System.Windows.Forms.Padding(2);
            this.container_grid.Name = "container_grid";
            this.container_grid.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.container_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.container_grid.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.container_grid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.container_grid.RowTemplate.Height = 24;
            this.container_grid.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(161)))), ((int)(((byte)(255)))));
            this.container_grid.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(161)))), ((int)(((byte)(255)))));
            this.container_grid.SelectedIndex = -1;
            this.container_grid.Size = new System.Drawing.Size(784, 171);
            this.container_grid.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.container_grid.Style = Sunny.UI.UIStyle.Custom;
            this.container_grid.TabIndex = 24;
            // 
            // col_quantity
            // 
            this.col_quantity.HeaderText = "Số lượng";
            this.col_quantity.MinimumWidth = 6;
            this.col_quantity.Name = "col_quantity";
            this.col_quantity.ReadOnly = true;
            this.col_quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.container_grid);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 147);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(8);
            this.panel5.Size = new System.Drawing.Size(800, 187);
            this.panel5.TabIndex = 47;
            // 
            // uiMarkLabel2
            // 
            this.uiMarkLabel2.AutoSize = true;
            this.uiMarkLabel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiMarkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiMarkLabel2.Location = new System.Drawing.Point(0, 0);
            this.uiMarkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uiMarkLabel2.MarkPos = Sunny.UI.UIMarkLabel.UIMarkPos.Bottom;
            this.uiMarkLabel2.Name = "uiMarkLabel2";
            this.uiMarkLabel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.uiMarkLabel2.Size = new System.Drawing.Size(82, 24);
            this.uiMarkLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiMarkLabel2.TabIndex = 37;
            this.uiMarkLabel2.Text = "Sản phẩm";
            this.uiMarkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiMarkLabel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 110);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 37);
            this.panel1.TabIndex = 46;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uiMarkLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 40);
            this.panel2.TabIndex = 37;
            // 
            // uiMarkLabel1
            // 
            this.uiMarkLabel1.AutoSize = true;
            this.uiMarkLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiMarkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiMarkLabel1.Location = new System.Drawing.Point(0, 0);
            this.uiMarkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uiMarkLabel1.MarkPos = Sunny.UI.UIMarkLabel.UIMarkPos.Bottom;
            this.uiMarkLabel1.Name = "uiMarkLabel1";
            this.uiMarkLabel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.uiMarkLabel1.Size = new System.Drawing.Size(57, 24);
            this.uiMarkLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiMarkLabel1.TabIndex = 36;
            this.uiMarkLabel1.Text = "Địa chỉ";
            this.uiMarkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiButton1.FillColor = System.Drawing.Color.White;
            this.uiButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton1.ForeColor = System.Drawing.Color.Black;
            this.uiButton1.Location = new System.Drawing.Point(562, 0);
            this.uiButton1.Margin = new System.Windows.Forms.Padding(2);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 6;
            this.uiButton1.RectSize = 2;
            this.uiButton1.Size = new System.Drawing.Size(111, 38);
            this.uiButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton1.TabIndex = 10;
            this.uiButton1.Text = "Hủy";
            this.uiButton1.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiButton3
            // 
            this.uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton3.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton3.Location = new System.Drawing.Point(673, 0);
            this.uiButton3.Margin = new System.Windows.Forms.Padding(2);
            this.uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Radius = 6;
            this.uiButton3.Size = new System.Drawing.Size(111, 38);
            this.uiButton3.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton3.TabIndex = 9;
            this.uiButton3.Text = "Đặt hàng";
            this.uiButton3.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton3.Click += new System.EventHandler(this.uiButton3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uiButton2);
            this.panel3.Controls.Add(this.uiButton1);
            this.panel3.Controls.Add(this.uiButton3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(8, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 38);
            this.panel3.TabIndex = 0;
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton2.Location = new System.Drawing.Point(397, -1);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(100, 35);
            this.uiButton2.TabIndex = 11;
            this.uiButton2.Text = "uiButton2";
            this.uiButton2.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // lb_totalPrice
            // 
            this.lb_totalPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.lb_totalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_totalPrice.Location = new System.Drawing.Point(562, 0);
            this.lb_totalPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_totalPrice.Name = "lb_totalPrice";
            this.lb_totalPrice.Size = new System.Drawing.Size(222, 36);
            this.lb_totalPrice.TabIndex = 0;
            this.lb_totalPrice.Text = "Tổng tiền hàng:";
            this.lb_totalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lb_totalPrice);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 26);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(784, 36);
            this.panel6.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(8, 8);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(784, 62);
            this.panel4.TabIndex = 1;
            // 
            // panel_action
            // 
            this.panel_action.Controls.Add(this.panel4);
            this.panel_action.Controls.Add(this.panel3);
            this.panel_action.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_action.Location = new System.Drawing.Point(0, 334);
            this.panel_action.Margin = new System.Windows.Forms.Padding(2);
            this.panel_action.Name = "panel_action";
            this.panel_action.Padding = new System.Windows.Forms.Padding(8);
            this.panel_action.Size = new System.Drawing.Size(800, 116);
            this.panel_action.TabIndex = 45;
            // 
            // panel_add
            // 
            this.panel_add.Controls.Add(this.panel2);
            this.panel_add.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_add.Location = new System.Drawing.Point(0, 0);
            this.panel_add.Margin = new System.Windows.Forms.Padding(2);
            this.panel_add.Name = "panel_add";
            this.panel_add.Size = new System.Drawing.Size(800, 110);
            this.panel_add.TabIndex = 44;
            // 
            // OrderBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_action);
            this.Controls.Add(this.panel_add);
            this.Name = "OrderBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderBill";
            this.Load += new System.EventHandler(this.OrderBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.container_grid)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel_action.ResumeLayout(false);
            this.panel_add.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn col_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewImageColumn col_image;
        private Sunny.UI.UIDataGridView container_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_quantity;
        private System.Windows.Forms.Panel panel5;
        private Sunny.UI.UIMarkLabel uiMarkLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UIMarkLabel uiMarkLabel1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton3;
        private System.Windows.Forms.Panel panel3;
        private Sunny.UI.UILabel lb_totalPrice;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel_action;
        private System.Windows.Forms.Panel panel_add;
        private Sunny.UI.UIButton uiButton2;
    }
}