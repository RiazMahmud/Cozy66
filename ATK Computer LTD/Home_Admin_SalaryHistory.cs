using BO;
using ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATK_Computer_LTD
{
    public partial class Home_Admin_SalaryHistory : Form
    {
        public Home_Admin_SalaryHistory()
        {
            InitializeComponent();
        }
        string userName = null;
     
        public void giveMemberUserName(string name)
        {
            userName = name;
        }
        int flag=0;
        public void indicator(int a)
        {
            flag = a;
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
        private void Home_Admin_SalaryHistory_Load(object sender, EventArgs e)
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

        private void Home_Admin_SalaryHistory_MouseMove(object sender, MouseEventArgs e)
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

        private void Home_Admin_SalaryHistory_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void last_dateTimePicker_CloseUp(object sender, EventArgs e)
        {
            string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\DB\Cozy66.MDF;Integrated Security=True"; 
            //string connString = @"Data Source=ATK-PC,49172;Network Library=DBMSSOCN;Initial Catalog=H:\APPSTICK_PROJECT\ATK COMPUTER LTD\ATK COMPUTER LTD\DATABASE.MDF;Integrated Security=True";
            //string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=Desktop-9knrbc7\data\DATABASE.MDF;Integrated Security=True"; 
            //string connString = @"Data Source=DESKTOP-9KNRBC7\SQLEXPRESS,49172;Network Library=DBMSSOCN;Initial Catalog=H:\APPSTICK_PROJECT\ATK COMPUTER LTD\ATK COMPUTER LTD\DATABASE.MDF;Integrated Security=True"; 
            SqlConnection conn = new SqlConnection(connString);
            if (flag == 1)
            {
                try
                {
                    
                    DataSet ds4 = new DataSet();
                    SqlCommand cmd2 = new SqlCommand("Select * from Advance Where Date Between '" + firstdateTimePicker.Text + "' and '" + last_dateTimePicker.Text + "' ", conn);
                    conn.Open();
                    SqlDataAdapter sdp2 = new SqlDataAdapter();
                    sdp2.SelectCommand = cmd2;
                    sdp2.Fill(ds4);
                    conn.Close();
                    historyGrid.DataSource = ds4.Tables[0];
                    double ser = 0;
                    for (int i = 0; i < historyGrid.Rows.Count; i++)
                    {
                        ser += Convert.ToDouble(historyGrid.Rows[i].Cells[2].Value.ToString());
                    }
                    label18.Text = ser.ToString() + " TK";
                    if (historyGrid.Rows.Count > 1)
                    {
                        total_label.Text = (historyGrid.Rows.Count).ToString() + " results found";
                    }
                    else if (historyGrid.Rows.Count == 1)
                    {
                        total_label.Text = "1 result found";
                    }
                    else
                    {
                        total_label.Text = "No result found";
                    }
                }
                catch
                {

                }
            }
            else
            {
                DataSet ds3 = new DataSet();

              
                string year = firstdateTimePicker.Value.Year.ToString();


              
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from SalaryHistory Where  Date Between'" + firstdateTimePicker.Text + "' and '" + last_dateTimePicker.Text + "'", conn);
                    conn.Open();
                    SqlDataAdapter sdp = new SqlDataAdapter();
                    sdp.SelectCommand = cmd;
                    sdp.Fill(ds3);
                    conn.Close();
                    historyGrid.DataSource = ds3.Tables[0];
                    double ser = 0;
                    for (int i = 0; i < historyGrid.Rows.Count; i++)
                    {
                        ser += Convert.ToDouble(historyGrid.Rows[i].Cells[9].Value.ToString());
                    }
                    label18.Text = ser.ToString() + " TK";
                    if (historyGrid.Rows.Count > 1)
                    {
                        total_label.Text = (historyGrid.Rows.Count).ToString() + " results found";
                    }
                    else if (historyGrid.Rows.Count == 1)
                    {
                        total_label.Text = "1 result found";
                    }
                    else
                    {
                        total_label.Text = "No result found";
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
