using BO;
using ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATK_Computer_LTD
{
    public partial class Home_Admin_AddClient : Form
    {
        public Home_Admin_AddClient()
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

        private void Home_Admin_ClientMaintainance_Load(object sender, EventArgs e)
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

        private void Home_Admin_ClientMaintainance_MouseMove(object sender, MouseEventArgs e)
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

        private void Home_Admin_ClientMaintainance_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            client_AdminPasswordtextBox.Clear();
            client_AdminUserNametextBox.Clear();
            clientAddress_Textbox.Clear();
            clientAge_textBox.Clear();
            clientDOB_datetimePicker.ResetText();
            clientEmail_TextBox.Clear();
            clientFatheName_textBox.Clear();
            clientFirstName_textBox.Clear();
            clientgenderComboBox.ResetText();
            clientLastName_textBox.Clear();
            clientLifetsyleCardNo_textBox.Clear();
            clientMotherName_textBox.Clear();
            clientNIDNo_textBox.Clear();
            clientPhoneNo_TextBox.Clear();
            clientQualification_textBox.Clear();
            signUpPictureBox.ImageLocation = "";
        }

        private void signUp_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(client_AdminPasswordtextBox.Text!="" && client_AdminUserNametextBox.Text != "" && clientAddress_Textbox.Text != "" && clientAge_textBox.Text != "" && clientDOB_datetimePicker.Text != "" && clientEmail_TextBox.Text != "" && clientFatheName_textBox.Text != "" && clientFirstName_textBox.Text != "" && clientgenderComboBox.Text != "" && clientLastName_textBox.Text != "" && clientLifetsyleCardNo_textBox.Text != "" & clientMotherName_textBox.Text != "" && clientNIDNo_textBox.Text != "" && clientPhoneNo_TextBox.Text != "" && clientQualification_textBox.Text != "" && imagePath != null)
                {
                    string expairyDate = issue_dateTimePicker.Text;
                    string s = expairyDate.Substring(0, 4);
                    int a = Convert.ToInt32(s);
                    a++;
                    StringBuilder sb = new StringBuilder();
                    sb.Append(a.ToString() + expairyDate.Substring(4, 6));
                   
                    Client client = new Client();
                    client.customerAddress = clientAddress_Textbox.Text;
                    client.customerAge = clientAge_textBox.Text;
                    client.customerDOB = clientDOB_datetimePicker.Text;
                    client.customerEmail = clientEmail_TextBox.Text;
                    client.customerFatherName = clientFatheName_textBox.Text;
                    client.customerFirstName = clientFirstName_textBox.Text;
                    client.customerGender = clientgenderComboBox.Text;
                    client.customerImagePath = imagePath;
                    client.customerLastName = clientLastName_textBox.Text;
                    client.customerlifeStyleCardExpiaryDate = sb.ToString();
                    client.customerLifeStyleCardIssuedate = issue_dateTimePicker.Text;
                    client.customerLifeStyleCardNo = clientLifetsyleCardNo_textBox.Text;
                    client.customerMobileNo = clientPhoneNo_TextBox.Text;
                    client.customerMothername = clientMotherName_textBox.Text;
                    client.customerNIDNo = clientNIDNo_textBox.Text;
                    client.customerQualification = clientQualification_textBox.Text;
                    try
                    {
                        Member m = account_Bo.getMember(client_AdminUserNametextBox.Text);
                        if (m.userName == client_AdminUserNametextBox.Text && m.password == client_AdminPasswordtextBox.Text)
                        {

                            if (MessageBox.Show("Are you sure?", "Entry New Client", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                if (account_Bo.setClient(client))
                                {
                                    MessageBox.Show("New Client Successfully Added");
                                    client_AdminPasswordtextBox.Clear();
                                    client_AdminUserNametextBox.Clear();
                                    clientAddress_Textbox.Clear();
                                    clientAge_textBox.Clear();
                                    clientDOB_datetimePicker.ResetText();
                                    clientEmail_TextBox.Clear();
                                    clientFatheName_textBox.Clear();
                                    clientFirstName_textBox.Clear();
                                    clientgenderComboBox.ResetText();
                                    clientLastName_textBox.Clear();
                                    clientLifetsyleCardNo_textBox.Clear();
                                    clientMotherName_textBox.Clear();
                                    clientNIDNo_textBox.Clear();
                                    clientPhoneNo_TextBox.Clear();
                                    clientQualification_textBox.Clear();
                                    signUpPictureBox.ImageLocation = "";

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Admin UserName or Password is wrong!!");
                            client_AdminUserNametextBox.Clear();
                            client_AdminPasswordtextBox.Clear();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Admin UserName or Password is wrong!!");
                        client_AdminUserNametextBox.Clear();
                        client_AdminPasswordtextBox.Clear();
                    } 
                         
                }
                else
                {
                    MessageBox.Show("Please Enter The Information Fully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("This Lifestyle Card No Is Already Exists" );
            }
        }
        string imagePath = null;
        private void uploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                openFileDialog.Title = "Select Image";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    signUpPictureBox.ImageLocation = openFileDialog.FileName;
                    imagePath = signUpPictureBox.ImageLocation;
                }
            }
            catch
            {

            }
        }

        private void clientNIDNo_textBox_KeyDown(object sender, KeyEventArgs e)
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
    }
}
