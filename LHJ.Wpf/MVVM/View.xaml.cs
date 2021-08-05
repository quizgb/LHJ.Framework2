using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LHJ.Wpf.MVVM
{
    /// <summary>
    /// View.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class View : Window
    {
        private ViewModels.ViewModel _ViewModel;

        public View()
        {
            InitializeComponent();

            //this._ViewModel = new ViewModels.ViewModel();
            //this.DataContext = this._ViewModel;
        }

        protected override void OnClosed(EventArgs e)
        {
            //커맨드 클래스에 CommandManager.RequerySuggested가 자동해지되지 않는 이슈로 인해 해당 윈도우 닫힐 때 DataContext 초기화
            this.DataContext = null;
            base.OnClosed(e);
        }
    }
}
