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
    public partial class LedgerForm : Form
    {
        LedgerView lv = new LedgerView();
        LedgerManager ldgr = new LedgerManager();
        public LedgerForm()
        {
            InitializeComponent();
            lv.DisplayAll(dataGridView1);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvUserDetails_RowPrePaint);
            this.dataGridView_Edit.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvUserDetails_RowPrePaint);
            this.dataGridView_Search.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvUserDetails_RowPrePaint);
        }
        public TabControl myTab
        {
            get
            {
                return tabcontrol_ledger;
            }

        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            lv.UpdateDB();
        }
       
        private void init()
        {
            textBox_Amount.Text = "";
            textBox_Ref.Text = "";
            //textBox_Remarks.Text = "";
            comboBox_particulars.Text = "";
        }
        private void keyDownHandlers(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void buttun_AddEntry_Click(object sender, EventArgs e)
        {
            //LedgerManager ldgr = new LedgerManager(Convert.ToDecimal(dataGridView1.Rows[row].Cells[col].Value));

            try
            {
                ldgr.AddNewEntry(textBox_Name.Text, dateTimePicker.Value, comboBox_particulars.Text, textBox_Ref.Text, datetime_Bill.Value, Convert.ToDecimal(textBox_Amount.Text));
                lv.DisplayAll(dataGridView1);
                init();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ErrorLFrm" + ex.Message);
            }
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value = e.RowIndex.ToString();
        }
        private void textBox_Amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttun_AddEntry_Click(this, new EventArgs());
            }
        }

        private void comboBox_particulars_KeyDown(object sender, KeyEventArgs e)
        {
            keyDownHandlers(e);
        }

        private void textBox_Ref_KeyDown(object sender, KeyEventArgs e)
        {
            keyDownHandlers(e);
        }

        private void LedgerForm_Load(object sender, EventArgs e)
        {

        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }
        private void Add_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox_Remarks_KeyDown(object sender, KeyEventArgs e)
        {
            keyDownHandlers(e);
        }

       

        private void button_Search_Click(object sender, EventArgs e)
        {
            ldgr.ShowSearchResut(textboxSearchName.Text, textbox_SearchBillno.Text, datetime_BillDateSearch.Value, dataGridView_Search);
        }

        private void buttun_AddEntry_Click_1(object sender, EventArgs e)
        {

            try
            {
                ldgr.AddNewEntry(textBox_Name.Text, dateTimePicker.Value, comboBox_particulars.Text, textBox_Ref.Text, datetime_Bill.Value, Convert.ToDecimal(textBox_Amount.Text));
                lv.DisplayAll(dataGridView1);
                init();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Search_Click_1(object sender, EventArgs e)
        {
            ldgr.ShowSearchResut(textboxSearchName.Text, textbox_SearchBillno.Text, datetime_BillDateSearch.Value, dataGridView_Search);
        }

        private void tabcontrol_ledger_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {

                case 1:
                    lv.DisplayAll(dataGridView_Search);
                    break;
                case 2:
                    lv.DisplayAll(dataGridView_Edit);
                    break;

            }
        }
        string userName = null;
        public void giveMemberUserName(string name)
        {
            userName = name;
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
