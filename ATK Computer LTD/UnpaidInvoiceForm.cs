using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITY;
namespace ATK_Computer_LTD
{
    public partial class UnpaidInvoiceForm : Form
    {
        public UnpaidInvoiceForm()
        {
            InitializeComponent();
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvUserDetails_RowPrePaint);
            LedgerManager ld = new LedgerManager();
            ld.GetUnpaidInvoice(0, dataGridView1);
        }
        void dgvUserDetails_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All);

            e.PaintHeader(DataGridViewPaintParts.Background
                | DataGridViewPaintParts.Border
                | DataGridViewPaintParts.Focus
                | DataGridViewPaintParts.SelectionBackground
                | DataGridViewPaintParts.ContentForeground);
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
            e.Handled = true;
        }
        string userName = null;
        public void giveMemberUserName(string name)
        {
            userName = name;
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value = e.RowIndex.ToString();
        }

        private void Ok_Button_Click(object sender, EventArgs e)
        {
            Home_Admin_PartyLedger hp = new Home_Admin_PartyLedger();
            hp.giveMemberUserName(userName);
            hp.Show();
            this.Hide(); 
        }
    }
}
