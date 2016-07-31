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
    public partial class Home_Admin_ManageProfile : Form
    {
        public Home_Admin_ManageProfile()
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

        private void Home_Admin_ManageProfile_MouseMove(object sender, MouseEventArgs e)
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

        private void Home_Admin_ManageProfile_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
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
        private void Home_Admin_ManageProfile_Load(object sender, EventArgs e)
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

        private void Ctrl_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Ctrl_KeyDown(object sender, KeyEventArgs e)
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
        string imagePath;
        private void reset_btn_Click(object sender, EventArgs e)
        {
            serachMembertextBox.Clear();
            signUpFirstNamemetroTextBox.Clear();
            signUpLastNamemetroTextBox.Clear();
            signUpGendermetroComboBox.ResetText();
            signUpDOBmetroDateTime.ResetText();
            signUpEmailmetroTextBox.Clear();
            signUpUserNamemetroTextBox.Clear();
            signUpPasswordmetroTextBox.Clear();
            signUpRepeatPasswordmetroTextBox.Clear();
            imagePath = "";
            signUpPictureBox.ImageLocation = imagePath;
            signUpPhoneNoMetroTextBox.Clear();
            signUpSalarytextBox.Clear();
            signUpAdminUserNametextBox.Clear();
            signUpAdminPasswordtextBox.Clear();
            
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void SerachMembertextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                signUpPictureBox.Visible = true;
                Account_BO ab = new Account_BO();
                member = ab.getMember(serachMembertextBox.Text);
                //memberFirstNameMetroLabel.Text = member.firstName.ToString();
               // memberLastNameMetroLabel.Text = member.lastName.ToString();
                MemoryStream ms = new MemoryStream(member.image);
                //pictureBox.Image = Image.FromStream(ms);
                signUpFirstNamemetroTextBox.Text = member.firstName;
                signUpLastNamemetroTextBox.Text = member.lastName;
                signUpGendermetroComboBox.Text = member.gender;
                signUpDOBmetroDateTime.Text = member.DOB;
                signUpEmailmetroTextBox.Text = member.email;
                signUpPhoneNoMetroTextBox.Text = member.phoneNo;
                signUpPictureBox.Image = Image.FromStream(ms);
                signUpSalarytextBox.Text = member.salary;
                signUpUserNamemetroTextBox.Text = member.userName;

            }
            catch
            {
                signUpFirstNamemetroTextBox.Clear();
                signUpLastNamemetroTextBox.Clear();
                signUpGendermetroComboBox.ResetText();
                signUpDOBmetroDateTime.ResetText();
                signUpEmailmetroTextBox.Clear();
                signUpUserNamemetroTextBox.Clear();
                signUpPasswordmetroTextBox.Clear();
                signUpRepeatPasswordmetroTextBox.Clear();
                imagePath = "";
                signUpPictureBox.Visible = false;
                signUpPhoneNoMetroTextBox.Clear();
                signUpSalarytextBox.Clear();
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (signUpFirstNamemetroTextBox.Text != "" && signUpLastNamemetroTextBox.Text != "" && signUpGendermetroComboBox.Text != "" && signUpDOBmetroDateTime.Text != "" && signUpEmailmetroTextBox.Text != "" && signUpUserNamemetroTextBox != null && signUpPasswordmetroTextBox.Text != null && signUpRepeatPasswordmetroTextBox != null && signUpPhoneNoMetroTextBox.Text != null && signUpAdminPasswordtextBox.Text != "" && signUpSalarytextBox.Text != "" && signUpAdminPasswordtextBox.Text != "" && signUpAdminUserNametextBox.Text != "")
                {
                    int flag = 0;
                    if (signUpPasswordmetroTextBox.Text == signUpRepeatPasswordmetroTextBox.Text)
                    {
                        flag = 1;
                    }
                    Member member = new Member();
                    try
                    {
                        member = account_Bo.getMember(signUpUserNamemetroTextBox.Text);
                    }
                    catch
                    {

                    }
                    member.firstName = signUpFirstNamemetroTextBox.Text;
                    member.lastName = signUpLastNamemetroTextBox.Text;
                    member.gender = signUpGendermetroComboBox.Text;
                    member.DOB = signUpDOBmetroDateTime.Text;
                    member.email = signUpEmailmetroTextBox.Text;
                    member.phoneNo = signUpPhoneNoMetroTextBox.Text;
                    member.userName = signUpUserNamemetroTextBox.Text;
                    member.password = signUpPasswordmetroTextBox.Text;
                    member.salary = signUpSalarytextBox.Text;
                    member.imagePath = imagePath;
                    if (flag == 1)
                    {
                        if (MessageBox.Show("Are you sure?", "Update Member", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            try
                            {
                                Member m = account_Bo.getMember(signUpAdminUserNametextBox.Text);
                                if (m.userName == signUpAdminUserNametextBox.Text && m.password == signUpAdminPasswordtextBox.Text)
                                {
                                    if (account_Bo.updateMember(member))
                                    {
                                        MessageBox.Show("Update Successfully Done");
                                        signUpFirstNamemetroTextBox.Clear();
                                        signUpLastNamemetroTextBox.Clear();
                                        signUpGendermetroComboBox.ResetText();
                                        signUpDOBmetroDateTime.ResetText();
                                        signUpEmailmetroTextBox.Clear();
                                        signUpUserNamemetroTextBox.Clear();
                                        signUpPasswordmetroTextBox.Clear();
                                        signUpRepeatPasswordmetroTextBox.Clear();
                                        imagePath = "";
                                        signUpPictureBox.ImageLocation = imagePath;
                                        signUpPhoneNoMetroTextBox.Clear();
                                        signUpAdminPasswordtextBox.Clear();
                                        signUpAdminUserNametextBox.Clear();
                                        signUpSalarytextBox.Clear();
                                        serachMembertextBox.Clear();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sorry this UserName is already in used");
                                        signUpUserNamemetroTextBox.Clear();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Admin UserName or Password is wrong!!");
                                    signUpAdminPasswordtextBox.Clear();
                                    signUpAdminUserNametextBox.Clear();
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Admin UserName or Password is wrong!!");
                                signUpAdminPasswordtextBox.Clear();
                                signUpAdminUserNametextBox.Clear();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Sorry this UserName is already in used");
                            signUpUserNamemetroTextBox.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your Password Doesn't match!");
                        signUpRepeatPasswordmetroTextBox.Clear();
                    }
                }
                else
                    MessageBox.Show("Wrong!!! Enter the information fully");
            }
            catch
            {
                MessageBox.Show("Sorry!!! This UserName is already exists");
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
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

        private void groupBox2_MouseHover(object sender, EventArgs e)
        {
            
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

        private void signUpAdminUserNametextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, false);
                signUpAdminUserNametextBox.AutoCompleteCustomSource.Add(signUpAdminUserNametextBox.Text);
                signUpEmailmetroTextBox.AutoCompleteCustomSource.Add(signUpEmailmetroTextBox.Text);
                signUpFirstNamemetroTextBox.AutoCompleteCustomSource.Add(signUpFirstNamemetroTextBox.Text);
                signUpLastNamemetroTextBox.AutoCompleteCustomSource.Add(signUpLastNamemetroTextBox.Text);
                signUpPhoneNoMetroTextBox.AutoCompleteCustomSource.Add(signUpPhoneNoMetroTextBox.Text);
                signUpSalarytextBox.AutoCompleteCustomSource.Add(signUpSalarytextBox.Text);
                signUpUserNamemetroTextBox.AutoCompleteCustomSource.Add(signUpUserNamemetroTextBox.Text);


            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, false);
                signUpAdminUserNametextBox.AutoCompleteCustomSource.Add(signUpAdminUserNametextBox.Text);
                signUpEmailmetroTextBox.AutoCompleteCustomSource.Add(signUpEmailmetroTextBox.Text);
                signUpFirstNamemetroTextBox.AutoCompleteCustomSource.Add(signUpFirstNamemetroTextBox.Text);
                signUpLastNamemetroTextBox.AutoCompleteCustomSource.Add(signUpLastNamemetroTextBox.Text);
                signUpPhoneNoMetroTextBox.AutoCompleteCustomSource.Add(signUpPhoneNoMetroTextBox.Text);
                signUpSalarytextBox.AutoCompleteCustomSource.Add(signUpSalarytextBox.Text);
                signUpUserNamemetroTextBox.AutoCompleteCustomSource.Add(signUpUserNamemetroTextBox.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (signUpFirstNamemetroTextBox.Text != "" && signUpLastNamemetroTextBox.Text != "" && signUpGendermetroComboBox.Text != "" && signUpDOBmetroDateTime.Text != "" && signUpEmailmetroTextBox.Text != "" && signUpUserNamemetroTextBox != null  && signUpPhoneNoMetroTextBox.Text != null  && signUpAdminPasswordtextBox.Text != "" && signUpSalarytextBox.Text != "" && signUpAdminPasswordtextBox.Text != "" && signUpAdminUserNametextBox.Text != "")
                {
                    int flag = 0;
                    if (signUpPasswordmetroTextBox.Text == signUpRepeatPasswordmetroTextBox.Text)
                    {
                        flag = 1;
                    }
                    Member member = new Member();
                    try
                    {
                        member = account_Bo.getMember(signUpUserNamemetroTextBox.Text);
                    }
                    catch
                    {

                    }
                    member.firstName = signUpFirstNamemetroTextBox.Text;
                    member.lastName = signUpLastNamemetroTextBox.Text;
                    member.gender = signUpGendermetroComboBox.Text;
                    member.DOB = signUpDOBmetroDateTime.Text;
                    member.email = signUpEmailmetroTextBox.Text;
                    member.phoneNo = signUpPhoneNoMetroTextBox.Text;
                    member.userName = signUpUserNamemetroTextBox.Text;
                    member.password = signUpPasswordmetroTextBox.Text;
                    member.salary = signUpSalarytextBox.Text;
                    member.imagePath = imagePath;
                    member.type = "M";
                    if (flag == 1)
                    {
                        if (MessageBox.Show("Are you sure?", "Delete Member", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            try
                            {
                                Member m = account_Bo.getMember(signUpAdminUserNametextBox.Text);
                                if (m.userName == signUpAdminUserNametextBox.Text && m.password == signUpAdminPasswordtextBox.Text)
                                {
                                    if (account_Bo.deleteMember(member.userName))
                                    {
                                        MessageBox.Show("Delete Member Successfully Done");
                                        signUpFirstNamemetroTextBox.Clear();
                                        signUpLastNamemetroTextBox.Clear();
                                        signUpGendermetroComboBox.ResetText();
                                        signUpDOBmetroDateTime.ResetText();
                                        signUpEmailmetroTextBox.Clear();
                                        signUpUserNamemetroTextBox.Clear();
                                        signUpPasswordmetroTextBox.Clear();
                                        signUpRepeatPasswordmetroTextBox.Clear();
                                        imagePath = "";
                                        signUpPictureBox.ImageLocation = imagePath;
                                        signUpPhoneNoMetroTextBox.Clear();
                                        signUpAdminPasswordtextBox.Clear();
                                        signUpAdminUserNametextBox.Clear();
                                        signUpSalarytextBox.Clear();
                                        serachMembertextBox.Clear();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Wrong!");
                                        signUpUserNamemetroTextBox.Clear();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Admin UserName or Password is wrong!!");
                                    signUpAdminPasswordtextBox.Clear();
                                    signUpAdminUserNametextBox.Clear();
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Admin UserName or Password is wrong!!");
                                signUpAdminPasswordtextBox.Clear();
                                signUpAdminUserNametextBox.Clear();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Sorry this UserName is already in used");
                            signUpUserNamemetroTextBox.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your Password Doesn't match!");
                        signUpRepeatPasswordmetroTextBox.Clear();
                    }
                }
                else
                    MessageBox.Show("Wrong!!! Enter the information fully");
            }
            catch
            {
                MessageBox.Show("Sorry!!! This UserName is already exists");
            }
        }
    }
}
