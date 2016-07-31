using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BO;
using ENTITY;
using System.IO;
namespace ATK_Computer_LTD
{
    public partial class Home_Admin_CreditHistory : Form
    {
        public Home_Admin_CreditHistory()
        {
            InitializeComponent();
        }
        string userName = null;
        public void giveMemberUserName(string name)
        {
            userName = name;
        }
        private void setFullScreen()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            Location = new Point(0, 0);
            Size = new Size(x, y);
        }
        private void setMainPanelPosition()
        {
            int mX = (Width - home_admin_main_panel.Width) / 2;
            int mY = (Height - home_admin_main_panel.Height) / 2;
            home_admin_main_panel.Location = new Point(mX, mY);
        }
        int rightX;
        int rightY;
        private void setRightOptionPanel()
        {
            int y = Height;
            rightY = 0;
            rightX = Width + right_pnl.Width;
            right_pnl.Size = new Size(right_pnl.Width, y);
            right_pnl.Location = new Point(rightX, rightY);
            int rX = pnlRightMain.Location.X;
            int rY = (right_pnl.Height - pnlRightMain.Height) / 2;
            pnlRightMain.Location = new Point(rX, rY);
        }
        string rightDirection = "right";
        int RightTimeOut = 0;
        Account_BO account_Bo = new Account_BO();
        Member member = new Member();

        private void Home_Admin_CreditHistory_Load(object sender, EventArgs e)
        {
            setFullScreen();
            setMainPanelPosition();
            setRightOptionPanel();
            right_option_timer.Start();


            try
            {
                Account_BO ab = new Account_BO();
                member = ab.getMember(userName);
                memberFirstNameMetroLabel.Text = member.firstName.ToString();
                memberLastNameMetroLabel.Text = member.lastName.ToString();
                MemoryStream ms = new MemoryStream(member.image);
                pictureBox.Image = Image.FromStream(ms);


                CreditHistory creditHistory = new CreditHistory();
                creditHistory.invoiceNo = invoiceNo_TextBox.Text;
                creditHistory.name = clientName_TextBox.Text;
                creditHistory.address = address_TextBox.Text;
                creditHistory.mobileNo = phoneNo_TextBox.Text;
                creditHistory.date = date_TextBox.Text;
                creditHistory.reference = userName_textBox.Text;
                DataSet ds = account_Bo.getCreditHistory(creditHistory);
                clientHistoryMetroGrid.DataSource = ds.Tables[0];
              
            }
            catch
            {

            }
        }

