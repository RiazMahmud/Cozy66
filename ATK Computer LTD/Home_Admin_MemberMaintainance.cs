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
using System.Data.SqlClient;
namespace ATK_Computer_LTD
{
    public partial class Home_Admin_MemberMaintainance : Form
    {
        public Home_Admin_MemberMaintainance()
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

        private void Home_Admin_MemberMaintainance_MouseMove(object sender, MouseEventArgs e)
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
        Member member = new Member();
        private void Home_Admin_MemberMaintainance_Load(object sender, EventArgs e)
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
        string imagePath;
        private void serachMembertextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                signUpPictureBox.Visible = true;
                Account_BO ab = new Account_BO();
                member = ab.getMember(serachMembertextBox.Text);
                
                MemoryStream ms = new MemoryStream(member.image);
                signUpFirstNamemetroTextBox.Text = member.firstName;
                signUpLastNamemetroTextBox.Text = member.lastName;
               
                signUpEmailmetroTextBox.Text = member.email;
                signUpPhoneNoMetroTextBox.Text = member.phoneNo;
                signUpPictureBox.Image = Image.FromStream(ms);
                signUpSalarytextBox.Text = member.salary;
               

            }
            catch
            {
               
                signUpFirstNamemetroTextBox.Clear();
                signUpLastNamemetroTextBox.Clear();              
                signUpEmailmetroTextBox.Clear();
                imagePath = "";

                signUpPictureBox.Visible = false;
                signUpPhoneNoMetroTextBox.Clear();
                signUpSalarytextBox.Clear();
                attendenceMetroGrid.DataSource = "";
                Attendence_Label.ResetText();
            }
        }

        private void Home_Admin_MemberMaintainance_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void giveAttendence_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (serachMembertextBox.Text != "" && signUpFirstNamemetroTextBox.Text != "")
                {
                    if (MessageBox.Show("Are you sure?", "Give Attendence Member", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        member.userName = serachMembertextBox.Text;
                        member.attendenceDate = dateTimePicker3.Text;
                        member.attendenceStatus = "P";
                        if (account_Bo.setMemberAttendence(member))
                        {
                            MessageBox.Show("Attendence added successfully done");
                        }
                        else
                        {
                            MessageBox.Show("Today's attendence is already added");
                        }

                    }
                }

                else
                {
                    MessageBox.Show("Please enter the userName first");
                }
            }
            catch
            {
                MessageBox.Show("Today's attendence is already added");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                attendenceMetroGrid.DataSource = "";
                Attendence_Label.ResetText();
                if (serachMembertextBox.Text != "" && signUpFirstNamemetroTextBox.Text != "")
                {
                    int pos = 0;
                    StringBuilder sb = new StringBuilder(dateTimePicker3.Text);
                    for (int i = sb.Length-1; i > 0; i--)
                    {
                        if (sb[i].ToString() == "/")
                        {
                            pos = i;
                            break;
                        }
                    }
                  
                    sb.Remove(pos+1, 2);
                    sb.Insert(pos + 1, "0");
                    sb.Insert(pos + 2, "0");
                    member.attendenceDate = sb.ToString();
                    member.userName = serachMembertextBox.Text;


                    DataSet ds = account_Bo.getMemberAttendenceOfTheCurrentMonth(member,dateTimePicker3.Text);

                    attendenceMetroGrid.DataSource = ds.Tables[0];
                   
                    int j = attendenceMetroGrid.Rows.Count;
                    if (j == 0)
                    {
                        Attendence_Label.Text = "0 day";
                    }
                    else if (j == 1)
                    {
                        Attendence_Label.Text = "1 day";
                    }
                    else
                    {
                        Attendence_Label.Text = attendenceMetroGrid.Rows.Count.ToString()+" days";
                    }
                }
                else
                {
                    MessageBox.Show("Please select a member first");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Date_Changed(object sender, EventArgs e)
        {
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void valueChange(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void SelectDate(object sender, EventArgs e)
        {
            try
            {
                attendenceMetroGrid.DataSource = "";
                Attendence_Label.ResetText();
                if (serachMembertextBox.Text != "" && signUpFirstNamemetroTextBox.Text != "")
                {
                    member.userName = serachMembertextBox.Text;
                    member.attendenceDate = dateTimePicker1.Text;
                    DataSet ds = account_Bo.getMemberAttendenceOfTheCurrentMonth(member, dateTimePicker2.Text);

                    attendenceMetroGrid.DataSource = ds.Tables[0];
                   
                    int j = attendenceMetroGrid.Rows.Count;
                    if (j == 0)
                    {
                        Attendence_Label.Text = "0 day";
                    }
                    else if (j == 1)
                    {
                        Attendence_Label.Text = "1 day";
                    }
                    else
                    {
                        int date = Convert.ToInt32(attendenceMetroGrid.Rows.Count.ToString());
                        Attendence_Label.Text =  date.ToString()+ " days";
                    }
                }
                else
                {
                    MessageBox.Show("Please select a member first");

                }
            }
            catch
            {

            }
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, false);
              
                signUpEmailmetroTextBox.AutoCompleteCustomSource.Add(signUpEmailmetroTextBox.Text);
                signUpFirstNamemetroTextBox.AutoCompleteCustomSource.Add(signUpFirstNamemetroTextBox.Text);
                signUpLastNamemetroTextBox.AutoCompleteCustomSource.Add(signUpLastNamemetroTextBox.Text);
                signUpPhoneNoMetroTextBox.AutoCompleteCustomSource.Add(signUpPhoneNoMetroTextBox.Text);
                signUpSalarytextBox.AutoCompleteCustomSource.Add(signUpSalarytextBox.Text);
                serachMembertextBox.AutoCompleteCustomSource.Add(serachMembertextBox.Text);


            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, false);
             
                signUpEmailmetroTextBox.AutoCompleteCustomSource.Add(signUpEmailmetroTextBox.Text);
                signUpFirstNamemetroTextBox.AutoCompleteCustomSource.Add(signUpFirstNamemetroTextBox.Text);
                signUpLastNamemetroTextBox.AutoCompleteCustomSource.Add(signUpLastNamemetroTextBox.Text);
                signUpPhoneNoMetroTextBox.AutoCompleteCustomSource.Add(signUpPhoneNoMetroTextBox.Text);
                signUpSalarytextBox.AutoCompleteCustomSource.Add(signUpSalarytextBox.Text);
                serachMembertextBox.AutoCompleteCustomSource.Add(serachMembertextBox.Text);

               
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void giveAdvance_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (serachMembertextBox.Text != "" && signUpFirstNamemetroTextBox.Text != "")
                {
                    if (advanceAmounttextBox.Text != "" && advanceCause_textBox.Text != "")
                    {
                        if (MessageBox.Show("Are you sure?", "Give Advance to Member", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            Advance advance = new Advance();
                            advance.date = advance_dateTimePicker.Text;
                            advance.amount = advanceAmounttextBox.Text;
                            advance.cause = advanceCause_textBox.Text;
                            advance.userName = serachMembertextBox.Text;
                            advance.reference = userName;

                            if (account_Bo.setMemberAdvance(advance))
                            {
                                MessageBox.Show("Advance given successfully done");
                                advanceAmounttextBox.Clear();
                                advanceCause_textBox.Clear();
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Please enter the information fully");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a member first");

                }
            }
            catch
            {
                MessageBox.Show("Error");
                advanceAmounttextBox.Clear();
                advanceCause_textBox.Clear();
            }
        }
        string month = null;
        private void salaryYearAndMonth(object sender, EventArgs e)
        {
            try
            {
                if (signUpFirstNamemetroTextBox.Text != "")
                {
                    string month = null;
                    if (month_comboBox.Text == "January")
                    {
                        month = "01";
                    }
                    else if (month_comboBox.Text == "February")
                    {
                        month = "02";
                    }
                    else if (month_comboBox.Text == "March")
                    {
                        month = "03";
                    }
                    else if (month_comboBox.Text == "April")
                    {
                        month = "04";
                    }
                    else if (month_comboBox.Text == "May")
                    {
                        month = "05";
                    }
                    else if (month_comboBox.Text == "June")
                    {
                        month = "06";
                    }
                    else if (month_comboBox.Text == "July")
                    {
                        month = "07";
                    }
                    else if (month_comboBox.Text == "August")
                    {
                        month = "08";
                    }
                    else if (month_comboBox.Text == "September")
                    {
                        month = "09";
                    }
                    else if (month_comboBox.Text == "October")
                    {
                        month = "10";
                    }
                    else if (month_comboBox.Text == "November")
                    {
                        month = "11";
                    }
                    else if (month_comboBox.Text == "December")
                    {
                        month = "12";
                    }

                    totalDays = DateTime.DaysInMonth(Convert.ToInt32(year_comboBox.Text), Convert.ToInt32(month));
                    StringBuilder sb = new StringBuilder();
                    StringBuilder sb1 = new StringBuilder();
                    sb.Append(year_comboBox.Text + "/" + month + "/00");

                    int m = DateTime.DaysInMonth(Convert.ToInt32(year_comboBox.Text), Convert.ToInt32(month));
                    sb1.Append(year_comboBox.Text + "/" + month + "/" + m.ToString());

                    member.attendenceDate = sb.ToString();
                    member.userName = serachMembertextBox.Text;


                    DataSet ds = account_Bo.getMemberAttendenceOfTheCurrentMonth(member, sb1.ToString());
                    attendenceMetroGrid.DataSource = ds.Tables[0];
                    totalAttendence_textBox.Text = ds.Tables[0].Rows.Count.ToString();
                    basicSalary_textBox.Text = signUpSalarytextBox.Text;

                    ds = account_Bo.getMemberAdvanceOfTheCurrentMonth(member, sb1.ToString());
                    dataGridView1.DataSource = ds.Tables[0];
                    ds = account_Bo.getProfitForsalary(sb.ToString(), sb1.ToString(), serachMembertextBox.Text);
                    dataGridView2.DataSource = ds.Tables[0];
                    double a = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        a += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    }
                    double b = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        b += Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    }
                    dataGridView2.DataSource = "";
                    //ds = account_Bo.getAllSoldProductForSalary(sb.ToString(), sb1.ToString(), serachMembertextBox.Text);
                    //dataGridView2.DataSource = ds.Tables[0];
                    //double c = 0;
                    //for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    //{
                    //    c += Convert.ToDouble(dataGridView2.Rows[i].Cells[16].Value.ToString());
                    //}
                    productSell_textBox.Text = b.ToString();
                    recievedadvance_textBox.Text = a.ToString();


                }
                else
                {
                    MessageBox.Show("Please select a member first");
                    year_comboBox.ResetText();
                    month_comboBox.ResetText();
                }
            }
            catch
            {

            }
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            month_comboBox.ResetText();
            year_comboBox.ResetText();
            basicSalary_textBox.Clear();
            totalAttendence_textBox.Clear();
            recievedadvance_textBox.Clear();
            totalTobePaid_textBox.Clear();
          
            festivalBonus_comboBox.ResetText();
            
            sell_comboBox.ResetText();
            productSell_textBox.Clear();
        }

        private void year_comboBox_TextUpdate(object sender, EventArgs e)
        {

        }

        private void syear_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
        int totalDays;
        
        private void salary(object sender, EventArgs e)
        {
            try
            {
                if (signUpFirstNamemetroTextBox.Text != "")
                {
                   
                    if (month_comboBox.Text == "January")
                    {
                        month = "01";
                    }
                    else if (month_comboBox.Text == "February")
                    {
                        month = "02";
                    }
                    else if (month_comboBox.Text == "March")
                    {
                        month = "03";
                    }
                    else if (month_comboBox.Text == "April")
                    {
                        month = "04";
                    }
                    else if (month_comboBox.Text == "May")
                    {
                        month = "05";
                    }
                    else if (month_comboBox.Text == "June")
                    {
                        month = "06";
                    }
                    else if (month_comboBox.Text == "July")
                    {
                        month = "07";
                    }
                    else if (month_comboBox.Text == "August")
                    {
                        month = "08";
                    }
                    else if (month_comboBox.Text == "September")
                    {
                        month = "09";
                    }
                    else if (month_comboBox.Text == "October")
                    {
                        month = "10";
                    }
                    else if (month_comboBox.Text == "November")
                    {
                        month = "11";
                    }
                    else if (month_comboBox.Text == "December")
                    {
                        month = "12";
                    }

                    totalDays = DateTime.DaysInMonth(Convert.ToInt32(year_comboBox.Text), Convert.ToInt32(month));
                    StringBuilder sb = new StringBuilder();
                    StringBuilder sb1 = new StringBuilder();
                    sb.Append(year_comboBox.Text + "/" + month + "/00");

                    int m = DateTime.DaysInMonth(Convert.ToInt32(year_comboBox.Text), Convert.ToInt32(month));
                    sb1.Append(year_comboBox.Text + "/" + month + "/" + m.ToString());

                    member.attendenceDate = sb.ToString();
                    member.userName = serachMembertextBox.Text;


                    DataSet ds = account_Bo.getMemberAttendenceOfTheCurrentMonth(member, sb1.ToString());
                    attendenceMetroGrid.DataSource = ds.Tables[0];
                    totalAttendence_textBox.Text = ds.Tables[0].Rows.Count.ToString();
                    basicSalary_textBox.Text = signUpSalarytextBox.Text;

                    ds = account_Bo.getMemberAdvanceOfTheCurrentMonth(member, sb1.ToString());
                    dataGridView1.DataSource = ds.Tables[0];
                    ds = account_Bo.getProfitForsalary(sb.ToString(), sb1.ToString(),serachMembertextBox.Text);
                    dataGridView2.DataSource = ds.Tables[0];
                    double a = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        a += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    }
                    double b = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        b += Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    }
                    dataGridView2.DataSource = "";
                    //ds = account_Bo.getAllSoldProductForSalary(sb.ToString(), sb1.ToString(), serachMembertextBox.Text);
                    //dataGridView2.DataSource = ds.Tables[0];
                    //double c = 0;
                    //for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    //{
                    //    c += Convert.ToDouble(dataGridView2.Rows[i].Cells[16].Value.ToString());
                    //}
                    productSell_textBox.Text = b.ToString();
                    recievedadvance_textBox.Text = a.ToString();
                  

                }
                else
                {
                    MessageBox.Show("Please select a member first");
                    year_comboBox.ResetText();
                    month_comboBox.ResetText();
                }
            }
            catch
            {
                
            }
        }

        private void bonus(object sender, EventArgs e)
        {
           
        }

        private void SalaryTobePaid(object sender, EventArgs e)
        {
            try
            {
                double b = Convert.ToDouble(basicSalary_textBox.Text);
                double b1 = b;
                b /= totalDays;
                b *= Convert.ToDouble(totalAttendence_textBox.Text);
                double increment;

                double f = Convert.ToDouble(festivalBonus_comboBox.Text);
                //double s = Convert.ToDouble(servicingBonus_comboBox.Text);
                double se = Convert.ToDouble(sell_comboBox.Text);
                double advance = Convert.ToDouble(recievedadvance_textBox.Text);
                double ps = Convert.ToDouble(productSell_textBox.Text);
                //double t = Convert.ToDouble(totalservicingAmount_textBox.Text);

                f = f / 100;
                //s = s / 100;
                se = se / 100;
                increment = (b1 * f) + (ps * se);
                b -= advance;
                b += increment;
                totalTobePaid_textBox.Text = b.ToString();
            }
            catch
            {

            }
        }

        private void sell_comboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double b = Convert.ToDouble(basicSalary_textBox.Text);
                double b1 = b;
                b /= totalDays;
                b *= Convert.ToDouble(totalAttendence_textBox.Text);
                double increment;

                double f = Convert.ToDouble(festivalBonus_comboBox.Text);
                //double s = Convert.ToDouble(servicingBonus_comboBox.Text);
                double se = Convert.ToDouble(sell_comboBox.Text);
                double advance = Convert.ToDouble(recievedadvance_textBox.Text);
                double ps = Convert.ToDouble(productSell_textBox.Text);
                //double t = Convert.ToDouble(totalservicingAmount_textBox.Text);

                f = f / 100;
                //s = s / 100;
                se = se / 100;
                increment = (b1 * f) + (ps * se);
                b -= advance;
                b += increment;
                totalTobePaid_textBox.Text = b.ToString();
            }
            catch
            {

            }
        }

        private void giveSalary_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (serachMembertextBox.Text != "" && signUpFirstNamemetroTextBox.Text != "")
                {
                    if (year_comboBox.Text != "" && month_comboBox.Text != "")
                    {
                        if (MessageBox.Show("Are you sure?", "Give Member Salary", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            SalaryHistory salaryHistory = new SalaryHistory();
                            salaryHistory.UserName = serachMembertextBox.Text;
                            salaryHistory.year = year_comboBox.Text;
                            salaryHistory.month = month_comboBox.Text;
                            salaryHistory.recieveAdvance = recievedadvance_textBox.Text;
                            salaryHistory.basicSalary = basicSalary_textBox.Text;
                            salaryHistory.totalAttendence = totalAttendence_textBox.Text;
                            //salaryHistory.servicingAmount = totalservicingAmount_textBox.Text;
                            salaryHistory.prouctSellProfitAmount = productSell_textBox.Text;
                            salaryHistory.festivalBonus = festivalBonus_comboBox.Text;
                            //salaryHistory.servicingBonus = servicingBonus_comboBox.Text;
                            salaryHistory.sellBonus = sell_comboBox.Text;
                            salaryHistory.totalsalary = totalTobePaid_textBox.Text;

                            try
                            {
                                totalDays = DateTime.DaysInMonth(Convert.ToInt32(year_comboBox.Text), Convert.ToInt32(month_comboBox));
                            }
                            catch
                            {

                            }
                             salaryHistory.date = year_comboBox.Text +"/"+ month+"/"+ totalDays.ToString();
                            // MessageBox.Show(salaryHistory.year+"    "+salaryHistory.month+"    "+salaryHistory.UserName+"  "+salaryHistory.totalAttendence+ "   "+salaryHistory.basicSalary+"  "+salaryHistory.recieveAdvance+"    "+salaryHistory.servicingAmount+"   "+salaryHistory.prouctSellProfitAmount+"    "+salaryHistory.servicingBonus+"    "+salaryHistory.festivalBonus+"     "+salaryHistory.sellBonus+" "+salaryHistory.totalsalary+"   "+salaryHistory.date);
                            if(account_Bo.setSalaryHistory(salaryHistory))
                            {
                                //string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\DB\Database.mdf;Integrated Security=True";
                                //SqlConnection conn = new SqlConnection(connString);
                                //SqlCommand cmd = new SqlCommand("Insert into SalaryHistory values('"+year_comboBox.Text+"','"+month_comboBox.Text+"','"+serachMembertextBox.Text+"','"+totalAttendence_textBox.Text+"','"+basicSalary_textBox.Text+"','"+recievedadvance_textBox.Text+"','"+ totalservicingAmount_textBox.Text+"','"+productSell_textBox.Text+"','"+servicingBonus_comboBox.Text+"','"+festivalBonus_comboBox.Text+"','"+sell_comboBox.Text+"','"+totalTobePaid_textBox.Text+"','"+date+"')", conn);
                                //conn.Open();
                                //cmd.ExecuteNonQuery();
                                //conn.Close();
                               
                                MessageBox.Show("Salary paid successfully done");
                               
                                   
                                Expenditure expenditure = new Expenditure();
                                expenditure.date = dateTimePicker3.Text;
                                expenditure.amount = totalTobePaid_textBox.Text;
                                expenditure.description = "MemberSalary";
                                account_Bo.setExpenditure(expenditure);
                                       
                                month_comboBox.ResetText();
                                year_comboBox.ResetText();
                                basicSalary_textBox.Clear();
                                totalAttendence_textBox.Clear();
                                recievedadvance_textBox.Clear();
                                totalTobePaid_textBox.Clear();
                                //servicingBonus_comboBox.ResetText();
                                festivalBonus_comboBox.ResetText();
                               // totalservicingAmount_textBox.Clear();
                                sell_comboBox.ResetText();
                                productSell_textBox.Clear();
                               
                            }
                            else
                            {
                                MessageBox.Show("Already paid");
                                month_comboBox.ResetText();
                                year_comboBox.ResetText();
                                basicSalary_textBox.Clear();
                                totalAttendence_textBox.Clear();
                                recievedadvance_textBox.Clear();
                                totalTobePaid_textBox.Clear();
                                //servicingBonus_comboBox.ResetText();
                                festivalBonus_comboBox.ResetText();
                                //totalservicingAmount_textBox.Clear();
                                sell_comboBox.ResetText();
                                productSell_textBox.Clear();
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Please enter the information fully");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a member first");

                }
            }
            catch
            {
                MessageBox.Show("Already paid");
                month_comboBox.ResetText();
                year_comboBox.ResetText();
                basicSalary_textBox.Clear();
                totalAttendence_textBox.Clear();
                recievedadvance_textBox.Clear();
                totalTobePaid_textBox.Clear();
                //servicingBonus_comboBox.ResetText();
                festivalBonus_comboBox.ResetText();
                //totalservicingAmount_textBox.Clear();
                sell_comboBox.ResetText();
                productSell_textBox.Clear();
            }
        }

        private void KeyDown2(object sender, KeyEventArgs e)
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

        private void viewAdvance_button_Click(object sender, EventArgs e)
        {
            if (serachMembertextBox.Text != "" && signUpFirstNamemetroTextBox.Text != "")
            {
                Home_Admin_MemberSalaryAndAdvanceHistory hs = new Home_Admin_MemberSalaryAndAdvanceHistory();
                hs.giveMemberUserName(userName, serachMembertextBox.Text);
                hs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a member first");
            }

        }

        private void salaryHistory_button_Click(object sender, EventArgs e)
        {
            if (serachMembertextBox.Text != "" && signUpFirstNamemetroTextBox.Text != "")
            {
                Home_Admin_MemberSalaryAndAdvanceHistory hs = new Home_Admin_MemberSalaryAndAdvanceHistory();
                hs.giveMemberUserName(userName,serachMembertextBox.Text);
                hs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a member first");
            }
        }

       
    }
}
