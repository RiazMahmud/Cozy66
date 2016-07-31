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
    public partial class Home_Admin_Bill : Form
    {
        public Home_Admin_Bill()
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

        private void Home_Admin_Bill_MouseMove(object sender, MouseEventArgs e)
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
        private void Home_Admin_Bill_Load(object sender, EventArgs e)
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
        Product product = new Product();
        private void Ctrl_Serach(object sender, EventArgs e)
        {
            
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
            if (totalmetroTextBox.Text == "" || totalmetroTextBox.Text=="0")
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

                else if (sender == exit_pnl)
                {
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("You can not go without check out it");
            }
            if (sender == minimized_pnl)
            {
                right_option_timer.Stop();
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void minimized_pnl_SizeChanged(object sender, EventArgs e)
        {
          
        }

        private void Ctrl_search(object sender, KeyEventArgs e)
        {
           
        }

        private void productMetroGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
        private void reloadshoppingCartDataGridview()
        {
            DataSet ds = account_Bo.getTempClientProduct();
            shoppingCartMetroGrid.DataSource = ds.Tables[0];
            
        }
        private void return_btn_Click(object sender, EventArgs e)
        {

        }

        private void removefromCartbutton_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            try
            {
                if (returnBarcode_txt.Text != "")
                {

                   
                    if (MessageBox.Show("Are you sure?", "Remove from cart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        product = account_Bo.getTempProductBySerialNoforReentry(returnBarcode_txt.Text);
                        account_Bo.setProduct(product);
                        account_Bo.deleteTempProduct(returnBarcode_txt.Text);
                        reloadshoppingCartDataGridview();
                        calculateTotal();
                        try
                        {

                            Product sproduct = new Product();
                            sproduct.productBarcode = "";
                            sproduct.productBatchNo = "";
                            DataSet ds = account_Bo.getProduct(sproduct);
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
                        returnBarcode_txt.Clear();                    
                        soldPrice_txt.Clear();
                        purchasePrice_txt.Clear();
                        returnName_txt.Clear();
                        nettotalmetroTextBox.Clear();
                        discountmetroTextBox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a item");
                }
            }
            catch
            {

            }
        }

        private void shoppingCartMetroGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
           
        }

        private void discountmetroTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void calculateTotal()
        {
            double amount = 0;
            for (int i = 0; i < shoppingCartMetroGrid.Rows.Count; i++)
            {
                amount += Convert.ToDouble(shoppingCartMetroGrid.Rows[i].Cells[9].Value.ToString());
            }
            totalmetroTextBox.Text = amount.ToString();
        }
    
        private void AddToCart_btn_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            try
            {
                if (returnBarcode_txt.Text != "")
                {
                    if (soldPrice_txt.Text != "")
                    {
                       
                        product.productName = productMetroGrid.CurrentRow.Cells[0].Value.ToString();
                        product.productBrand =  productMetroGrid.CurrentRow.Cells[1].Value.ToString();
                        product.productUnitPrice =  productMetroGrid.CurrentRow.Cells[8].Value.ToString();
                        product.productShortDescription =  productMetroGrid.CurrentRow.Cells[4].Value.ToString();
                        product.productEntryDate =  productMetroGrid.CurrentRow.Cells[5].Value.ToString();
                        product.productBarcode =  productMetroGrid.CurrentRow.Cells[6].Value.ToString();
                        product.importerName =  productMetroGrid.CurrentRow.Cells[3].Value.ToString();
                        product.importerInvoiceNo =  productMetroGrid.CurrentRow.Cells[2].Value.ToString();
                        product.soldPrice = productMetroGrid.CurrentRow.Cells[9].Value.ToString();
                        product.productEntrier =  productMetroGrid.CurrentRow.Cells[7].Value.ToString();
                        product.soldDate = firstdateTimePicker.Text;
                       
                        product.profit = (Convert.ToDouble(soldPrice_txt.Text) - Convert.ToDouble(purchasePrice_txt.Text)).ToString();
                        if (MessageBox.Show("Are you sure?", "Add to cart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            
                           try
                           {
                                    account_Bo.setTempProduct(product);

                                    reloadshoppingCartDataGridview();

                                    account_Bo.deleteProduct(product.productBarcode);


                                    Product sproduct = new Product();
                                    sproduct.productBarcode = "";
                                    sproduct.productBatchNo = "";
                                    DataSet ds = account_Bo.getProduct(sproduct);
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

                                    calculateTotal();
                                }
                                catch
                                {

                                }
                                soldPrice_txt.Clear();
                                returnBarcode_txt.Clear();
                                purchasePrice_txt.Clear();
                                returnName_txt.Clear();
                            }
                        }
                  
                    
                }
                else
                {
                    MessageBox.Show("Please select a item");
                }
            }
            catch
            {
              
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            clientAddresstextbox.Clear();
            clienCardNo.Clear();
            clientNametextbox.Clear();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
           
        }

        private void clientMobileNo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Home_Admin_Bill_SizeChanged(object sender, EventArgs e)
        {
            setRightOptionPanel();
            right_option_timer.Start();
        }

        private void CheckOut_btn_Click(object sender, EventArgs e)
        {
            try
            {

               
                
                if (clientNametextbox.Text != "" && clienCardNo.Text != "" && clientAddresstextbox.Text != "")
                {
                   
                    if (nettotalmetroTextBox.Text != "" )
                    {
                        if (due_metroTextBox.Text != "Negetive balance")
                        {

                            if (MessageBox.Show("Are you sure?", "Check Out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                CheckOut_btn.Enabled = false;

                                try
                                {
                                    double dis = Convert.ToDouble(discountmetroTextBox.Text);
                                    //dis = dis / shoppingCartMetroGrid.Rows.Count;
                                    for (int i = 0; i < shoppingCartMetroGrid.Rows.Count; i++)
                                    {
                                        //product.productSerialNo = shoppingCartMetroGrid.Rows[i].Cells[0].Value.ToString();
                                        //product.productName = shoppingCartMetroGrid.Rows[i].Cells[1].Value.ToString();
                                        //product.productModel = shoppingCartMetroGrid.Rows[i].Cells[2].Value.ToString();
                                        //product.productBrand = shoppingCartMetroGrid.Rows[i].Cells[3].Value.ToString();
                                        //product.importerInvoiceNo = shoppingCartMetroGrid.Rows[i].Cells[4].Value.ToString();
                                        //product.importerID = shoppingCartMetroGrid.Rows[i].Cells[5].Value.ToString();
                                        //product.importerName = shoppingCartMetroGrid.Rows[i].Cells[6].Value.ToString();
                                        //product.productAvailableWarrenty = shoppingCartMetroGrid.Rows[i].Cells[7].Value.ToString();
                                        //product.productShortDescription = shoppingCartMetroGrid.Rows[i].Cells[8].Value.ToString();
                                        //product.productLongDescription = shoppingCartMetroGrid.Rows[i].Cells[9].Value.ToString();
                                        //product.productEntryDate = shoppingCartMetroGrid.Rows[i].Cells[10].Value.ToString();
                                        //product.productBarcode = shoppingCartMetroGrid.Rows[i].Cells[11].Value.ToString();
                                        //product.productEntrier = shoppingCartMetroGrid.Rows[i].Cells[12].Value.ToString();
                                        //product.productUnitPrice = shoppingCartMetroGrid.Rows[i].Cells[13].Value.ToString();
                                        //product.productBatchNo = shoppingCartMetroGrid.Rows[i].Cells[14].Value.ToString();
                                        //product.soldDate = firstdateTimePicker.Text;
                                        ////dis = dis / 100;
                                     
                                        product.productName = shoppingCartMetroGrid.Rows[i].Cells[0].Value.ToString();
                                        product.productBrand = shoppingCartMetroGrid.Rows[i].Cells[1].Value.ToString();
                                        product.productUnitPrice = shoppingCartMetroGrid.Rows[i].Cells[8].Value.ToString();
                                        product.productShortDescription = shoppingCartMetroGrid.Rows[i].Cells[4].Value.ToString();
                                        product.productEntryDate = shoppingCartMetroGrid.Rows[i].Cells[5].Value.ToString();
                                        product.productBarcode = shoppingCartMetroGrid.Rows[i].Cells[6].Value.ToString();
                                        product.importerName = shoppingCartMetroGrid.Rows[i].Cells[3].Value.ToString();
                                        product.importerInvoiceNo = shoppingCartMetroGrid.Rows[i].Cells[2].Value.ToString();
                                        product.soldPrice = shoppingCartMetroGrid.Rows[i].Cells[9].Value.ToString();
                                        product.productEntrier = shoppingCartMetroGrid.Rows[i].Cells[7].Value.ToString();
                                        product.soldDate = firstdateTimePicker.Text;
                                        product.refrence = userName;
                                        //product.profit = (Convert.ToDouble(soldPrice_txt.Text) - Convert.ToDouble(purchasePrice_txt.Text)).ToString();
                                        double s = Convert.ToDouble(shoppingCartMetroGrid.Rows[i].Cells[9].Value.ToString());
                                        s = (s - (s*(dis/100)));
                                        product.soldPrice = s.ToString();
                                        product.profit = (Convert.ToDouble(s.ToString()) - Convert.ToDouble(shoppingCartMetroGrid.Rows[i].Cells[8].Value.ToString())).ToString();
                                       
                                        


                                        ////creditHistorySet
                                        StreamReader reader = new StreamReader(@"C:\DB\Invoice.txt");
                                        double invoice = Convert.ToDouble(reader.ReadLine());
                                        reader.Close();
                                        invoice++;
                                        string invoice2 = "COZY66-" + Convert.ToString(invoice);
                                        //CreditHistory creditHistory = new CreditHistory();
                                        //creditHistory.invoiceNo = invoice2;
                                        //creditHistory.name = clientNametextbox.Text;
                                        //creditHistory.address = clientAddresstextbox.Text;
                                        //creditHistory.mobileNo = clienCardNo.Text;
                                        //creditHistory.cash = cash_metroTextBox.Text;
                                        //creditHistory.due = due_metroTextBox.Text;
                                        //creditHistory.date = productEntryDTP.Text;
                                        //creditHistory.reference = userName;
                                        //account_Bo.setCreditHistory(creditHistory);
                                        //account_Bo.setCreditHistoryBalance(creditHistory);
                                        StreamWriter writer = new StreamWriter(@"C:\DB\Invoice.txt");
                                        writer.Write(invoice.ToString());
                                        writer.Close();
                                        product.importerID = invoice2;

                                        account_Bo.setSoldProduct(product, discountmetroTextBox.Text, shoppingCartMetroGrid.Rows[i].Cells[9].Value.ToString());
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("!"+ex.Message);
                                }
                                Home_Admin_PrintBill hp = new Home_Admin_PrintBill();
                                hp.getTotal(nettotalmetroTextBox.Text, clientNametextbox.Text, clienCardNo.Text, clientAddresstextbox.Text, discountmetroTextBox.Text, totalmetroTextBox.Text);
                                hp.Show();
                               
                                CheckOut_btn.Enabled = true;
                                totalmetroTextBox.Clear();
                                returnBarcode_txt.Clear();
                                soldPrice_txt.Clear();
                                nettotalmetroTextBox.Clear();
                                discountmetroTextBox.Clear();
                                purchasePrice_txt.Clear();
                                returnName_txt.Clear();
                                due_metroTextBox.Clear();
                                cash_metroTextBox.Clear();
                                account_Bo.deleteAllTempProduct();
                                reloadshoppingCartDataGridview();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Negative balance!! Please enter the amount in correct format");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please fill the discount text");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the client details");
                }
                //MessageBox.Show("Your system doesn't fullfill the requirment error code: 0x6DG*");
            }
            catch(Exception ex)
            {
                MessageBox.Show("@"+ex.Message);
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

        private void right_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void preview_button_Click(object sender, EventArgs e)
        {
            ATKprintPreviewDialog.Document = ATKprintDocument;
            ATKprintPreviewDialog.ShowDialog();
        }

        private void ATKprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
         
        }

        private void Ctrl_Client(object sender, KeyEventArgs e)
        {

           
        }

        private void Client_Ctrl(object sender, KeyEventArgs e)
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

        private void productMetroGrid_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                returnBarcode_txt.Text = productMetroGrid.CurrentRow.Cells[11].Value.ToString();
                purchasePrice_txt.Text = productMetroGrid.CurrentRow.Cells[13].Value.ToString();
                returnName_txt.Text = productMetroGrid.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {

            }
        }

        private void shoppingCartMetroGrid_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                returnBarcode_txt.Clear();
                purchasePrice_txt.Clear();
                returnName_txt.Clear();

                returnName_txt.Text = shoppingCartMetroGrid.CurrentRow.Cells[0].Value.ToString();
                returnBarcode_txt.Text = shoppingCartMetroGrid.CurrentRow.Cells[6].Value.ToString();
                purchasePrice_txt.Text = shoppingCartMetroGrid.CurrentRow.Cells[8].Value.ToString();
                soldPrice_txt.Text = shoppingCartMetroGrid.CurrentRow.Cells[9].Value.ToString();
            }
            catch
            {

            }
        }

        private void clientMobileNo_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                Client client = account_Bo.getClient(clienCardNo.Text);
                clientAddresstextbox.Text = client.customerAddress;
                clientMobileNo.Text = client.customerMobileNo;
                clientNametextbox.Text = client.customerFirstName;
                DateTime expairy = DateTime.Parse(client.customerlifeStyleCardExpiaryDate);
                string date =  DateTime.Now.ToShortDateString();
                DateTime dt = DateTime.Parse(date);



                string s= expairy.Subtract(dt).TotalDays.ToString();
                int a = Convert.ToInt32(s);
                if (a < 0)
                {
                    MessageBox.Show("Sorry!! Lifestyle card validation has been expired. Please reissue again");
                }
              
               
            }
            catch
            {
                clientAddresstextbox.Clear();
                clientMobileNo.Clear();
                clientNametextbox.Clear();
              
            }
        }

        private void cash_metroTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void discountmetroTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void discountmetroTextBox_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void cash_metroTextBox_TextChanged_1(object sender, EventArgs e)
        {

           
        }

        private void discountmetroTextBox_KeyDown_1(object sender, KeyEventArgs e)
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

        private void userNametextBox_TextChanged(object sender, EventArgs e)
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
            }
            catch
            {

            }
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
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
            }
            catch
            {

            }
        }

        private void productMetroGrid_CellMouseClick_2(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                returnName_txt.Text = productMetroGrid.CurrentRow.Cells[0].Value.ToString();
                returnBarcode_txt.Text = productMetroGrid.CurrentRow.Cells[6].Value.ToString();
                purchasePrice_txt.Text = productMetroGrid.CurrentRow.Cells[8].Value.ToString();
                soldPrice_txt.Text = productMetroGrid.CurrentRow.Cells[9].Value.ToString();
            }
            catch
            {

            }
        }

        private void discountmetroTextBox_TextChanged_2(object sender, EventArgs e)
        {
            try
            {
                if (discountmetroTextBox.Text != "")
                {
                    double percent = Convert.ToDouble(discountmetroTextBox.Text);
                    double total = Convert.ToDouble(totalmetroTextBox.Text);
                    total = total - total * (percent / 100);
                    nettotalmetroTextBox.Text = total.ToString();
                }
                else
                {
                    nettotalmetroTextBox.Clear();
                }
           
                double a = Convert.ToDouble(nettotalmetroTextBox.Text);
                double c = Convert.ToDouble(cash_metroTextBox.Text);
                a = c - a;

                due_metroTextBox.Text = a.ToString();

            }
            catch
            {
                due_metroTextBox.Clear();
            }
        }
    }
}
