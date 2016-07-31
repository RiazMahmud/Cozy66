using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using ENTITY;
using BO;
using System.Data.SqlClient;
namespace ATK_Computer_LTD
{
    public partial class Home_Admin_PrintBill : Form
    {
        ReportDocument rd = new ReportDocument();
        CrystalReport cr = new CrystalReport();
        TextObject mytext;
        public Home_Admin_PrintBill()
        {
            InitializeComponent();
       
          // cr.ParameterFields.to
        }
        string total;
        string name;
        string address;
        string phoneNo;
        string discount;
        string total1;
       
        public void getTotal(string t,string n, string pNo,string add,string dis,string t1)
        {
            total = t;
            name = n;
            phoneNo = pNo;
            address = add;
            discount = dis;
            total1 = t1;
          
        }
        Account_BO account_Bo = new Account_BO();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet st = account_Bo.getTempClientProduct();
                rd.Load(@"C:\DB\cozzyRpt.rpt");  
                rd.SetDataSource(st.Tables[0]);
               
                crystalReportViewer1.ReportSource = rd;

                if (rd.ReportDefinition.ReportObjects["totalText"] != null)
                {
                    mytext = (TextObject)rd.ReportDefinition.ReportObjects["totalText"];
                    mytext.Text = total+" BDT";
                    //mytext = (TextObject)rd.ReportDefinition.ReportObjects["text_box_customerName"];
                    //mytext.Text = name;
                    //mytext = (TextObject)rd.ReportDefinition.ReportObjects["textbox_Customer_Phoneno"];
                    //mytext.Text = phoneNo;
                    //mytext = (TextObject)rd.ReportDefinition.ReportObjects["textbox_CustomerAddress"];
                    //mytext.Text = address;
                    mytext = (TextObject)rd.ReportDefinition.ReportObjects["Discount"];
                    mytext.Text = discount+"%";
                    mytext = (TextObject)rd.ReportDefinition.ReportObjects["Amount"];
                    mytext.Text = total1 +" BDT";
                  
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bil"+ex.Message);
            }
            
        }

        private void Home_Admin_PrintBill_Load(object sender, EventArgs e)
        {

        }
    }
}
