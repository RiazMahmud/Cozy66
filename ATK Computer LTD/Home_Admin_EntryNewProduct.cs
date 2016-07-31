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
using Microsoft.PointOfService;
namespace ATK_Computer_LTD
{
    public partial class Home_Admin_EntryNewProduct : Form
    {
        public Home_Admin_EntryNewProduct()
        {
            InitializeComponent();
        }
        Account_BO account_Bo = new Account_BO();
        string userName = null;
        public void giveMemberUserName(string name)
        {
            userName = name;
        }

        private PosExplorer explorer;
        private DeviceCollection scannerList;
        private DeviceCollection scannerList1;
        private Scanner activeScanner;

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

        private void Home_Admin_Load(object sender, EventArgs e)
        {
            setFullScreen();
            setMainPanelPosition();
            setRightOptionPanel();
            right_option_timer.Start();
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

        private void Home_Admin_EntryNewProduct_MouseMove(object sender, MouseEventArgs e)
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
        Member member = new Member();
        private void reportFailure()
        {
            throw new Exception("This method or operation is not implemented.");
        }
        private void ActiveScanner(DeviceInfo selectedScanner)
        {
            if (selectedScanner != null && !selectedScanner.IsDeviceInfoOf(activeScanner))
            {
                DeactivateScanner();

                UpdateEventHistory(string.Format("Activate Scanner:{0}", selectedScanner.ServiceObjectName));
                try
                {
                    activeScanner = (Scanner)explorer.CreateInstance(selectedScanner);
                    activeScanner.Open();
                    activeScanner.Claim(1000);
                    activeScanner.DeviceEnabled = true;
                    activeScanner.DataEvent += new DataEventHandler(activeScanner_DataEvent);
                    activeScanner.ErrorEvent += new DeviceErrorEventHandler(activeScanner_ErrorEvent);
                    activeScanner.DecodeData = true;
                    activeScanner.DataEventEnabled = true;
                }
                catch (PosControlException)
                {
                    UpdateEventHistory(string.Format("Activation Failed:{0}", selectedScanner.ServiceObjectName));
                    activeScanner = null;
                }
            }
        }
        private void DeactivateScanner()
        {
            UpdateEventHistory("Deactivate Current Scanner");
            try
            {
                activeScanner.Close();
            }
            catch (PosControlException)
            {
                UpdateEventHistory("Close Failed");
            }
            finally
            {
                activeScanner = null;
            }
        }

        private void activeScanner_ErrorEvent(object sender, DeviceErrorEventArgs e)
        {
            UpdateEventHistory("Error Event");
            try
            {
                activeScanner.DataEventEnabled = true;

            }
            catch (PosControlException)
            {
                UpdateEventHistory("ErrorEventArgs Operation Failed");

            }
        }

        private void activeScanner_DataEvent(object sender, DataEventArgs e)
        {
            UpdateEventHistory("Data Event");
            ASCIIEncoding encoder = new ASCIIEncoding();

            try
            {

              
                

                activeScanner.DataEventEnabled = true;

            }
            catch (PosControlException)
            {
                UpdateEventHistory("DataEn=vent Operation Failed");
            }
        }

        private void UpdateEventHistory(string newEvent)
        {
           
        }
        private void Home_Admin_EntryNewProduct_Load(object sender, EventArgs e)
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



                //explorer = new PosExplorer();

                //scannerList1 = explorer.GetDevices();
                //bsDevices.DataSource = scannerList1;
                //cboDevices.DisplayMember = scannerList1.ToString();

                //scannerList = explorer.GetDevices(DeviceType.Scanner);
                //devicesBinidingSource.DataSource = scannerList;
                //lstDevices.DisplayMember = scannerList.ToString();


            }
            catch (Exception ex)
            {

            }
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
            Home_Admin ha = new Home_Admin();
            ha.giveMemberUserName(userName);
            ha.Show();
            this.Hide();
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

