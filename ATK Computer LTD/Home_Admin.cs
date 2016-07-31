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
using ATK_Computer_LTD;


namespace ATK_Computer_LTD
{
    public partial class Home_Admin : Form
    {
        public Home_Admin()
        {
            InitializeComponent();
           
        }
        int i = 0;
        string userName = null;
        public void giveMemberUserName(string name)
        {
            userName = name;
            i = 1;
        }
        public void giveMemberUserName1(string name)
        {
            userName = name;
            i = 0;
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
            main_panel2.Location = new Point(Width+20, mY);
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

        Member member;
        private void Home_Admin_Load(object sender, EventArgs e)
        {
            setFullScreen();
            setMainPanelPosition();
            setRightOptionPanel();
            right_option_timer.Start();
            try
            {
                Account_BO ab = new Account_BO();
                member = ab.getMember(userName.ToString());
                memberNameMetroLabel.Text = member.firstName.ToString();
                memberTypeMetroLabel.Text = member.lastName.ToString();
                MemoryStream ms = new MemoryStream(member.image);
                pictureBox.Image = Image.FromStream(ms);
                pictureBox18.Image = Image.FromStream(ms);
                metroLabel4.Text = member.firstName.ToString();
                metroLabel3.Text = member.lastName.ToString();
                if(i==0)
                {
                    soundPlay();
                    i = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        string rightDirection = "right";
        int RightTimeOut = 0;

      
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

        private void Home_Admin_MouseMove(object sender, MouseEventArgs e)
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

        private void entry_new_client_pnl_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void entry_new_client_pnl_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void entry_new_client_pnl_Click(object sender, EventArgs e)
        {
           
        }

        private void lblStudents_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void entry_new_client_pnl_MouseUp(object sender, MouseEventArgs e)
        {
           
        }
        private void soundPlay()
        {
            try
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = @"C:\DB\Sound\sounds-1060-demonstrative.wav";
                player.Load();
                player.Play();
            }
            catch
            {

            }
        }
        private void soundPlay2()
        {
            try
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = @"C:\DB\Sound\Slide Closed-SoundBible.com-1521580537.wav";
                player.Load();
                player.Play();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void entry_new_client_pnl_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void lblStudents_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void lblStudents_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            Home_Admin_EntryNewProduct hn = new Home_Admin_EntryNewProduct();
            hn.giveMemberUserName(userName);
            hn.Show();
            this.Hide();
        }

        private void lblStudents_MouseClick(object sender, MouseEventArgs e)
        {
            Home_Admin_EntryNewProduct hn = new Home_Admin_EntryNewProduct();
            hn.giveMemberUserName(userName);
            hn.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bill_payment_pnl_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void pbAttendance_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void label12_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void bill_payment_pnl_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pbAttendance_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void search_pnl_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void pbAccounts_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void label21_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void search_pnl_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pbAccounts_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void label21_MouseLeave(object sender, EventArgs e)
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

        private void minimized_pnl_Click(object sender, EventArgs e)
        {
            
        }

        private void home_pnl_MouseMove(object sender, MouseEventArgs e)
        {
            home_pnl.BackColor = Color.Red;
        }

        private void home_pnl_MouseLeave(object sender, EventArgs e)
        {
            home_pnl.BackColor = Color.Transparent;
        }

        private void home_pnl_MouseClick(object sender, MouseEventArgs e)
        {
            rightDirection = "right";
        }

        private void minimized_pnl_MouseClick(object sender, MouseEventArgs e)
        {
            right_option_timer.Stop();
            this.WindowState = FormWindowState.Minimized;
        }

        private void lock_pnl_MouseMove(object sender, MouseEventArgs e)
        {
            lock_pnl.BackColor = Color.Red;
        }

        private void lock_pnl_MouseLeave(object sender, EventArgs e)
        {
            lock_pnl.BackColor = Color.Transparent;
        }

        private void lock_pnl_MouseClick(object sender, MouseEventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
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

        private void entry_new_client_pnl_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void home_admin_main_panel_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void Home_Admin_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void entry_new_client_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void serach_mouseClick(object sender, MouseEventArgs e)
        {

           


           
        }

        private void returnImporetr(object sender, MouseEventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_ReturnToImporter_History hs = new Home_Admin_ReturnToImporter_History();
                hs.giveMemberUserName(userName);
                hs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
          
        }

        private void remove_client_pnl_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void Manage_pnl(object sender, MouseEventArgs e)
        {
            
        }

        private void manageProfilepanel_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void manage_pnlClick(object sender, MouseEventArgs e)
        {
           
        }

        private void ManageClient_Click(object sender, MouseEventArgs e)
        {
           
        }

        private void ManageClient_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void ManageClient_MouseLeave(object sender, EventArgs e)
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

        private void MemberSarary_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void MemberSarary_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void MemberSarary_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void MemberAttendence_MouseMove(object sender, MouseEventArgs e)
        {
         
        }

        private void MemberAttendence_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void MemberAttendence_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void update_Product_MouseHover(object sender, EventArgs e)
        {

        }

        private void update_Product_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void update_Product_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void update_Product_MouseClick(object sender, MouseEventArgs e)
        {

           
        }

        private void OwnerIncome_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void OwnerIncome_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void OwnerIncome_MouseClick(object sender, MouseEventArgs e)
        {

          
        }

        private void OwnerExpenditure_MouseMove(object sender, MouseEventArgs e)
        {
           
           
        }

        private void OwnerExpenditure_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void OwnerExpenditure_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void SoldProduct_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void SoldProduct_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void SoldProduct_MouseClick(object sender, MouseEventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_SoldProductHistory hh = new Home_Admin_SoldProductHistory();
                hh.giveMemberUserName(userName);
                hh.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void pbMasterEntry_MouseMove_1(object sender, MouseEventArgs e)
        {
           
        }

        private void pbMasterEntry_MouseLeave_1(object sender, EventArgs e)
        {
            
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_DayBook hd = new Home_Admin_DayBook();
                hd.giveMemberUserName(userName);
                hd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void update_user_pnl_MouseClick(object sender, MouseEventArgs e)
        {
            //if (member.type == "A")
            //{
            //    Home_Admin_PartyLedger hp = new Home_Admin_PartyLedger();
            //    hp.giveMemberUserName(userName);
            //    hp.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Access denied");
            //}
        }

        private void pbReports_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void pbReports_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox10_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void pnlOptions_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox11_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void pictureBox11_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_AddClient hc = new Home_Admin_AddClient();
                hc.giveMemberUserName(userName);
                hc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_CreditHistoryBalance hh = new Home_Admin_CreditHistoryBalance();
                hh.giveMemberUserName(userName);
                hh.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void pictureBox13_MouseHover(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.Red;
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.Transparent;
        }

        private void pictureBox13_MouseClick(object sender, MouseEventArgs e)
        {
            soundPlay2();
            X = (Width - home_admin_main_panel.Width) / 2;
            Y = (Height - home_admin_main_panel.Height) / 2;
            swapAMinPaneltimer.Start();
        }
        int X = 0;
        int Y=0;
        private void swapAMinPaneltimer_Tick(object sender, EventArgs e)
        {
            X-=60;
            home_admin_main_panel.Location = new Point(X, Y);
            int mX = (Width - home_admin_main_panel.Width) / 2;
                int mY = (Height - home_admin_main_panel.Height) / 2;
            main_panel2.Location = new Point(X+700, Y);
            if (main_panel2.Location.X<mX)
            {
                
                home_admin_main_panel.Location = new Point(-Width, mY);
                main_panel2.Location = new Point(mX, mY);
                swapAMinPaneltimer.Stop();
            }
            
        }

        private void pictureBox14_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox14.BackColor = Color.Red;
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            pictureBox14.BackColor = Color.Transparent;
        }

        private void pictureBox14_MouseClick(object sender, MouseEventArgs e)
        {
            soundPlay2();
            X = (Width - main_panel2.Width) / 2;
            Y = (Height - main_panel2.Height) / 2;
            home_admin_main_panel.Location = new Point(-Width,0);
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            X += 60;
            main_panel2.Location = new Point(X, Y);
            home_admin_main_panel.Location = new Point(X-300, Y);
            int mX = (Width - home_admin_main_panel.Width) / 2;
            int mY = (Height - home_admin_main_panel.Height) / 2;
            if (home_admin_main_panel.Location.X > mX)
            {
               
                main_panel2.Location = new Point(Width, Y);
                home_admin_main_panel.Location = new Point(mX, mY);
                timer2.Stop();
            }
        }

        private void pictureBox15_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox15_MouseClick(object sender, MouseEventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_Exchanged_Client hh = new Home_Admin_Exchanged_Client();
                hh.giveMemberUserName(userName);
                hh.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void panel3_MouseMove_1(object sender, MouseEventArgs e)
        {
            
        }

        private void panel3_MouseLeave_1(object sender, EventArgs e)
        {
            
        }

        private void panel3_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_IncomeStatement hi = new Home_Admin_IncomeStatement();
                hi.giveMemberUserName(userName);
                hi.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void pictureBox17_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox17_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox17_MouseClick(object sender, MouseEventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_SalaryHistory hs = new Home_Admin_SalaryHistory();
                hs.giveMemberUserName(userName);
                hs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void home_admin_main_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addNewProduct_Button_Click(object sender, EventArgs e)
        {
            Home_Admin_EntryNewProduct hn = new Home_Admin_EntryNewProduct();
            hn.giveMemberUserName(userName);
            hn.Show();
            this.Hide();
        }

        private void updateProduct_button_Click(object sender, EventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_UpdateProduct hu = new Home_Admin_UpdateProduct();
                hu.giveMemberUserName(userName);
                hu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void addNewClient_button_Click(object sender, EventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_AddClient hc = new Home_Admin_AddClient();
                hc.giveMemberUserName(userName);
                hc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void manageClient_button_Click(object sender, EventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_ManageClient hc = new Home_Admin_ManageClient();
                hc.giveMemberUserName(userName);
                hc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void totalMember_button_Click(object sender, EventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_TotalMember ht = new Home_Admin_TotalMember();
                ht.giveMemberUserName(userName);
                ht.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void mamangeMemberProfilebutton_Click(object sender, EventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_ManageProfile hm = new Home_Admin_ManageProfile();
                hm.giveMemberUserName(userName);
                hm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_NotesAndReminder hn = new Home_Admin_NotesAndReminder();
                hn.giveMemberUserName(userName);
                hn.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void advancepaymentHistory_button_Click(object sender, EventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_SalaryHistory hs = new Home_Admin_SalaryHistory();
                hs.giveMemberUserName(userName);
                hs.indicator(1);
                hs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
           
        }

        private void ownerExpenditure_button_Click(object sender, EventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_OwnerExpenditure he = new Home_Admin_OwnerExpenditure();
                he.giveMemberUserName(userName);
                he.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void memberAttendence_button_Click(object sender, EventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_MemberMaintainance hm = new Home_Admin_MemberMaintainance();
                hm.giveMemberUserName(userName);
                hm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void memberSalary_button_Click(object sender, EventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_MemberMaintainance hm = new Home_Admin_MemberMaintainance();
                hm.giveMemberUserName(userName);
                hm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void ownerIncome_button_Click(object sender, EventArgs e)
        {
            if (member.type == "A")
            {
                Home_Admin_OwnerIncome hc = new Home_Admin_OwnerIncome();
                hc.giveMemberUserName(userName);
                hc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void searccProduct_button_Click(object sender, EventArgs e)
        {
            if (member.type == "A" || member.type == "M")
            {
                Home_Admin_SearchProduct hs = new Home_Admin_SearchProduct();
                hs.giveMemberUserName(userName);
                hs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void prepareBill_button_Click(object sender, EventArgs e)
        {
            if (member.type == "A" || member.type == "M")
            {
                Home_Admin_Bill hb = new Home_Admin_Bill();
                hb.giveMemberUserName(userName);
                hb.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (member.type == "A" || member.type == "M")
            {
                Home_Admin_Accounting hs = new Home_Admin_Accounting();
                hs.giveMemberUserName(userName);
                hs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void soldProductHistorybutton_Click(object sender, EventArgs e)
        {
            if (member.type == "A" || member.type == "M")
            {
                Home_Admin_SoldProductHistory hs = new Home_Admin_SoldProductHistory();
                hs.giveMemberUserName(userName);
                hs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (member.type == "A" || member.type == "M")
            {
                Home_Admin_SearchProduct hs = new Home_Admin_SearchProduct();
                hs.giveMemberUserName(userName);
                hs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void incomeStatement_button_Click(object sender, EventArgs e)
        {
            if (member.type == "A" || member.type == "M")
            {
                Home_Admin_IncomeStatement hs = new Home_Admin_IncomeStatement();
                hs.giveMemberUserName(userName);
                hs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void clientExchangebutton_Click(object sender, EventArgs e)
        {
            if (member.type == "A" || member.type == "M")
            {
                Home_Admin_Exchanged_Client hs = new Home_Admin_Exchanged_Client();
                hs.giveMemberUserName(userName);
                hs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void companyExchangebutton_Click(object sender, EventArgs e)
        {
            Home_Admin_ReturnToImporter_History hs = new Home_Admin_ReturnToImporter_History();
            hs.giveMemberUserName(userName);
            hs.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (member.type == "A" || member.type == "M")
            {
                Home_Admin_SalaryHistory hs = new Home_Admin_SalaryHistory();
                hs.giveMemberUserName(userName);
                hs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

    }
}
