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
    public partial class Home_Admin_DayBook : Form
    {
        public Home_Admin_DayBook()
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
        Member member = new Member();
        private void Home_Admin_DayBook_Load(object sender, EventArgs e)
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
            catch
            {

            }
        }

        private void Home_Admin_DayBook_MouseMove(object sender, MouseEventArgs e)
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

        private void Ctrl_MouseLeve(object sender, EventArgs e)
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

        private void home_admin_main_panel_MouseMove_1(object sender, MouseEventArgs e)
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

        private void right_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void right_option_timer_Tick_1(object sender, EventArgs e)
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

        private void Home_Admin_DayBook_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void home_admin_main_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker3_CloseUp(object sender, EventArgs e)
        {
            //try
            //{
            //    DataSet ds = account_Bo.getProductForDayBook(dateTimePicker3.Text);
            //    entryProductGrid.DataSource = ds.Tables[0];
            //    entryResult_lbl.Text = entryProductGrid.Rows.Count.ToString();
            //    double a = 0;
            //    for (int i = 0; i < entryProductGrid.Rows.Count; i++)
            //    {
            //        a += Convert.ToDouble(entryProductGrid.Rows[i].Cells[13].Value.ToString());
            //    }
            //    entryPurchase_label.Text = a.ToString() + " TK";


            //    ds = account_Bo.getSoldProductForDayBook(dateTimePicker3.Text);
            //    soldProductGrid.DataSource = ds.Tables[0];
            //    soldResultlabel.Text = soldProductGrid.Rows.Count.ToString();
            //    a = 0;
            //    for (int i = 0; i < soldProductGrid.Rows.Count; i++)
            //    {
            //        a += Convert.ToDouble(soldProductGrid.Rows[i].Cells[16].Value.ToString());
            //    }
            //    totalProfit_label.Text = a.ToString() + " TK";


            //    ds = account_Bo.getExpenditure(dateTimePicker3.Text, dateTimePicker3.Text);
            //    expendituredataGridView.DataSource = ds.Tables[0];
            //    expenditure_label.Text = expendituredataGridView.Rows.Count.ToString();
            //    a = 0;
            //    for (int i = 0; i < expendituredataGridView.Rows.Count; i++)
            //    {
            //        a += Convert.ToDouble(expendituredataGridView.Rows[i].Cells[1].Value.ToString());
            //    }
            //    totalExxpenditure_label.Text = a.ToString() + " TK";

            //    try
            //    {
            //        ds = account_Bo.getReturnProductForDayBook(dateTimePicker3.Text);
            //        importer_dataGridView.DataSource = ds.Tables[0];
            //        return_label.Text = importer_dataGridView.Rows.Count.ToString();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }


            //    ds = account_Bo.getHardIncome(dateTimePicker3.Text, dateTimePicker3.Text);
            //    income_dataGridView.DataSource = ds.Tables[0];
            //    income_label.Text = income_dataGridView.Rows.Count.ToString();
            //    a = 0;
            //    for (int i = 0; i < income_dataGridView.Rows.Count; i++)
            //    {
            //        a += Convert.ToDouble(income_dataGridView.Rows[i].Cells[1].Value.ToString());
            //    }
            //    servicingIncomelabel.Text = a.ToString() + " TK";

            //    ds = account_Bo.getAllLedger(dateTimePicker3.Text);
            //    dayBook_dataGridView.DataSource = ds.Tables[0];
            //    daybook_label.Text = dayBook_dataGridView.Rows.Count.ToString();
            //}
            //catch
            //{

            //}
        }
    }
}
