using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingManagement;
namespace Communication
{
    public class CO
    {
        public void OpenHome(Form from)
        {
            from.Hide();
            Home h = new Home();
            h.Show();
        }
    }
}
