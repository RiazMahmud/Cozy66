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
    public partial class Home_Admin_TotalMember : Form
    {
        public Home_Admin_TotalMember()
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

        private void Home_Admin_TotalMember_MouseMove(object sender, MouseEventArgs e)
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

        private void Home_Admin_TotalMember_Load(object sender, EventArgs e)
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
                DataSet ds = account_Bo.getAllMember();
                memberMetroGrid.DataSource = ds.Tables[0];
             
                if (memberMetroGrid.Rows.Count > 1)
                {
                    Mlabel.Text = (memberMetroGrid.Rows.Count).ToString() + " results found";
                }
                else if (memberMetroGrid.Rows.Count == 1)
                {
                    Mlabel.Text = "1 result found";
                }
                else
                {
                    Mlabel.Text = "No result found";
                }
            }
            catch
            {

            }


        }

        private void Home_Admin_TotalMember_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void memberMetroGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void home_admin_main_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void calendarClock1_Load(object sender, EventArgs e)
        {

        }

        private void memberFirstNameMetroLabel_Click(object sender, EventArgs e)
        {

        }

        private void memberLastNameMetroLabel_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pnlRightMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void right_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void signUpGenderTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void signUpDOB_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUpReference_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUpSalarytextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUpLastNamemetroTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUpPasswordmetroTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUpUserNamemetroTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUpPhoneNoMetroTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUpEmailmetroTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUpFirstNamemetroTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void memberMetroGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Mlabel_Click(object sender, EventArgs e)
        {

        }

        private void minimized_pnl_Click(object sender, EventArgs e)
        {

        }

        private void exit_pnl_Click(object sender, EventArgs e)
        {

        }

        private void lock_pnl_Click(object sender, EventArgs e)
        {

        }

        private void home_pnl_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void bsDevices_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void devicesBinidingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void memberMetroGrid_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                signUpFirstNamemetroTextBox.Text = memberMetroGrid.CurrentRow.Cells[0].Value.ToString();
                signUpLastNamemetroTextBox.Text = memberMetroGrid.CurrentRow.Cells[1].Value.ToString();
                signUpGenderTextbox.Text = memberMetroGrid.CurrentRow.Cells[2].Value.ToString();
                signUpDOB.Text = memberMetroGrid.CurrentRow.Cells[3].Value.ToString();
                signUpEmailmetroTextBox.Text = memberMetroGrid.CurrentRow.Cells[4].Value.ToString();
                signUpUserNamemetroTextBox.Text = memberMetroGrid.CurrentRow.Cells[5].Value.ToString();
                signUpPasswordmetroTextBox.Text = memberMetroGrid.CurrentRow.Cells[6].Value.ToString();
                signUpPhoneNoMetroTextBox.Text = memberMetroGrid.CurrentRow.Cells[9].Value.ToString();
                signUpSalarytextBox.Text = memberMetroGrid.CurrentRow.Cells[10].Value.ToString();
                signUpReference_textBox.Text = memberMetroGrid.CurrentRow.Cells[11].Value.ToString();

            }
            catch
            {

            }
        }
    }
}
