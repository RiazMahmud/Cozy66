﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BO;
using ENTITY;
using System.IO;
namespace ATK_Computer_LTD
{
    public partial class Home_Admin_Exchanged_Client : Form
    {
        public Home_Admin_Exchanged_Client()
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

        private void Home_Admin_CreditHistory_Load(object sender, EventArgs e)
        {
            setFullScreen();
            setMainPanelPosition();
            setRightOptionPanel();
            right_option_timer.Start();


           
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

        private void Home_Admin_CreditHistory_MouseMove(object sender, MouseEventArgs e)
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

        private void Home_Admin_CreditHistory_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void productUnitPriceTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void productEntryDTP_CloseUp(object sender, EventArgs e)
        {
            
           
        }

        private void userName_textBox_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        private void phoneNo_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void payAmount_textBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void clientHistoryMetroGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void payment_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void barcodeClienttextBox_TabIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void barcodeClienttextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataSet ds = account_Bo.getReturnClientProduct(barcodeClienttextBox.Text, invoiceNoTextBox.Text);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void barcodeClienttextBox_KeyDown(object sender, KeyEventArgs e)
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

        private void productMetroGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
                reference_textBox.Text = productMetroGrid.CurrentRow.Cells[15].Value.ToString();
                cause_textBox.Text = productMetroGrid.CurrentRow.Cells[16].Value.ToString();
                returndate_textBox.Text = productMetroGrid.CurrentRow.Cells[17].Value.ToString();
                try
                {
                    invoiceNo_textBox.Text = productMetroGrid.CurrentRow.Cells[14].Value.ToString();
                }
                catch
                {

                }

            }
            catch
            {

            }
        }

        private void returnClient_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (returnName_txt.Text != "" && reference_textBox.Text != "" && cause_textBox.Text != "" && invoiceNo_textBox.Text != "")
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
                    product.productEntrier = productMetroGrid.CurrentRow.Cells[7].Value.ToString();
                    product.profit = productMetroGrid.CurrentRow.Cells[10].Value.ToString();
                    product.soldDate = productMetroGrid.CurrentRow.Cells[11].Value.ToString();
                    product.importerID = productMetroGrid.CurrentRow.Cells[14].Value.ToString();
                    if (MessageBox.Show("Are you sure?", "Return to client", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        account_Bo.setSoldProduct(product, productMetroGrid.CurrentRow.Cells[12].Value.ToString(), productMetroGrid.CurrentRow.Cells[9].Value.ToString());
                        account_Bo.deleteReturnClientProduct(returnBarcode_txt.Text);
                        MessageBox.Show("Back Product to Client Successfully Done");
                        returnBarcode_txt.Clear();
                        returnBrand_txt.Clear();
                        returnImporterName_txt.Clear();
                        returnInvoiceNo_txt.Clear();
                        returnName_txt.Clear();
                        returnEntrydate_txt.Clear();
                        returnUnitPrice_txt.Clear();
                        returnShortdescription_txt.Clear();
                        returnMrp_TextBox.Clear();
                        reference_textBox.Clear();
                        cause_textBox.Clear();
                        invoiceNo_textBox.Clear();
                        try
                        {

                           
         
                            DataSet ds = account_Bo.getReturnClientProduct("", "");
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
                    MessageBox.Show("Please select a item first and fill the information fully");
                }
            }
            catch
            {

            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (returnName_txt.Text != "" && reference_textBox.Text != "" && cause_textBox.Text != "" && invoiceNo_textBox.Text != "")
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
                    product.productEntrier = productMetroGrid.CurrentRow.Cells[7].Value.ToString();
                    product.profit = productMetroGrid.CurrentRow.Cells[10].Value.ToString();
                    product.soldDate = productMetroGrid.CurrentRow.Cells[11].Value.ToString();
                    product.importerID = productMetroGrid.CurrentRow.Cells[14].Value.ToString();
                    if (MessageBox.Show("Are you sure?", "Delete this record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        
                        account_Bo.deleteReturnClientProduct(returnBarcode_txt.Text);
                        MessageBox.Show("Exchanged Product From Delete Successfully Done");
                        returnBarcode_txt.Clear();
                        returnBrand_txt.Clear();
                        returnImporterName_txt.Clear();
                        returnInvoiceNo_txt.Clear();
                        returnName_txt.Clear();
                        returnEntrydate_txt.Clear();
                        returnUnitPrice_txt.Clear();
                        returnShortdescription_txt.Clear();
                        returnMrp_TextBox.Clear();
                        reference_textBox.Clear();
                        cause_textBox.Clear();
                        invoiceNo_textBox.Clear();
                        try
                        {



                            DataSet ds = account_Bo.getReturnClientProduct("", "");
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
                    MessageBox.Show("Please select a item first and fill the information fully");
                }
            }
            catch
            {

            }
        }
    }
}
