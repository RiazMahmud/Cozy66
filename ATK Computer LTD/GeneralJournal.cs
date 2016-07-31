using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIBlend.Utilities;
using VIBlend.WinForms.DataGridView;

namespace ATK_Computer_LTD
{
    class GeneralJournal
    {
        private decimal debitAmount;
        private decimal creditAmount;

        string dbLoc = @"D:\DB\Journal.mdf";

        public void AddNewEntry(decimal amount, string type, DateTime time, string name)
        {

            if (type == "Debit")
            {
                debitAmount = amount;
                creditAmount = 0;
            }
            else if (type == "Credit")
            {
                creditAmount = amount;
                debitAmount = 0;
            }

            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + dbLoc + ";Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = con;
                cmdLdger.CommandType = CommandType.Text;
                cmdLdger.CommandText = @"INSERT INTO Enties(Date,AccountTitle,Debit,Credit) 
                                        VALUES('" + time + "','" + name + "','" + debitAmount + "','" + creditAmount + "')";
                cmdLdger.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ShowJournal(vDataGridView dgv)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection cnTB = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + dbLoc + ";Integrated Security=True");
                cnTB.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = cnTB;
                cmdLdger.CommandType = CommandType.Text;
                string query = "SELECT * FROM Enties";
                cmdLdger.CommandText = query;


                // dgv.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLACKPEARL;
                dgv.ColumnsHierarchy.AutoStretchColumns = true;


                SqlDataAdapter daProperty = new SqlDataAdapter(cmdLdger);
                daProperty.Fill(ds);

                dgv.DataSource = ds.Tables[0];
                dgv.ColumnsHierarchy.Items[0].CellsFormatString = "{0:d MMMM yyyy}";


                cnTB.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void TrailBalance(vDataGridView dgv)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection cnTB = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + dbLoc + ";Integrated Security=True");
                cnTB.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = cnTB;
                cmdLdger.CommandType = CommandType.Text;
                //string query = "SELECT * FROM Enties WHERE AccountTitle IN (SELECT AccountTitle FROM Enties GROUP BY AccountTitle HAVING count(*)>1)";
                string query = @"SELECT AccountTitle,sum(Debit) Debit,sum(Credit) Credit
                                 FROM Enties
                                 GROUP BY AccountTitle
                                 ";
                cmdLdger.CommandText = query;

                SqlDataAdapter daProperty = new SqlDataAdapter(cmdLdger);
                daProperty.Fill(ds);
                //dgv.DataSource = ds.Tables[0];

