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
    public partial class Home_Admin_IncomeStatement : Form
    {
        public Home_Admin_IncomeStatement()
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

        private void Home_Admin_IncomeStatement_Load(object sender, EventArgs e)
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

        private void Home_Admin_IncomeStatement_MouseMove(object sender, MouseEventArgs e)
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

        private void Home_Admin_IncomeStatement_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void firstdateTimePicker_CloseUp(object sender, EventArgs e)
        {
            //try
            //{
            //    double b1 = 0;
            //    double b2 = 0;
            //    double b3 = 0;
            //    double b4 = 0;

            //    DataSet ds2 = account_Bo.getCreditHistoryBalance(firstdateTimePicker.Text, last_dateTimePicker.Text);
            //    duedHistorydataGridView.DataSource = ds2.Tables[0];

            //    if (duedHistorydataGridView.Rows.Count > 1)
            //    {

            //        invoice_label.Text = (duedHistorydataGridView.Rows.Count).ToString();
            //    }
            //    else if (duedHistorydataGridView.Rows.Count == 1)
            //    {
            //        invoice_label.Text = "1";
            //    }
            //    else
            //    {
            //        invoice_label.Text = "0";
            //    }
            //    double a = 0;
            //    for (int i = 0; i < duedHistorydataGridView.Rows.Count; i++)
            //    {
            //        a += Convert.ToDouble(duedHistorydataGridView.Rows[i].Cells[1].Value.ToString());
            //    }
            //    dued_label.Text = a.ToString();
            //    b1 = a;

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
            //    servicing_label.Text = ser.ToString() + " TK";
            //    pro_label.Text = profit.ToString() + " TK";
            //    b4 = profit;


            //    DataSet ds3 = new DataSet();
            //    string connString = @"Data Source=ATK-PC,49172;Network Library=DBMSSOCN;Initial Catalog=H:\APPSTICK_PROJECT\ATK COMPUTER LTD\ATK COMPUTER LTD\DATABASE.MDF;Integrated Security=True";
            //    //string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=Desktop-9knrbc7\data\DATABASE.MDF;Integrated Security=True"; 
            //    //string connString = @"Data Source=DESKTOP-9KNRBC7\SQLEXPRESS,49172;Network Library=DBMSSOCN;Initial Catalog=H:\APPSTICK_PROJECT\ATK COMPUTER LTD\ATK COMPUTER LTD\DATABASE.MDF;Integrated Security=True"; 
            //    string year = firstdateTimePicker.Value.Year.ToString();
               
               
            //    SqlConnection conn = new SqlConnection(connString);
            //    try
            //    {
            //        SqlCommand cmd = new SqlCommand("Select UserName,TotalAttendence,TotalSalary from SalaryHistory Where  Date Between'" + firstdateTimePicker.Text + "' and '" + last_dateTimePicker.Text + "'", conn);
            //        conn.Open();
            //        SqlDataAdapter sdp = new SqlDataAdapter();
            //        sdp.SelectCommand = cmd;
            //        sdp.Fill(ds3);
            //        conn.Close();
            //        dataGridView2.DataSource = ds3.Tables[0];
            //        ser = 0;
            //        for (int i = 0; i < dataGridView2.Rows.Count; i++)
            //        {
            //            ser += Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value.ToString());
            //        }
            //        label18.Text = ser.ToString() + " TK";
            //        b2 = 0;
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }

            //    DataSet ds4 = new DataSet();
            //    SqlCommand cmd2 = new SqlCommand("Select * from Advance Where Date Between '" + firstdateTimePicker.Text + "' and '" + last_dateTimePicker.Text + "' ", conn);
            //    conn.Open();
            //    SqlDataAdapter sdp2 = new SqlDataAdapter();
            //    sdp2.SelectCommand = cmd2;
            //    sdp2.Fill(ds4);
            //    conn.Close();
            //    dataGridView3.DataSource = ds4.Tables[0];
            //    ser = 0;
            //    for (int i = 0; i < dataGridView3.Rows.Count; i++)
            //    {
            //        ser += Convert.ToDouble(dataGridView3.Rows[i].Cells[2].Value.ToString());
            //    }
            //    label22.Text = ser.ToString() + " TK";
              


            //    DataSet ds5 = new DataSet();
            //    SqlCommand cmd5 = new SqlCommand("Select * from Expenditure Where Date Between '" + firstdateTimePicker.Text + "' and '" + last_dateTimePicker.Text + "' ", conn);
            //    conn.Open();
            //    SqlDataAdapter sdp5 = new SqlDataAdapter();
            //    sdp5.SelectCommand = cmd5;
            //    sdp5.Fill(ds5);
            //    conn.Close();
            //    dataGridView1.DataSource = ds5.Tables[0];
            //    ser = 0;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        ser += Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value.ToString());
            //    }
            //    label19.Text = ser.ToString() + " TK";

            //    label30.Text = pro_label.Text;
            //    label29.Text = dued_label.Text;
            //    label24.Text = label19.Text;
            //    label34.Text = label18.Text;
            //    label35.Text = label22.Text;
            //    b3 = ser;
               
              

               
            //    b4 = b4 - (b1 + b2 + b3);
            //    incomelabel.Text = b4.ToString()+" TK";
            //}
            //catch
            //{
                
            //}
        }

        private void last_dateTimePicker_CloseUp(object sender, EventArgs e)
        {
            try
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


                expenditureMetroGrid.DataSource = "";
                ds = account_Bo.getExpenditure(firstdateTimePicker.Text, last_dateTimePicker.Text);
                expenditureMetroGrid.DataSource = ds.Tables[0];

                double amount = 0;
                for (int i = 0; i < expenditureMetroGrid.Rows.Count; i++)
                {
                    amount += Convert.ToDouble(expenditureMetroGrid.Rows[i].Cells[1].Value.ToString());
                }
                expenditure_label.Text = "Total " + amount.ToString() + " TK";

                amount = profit - amount;
                netProfit_label.Text = amount.ToString() + " TK";

            }
            catch
            {

            }
        }
    }
}
