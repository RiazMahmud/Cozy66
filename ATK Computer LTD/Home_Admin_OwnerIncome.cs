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
using BO;
using System.IO;
namespace ATK_Computer_LTD
{
    public partial class Home_Admin_OwnerIncome : Form
    {
        public Home_Admin_OwnerIncome()
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

        private void Home_Admin_OwnerIncome_MouseMove(object sender, MouseEventArgs e)
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
        Member member = new Member();
        private void Home_Admin_OwnerIncome_Load(object sender, EventArgs e)
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


            }
            catch (Exception ex)
            {

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

            else if (sender == exit_pnl)
            {
                Application.Exit();
            }
            else if (sender == minimized_pnl)
            {
                right_option_timer.Stop();
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void Home_Admin_OwnerIncome_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            //expendituredateTimePicker.ResetText();
            //expenditureAmount_Txtbox.Clear();
            //expenditureDescription_Txtbox.Clear();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (expenditureAmount_Txtbox.Text != "" && expenditureDescription_Txtbox.Text != "")
            //    {
            //        Expenditure expenditure = new Expenditure();
            //        expenditure.date = expendituredateTimePicker.Text;
            //        expenditure.amount = expenditureAmount_Txtbox.Text;
            //        expenditure.description = expenditureDescription_Txtbox.Text;
            //        if (MessageBox.Show("Are you sure?", "Add Income", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //        {
            //            if (account_Bo.setHardwareIncome(expenditure))
            //            {
            //                MessageBox.Show("Servicing income entry succefully done");
            //                expendituredateTimePicker.ResetText();
            //                expenditureAmount_Txtbox.Clear();
            //                expenditureDescription_Txtbox.Clear();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Enter the information fully");
            //    }
            //}
            //catch
            //{

            //}
        }

        private void serachDateRange(object sender, EventArgs e)
        {
            //try
            //{
            //    expenditureMetroGrid.DataSource = "";
            //    DataSet ds = account_Bo.getHardIncome(firstdateTimePicker.Text, last_dateTimePicker.Text);
            //    expenditureMetroGrid.DataSource = ds.Tables[0];

            //    DataSet ds1 = account_Bo.getAllSoldProduct(firstdateTimePicker.Text, last_dateTimePicker.Text);
            //    productMetroGrid2.DataSource = ds1.Tables[0];

            //    if (productMetroGrid2.Rows.Count > 1)
            //    {
            //        totalProductlabel.Text = (productMetroGrid2.Rows.Count).ToString();
            //    }
            //    else if (productMetroGrid2.Rows.Count == 1)
            //    {
            //        totalProductlabel.Text = "1";
            //    }
            //    else
            //    {
            //        totalProductlabel.Text = "0";
            //    }
            //    double p_amount = 0;
            //    double s_amount = 0;
            //    double profit = 0;
            //    double ser = 0;
            //    for (int i = 0; i < productMetroGrid2.Rows.Count; i++)
            //    {
            //        p_amount += Convert.ToDouble(productMetroGrid2.Rows[i].Cells[14].Value.ToString());
            //        s_amount += Convert.ToDouble(productMetroGrid2.Rows[i].Cells[15].Value.ToString());
            //        profit += Convert.ToDouble(productMetroGrid2.Rows[i].Cells[16].Value.ToString());
            //    }
            //    for (int i = 0; i < expenditureMetroGrid.Rows.Count; i++)
            //    {
            //        ser += Convert.ToDouble(expenditureMetroGrid.Rows[i].Cells[1].Value.ToString());
            //    }
            //    pp_label.Text = profit.ToString() + " TK";
            //    profit += ser;
            //    p_label.Text = p_amount.ToString() + " TK";
            //    s_label.Text = s_amount.ToString() + " TK";
            //    servicing_label.Text = ser.ToString()+" TK";
            //    pro_label.Text = profit.ToString() + " TK";

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void expenditureAmount_Txtbox_KeyDown(object sender, KeyEventArgs e)
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

        private void firstdateTimePicker_CloseUp(object sender, EventArgs e)
        {
            DataSet ds = account_Bo.getAllSoldProduct(firstdateTimePicker.Text, last_dateTimePicker.Text);
            productMetroGrid2.DataSource = ds.Tables[0];

            if (productMetroGrid2.Rows.Count > 1)
            {
                totalProductlabel.Text = (productMetroGrid2.Rows.Count).ToString();
            }
            else if (productMetroGrid2.Rows.Count == 1)
            {
                totalProductlabel.Text = "1";
            }
            else
            {
                totalProductlabel.Text = "0";
            }
            double p_amount = 0;
            double s_amount = 0;
            double profit = 0;

            for (int i = 0; i < productMetroGrid2.Rows.Count; i++)
            {
                p_amount += Convert.ToDouble(productMetroGrid2.Rows[i].Cells[8].Value.ToString());
                s_amount += Convert.ToDouble(productMetroGrid2.Rows[i].Cells[9].Value.ToString());
                profit += Convert.ToDouble(productMetroGrid2.Rows[i].Cells[10].Value.ToString());
            }
            p_label.Text = p_amount.ToString() + " TK";
            s_label.Text = s_amount.ToString() + " TK";
            pro_label.Text = profit.ToString() + " TK";
        }
    }
}
