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
namespace ATK_Computer_LTD
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
           
        }
        Account_BO account_BO = new Account_BO();
        public string conn = global::ATK_Computer_LTD.Properties.Settings.Default.DatabaseConnectionString;
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void logInbutton_Click(object sender, EventArgs e)
        {
            try
            {

                if (loginUserName_metroTextBox.Text == "" || loginPassword_metroTextBox.Text == "")
                {
                    MessageBox.Show("Wrong!!! Enter the information fully");
                }
                else
                {
                    Member member = account_BO.getMember(loginUserName_metroTextBox.Text);

                    if (member.password == loginPassword_metroTextBox.Text)
                    {
                        Home_Admin hm = new Home_Admin();
                        hm.giveMemberUserName(loginUserName_metroTextBox.Text);
                        hm.giveMemberUserName1(loginUserName_metroTextBox.Text);
                        hm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorect UserName or Password");
                        loginUserName_metroTextBox.Clear();
                        loginPassword_metroTextBox.Clear();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Incorect UserName or Password");
                loginUserName_metroTextBox.Clear();
                loginPassword_metroTextBox.Clear();
            }
        }

        private void resetLogin_Click(object sender, EventArgs e)
        {
            try
            {
                loginUserName_metroTextBox.Clear();
                loginPassword_metroTextBox.Clear();
            }
            catch
            {

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

        private void reset_btn_Click(object sender, EventArgs e)
        {
            try
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
                signUpPictureBox.ImageLocation = imagePath;
                signUpPhoneNoMetroTextBox.Clear();
                signUpSalarytextBox.Clear();
                signUpAdminPasswordtextBox.Clear();
                signUpReference_textBox.Clear();
            }
            catch
            {

            }
        }

        private void signUp_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (signUpFirstNamemetroTextBox.Text != "" && signUpLastNamemetroTextBox.Text != "" && signUpGendermetroComboBox.Text != "" && signUpDOBmetroDateTime.Text != "" && signUpEmailmetroTextBox.Text != "" && signUpUserNamemetroTextBox != null && signUpPasswordmetroTextBox.Text != null && signUpRepeatPasswordmetroTextBox != null && signUpPhoneNoMetroTextBox.Text != null && imagePath != null && signUpAdminPasswordtextBox.Text != "" && signUpSalarytextBox.Text != "" && signUpAdminPasswordtextBox.Text != "" && signUpAdminUserNametextBox.Text!=""&& signUpReference_textBox.Text != "")
                {
                    int flag = 0;
                    if (signUpPasswordmetroTextBox.Text == signUpRepeatPasswordmetroTextBox.Text)
                    {
                        flag = 1;
                    }
                    Member member = new Member();
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
                    member.reference = signUpReference_textBox.Text;
                    if (flag == 1)
                    {
                        if (MessageBox.Show("Are you sure?", "Sign Up for new Member", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            try
                            {
                               
                                Member m = account_BO.getMember(signUpAdminUserNametextBox.Text);
                                if (m.userName == signUpAdminUserNametextBox.Text && m.password == signUpAdminPasswordtextBox.Text)
                                {
                                    if (account_BO.setMember(member))
                                    {
                                        MessageBox.Show("Sign Up Successfully Done");
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
                                        signUpReference_textBox.Clear();
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
        private void Home_Load(object sender, EventArgs e)
        {

            setFullScreen();
            setMainPanelPosition();
            setRightOptionPanel();
            right_option_timer.Start();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
        string rightDirection = "right";
        int RightTimeOut = 0;
        private void Home_MouseMove(object sender, MouseEventArgs e)
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

        private void minimized_pnl_MouseHover(object sender, EventArgs e)
        {

        }

        private void minimized_pnl_MouseMove(object sender, MouseEventArgs e)
        {
            minimized_pnl.BackColor = Color.Red;
        }

        private void minimized_pnl_MouseLeave(object sender, EventArgs e)
        {
            minimized_pnl.BackColor = Color.Transparent;
        }

        private void minimized_pnl_MouseClick(object sender, MouseEventArgs e)
        {
            right_option_timer.Stop();
            this.WindowState = FormWindowState.Minimized;
           
        }

        private void exit_pnl_MouseMove(object sender, MouseEventArgs e)
        {
            exit_pnl.BackColor = Color.Red;
        }

        private void exit_pnl_MouseLeave(object sender, EventArgs e)
        {
            exit_pnl.BackColor = Color.Transparent;
        }

        private void exit_pnl_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void Home_MaximumSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void Home_MinimumSizeChanged(object sender, EventArgs e)
        {
           
        }

        private void Home_ResizeBegin(object sender, EventArgs e)
        {
            
        }

        private void Home_SizeChanged(object sender, EventArgs e)
        {
           
        }

        private void Home_StyleChanged(object sender, EventArgs e)
        {
            
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void log_in(object sender, KeyEventArgs e)
        {
        }

        private void Ctrl_LogIn(object sender, KeyEventArgs e)
        {
            
        }

        private void signUpPasswordmetroTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ctrl_SignUp(object sender, KeyEventArgs e)
        {
           
        }

        private void Ctrl2_logIn(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, false);
                loginUserName_metroTextBox.AutoCompleteCustomSource.Add(loginUserName_metroTextBox.Text);
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, false);
                loginUserName_metroTextBox.AutoCompleteCustomSource.Add(loginUserName_metroTextBox.Text);
            }
            
        }

        private void Ctrl2SignUp(object sender, KeyEventArgs e)
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

        private void loginUserName_metroTextBox_TabIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void signUpLastNamemetroTextBox_KeyDown(object sender, KeyEventArgs e)
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
            AboutUs ab = new AboutUs();
            ab.Show();
        }
    }
}
