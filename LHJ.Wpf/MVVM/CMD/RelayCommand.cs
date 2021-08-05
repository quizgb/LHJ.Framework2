using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LHJ.Wpf.MVVM.CMD
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public RelayCommand(Action<object> pExecute, Func<object, bool> pCanExecute = null) 
        {
            if (pExecute == null)
                throw new ArgumentNullException("pExecute");

            this._Execute = pExecute;
            this._CanExecute = pCanExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {

                if (this._CanExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {

                if (this._CanExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        public bool CanExecute(object pParam)
        {
            return this._CanExecute == null ? true : this._CanExecute(pParam);
        }

        public void Execute(object pParam)
        {
            this._Execute(pParam);
        }
    }
}