        private void exit_pnl_MouseUp(object sender, MouseEventArgs e)
        {

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

        private void Home_Admin_EntryNewProduct_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
           
            productNameTextBox.Clear();        
            productBrandTextBox.Clear();
            productUnitPriceTextBox.Clear();
            productShortDescriptiontextBox.Clear();
            mrp_textBox.Clear();
            productBarcodeTextBox.Clear();
            importerNamemetroTextBox.Clear();
            importerInvoiceNoTextBox.Clear();

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            try
            {
                if (productShortDescriptiontextBox.Text != "" && mrp_textBox.Text != ""  && productNameTextBox.Text != ""  && productBrandTextBox.Text != ""  && productUnitPriceTextBox.Text != ""  && importerInvoiceNoTextBox.Text != "" && importerNamemetroTextBox.Text != "" && productBarcodeTextBox.Text != "")
                {

                    product.productName = productNameTextBox.Text;  
                    product.productBrand = productBrandTextBox.Text; 
                    product.productUnitPrice = productUnitPriceTextBox.Text;
                    product.productShortDescription = productShortDescriptiontextBox.Text;
                    product.productEntryDate = productEntryDTP.Text;
                    product.productBarcode = productBarcodeTextBox.Text;
                    product.productEntrier = member.userName;
                    product.importerName = importerNamemetroTextBox.Text;
                    product.importerInvoiceNo = importerInvoiceNoTextBox.Text;
                    product.soldPrice = mrp_textBox.Text;
                    if (MessageBox.Show("Are you sure?", "Entry Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (account_Bo.setProduct(product))
                        {
                            MessageBox.Show("Product entry successfully done");
                           
                            productNameTextBox.Clear();  
                            productBrandTextBox.Clear();
                            productUnitPriceTextBox.Clear();
                            productShortDescriptiontextBox.Clear();
                            mrp_textBox.Clear();
                            productBarcodeTextBox.Clear();
                            importerNamemetroTextBox.Clear();
                            importerInvoiceNoTextBox.Clear();          
                        }
                        else
                        {
                            MessageBox.Show("This product serial no is already exists!!!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Please enter the information fully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ctrl_ProductEntry(object sender, KeyEventArgs e)
        {
           
        }

        private void productWarrentyTextBox_KeyDown(object sender, KeyEventArgs e)
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

        private void productUnitPriceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void home_admin_main_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mrp_textBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, false);
                productBarcodeTextBox.AutoCompleteCustomSource.Add(productBarcodeTextBox.Text);
                productBrandTextBox.AutoCompleteCustomSource.Add(productBrandTextBox.Text);
                productNameTextBox.AutoCompleteCustomSource.Add(productNameTextBox.Text);
                productShortDescriptiontextBox.AutoCompleteCustomSource.Add(productShortDescriptiontextBox.Text);
                productUnitPriceTextBox.AutoCompleteCustomSource.Add(productUnitPriceTextBox.Text);
                importerInvoiceNoTextBox.AutoCompleteCustomSource.Add(importerInvoiceNoTextBox.Text);
                importerNamemetroTextBox.AutoCompleteCustomSource.Add(importerNamemetroTextBox.Text);
                mrp_textBox.AutoCompleteCustomSource.Add(mrp_textBox.Text);

            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, false);
                productBarcodeTextBox.AutoCompleteCustomSource.Add(productBarcodeTextBox.Text);
                productBrandTextBox.AutoCompleteCustomSource.Add(productBrandTextBox.Text);
                productNameTextBox.AutoCompleteCustomSource.Add(productNameTextBox.Text);
                productShortDescriptiontextBox.AutoCompleteCustomSource.Add(productShortDescriptiontextBox.Text);
                productUnitPriceTextBox.AutoCompleteCustomSource.Add(productUnitPriceTextBox.Text);
                importerInvoiceNoTextBox.AutoCompleteCustomSource.Add(importerInvoiceNoTextBox.Text);
                importerNamemetroTextBox.AutoCompleteCustomSource.Add(importerNamemetroTextBox.Text);
                mrp_textBox.AutoCompleteCustomSource.Add(mrp_textBox.Text);
            }
        }
    }
}
