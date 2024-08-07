using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WinFormsPagination.Properties;

namespace WinFormsPagination
{
    public partial class PaginationControl : UserControl
    {
        #region delegates
        public delegate void CurrentPageChange(PaginationControl paginationControl);
        public delegate void RowsPerPageChange(PaginationControl paginationControl);
        #endregion

        #region events
        event CurrentPageChange? CurrentPageChangedEvent;
        event RowsPerPageChange? RowsPerPageChangedEvent;
        #endregion

        #region properties
        Color _pageNumberDefaultBackColor = Color.Transparent;
        Color _pageNumberHoverBackColor = Color.FromArgb(22, 120, 218);
        Color _pageNumberActiveBackColor = Color.FromArgb(95, 173, 251);
        Color _pageNumberDefaultForeColor = Color.Black;
        Color _pageNumberHoverForeColor = Color.White;
        Color _pageNumberActiveForeColor = Color.White;

        Label? _activeLabel = null;
        int _pageToShow = 0;
        int _totalRows = 0;
        readonly List<int> _locationList = new();
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public PaginationControl()
        {
            InitializeComponent();
            ComboBoxRowsPerPage.SelectedIndex = 0;
        }

        #region custom events
        /// <summary>
        /// OnCurrentPageChanged Event
        /// </summary>
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when current page changed")]
        public event CurrentPageChange? CurrentPageChanged
        {
            add
            {
                CurrentPageChangedEvent += value;
            }
            remove
            {
                CurrentPageChangedEvent -= value;
            }
        }

        /// <summary>
        /// OnRowsPerPageChanged Event
        /// </summary>
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when rows per page changed")]
        public event RowsPerPageChange? RowsPerPageChanged
        {
            add
            {
                RowsPerPageChangedEvent += value;
            }
            remove
            {
                RowsPerPageChangedEvent -= value;
            }
        }
        #endregion

        #region custom properties
        /// <summary>
        /// RowsPerPage Property
        /// </summary>
        [Browsable(true)]
        [Category("Pagination")]
        [Description("Gets the value of Rows Per Page")]
        public int RowsPerPage
        {
            get
            {
                int rows = 0;

                if (ComboBoxRowsPerPage.SelectedItem != null)
                {
                    string? item = ComboBoxRowsPerPage.SelectedItem.ToString();

                    if (!string.IsNullOrEmpty(item))
                    {
                        int index = item.IndexOf('/');

                        if (index >= 0)
                        {
                            rows = Convert.ToInt32(item[0..(index - 1)]);
                        }
                    }
                }

                return rows;
            }
        }

        /// <summary>
        /// TotalRows Property
        /// </summary>
        [Browsable(true)]
        [Category("Pagination")]
        [Description("Gets or sets the value of Total Rows")]
        public int TotalRows
        {
            get
            {
                return _totalRows;
            }
            set
            {
                _totalRows = value;
                UpdatePageButtons();
            }
        }

        /// <summary>
        /// CurrentPage Property
        /// </summary>
        [Browsable(true)]
        [Category("Pagination")]
        [Description("Gets the value of Current Page")]
        public int CurrentPage
        {
            get
            {
                return Convert.ToInt32(NumericUpDownPage.Value);
            }
        }

        /// <summary>
        /// PageToShow Property
        /// </summary>
        [Browsable(true)]
        [Category("Pagination")]
        [Description("Gets the value of Page To Show")]
        public int PageToShow
        {
            get
            {
                return _pageToShow;
            }
            set
            {
                _pageToShow = value;
                InitializePageButtons();
            }
        }

        /// <summary>
        /// PageNumberDefaultBackColor Property
        /// </summary>
        [Browsable(true)]
        [Category("Pagination")]
        [Description("Gets or sets the value of Page Number Default Back Color")]
        public Color PageNumberDefaultBackColor
        {
            get
            {
                return _pageNumberDefaultBackColor;
            }
            set
            {
                _pageNumberDefaultBackColor = value;
            }
        }

        /// <summary>
        /// PageNumberHoverBackColor Property
        /// </summary>
        [Browsable(true)]
        [Category("Pagination")]
        [Description("Gets or sets the value of Page Number Hover Back Color")]
        public Color PageNumberHoverBackColor
        {
            get
            {
                return _pageNumberHoverBackColor;
            }
            set
            {
                _pageNumberHoverBackColor = value;
            }
        }

        /// <summary>
        /// PageNumberActiveBackColor Property
        /// </summary>
        [Browsable(true)]
        [Category("Pagination")]
        [Description("Gets or sets the value of Page Number Active Back Color")]
        public Color PageNumberActiveBackColor
        {
            get
            {
                return _pageNumberActiveBackColor;
            }
            set
            {
                _pageNumberActiveBackColor = value;
            }
        }

