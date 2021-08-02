using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
