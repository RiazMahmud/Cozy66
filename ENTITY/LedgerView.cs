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
    public class LedgerView
    {
        string connString = @"Data Source=ATK-PC,49172;Network Library=DBMSSOCN;Initial Catalog=H:\APPSTICK_PROJECT\ATK COMPUTER LTD\ATK COMPUTER LTD\DATABASE.MDF;Integrated Security=True";
        //string connString = @"Data Source=DESKTOP-9KNRBC7,49172;Network Library=DBMSSOCN;Initial Catalog=H:\APPSTICK_PROJECT\ATK COMPUTER LTD\ATK COMPUTER LTD\DATABASE.MDF;Integrated Security=True"; 
        //string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DB\Database.mdf;Integrated Security=True"; 
        SqlDataAdapter daLedger;
        SqlCommandBuilder sqb;
        DataSet ds;
        public void DisplayAll(DataGridView dtagrdview)
        {
            ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();
                SqlCommand cmdLdger = new SqlCommand();
                cmdLdger.Connection = con;
                cmdLdger.CommandType = CommandType.Text;
                cmdLdger.CommandText = "SELECT * FROM GeneralLedger";
                daLedger = new SqlDataAdapter(cmdLdger);
                daLedger.Fill(ds, "Detail");
                con.Close();

                dtagrdview.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("ErrorLV" + ex.Message);
            }
        }

        public void UpdateDB()
        {
            if (MessageBox.Show("Are you sure ?", "Update", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sqb = new SqlCommandBuilder(daLedger);
                daLedger.Update(ds, "Detail");
                MessageBox.Show("Successfully Updated");
            }
            else
            {
                MessageBox.Show("Something Went Wrong. Please try later.");
            }
        }
    }
}
