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
            LHJ.GoFDesignPattern.Creational.Singleton.frmSingleton frm = new LHJ.GoFDesignPattern.Creational.Singleton.frmSingleton();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LHJ.GoFDesignPattern.Creational.Factory_Method.DBCheck.frmFactoryMethod frm = new LHJ.GoFDesignPattern.Creational.Factory_Method.DBCheck.frmFactoryMethod();
            frm.Show();
        }
    }
}
