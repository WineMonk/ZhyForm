using CommunityToolkit.Mvvm.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using zhy.common.datagrid.core.view;

namespace zhy.common.datagrid.core.text
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<TestItem> testItems = new List<TestItem>()
            {
                new TestItem(){ IsChecked = true, Text = "测试文本1", ComboList = new List<string>(){ "选项1","选项2" }, Combo = "选项1" ,SelectText = "asd"},
                new TestItem(){ IsChecked = false, Text = "测试文本2", ComboList = new List<string>(){ "选项1","选项2","选项3" }, Combo = "选项2" },
                new TestItem(){ IsChecked = true, Text = "测试文本3", ComboList = new List<string>(){ "选项1","选项2" }, Combo = "选项1" },
                new TestItem(){ IsChecked = false, Text = "测试文本4", ComboList = new List<string>(){ "选项1","选项2" }, Combo = "选项2" },
            };
            grid.Children.Add(new ZDataGrid(testItems));
            //this.DataContext = new MainWindowViewModel();
        }

        
    }
    public class MainWindowViewModel:ObservableObject
    {
        public List<TestItem> PropertyItemsSource = new List<TestItem>()
            {
                new TestItem(){ IsChecked = true, Text = "测试文本1", ComboList = new List<string>(){ "选项1","选项2" }, Combo = "选项1" ,SelectText = "asd"},
                new TestItem(){ IsChecked = false, Text = "测试文本2", ComboList = new List<string>(){ "选项1","选项2","选项3" }, Combo = "选项2" },
                new TestItem(){ IsChecked = true, Text = "测试文本3", ComboList = new List<string>(){ "选项1","选项2" }, Combo = "选项1" },
                new TestItem(){ IsChecked = false, Text = "测试文本4", ComboList = new List<string>(){ "选项1","选项2" }, Combo = "选项2" },
            };

    }
}
