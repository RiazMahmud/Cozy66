using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATK_Computer_LTD
{
    public partial class Splash : Form
    {
        int i = 0;
        public Splash()
        {
            InitializeComponent();
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            i++;
           // MessageBox.Show(i + "");
            if (i >= 20)
            {
                timerSplash.Stop();
                this.Hide();
                Home f = new Home();
                f.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
        }

      
    }
}