        private void Ctrl_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender == home_pnl)
            {
                home_pnl.BackColor = Color.Red;
            }
            else if (sender == lock_pnl)
            {
                lock_pnl.BackColor = Color.Red;
            }
            else if (sender == minimized_pnl)
            {
                minimized_pnl.BackColor = Color.Red;
            }
            else if (sender == exit_pnl)
            {
                exit_pnl.BackColor = Color.Red;
            }
        }

        private void Ctrl_MouseLeave(object sender, EventArgs e)
        {
            if (sender == home_pnl)
            {
                home_pnl.BackColor = Color.Transparent;
            }
            else if (sender == lock_pnl)
            {
                lock_pnl.BackColor = Color.Transparent;
            }
            else if (sender == minimized_pnl)
            {
                minimized_pnl.BackColor = Color.Transparent;
            }
            else if (sender == exit_pnl)
            {
                exit_pnl.BackColor = Color.Transparent;
            }
        }

        private void Ctrl_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender == home_pnl)
            {
                Home_Admin hm = new Home_Admin();
                hm.giveMemberUserName(userName);
                hm.Show();
                this.Hide();
            }
            else if (sender == lock_pnl)
            {
                Home h = new Home();
                h.Show();
                this.Hide();
            }
            else if (sender == minimized_pnl)
            {
                right_option_timer.Stop();
                this.WindowState = FormWindowState.Minimized;
            }
            else if (sender == exit_pnl)
            {
                Application.Exit();
            }
        }

        private void Home_Admin_CreditHistory_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y >= Height - 15 && e.X < (Width - right_pnl.Width))
            {

                rightDirection = "right";

            }
            if (e.X >= Width - 15)
            {
                rightDirection = "left";
                RightTimeOut = 0;

            }
            if (e.X < (Width - right_pnl.Width))
            {
                rightDirection = "Left";
            }
        }

        private void home_admin_main_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y >= Height - 15 && e.X < (Width - right_pnl.Width))
            {

                rightDirection = "right";

            }
            if (e.X >= Width - 15)
            {
                rightDirection = "left";
                RightTimeOut = 0;

            }
            if (e.X < (Width - right_pnl.Width))
            {
                rightDirection = "Left";
            }
        }

        private void right_option_timer_Tick(object sender, EventArgs e)
        {
            if (RightTimeOut < 1000)
            {
                RightTimeOut++;
            }
            if (RightTimeOut == 1000)
            {
                if (rightDirection == "left")
                {
                    rightDirection = "right";
                }
            }
            if (rightDirection == "left")
            {
                if (rightX > Width - right_pnl.Width)
                {
                    rightX -= 3;
                    right_pnl.Location = new Point(rightX, rightY);
                }
            }
            else
            {
                if (rightX < Width)
                {
                    rightX += 3;
                }
                right_pnl.Location = new Point(rightX, rightY);
            }
        }

        private void Home_Admin_CreditHistory_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void productUnitPriceTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void productEntryDTP_CloseUp(object sender, EventArgs e)
        {
            CreditHistory creditHistory = new CreditHistory();
            creditHistory.invoiceNo = invoiceNo_TextBox.Text;
            creditHistory.name = clientName_TextBox.Text;
            creditHistory.address = address_TextBox.Text;
            creditHistory.mobileNo = phoneNo_TextBox.Text;
            creditHistory.date = date_TextBox.Text;
            creditHistory.reference = userName_textBox.Text;
            DataSet ds = account_Bo.getCreditHistory(creditHistory);
            clientHistoryMetroGrid.DataSource = ds.Tables[0];
           
        }

        private void userName_textBox_TextChanged(object sender, EventArgs e)
        {
            CreditHistory creditHistory = new CreditHistory();
            creditHistory.invoiceNo = invoiceNo_TextBox.Text;
            creditHistory.name = clientName_TextBox.Text;
            creditHistory.address = address_TextBox.Text;
            creditHistory.mobileNo = phoneNo_TextBox.Text;
            creditHistory.date = date_TextBox.Text;
            creditHistory.reference = userName_textBox.Text;
            DataSet ds = account_Bo.getCreditHistory(creditHistory);
            clientHistoryMetroGrid.DataSource = ds.Tables[0];
           
        }

        private void phoneNo_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, false);
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, false);
            }
        }

        private void payAmount_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(lastDuedAmount_textBox.Text);
                double c = Convert.ToDouble(payAmount_textBox.Text);
                a = a - c;
                if (a >= 0)
                {
                    paymentDue_textBox.Text = a.ToString();
                }
                else
                {
                    paymentDue_textBox.Text = "Negetive balance";
                }
            }
            catch
            {
                paymentDue_textBox.Clear();
            }
        }

        private void clientHistoryMetroGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                paymentInvoiceNotextBox.Text = clientHistoryMetroGrid.CurrentRow.Cells[0].Value.ToString();
                paymentClientNametextBox.Text = clientHistoryMetroGrid.CurrentRow.Cells[1].Value.ToString();
                paymentAddresstextBox.Text = clientHistoryMetroGrid.CurrentRow.Cells[2].Value.ToString();
                paymentPhoneNotextBox.Text = clientHistoryMetroGrid.CurrentRow.Cells[3].Value.ToString();
                lastPaidAmount_textBox.Text = clientHistoryMetroGrid.CurrentRow.Cells[4].Value.ToString();
                lastDuedAmount_textBox.Text = clientHistoryMetroGrid.CurrentRow.Cells[5].Value.ToString();
                lastPaidDate_textBox.Text = clientHistoryMetroGrid.CurrentRow.Cells[6].Value.ToString();
            }
            catch
            {

            }
        }

        private void payment_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (payAmount_textBox.Text != "" && paymentDue_textBox.Text != "Negetive balance")
                {
                    if (MessageBox.Show("Are you sure?", "Dued Amount Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        CreditHistory creditHistory = new CreditHistory();
                        creditHistory.invoiceNo = paymentInvoiceNotextBox.Text;
                        creditHistory.name = paymentClientNametextBox.Text;
                        creditHistory.address = paymentAddresstextBox.Text;
                        creditHistory.mobileNo = paymentPhoneNotextBox.Text;
                        creditHistory.cash = payAmount_textBox.Text;
                        creditHistory.due = paymentDue_textBox.Text;
                        creditHistory.date = dateTimePicker1.Text;
                        creditHistory.reference = userName;
                        account_Bo.setCreditHistory(creditHistory);
                        account_Bo.updateCreditHistoryBalance(creditHistory);
                        MessageBox.Show("Payment successfully done");


                        creditHistory.invoiceNo = paymentInvoiceNotextBox.Text;

                        paymentDue_textBox.Clear();
                        payAmount_textBox.Clear();
                        paymentAddresstextBox.Clear();
                        paymentClientNametextBox.Clear();
                        paymentDue_textBox.Clear();
                        paymentInvoiceNotextBox.Clear();
                        paymentPhoneNotextBox.Clear();
                        lastDuedAmount_textBox.Clear();
                        lastPaidAmount_textBox.Clear();
                        lastPaidDate_textBox.Clear();
                        DataSet ds = account_Bo.getCreditHistory(creditHistory);
                        clientHistoryMetroGrid.DataSource = ds.Tables[0];
                        

                    }
                }
                else
                {
                    MessageBox.Show("Please enter the correct format");
                }
            }
            catch
            {

            }
        }
    }
}
