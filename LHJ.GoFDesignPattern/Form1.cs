using LHJ.GoFDesignPattern.Creational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.GoFDesignPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSingleton_Click(object sender, EventArgs e)
        {
            frmSingleton frm = new frmSingleton();
            frm.Show();
        }
    }
}
