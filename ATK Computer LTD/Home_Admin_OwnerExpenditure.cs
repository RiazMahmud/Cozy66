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
    public partial class Home_Admin_OwnerExpenditure : Form
    {
        public Home_Admin_OwnerExpenditure()
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
        private void Home_Admin_OwnerExpenditure_Load(object sender, EventArgs e)
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

        private void Home_Admin_OwnerExpenditure_MouseMove(object sender, MouseEventArgs e)
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

        private void Home_Admin_OwnerExpenditure_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            expendituredateTimePicker.ResetText();
            expenditureAmount_Txtbox.Clear();
            expenditureDescription_Txtbox.Clear();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(expenditureAmount_Txtbox.Text!= ""&& expenditureDescription_Txtbox.Text !="")
                {
                    Expenditure expenditure = new Expenditure();
                    expenditure.date = expendituredateTimePicker.Text;
                    expenditure.amount = expenditureAmount_Txtbox.Text;
                    expenditure.description = expenditureDescription_Txtbox.Text;
                    if (MessageBox.Show("Are you sure?", "Add Expenditure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (account_Bo.setExpenditure(expenditure))
                        {
                            MessageBox.Show("Expenditure entry succefully done");
                            expendituredateTimePicker.ResetText();
                            expenditureAmount_Txtbox.Clear();
                            expenditureDescription_Txtbox.Clear();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter the information fully");
                }
            }
            catch
            {

            }
        }

        private void search_dateRamge(object sender, EventArgs e)
        {
           
        
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void Search_daterange(object sender, EventArgs e)
        {
            try
            {
                expenditureMetroGrid.DataSource = "";
                DataSet ds = account_Bo.getExpenditure(firstdateTimePicker.Text,last_dateTimePicker.Text);
                expenditureMetroGrid.DataSource = ds.Tables[0];
                if (expenditureMetroGrid.Rows.Count > 1)
                {
                    Mlabel.Text = (expenditureMetroGrid.Rows.Count).ToString() + " results found";
                }
                else if (expenditureMetroGrid.Rows.Count == 1)
                {
                    Mlabel.Text = "1 result found";
                }
                else
                {
                    Mlabel.Text = "No result found";
                }
                double amount = 0;
                for (int i = 0; i < expenditureMetroGrid.Rows.Count; i++)
                {
                    amount += Convert.ToDouble(expenditureMetroGrid.Rows[i].Cells[1].Value.ToString());
                }
                amount_label.Text = "Total " + amount.ToString() + " TK";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteAllRecords_btn_Click(object sender, EventArgs e)
        {

        }

        private void home_admin_main_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
