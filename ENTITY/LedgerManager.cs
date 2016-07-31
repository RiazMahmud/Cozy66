using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;
namespace ENTITY
{
    public class LedgerManager
    {
        string connString = @"Data Source=ATK-PC,49172;Network Library=DBMSSOCN;Initial Catalog=H:\APPSTICK_PROJECT\ATK COMPUTER LTD\ATK COMPUTER LTD\DATABASE.MDF;Integrated Security=True";
        //string connString = @"Data Source=DESKTOP-9KNRBC7,49172;Network Library=DBMSSOCN;Initial Catalog=H:\APPSTICK_PROJECT\ATK COMPUTER LTD\ATK COMPUTER LTD\DATABASE.MDF;Integrated Security=True"; 

        //Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename="";Integrated Security = True
        //string dbLocation = @"C:\Users\Shuvro\Documents\Visual Studio 2015\Projects\GeneralLedger\GeneralLedger\GeneralLedger.mdf";
        //string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DB\Database.mdf;Integrated Security=True"; 
        //SqlConnection cnTB = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbLocation + ";Integrated Security = True; Connect Timeout =30");
        bool sameName;
        Company c;
        private decimal debitAmount;
        private decimal creditAmount;
        public void AddNewEntry(string name, DateTime time, string particulars, string reference, DateTime billdate, decimal amount)
        {
            
            c = new Company(name, amount);
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);

            if (particulars == "Opening Balance")
            {
                PartyEntry(name, amount);
                if (sameName == true)
                {
                    return;
                }
                debitAmount = 0;
                creditAmount = 0;
            }

            else if (particulars == "Sales")
            {
                c.Balance = GetCompanyBalance(name);
                debitAmount = c.deposite(amount);
                UpdateCompanyBalance(name, c.Balance);
            }
            else if (particulars == "CashCollection")
            {
                c.Balance = GetCompanyBalance(name);
                creditAmount = c.withdraw(amount);
                UpdateCompanyBalance(name, c.Balance);
            }
            else
            {
                debitAmount = 0;
                creditAmount = 0;
            }


            try
            {
                con.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = con;
                cmdLdger.CommandType = CommandType.Text;
                cmdLdger.CommandText = @"INSERT INTO GeneralLedger(CompanyName,Date,Description,CheckNo,BillDate,Debit,Credit,Balance) 
                                        VALUES('" + name + "','" + time + "','" + particulars + "','" + reference + "' , '" + billdate + "', '" + debitAmount + "', '" + creditAmount + "','" + c.Balance + "')";
                cmdLdger.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done");
            }
            catch 
            {
                MessageBox.Show("Party with a same name exists");
            }
        }

        void PartyEntry(string name, decimal amount)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbLocation + ";Integrated Security = True; Connect Timeout =30");
                con.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = con;
                cmdLdger.CommandType = CommandType.Text;
                cmdLdger.CommandText = "UPDATE PatyLedger SET Balance = '" + amount + "' Where CompanyName = '" + name + "'";
                cmdLdger.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("Done");
            }
            catch
            {

                MessageBox.Show("A Party with same name exits. Try to name something else!!!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                sameName = true;
            }

        }

        decimal GetCompanyBalance(string name)
        {
            try
            {
                SqlConnection cnTB = new SqlConnection(connString);
                //SqlConnection cnTB = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbLocation + ";Integrated Security = True; Connect Timeout =30");
                cnTB.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = cnTB;
                cmdLdger.CommandType = CommandType.Text;
                string query = "SELECT Balance FROM PatyLedger Where CompanyName='" + name + "'";
                cmdLdger.CommandText = query;
                string s = cmdLdger.ExecuteScalar().ToString();
                cnTB.Close();
                return Convert.ToDecimal(s);
            }
            catch
            {
                MessageBox.Show("Didnt found Anything Out There");
                return 0;
            }
        }

        void UpdateCompanyBalance(string name, decimal bal)
        {
            try
            {
                SqlConnection cnTB = new SqlConnection(connString);
                //SqlConnection cnTB = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbLocation + ";Integrated Security = True; Connect Timeout =30");
                cnTB.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = cnTB;
                cmdLdger.CommandType = CommandType.Text;
                cmdLdger.CommandText = "UPDATE PatyLedger SET Balance = '" + bal + "' Where CompanyName = '" + name + "'";
                cmdLdger.ExecuteNonQuery();
                cnTB.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No Patry With the name Exists!!!!");
            }
            
        }

        public void ShowSearchResut(string name, string billNo, DateTime billtime, DataGridView dgv)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection cnTB = new SqlConnection(connString);
                //SqlConnection cnTB = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbLocation + ";Integrated Security = True; Connect Timeout =30");
                cnTB.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = cnTB;
                cmdLdger.CommandType = CommandType.Text;
                string query = "SELECT * FROM GeneralLedger Where CompanyName='" + name + "'";
                if (billNo != "")
                {
                    query = query + "AND CheckNo='" + billNo + "'";
                }
                if (!billtime.Equals(""))
                {
                    query = query + "AND BillDate= '" + billtime + "'";
                }
                cmdLdger.CommandText = query;

                SqlDataAdapter daProperty = new SqlDataAdapter(cmdLdger);
                daProperty.Fill(ds);
                dgv.DataSource = ds.Tables[0];
                cnTB.Close();
            }
            catch
            {
                MessageBox.Show("Sorry! Didn't find anything");
            }

        }

        public void GetUnpaidInvoice(int amount, DataGridView dgv)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection cnTB = new SqlConnection(connString);
                //SqlConnection cnTB = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbLocation + ";Integrated Security = True; Connect Timeout =30");
                cnTB.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = cnTB;
                cmdLdger.CommandType = CommandType.Text;
                string query = "SELECT CompanyName FROM GeneralLedger Where Balance >'" + amount + "'";
                cmdLdger.CommandText = query;
                string name = cmdLdger.ExecuteScalar().ToString();
                query = "SELECT * FROM GeneralLedger Where CompanyName='" + name + "'";
                cmdLdger.CommandText = query;

                SqlDataAdapter daProperty = new SqlDataAdapter(cmdLdger);
                daProperty.Fill(ds);
                dgv.DataSource = ds.Tables[0];
                cnTB.Close();

            }
            catch
            {
                MessageBox.Show("No data exists!!");
            }
        }
        public void AddNewClient(string name, decimal amount)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbLocation + ";Integrated Security = True; Connect Timeout =30");
                con.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = con;
                cmdLdger.CommandType = CommandType.Text;
                cmdLdger.CommandText = @"INSERT INTO PatyLedger(CompanyName,Balance) 
                                        VALUES('" + name + "','" + amount + "')";
                cmdLdger.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Added");
            }
            catch
            {
                MessageBox.Show("A Party with same name exits. Try to name something else!!!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
