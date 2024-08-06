using System.Drawing;
using System.Windows.Forms;

namespace WinFormsPagination
{
    partial class PaginationControl
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
            PanelPaginationControl = new Panel();
            FlowLayoutPanelPage = new FlowLayoutPanel();
            PanelNextPage = new Panel();
            PanelRightSpace = new Panel();
            PanelPreviousPage = new Panel();
            PanelLeftSpace = new Panel();
            PanelLastPage = new Panel();
            PanelFirstPage = new Panel();
            PanelPage = new Panel();
            NumericUpDownPage = new NumericUpDown();
            LabelPage = new Label();
            ComboBoxRowsPerPage = new ComboBox();
            LabelMaxPage = new Label();
            PanelPaginationControl.SuspendLayout();
            PanelPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownPage).BeginInit();
            SuspendLayout();
            // 
            // PanelPaginationControl
            // 
            PanelPaginationControl.BackColor = Color.Transparent;
            PanelPaginationControl.Controls.Add(FlowLayoutPanelPage);
            PanelPaginationControl.Controls.Add(PanelNextPage);
            PanelPaginationControl.Controls.Add(PanelRightSpace);
            PanelPaginationControl.Controls.Add(PanelPreviousPage);
            PanelPaginationControl.Controls.Add(PanelLeftSpace);
            PanelPaginationControl.Controls.Add(PanelLastPage);
            PanelPaginationControl.Controls.Add(PanelFirstPage);
            PanelPaginationControl.Controls.Add(PanelPage);
            PanelPaginationControl.Dock = DockStyle.Fill;
            PanelPaginationControl.Location = new Point(0, 0);
            PanelPaginationControl.Margin = new Padding(4, 0, 4, 0);
            PanelPaginationControl.Name = "PanelPaginationControl";
            PanelPaginationControl.Size = new Size(1374, 40);
            PanelPaginationControl.TabIndex = 0;
            // 
            // FlowLayoutPanelPage
            // 
            FlowLayoutPanelPage.Dock = DockStyle.Fill;
            FlowLayoutPanelPage.Location = new Point(86, 0);
            FlowLayoutPanelPage.Margin = new Padding(4, 0, 4, 0);
            FlowLayoutPanelPage.Name = "FlowLayoutPanelPage";
            FlowLayoutPanelPage.Size = new Size(845, 40);
            FlowLayoutPanelPage.TabIndex = 10;
            FlowLayoutPanelPage.WrapContents = false;
            // 
            // PanelNextPage
            // 
            PanelNextPage.BackgroundImage = Properties.Resources.NextLogoDisable;
            PanelNextPage.BackgroundImageLayout = ImageLayout.Stretch;
            PanelNextPage.Dock = DockStyle.Right;
            PanelNextPage.Location = new Point(931, 0);
            PanelNextPage.Margin = new Padding(4, 5, 4, 5);
            PanelNextPage.Name = "PanelNextPage";
            PanelNextPage.Size = new Size(40, 40);
            PanelNextPage.TabIndex = 9;
            PanelNextPage.Click += PanelNextPage_Click;
            PanelNextPage.MouseLeave += Panel_MouseLeave;
            PanelNextPage.MouseHover += Panel_MouseHover;
            // 
            // PanelRightSpace
            // 
            PanelRightSpace.BackgroundImageLayout = ImageLayout.None;
            PanelRightSpace.Dock = DockStyle.Right;
            PanelRightSpace.Location = new Point(971, 0);
            PanelRightSpace.Margin = new Padding(4, 5, 4, 5);
            PanelRightSpace.Name = "PanelRightSpace";
            PanelRightSpace.Size = new Size(6, 40);
            PanelRightSpace.TabIndex = 8;
            // 
            // PanelPreviousPage
            // 
            PanelPreviousPage.BackgroundImage = Properties.Resources.PreviousLogoDisable;
            PanelPreviousPage.BackgroundImageLayout = ImageLayout.Stretch;
            PanelPreviousPage.Dock = DockStyle.Left;
            PanelPreviousPage.Location = new Point(46, 0);
            PanelPreviousPage.Margin = new Padding(4, 5, 4, 5);
            PanelPreviousPage.Name = "PanelPreviousPage";
            PanelPreviousPage.Size = new Size(40, 40);
            PanelPreviousPage.TabIndex = 7;
            PanelPreviousPage.Click += PanelPreviousPage_Click;
            PanelPreviousPage.MouseLeave += Panel_MouseLeave;
            PanelPreviousPage.MouseHover += Panel_MouseHover;
            // 
            // PanelLeftSpace
            // 
            PanelLeftSpace.BackgroundImageLayout = ImageLayout.None;
            PanelLeftSpace.Dock = DockStyle.Left;
            PanelLeftSpace.Location = new Point(40, 0);
            PanelLeftSpace.Margin = new Padding(4, 5, 4, 5);
            PanelLeftSpace.Name = "PanelLeftSpace";
            PanelLeftSpace.Size = new Size(6, 40);
            PanelLeftSpace.TabIndex = 6;
            // 
            // PanelLastPage
            // 
            PanelLastPage.BackgroundImage = Properties.Resources.LastLogoDisable;
            PanelLastPage.BackgroundImageLayout = ImageLayout.Stretch;
            PanelLastPage.Dock = DockStyle.Right;
            PanelLastPage.Location = new Point(977, 0);
            PanelLastPage.Margin = new Padding(4, 5, 4, 5);
            PanelLastPage.Name = "PanelLastPage";
            PanelLastPage.Size = new Size(40, 40);
            PanelLastPage.TabIndex = 2;
            PanelLastPage.Click += PanelLastPage_Click;
            PanelLastPage.MouseLeave += Panel_MouseLeave;
            PanelLastPage.MouseHover += Panel_MouseHover;
            // 
            // PanelFirstPage
            // 
            PanelFirstPage.BackgroundImage = Properties.Resources.FirstLogoDisable;
            PanelFirstPage.BackgroundImageLayout = ImageLayout.Stretch;
            PanelFirstPage.Dock = DockStyle.Left;
            PanelFirstPage.Location = new Point(0, 0);
            PanelFirstPage.Margin = new Padding(4, 5, 4, 5);
            PanelFirstPage.Name = "PanelFirstPage";
            PanelFirstPage.Size = new Size(40, 40);
            PanelFirstPage.TabIndex = 0;
            PanelFirstPage.Click += PanelFirstPage_Click;
            PanelFirstPage.MouseLeave += Panel_MouseLeave;
            PanelFirstPage.MouseHover += Panel_MouseHover;
            // 
            // PanelPage
            // 
            PanelPage.BackgroundImageLayout = ImageLayout.None;
            PanelPage.Controls.Add(NumericUpDownPage);
            PanelPage.Controls.Add(LabelPage);
            PanelPage.Controls.Add(ComboBoxRowsPerPage);
            PanelPage.Controls.Add(LabelMaxPage);
            PanelPage.Dock = DockStyle.Right;
            PanelPage.Location = new Point(1017, 0);
            PanelPage.Margin = new Padding(4, 0, 4, 0);
            PanelPage.Name = "PanelPage";
            PanelPage.Size = new Size(357, 40);
            PanelPage.TabIndex = 5;
            // 
            // NumericUpDownPage
            // 
            NumericUpDownPage.Dock = DockStyle.Fill;
            NumericUpDownPage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            NumericUpDownPage.Location = new Point(190, 0);
            NumericUpDownPage.Margin = new Padding(4, 5, 4, 5);
            NumericUpDownPage.Name = "NumericUpDownPage";
            NumericUpDownPage.Size = new Size(81, 33);
            NumericUpDownPage.TabIndex = 4;
            NumericUpDownPage.TabStop = false;
            NumericUpDownPage.TextAlign = HorizontalAlignment.Center;
            NumericUpDownPage.ValueChanged += NumericUpDownPage_ValueChanged;
            // 
            // LabelPage
            // 
            LabelPage.Dock = DockStyle.Left;
            LabelPage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            LabelPage.Location = new Point(130, 0);
            LabelPage.Margin = new Padding(4, 0, 4, 0);
            LabelPage.Name = "LabelPage";
            LabelPage.Size = new Size(60, 40);
            LabelPage.TabIndex = 2;
            LabelPage.Text = "Page";
            LabelPage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ComboBoxRowsPerPage
            // 
            ComboBoxRowsPerPage.DisplayMember = "10 / page";
            ComboBoxRowsPerPage.Dock = DockStyle.Left;
            ComboBoxRowsPerPage.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxRowsPerPage.FlatStyle = FlatStyle.Flat;
            ComboBoxRowsPerPage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ComboBoxRowsPerPage.FormattingEnabled = true;
            ComboBoxRowsPerPage.Items.AddRange(new object[] { "10 / page", "20 / page", "30 / page", "40 / page", "50 / page" });
            ComboBoxRowsPerPage.Location = new Point(0, 0);
            ComboBoxRowsPerPage.Margin = new Padding(4, 0, 4, 0);
            ComboBoxRowsPerPage.Name = "ComboBoxRowsPerPage";
            ComboBoxRowsPerPage.Size = new Size(130, 36);
            ComboBoxRowsPerPage.Sorted = true;
            ComboBoxRowsPerPage.TabIndex = 1;
            ComboBoxRowsPerPage.TabStop = false;
            ComboBoxRowsPerPage.SelectedIndexChanged += ComboBoxRowsPerPage_SelectedIndexChanged;
            // 
            // LabelMaxPage
            // 
            LabelMaxPage.Dock = DockStyle.Right;
            LabelMaxPage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            LabelMaxPage.Location = new Point(271, 0);
            LabelMaxPage.Margin = new Padding(4, 0, 4, 0);
            LabelMaxPage.Name = "LabelMaxPage";
            LabelMaxPage.Size = new Size(86, 40);
            LabelMaxPage.TabIndex = 0;
            LabelMaxPage.Text = "of 0";
            LabelMaxPage.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PaginationControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelPaginationControl);
            Margin = new Padding(4, 5, 4, 5);
            Name = "PaginationControl";
            Size = new Size(1374, 40);
            PanelPaginationControl.ResumeLayout(false);
            PanelPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumericUpDownPage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelPaginationControl;
        private Panel PanelLastPage;
        private Panel PanelFirstPage;
        private Panel PanelPage;
        private Label LabelMaxPage;
        private ComboBox ComboBoxRowsPerPage;
        private NumericUpDown NumericUpDownPage;
        private Label LabelPage;
        private FlowLayoutPanel FlowLayoutPanelPage;
        private Panel PanelNextPage;
        private Panel PanelRightSpace;
        private Panel PanelPreviousPage;
        private Panel PanelLeftSpace;
    }
}
