using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;
using WinFormsPagination.Properties;

namespace WinFormsPagination
{
    public partial class PaginationControl : UserControl
    {
        // delegates
        public delegate void OnCurrentPageChange(PaginationControl paginationControl);
        public delegate void OnRowsPerPageChange(PaginationControl paginationControl);

        // events
        event OnCurrentPageChange? OnCurrentPageChangedEvent;
        event OnRowsPerPageChange? OnRowsPerPageChangedEvent;

        /// <summary>
        /// Constructor
        /// </summary>
        public PaginationControl()
        {
            InitializeComponent();
            ComboBoxRowsPerPage.SelectedIndex = 0;
        }

        /// <summary>
        /// RowsPerPage Property
        /// </summary>
        [Browsable(true)]
        [Category("Pagination")]
        [Description("Gets the value of Rows Per Page")]
        public string RowsPerPage
        {
            get
            {
                return ComboBoxRowsPerPage.SelectedItem?.ToString() ?? string.Empty;
            }
            //set
            //{
            //    ComboBoxRowsPerPage.Items.Clear();
            //    ComboBoxRowsPerPage.Items.AddRange(value.Cast<object>().ToArray());
            //}
        }

        /// <summary>
        /// OnCurrentPageChanged Event
        /// </summary>
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when current page changed")]
        public event OnCurrentPageChange? OnCurrentPageChanged
        {
            add
            {
                OnCurrentPageChangedEvent += value;
            }
            remove
            {
                OnCurrentPageChangedEvent -= value;
            }
        }

        /// <summary>
        /// OnRowsPerPageChanged Event
        /// </summary>
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when rows per page changed")]
        public event OnRowsPerPageChange? OnRowsPerPageChanged
        {
            add
            {
                OnRowsPerPageChangedEvent += value;
            }
            remove
            {
                OnRowsPerPageChangedEvent -= value;
            }
        }

        /// <summary>
        /// Numeric Up Down Page Value Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownPage_ValueChanged(object sender, EventArgs e)
        {
            OnCurrentPageChangedEvent?.Invoke(this);
        }

        /// <summary>
        /// Combo Box Rows Per Page Selected Index Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxRowsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnRowsPerPageChangedEvent?.Invoke(this);
        }
    }
}