        /// <summary>
        /// PageNumberDefaultForeColor Property
        /// </summary>
        [Browsable(true)]
        [Category("Pagination")]
        [Description("Gets or sets the value of Page Number Default Fore Color")]
        public Color PageNumberDefaultForeColor
        {
            get
            {
                return _pageNumberDefaultForeColor;
            }
            set
            {
                _pageNumberDefaultForeColor = value;
            }
        }

        /// <summary>
        /// PageNumberHoverForeColor Property
        /// </summary>
        [Browsable(true)]
        [Category("Pagination")]
        [Description("Gets or sets the value of Page Number Hover Fore Color")]
        public Color PageNumberHoverForeColor
        {
            get
            {
                return _pageNumberHoverForeColor;
            }
            set
            {
                _pageNumberHoverForeColor = value;
            }
        }

        /// <summary>
        /// PageNumberActiveForeColor Property
        /// </summary>
        [Browsable(true)]
        [Category("Pagination")]
        [Description("Gets or sets the value of Page Number Active Fore Color")]
        public Color PageNumberActiveForeColor
        {
            get
            {
                return _pageNumberActiveForeColor;
            }
            set
            {
                _pageNumberActiveForeColor = value;
            }
        }
        #endregion

        /// <summary>
        /// Numeric Up Down Page Value Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownPage_ValueChanged(object sender, EventArgs e)
        {
            Label label = (Label)FlowLayoutPanelPage.Controls[CurrentPage - 1].Controls[0];
            UpdateLabel(label);
            UpdatePageButtons();

            CurrentPageChangedEvent?.Invoke(this);
        }

        /// <summary>
        /// Combo Box Rows Per Page Selected Index Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxRowsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePageButtons();
            RowsPerPageChangedEvent?.Invoke(this);
        }

        /// <summary>
        /// Set Page Buttons
        /// </summary>
        /// <param name="initialize"></param>
        private void SetPageButtons(bool initialize)
        {
            if (_pageToShow <= 0)
            {
                return;
            }

            int maxPage = (_totalRows - 1) / RowsPerPage + 1;

            int x = 0;
            bool reducePage = (FlowLayoutPanelPage.Controls.Count > maxPage);
            bool addPage = (FlowLayoutPanelPage.Controls.Count < maxPage);

            FlowLayoutPanelPage.SuspendLayout();

            if (initialize)
            {
                foreach (Panel panel in FlowLayoutPanelPage.Controls)
                {
                    foreach (Label label in panel.Controls)
                    {
                        label.MouseClick -= Label_MouseClick;
                        label.MouseHover -= Label_MouseHover;
                        label.MouseLeave -= Label_MouseLeave;
                    }
                }

                FlowLayoutPanelPage.Controls.Clear();
                _locationList.Clear();
            }

            while (FlowLayoutPanelPage.Controls.Count > maxPage)
            {
                FlowLayoutPanelPage.Controls.RemoveAt(FlowLayoutPanelPage.Controls.Count - 1);
            }

            while (FlowLayoutPanelPage.Controls.Count < maxPage)
            {
                // label
                Label label = new()
                {
                    BackColor = PageNumberDefaultBackColor,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point),
                    ForeColor = PageNumberDefaultForeColor,
                    Margin = new Padding(0),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = $"{FlowLayoutPanelPage.Controls.Count + 1}"
                };

                label.MouseClick += Label_MouseClick;
                label.MouseHover += Label_MouseHover;
                label.MouseLeave += Label_MouseLeave;

                // panel
                Panel panel = new()
                {
                    Location = new Point(x, 0),
                    Margin = new Padding(0),
                    Size = new Size(FlowLayoutPanelPage.Width / Math.Min(_pageToShow, maxPage), FlowLayoutPanelPage.Height)
                };

                _locationList.Add(x);
                panel.Controls.Add(label);
                x += panel.Width;

                FlowLayoutPanelPage.Controls.Add(panel);
            }

            if (reducePage || addPage)
            {
                for (int i = 0; i < maxPage; i++)
                {
                    FlowLayoutPanelPage.Controls[i].Location = new Point(x, 0);
                    FlowLayoutPanelPage.Controls[i].Size = new Size(FlowLayoutPanelPage.Width / Math.Min(_pageToShow, maxPage), FlowLayoutPanelPage.Height);
                    x += FlowLayoutPanelPage.Controls[i].Width;
                }
            }

            FlowLayoutPanelPage.ResumeLayout();