                DataTable dt = ds.Tables[0];
                //decimal sum = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        if ((decimal)dr[1] > (decimal)dr[2])
                        {
                            dr[1] = (decimal)dr[1] - (decimal)dr[2];
                            dr[2] = 0;
                        }
                        else
                        {
                            dr[2] = (decimal)dr[2] - (decimal)dr[1];
                            dr[1] = 0;
                        }
                        //if (dc.ColumnName == "Debit")
                        //    sum += (decimal)dr[dc];
                    }

                }

                decimal dSum = 0;
                decimal cSum = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    dSum += (decimal)dr[1];
                    cSum += (decimal)dr[2];
                }

                GridCellStyle orangestyle = new GridCellStyle();
                orangestyle.FillStyle = new FillStyleSolid(Color.FromArgb(255, 254, 122, 1));
                orangestyle.TextColor = Color.White;

                //dgv.CellsArea.SetCellDrawStyle(grid.RowsHierarchy.Items[1], this.grid.ColumnsHierarchy.Items[3], orangestyle);

                dt.Rows.Add("Total", dSum, cSum);
                dgv.DataSource = dt;

                dgv.RowsHierarchy.Items[dgv.RowsHierarchy.Items.Count - 1].CellsStyle = orangestyle;
                dgv.ColumnsHierarchy.AutoStretchColumns = true;

                cnTB.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Ledger(vDataGridView dgv)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection cnTB = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + dbLoc + ";Integrated Security=True");
                cnTB.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = cnTB;
                cmdLdger.CommandType = CommandType.Text;
                string query = "SELECT * FROM Enties";
                cmdLdger.CommandText = query;


                dgv.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLACKPEARL;
                dgv.ColumnsHierarchy.AutoStretchColumns = true;
                //dgv.GroupingColumns.
                //dgv.GroupingEnabled = true;

                SqlDataAdapter daProperty = new SqlDataAdapter(cmdLdger);
                daProperty.Fill(ds);

                dgv.BoundFields.Add(new BoundField("Date", "Date"));
                dgv.BoundFields.Add(new BoundField("Accounts", "AccountTitle"));
                dgv.BoundFields.Add(new BoundField("Debit", "Debit"));
                dgv.BoundFields.Add(new BoundField("Credit", "Credit"));
                dgv.BoundFields.Add(new BoundField("Sum", "Sum"));
                dgv.GroupingColumns.Add(new BoundField("Accounts", "AccountTitle"));
                dgv.GroupingEnabled = true;

                dgv.DataSource = ds.Tables[0];
                dgv.ColumnsHierarchy.Items[0].CellsFormatString = "{0:d MMMM yyyy}";
                cnTB.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddNewBankEntry(DateTime date, string particular, string check, string recievable, string payable, decimal deposit, decimal withdrawl)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + dbLoc + ";Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = con;
                cmdLdger.CommandType = CommandType.Text;
                //date = Convert.ToDateTime(d);
                cmdLdger.CommandText = @"INSERT INTO Bank(Date,Particulars,CheckNo,Recievable,Payable,Deposit,Withdrawl) 
                                        VALUES('" + date.Date + "','" + particular + "','" + check + "','" + recievable + "','" + payable + "','" + deposit + "','" + withdrawl + "')";
                cmdLdger.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowBankTransection(vDataGridView dgv)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection cnTB = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + dbLoc + ";Integrated Security=True");
                cnTB.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = cnTB;
                cmdLdger.CommandType = CommandType.Text;
                string query = "SELECT Date,Particulars,CheckNo,Recievable,Payable,Deposit,Withdrawl FROM Bank";
                cmdLdger.CommandText = query;


                dgv.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLACKPEARL;
                dgv.ColumnsHierarchy.AutoStretchColumns = true;


                SqlDataAdapter daProperty = new SqlDataAdapter(cmdLdger);
                daProperty.Fill(ds);
                dgv.DataSource = ds.Tables[0];

                dgv.ColumnsHierarchy.Items[0].CellsFormatString = "{0:d MMMM yyyy}";
                cnTB.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowSearchResut(string check, string particular, DateTime startTime, DateTime endTime, vDataGridView dgv)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection cnTB = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + dbLoc + ";Integrated Security=True");
                cnTB.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = cnTB;
                cmdLdger.CommandType = CommandType.Text;
                //string query = "SELECT * FROM Bank Where CheckNo='" + check + "'";
                string query = "SELECT * FROM Bank Where Date between @SD and @ED";

                if (particular != "")
                {
                    query = query + "AND Particulars='" + particular + "'";
                }
                if (check != "")
                {
                    query = query + "AND CheckNo= '" + check + "'";
                }
                cmdLdger.CommandText = query;
                cmdLdger.Parameters.AddWithValue("@SD", startTime);
                cmdLdger.Parameters.AddWithValue("@ED", endTime);
                SqlDataAdapter daProperty = new SqlDataAdapter(cmdLdger);
                daProperty.Fill(ds);

                dgv.DataSource = ds.Tables[0];

                dgv.ColumnsHierarchy.Items[0].CellsFormatString = "{0:d MMMM yyyy}";
                // MessageBox.Show(billtime.Date+"");
                cnTB.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Search. Try Again");
            }

        }


        public void filterResult(DateTime startDate, DateTime endDate, vDataGridView dgv)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection cnTB = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + dbLoc + ";Integrated Security=True");
                cnTB.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = cnTB;
                cmdLdger.CommandType = CommandType.Text;
                //string query = "SELECT * FROM Bank Where CheckNo='" + check + "'";
                string query = "SELECT * FROM Enties Where Date between @SD and @ED";


                cmdLdger.CommandText = query;
                cmdLdger.Parameters.AddWithValue("@SD", startDate);
                cmdLdger.Parameters.AddWithValue("@ED", endDate);
                SqlDataAdapter daProperty = new SqlDataAdapter(cmdLdger);
                daProperty.Fill(ds);
                dgv.DataSource = ds.Tables[0];

                dgv.ColumnsHierarchy.Items[0].CellsFormatString = "{0:d MMMM yyyy}";
                // MessageBox.Show(billtime.Date+"");
                cnTB.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Search. Try Again");
                // MessageBox.Show(ex.Message);
            }
        }

        public void filterLedger(DateTime startDate, DateTime endDate, vDataGridView dgv)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection cnTB = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + dbLoc + ";Integrated Security=True");
                cnTB.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = cnTB;
                cmdLdger.CommandType = CommandType.Text;
                //string query = "SELECT * FROM Enties WHERE AccountTitle IN (SELECT AccountTitle FROM Enties GROUP BY AccountTitle HAVING count(*)>1)";

                string query = @"SELECT AccountTitle,sum(Debit) Debit,sum(Credit) Credit                
                                                from (select t.*,
                                                (row_number() over (order by AccountTitle) -
                                                row_number() over (partition by AccountTitle order by Date)) 
                                                as grpid
                                                from Enties t Where Date Between'" + startDate + "'and'" + endDate +
                                "') t group by grpid, AccountTitle";


                cmdLdger.CommandText = query;

                SqlDataAdapter daProperty = new SqlDataAdapter(cmdLdger);
                daProperty.Fill(ds);

                DataTable dt = ds.Tables[0];
                decimal dSum = 0;
                decimal cSum = 0;
                foreach (DataRow dr in dt.Rows)
                {

                    if ((decimal)dr[1] > (decimal)dr[2])
                    {
                        dr[1] = (decimal)dr[1] - (decimal)dr[2];
                        dr[2] = 0;
                    }
                    else
                    {
                        dr[2] = (decimal)dr[2] - (decimal)dr[1];
                        dr[1] = 0;
                    }


                }

                foreach (DataRow dr in dt.Rows)
                {
                    dSum += (decimal)dr[1];
                    cSum += (decimal)dr[2];
                }

                GridCellStyle orangestyle = new GridCellStyle();
                orangestyle.FillStyle = new FillStyleSolid(Color.FromArgb(255, 254, 122, 1));
                orangestyle.TextColor = Color.White;

                dt.Rows.Add("Total", dSum, cSum);
                dgv.DataSource = dt;

                dgv.RowsHierarchy.Items[dgv.RowsHierarchy.Items.Count - 1].CellsStyle = orangestyle;
                dgv.ColumnsHierarchy.AutoStretchColumns = true;
                dgv.Refresh();
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Invalid Search. Try Again");
                MessageBox.Show(ex.Message);
            }
        }


        void ShowTotal()
        {

        }
    }
}
