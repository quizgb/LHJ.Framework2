using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.Wpf.MVVM.Models
{
    public class Model1
    {
        private string _ModelName = string.Empty;
        private bool _LHJ = false;

        public string ModelName
        {
            get { return this._ModelName; }
            set { this._ModelName = value; }
        }

        public bool LHJ
        {
            get { return this._LHJ; }
            set { this._LHJ = value; }
        }
    }
}
