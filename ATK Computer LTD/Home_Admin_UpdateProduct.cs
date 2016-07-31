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
    public partial class Home_Admin_UpdateProduct : Form
    {
        public Home_Admin_UpdateProduct()
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

        private void Home_Admin_UpdateProduct_MouseMove(object sender, MouseEventArgs e)
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
        private void Home_Admin_UpdateProduct_Load(object sender, EventArgs e)
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
            catch (Exception ex)
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

        private void right_pnl_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void productMetroGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void Ctrl_KeyDown(object sender, KeyEventArgs e)
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
                userNametextBox.AutoCompleteCustomSource.Add(userNametextBox.Text);
               
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
                userNametextBox.AutoCompleteCustomSource.Add(userNametextBox.Text);
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
        Product product = new Product();
        private void Ctrl_SearchProduct(object sender, EventArgs e)
        {
            try
            {

                product.productName = productNameTextBox.Text;
                product.productBrand = productBrandTextBox.Text;
                product.productUnitPrice = productUnitPriceTextBox.Text;
                product.productShortDescription = productShortDescriptiontextBox.Text;
                product.productEntryDate = "";
                product.productBarcode = productBarcodeTextBox.Text;
                product.productEntrier = member.userName;
                product.importerName = importerNamemetroTextBox.Text;
                product.importerInvoiceNo = importerInvoiceNoTextBox.Text;
                product.soldPrice = mrp_textBox.Text;
                product.productEntrier = userNametextBox.Text;

                DataSet ds = account_Bo.getProduct(product);
                productMetroGrid.DataSource = ds.Tables[0];
               

                if (productMetroGrid.Rows.Count > 1)
                {
                    Mlabel.Text = (productMetroGrid.Rows.Count).ToString() + " results found";
                }
                else if (productMetroGrid.Rows.Count == 1)
                {
                    Mlabel.Text = "1 result found";
                }
                else
                {
                    Mlabel.Text = "No result found";
                }

                try
                {
                    double pur = 0;
                    double mrp = 0;
                    for (int i = 0; i < productMetroGrid.Rows.Count; i++)
                    {
                        pur += Convert.ToDouble(productMetroGrid.Rows[i].Cells[8].Value.ToString());
                        mrp += Convert.ToDouble(productMetroGrid.Rows[i].Cells[9].Value.ToString());
                    }
                    purchase_Lbl.Text = pur.ToString() + " TK";
                    mrp_label.Text = mrp.ToString() + " TK";
                }
                catch
                {

                }
            }
            catch
            {

            }
        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (returnName_txt.Text != "")
                {
                    Product product = new Product();
                    product.productName = returnName_txt.Text;
                    product.productBrand = returnBrand_txt.Text;
                    product.productUnitPrice = returnUnitPrice_txt.Text;
                    product.productShortDescription = returnShortdescription_txt.Text;
                    product.productEntryDate = returnEntrydate_txt.Text;
                    product.productBarcode = returnBarcode_txt.Text;
                    product.importerName = returnImporterName_txt.Text;
                    product.importerInvoiceNo = returnInvoiceNo_txt.Text;
                    product.soldPrice = returnMrp_TextBox.Text;

                    if (MessageBox.Show("Are you sure?", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        account_Bo.deleteProduct(returnBarcode_txt.Text);
                        MessageBox.Show("Product Delete Successfully Done");
                        returnBarcode_txt.Clear();
                        returnBrand_txt.Clear();  
                        returnImporterName_txt.Clear();
                        returnInvoiceNo_txt.Clear();                     
                        returnName_txt.Clear();
                        returnEntrydate_txt.Clear();
                        returnUnitPrice_txt.Clear();
                        returnShortdescription_txt.Clear();
                        returnMrp_TextBox.Clear();

                        try
                        {

                            product.productName = returnName_txt.Text;
                            product.productBrand = returnBrand_txt.Text;
                            product.productUnitPrice = returnUnitPrice_txt.Text;
                            product.productShortDescription = returnShortdescription_txt.Text;
                            product.productEntryDate = returnEntrydate_txt.Text;
                            product.productBarcode = returnBarcode_txt.Text;
                            product.importerName = returnImporterName_txt.Text;
                            product.importerInvoiceNo = returnInvoiceNo_txt.Text;
                            product.productEntrier = userNametextBox.Text;
                            product.soldPrice = returnMrp_TextBox.Text;
                            DataSet ds = account_Bo.getProduct(product);
                            productMetroGrid.DataSource = ds.Tables[0];
                          

                            if (productMetroGrid.Rows.Count > 1)
                            {
                                Mlabel.Text = (productMetroGrid.Rows.Count).ToString() + " results found";
                            }
                            else if (productMetroGrid.Rows.Count == 1)
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


                }
                else
                {
                    MessageBox.Show("Please select a item first");
                }
            }
            catch
            {

            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (returnName_txt.Text != "")
                {
                    Product product = new Product();
                    product.productName = returnName_txt.Text;
                    product.productBrand = returnBrand_txt.Text;
                    product.productUnitPrice = returnUnitPrice_txt.Text;
                    product.productShortDescription = returnShortdescription_txt.Text;
                    product.productEntryDate = returnEntrydate_txt.Text;
                    product.productBarcode = returnBarcode_txt.Text;
                    product.importerName = returnImporterName_txt.Text;
                    product.importerInvoiceNo = returnInvoiceNo_txt.Text;
                    product.soldPrice = returnMrp_TextBox.Text;
                    product.productEntrier = userNametextBox.Text;
                    if (MessageBox.Show("Are you sure?", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        account_Bo.updateProduct(product);
                        MessageBox.Show("Product Update Successfully Done");
                        returnBarcode_txt.Clear(); 
                        returnBrand_txt.Clear();                 
                        returnImporterName_txt.Clear();
                        returnInvoiceNo_txt.Clear();                  
                        returnName_txt.Clear();
                        returnEntrydate_txt.Clear();
                        returnUnitPrice_txt.Clear();
                        returnShortdescription_txt.Clear();
                        returnMrp_TextBox.Clear();

                        try
                        {

                            product.productName = returnName_txt.Text;
                            product.productBrand = returnBrand_txt.Text;
                            product.productUnitPrice = returnUnitPrice_txt.Text;
                            product.productShortDescription = returnShortdescription_txt.Text;
                            product.productEntryDate = returnEntrydate_txt.Text;
                            product.productBarcode = returnBarcode_txt.Text;
                            product.importerName = returnImporterName_txt.Text;
                            product.importerInvoiceNo = returnInvoiceNo_txt.Text;
                            product.soldPrice = returnMrp_TextBox.Text;
                            product.productEntrier = userNametextBox.Text;
                            DataSet ds = account_Bo.getProduct(product);
                            productMetroGrid.DataSource = ds.Tables[0];
                          

                            if (productMetroGrid.Rows.Count > 1)
                            {
                                Mlabel.Text = (productMetroGrid.Rows.Count).ToString() + " results found";
                            }
                            else if (productMetroGrid.Rows.Count == 1)
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


                }
                else
                {
                    MessageBox.Show("Please select a item first");
                }
            }
            catch
            {

            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void Key_Down(object sender, KeyEventArgs e)
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

        private void returnEntrydate_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void returnImporterID_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void returnLongDescription_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, false);
                returnBarcode_txt.AutoCompleteCustomSource.Add(returnBarcode_txt.Text);
              
                returnBrand_txt.AutoCompleteCustomSource.Add(returnBrand_txt.Text);
                returnEntrydate_txt.AutoCompleteCustomSource.Add(returnEntrydate_txt.Text);
              
                returnImporterName_txt.AutoCompleteCustomSource.Add(returnImporterName_txt.Text);
                returnInvoiceNo_txt.AutoCompleteCustomSource.Add(returnInvoiceNo_txt.Text);
                returnMrp_TextBox.AutoCompleteCustomSource.Add(returnMrp_TextBox.Text);
              
                returnName_txt.AutoCompleteCustomSource.Add(returnName_txt.Text);
             
                returnShortdescription_txt.AutoCompleteCustomSource.Add(returnShortdescription_txt.Text);
                returnUnitPrice_txt.AutoCompleteCustomSource.Add(returnUnitPrice_txt.Text);
               

            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, false);
                returnBarcode_txt.AutoCompleteCustomSource.Add(returnBarcode_txt.Text);
             
                returnBrand_txt.AutoCompleteCustomSource.Add(returnBrand_txt.Text);
                returnEntrydate_txt.AutoCompleteCustomSource.Add(returnEntrydate_txt.Text);
              
                returnImporterName_txt.AutoCompleteCustomSource.Add(returnImporterName_txt.Text);
                returnInvoiceNo_txt.AutoCompleteCustomSource.Add(returnInvoiceNo_txt.Text);
                returnMrp_TextBox.AutoCompleteCustomSource.Add(returnMrp_TextBox.Text);
                
                returnName_txt.AutoCompleteCustomSource.Add(returnName_txt.Text);
                
                returnShortdescription_txt.AutoCompleteCustomSource.Add(returnShortdescription_txt.Text);
                returnUnitPrice_txt.AutoCompleteCustomSource.Add(returnUnitPrice_txt.Text);
              
            }
        }

        private void productMetroGrid_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                returnBarcode_txt.Text = productMetroGrid.CurrentRow.Cells[6].Value.ToString();             
                returnBrand_txt.Text = productMetroGrid.CurrentRow.Cells[1].Value.ToString();            
                returnImporterName_txt.Text = productMetroGrid.CurrentRow.Cells[3].Value.ToString();
                returnInvoiceNo_txt.Text = productMetroGrid.CurrentRow.Cells[2].Value.ToString();          
                returnName_txt.Text = productMetroGrid.CurrentRow.Cells[0].Value.ToString();
                returnEntrydate_txt.Text = productMetroGrid.CurrentRow.Cells[5].Value.ToString();
                returnUnitPrice_txt.Text = productMetroGrid.CurrentRow.Cells[8].Value.ToString();
                returnShortdescription_txt.Text = productMetroGrid.CurrentRow.Cells[4].Value.ToString();
                returnMrp_TextBox.Text = productMetroGrid.CurrentRow.Cells[9].Value.ToString();
            }
            catch
            {

            }
        }

        private void productEntryDTP_CloseUp(object sender, EventArgs e)
        {
            try
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
                product.productEntrier = userNametextBox.Text;

                DataSet ds = account_Bo.getProduct(product);
                productMetroGrid.DataSource = ds.Tables[0];


                if (productMetroGrid.Rows.Count > 1)
                {
                    Mlabel.Text = (productMetroGrid.Rows.Count).ToString() + " results found";
                }
                else if (productMetroGrid.Rows.Count == 1)
                {
                    Mlabel.Text = "1 result found";
                }
                else
                {
                    Mlabel.Text = "No result found";
                }

                try
                {
                    double pur = 0;
                    double mrp = 0;
                    for (int i = 0; i < productMetroGrid.Rows.Count; i++)
                    {
                        pur += Convert.ToDouble(productMetroGrid.Rows[i].Cells[8].Value.ToString());
                        mrp += Convert.ToDouble(productMetroGrid.Rows[i].Cells[9].Value.ToString());
                    }
                    purchase_Lbl.Text = pur.ToString() + " TK";
                    mrp_label.Text = mrp.ToString() + " TK";
                }
                catch
                {

                }
            }
            catch
            {

            }
        }
    }
}
