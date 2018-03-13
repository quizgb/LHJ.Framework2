using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.DBCheck
{
    public partial class frmFactoryMethod : Form
    {
        public frmFactoryMethod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            csDBCheck dbChk = new csDBCheck();
        }
    }
}