            LabelMaxPage.Text = $"of {maxPage}";
            NumericUpDownPage.Maximum = maxPage;

            if (initialize)
            {
                NumericUpDownPage.Value = 1;
                NumericUpDownPage.Minimum = 1;
            }

            if (reducePage || addPage)
            {
                UpdatePage(CurrentPage);
            }
        }

        /// <summary>
        /// Initialize Page Buttons
        /// </summary>
        public void InitializePageButtons()
        {
            SetPageButtons(true);
        }

        /// <summary>
        /// Update Page Buttons
        /// </summary>
        public void UpdatePageButtons()
        {
            SetPageButtons(false);
        }

        /// <summary>
        /// Update Label Color
        /// </summary>
        /// <param name="label"></param>
        /// <param name="backColor"></param>
        /// <param name="foreColor"></param>
        /// <param name="resetColor"></param>
        private void UpdateLabelColor(Label? label, Color backColor, Color foreColor, bool resetColor)
        {
            if (label != null)
            {
                if (_activeLabel != label || resetColor)
                {
                    label.BackColor = backColor;
                    label.ForeColor = foreColor;
                }
            }
        }

        /// <summary>
        /// Update Label
        /// </summary>
        /// <param name="label"></param>
        private void UpdateLabel(Label label)
        {
            int newIndex = Convert.ToInt32(label.Text);

            UpdateLabelColor(_activeLabel, PageNumberDefaultBackColor, PageNumberDefaultForeColor, true);
            UpdateLabelColor(label, PageNumberActiveBackColor, PageNumberActiveForeColor, false);
            _activeLabel = label;

            UpdatePage(newIndex);

            FlowLayoutPanelPage.SuspendLayout();

            int halfIndex = (_pageToShow / 2) + 1; // odd

            if ((_pageToShow % 2).Equals(0))
            {
                halfIndex = _pageToShow / 2;
            }

            int minIndex = Math.Max(0, newIndex - halfIndex);
            int maxIndex = Math.Min(FlowLayoutPanelPage.Controls.Count, minIndex + _pageToShow);

            // adjust min index if max index is the max page
            if (maxIndex.Equals(FlowLayoutPanelPage.Controls.Count))
            {
                minIndex = maxIndex - _pageToShow;
            }

            // change visibility of left panels till max index
            for (int i = 0; i < maxIndex; i++)
            {
                FlowLayoutPanelPage.Controls[i].Visible = (i >= minIndex && i < maxIndex);
            }

            FlowLayoutPanelPage.ResumeLayout();
        }

        /// <summary>
        /// Update Page
        /// </summary>
        /// <param name="page"></param>
        private void UpdatePage(int page)
        {
            NumericUpDownPage.Value = page;

            if (CurrentPage.Equals(1) && CurrentPage.Equals((int)NumericUpDownPage.Maximum))
            {
                PanelFirstPage.BackgroundImage = Resources.FirstLogoDisable;
                PanelPreviousPage.BackgroundImage = Resources.PreviousLogoDisable;
                PanelNextPage.BackgroundImage = Resources.NextLogoDisable;
                PanelLastPage.BackgroundImage = Resources.LastLogoDisable;

                PanelFirstPage.Enabled = false;
                PanelPreviousPage.Enabled = false;
                PanelNextPage.Enabled = false;
                PanelLastPage.Enabled = false;
            }
            else if (CurrentPage.Equals(1))
            {
                PanelFirstPage.BackgroundImage = Resources.FirstLogoDisable;
                PanelPreviousPage.BackgroundImage = Resources.PreviousLogoDisable;
                PanelNextPage.BackgroundImage = Resources.NextLogoEnable;
                PanelLastPage.BackgroundImage = Resources.LastLogoEnable;

                PanelFirstPage.Enabled = false;
                PanelPreviousPage.Enabled = false;
                PanelNextPage.Enabled = true;
                PanelLastPage.Enabled = true;
            }
            else if (CurrentPage.Equals((int)NumericUpDownPage.Maximum))
            {
                PanelFirstPage.BackgroundImage = Resources.FirstLogoEnable;
                PanelPreviousPage.BackgroundImage = Resources.PreviousLogoEnable;
                PanelNextPage.BackgroundImage = Resources.NextLogoDisable;
                PanelLastPage.BackgroundImage = Resources.LastLogoDisable;

                PanelFirstPage.Enabled = true;
                PanelPreviousPage.Enabled = true;
                PanelNextPage.Enabled = false;
                PanelLastPage.Enabled = false;
            }
            else
            {
                PanelFirstPage.BackgroundImage = Resources.FirstLogoEnable;
                PanelPreviousPage.BackgroundImage = Resources.PreviousLogoEnable;
                PanelNextPage.BackgroundImage = Resources.NextLogoEnable;
                PanelLastPage.BackgroundImage = Resources.LastLogoEnable;

                PanelFirstPage.Enabled = true;
                PanelPreviousPage.Enabled = true;
                PanelNextPage.Enabled = true;
                PanelLastPage.Enabled = true;
            }
        }

        /// <summary>
        /// Panel Mouse Hover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_MouseHover(object sender, EventArgs e)
        {
            if (sender != null)
            {
                Panel panel = (Panel)sender;

                switch (panel.Name)
                {
                    case "PanelFirstPage":
                        PanelFirstPage.BackgroundImage = NumericUpDownPage.Value.Equals(NumericUpDownPage.Minimum) ? Resources.FirstLogoDisable : Resources.FirstLogoHover;
                        break;
                    case "PanelPreviousPage":
                        PanelPreviousPage.BackgroundImage = NumericUpDownPage.Value.Equals(NumericUpDownPage.Minimum) ? Resources.PreviousLogoDisable : Resources.PreviousLogoHover;
                        break;
                    case "PanelNextPage":
                        PanelNextPage.BackgroundImage = NumericUpDownPage.Value.Equals(NumericUpDownPage.Maximum) ? Resources.NextLogoDisable : Resources.NextLogoHover;
                        break;
                    case "PanelLastPage":
                        PanelLastPage.BackgroundImage = NumericUpDownPage.Value.Equals(NumericUpDownPage.Maximum) ? Resources.LastLogoDisable : Resources.LastLogoHover;
                        break;
                }
            }
        }

        /// <summary>
        /// Panel Mouse Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            if (sender != null)
            {
                Panel panel = (Panel)sender;

                switch (panel.Name)
                {
                    case "PanelFirstPage":
                        PanelFirstPage.BackgroundImage = NumericUpDownPage.Value.Equals(NumericUpDownPage.Minimum) ? Resources.FirstLogoDisable : Resources.FirstLogoEnable;
                        break;
                    case "PanelPreviousPage":
                        PanelPreviousPage.BackgroundImage = NumericUpDownPage.Value.Equals(NumericUpDownPage.Minimum) ? Resources.PreviousLogoDisable : Resources.PreviousLogoEnable;
                        break;
                    case "PanelNextPage":
                        PanelNextPage.BackgroundImage = NumericUpDownPage.Value.Equals(NumericUpDownPage.Maximum) ? Resources.NextLogoDisable : Resources.NextLogoEnable;
                        break;
                    case "PanelLastPage":
                        PanelLastPage.BackgroundImage = NumericUpDownPage.Value.Equals(NumericUpDownPage.Maximum) ? Resources.LastLogoDisable : Resources.LastLogoEnable;
                        break;
                }
            }
        }

        /// <summary>
        /// Label Mouse Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseClick(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Label label = (Label)sender;

                NumericUpDownPage.Value = Convert.ToInt32(label.Text);
            }
        }

        /// <summary>
        /// Label Mouse Hover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseHover(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Label label = (Label)sender;

                UpdateLabelColor(label, PageNumberHoverBackColor, PageNumberHoverForeColor, false);
            }
        }

        /// <summary>
        /// Label Mouse Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseLeave(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Label label = (Label)sender;

                UpdateLabelColor(label, PageNumberDefaultBackColor, PageNumberDefaultForeColor, false);
            }
        }

        /// <summary>
        /// Panel First Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelFirstPage_Click(object sender, EventArgs e)
        {
            Label_MouseClick(FlowLayoutPanelPage.Controls[0].Controls[0], new EventArgs());
        }

        /// <summary>
        /// Panel Previous Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelPreviousPage_Click(object sender, EventArgs e)
        {
            if (_activeLabel != null)
            {
                int index = Convert.ToInt32(_activeLabel.Text) - 2;

                Label_MouseClick(FlowLayoutPanelPage.Controls[index].Controls[0], new EventArgs());
            }
        }

        /// <summary>
        /// Panel Next Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelNextPage_Click(object sender, EventArgs e)
        {
            if (_activeLabel != null)
            {
                int index = Convert.ToInt32(_activeLabel.Text);

                Label_MouseClick(FlowLayoutPanelPage.Controls[index].Controls[0], new EventArgs());
            }
        }

        /// <summary>
        /// Panel Last Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelLastPage_Click(object sender, EventArgs e)
        {
            Label_MouseClick(FlowLayoutPanelPage.Controls[FlowLayoutPanelPage.Controls.Count - 1].Controls[0], new EventArgs());
        }
    }
}
