using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.GoFDesignPattern.Creational
{
    public partial class frmSingleton : Form
    {
        public frmSingleton()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            if (s1 == s2)
            {
                MessageBox.Show("Objects are the same instance");
            }
            else
            {
                MessageBox.Show("Objects are the not same instance");
            }
        }
    }
}
