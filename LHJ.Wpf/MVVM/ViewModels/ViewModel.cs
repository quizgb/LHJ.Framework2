using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LHJ.Wpf.MVVM.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private MVVM.Models.Model1 _Model1;

        public MVVM.Models.Model1 Model1
        {
            get { return this._Model1; }
            set { this._Model1 = value; }
        }

        public string ModelName
        {
            get { return this._Model1.ModelName; }
            set
            {
                if (this._Model1.ModelName != value)
                {
                    this._Model1.ModelName = value;
                    this.NotiPropertyChanged("ModelName");

                    if (this._Model1.ModelName.Equals("이호준") || this._Model1.ModelName.Equals("LHJ"))
                    {
                        this.LHJ = true;
                    }
                    else
                    {
                        this.LHJ = false;
                    }
                }
            }
        }

        public string ModelName2
        {
            get { return this._Model1.ModelName2; }
            set
            {
                this._Model1.ModelName2 = value;
                this.NotiPropertyChanged("ModelName2");
            }
        }

        public bool LHJ
        {
            get { return this._Model1.LHJ; }
            set
            {
                this._Model1.LHJ = value;
                this.NotiPropertyChanged("LHJ");
            }
        }

        public ViewModel()
        {
            this._Model1 = new Models.Model1();
        }

        private void ButtonCmdExe(object pParam)
        {
            MessageBox.Show("버튼 클릭");
        }

        private bool CanButtonCmdExe(object pParam)
        {
            if (!string.IsNullOrEmpty(this._Model1.ModelName2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICommand ButtonCmd { get { return new MVVM.CMD.RelayCommand(ButtonCmdExe, CanButtonCmdExe); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotiPropertyChanged([CallerMemberName] string pPropName = null)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(pPropName));
            }
        }
    }
}
