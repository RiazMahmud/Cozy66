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
namespace ATK_Computer_LTD
{
    public partial class AddNewUser : Form
    {
        public AddNewUser()
        {
            InitializeComponent();
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {

        }
        string userName = null;
        public void giveMemberUserName(string name)
        {
            userName = name;
        }
        LedgerManager ld = new LedgerManager();
        private void button_AddCLient_Click(object sender, EventArgs e)
        {
            if (textBox_Name.Text != "" && textBoxAmount.Text != "")
            {
                ld.AddNewClient(textBox_Name.Text, Convert.ToDecimal(textBoxAmount.Text));
                textBoxAmount.Clear();
                textBox_Name.Clear();
            }
            else
            {
                MessageBox.Show("Pelase enter the information fully");
            }
        }

        private void Ok_Button_Click(object sender, EventArgs e)
        {
            Home_Admin_PartyLedger hp = new Home_Admin_PartyLedger();
            hp.giveMemberUserName(userName);
            hp.Show();
            this.Hide(); 
        }
    }
}
