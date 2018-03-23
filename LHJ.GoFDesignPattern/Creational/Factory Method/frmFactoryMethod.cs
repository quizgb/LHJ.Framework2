using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method
{
    public partial class frmFactoryMethod : Form
    {
        private SignPad.ConfigSignPad _ConfigSignPad = new SignPad.ConfigSignPad();

        public frmFactoryMethod()
        {
            InitializeComponent();

            this.SetInitialize();
        }

        private void SetInitialize()
        {
            this.SetSignPadKoces();
        }

        private void SetSignPadKoces()
        {
            this._ConfigSignPad.ModuleType = SignPad.signPadModuleType.Koces;
            this._ConfigSignPad.IsUseSignPad = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBCheck.CreateTable dbChk = new DBCheck.CreateTable();
            dbChk.CreateDataBaseLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignPad.SignPadBase signPad = SignPad.SignPadFactory.CreateInstance(_ConfigSignPad);
            Bitmap signImage = signPad.RequestSign();
        }
    }
}
