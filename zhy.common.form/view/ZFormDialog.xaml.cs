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
using zhy.common.form.model;
using zhy.common.form.model.Interf;
using zhy.common.form.view.viewmodel;

namespace zhy.common.form.view
{
    /// <summary>
    /// ZFormWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ZFormDialog : Window
    {
        private ZFormViewModel _vm = null;
        public ZFormDialog(List<IZFormItem> zFormItems)
        {
            InitializeComponent();
            _vm = new ZFormViewModel(zFormItems, 
                dr => 
                { 
                    try 
                    {
                        this.DialogResult = dr; 
                    }
                    catch 
                    {
                        this.Close(); 
                    }
                });
            DataContext = _vm;
        }
        public List<ZFormResultItem> ResultItems => _vm.ResultItems;
    }
}
