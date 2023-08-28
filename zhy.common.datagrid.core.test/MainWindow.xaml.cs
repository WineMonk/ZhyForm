using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace zhy.common.datagrid.core.test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }
    public class MainWindowViewModel:ObservableObject
    {
        public MainWindowViewModel()
        {
            _testItems = new ObservableCollection<TestItem>()
            {
                new TestItem(){ IsChecked = true,  OnlyReadText = "测试文本1",Text = "测试文本1", ComboList = new List<string>(){ "选项1","选项2" }, Combo = "选项1" ,SelectText = "asd"},
                new TestItem(){ IsChecked = false, OnlyReadText = "测试文本2",Text = "测试文本2", ComboList = new List<string>(){ "选项1","选项2","选项3" }, Combo = "选项2" },
                new TestItem(){ IsChecked = true,  OnlyReadText = "测试文本3",Text = "测试文本3", ComboList = new List<string>(){ "选项1","选项2" }, Combo = "选项1" },
                new TestItem(){ IsChecked = false, OnlyReadText = "测试文本4",Text = "测试文本4", ComboList = new List<string>(){ "选项1","选项2" }, Combo = "选项2" },
            };
            TestItem testItem = new TestItem() { IsChecked = false, Text = "测试文本4", SelectMember = new TestSearchMemberItem("小度", 55), ComboList = new List<string>() { "选项1", "选项2" }, Combo = "选项2", Members = new List<TestSearchMemberItem> { new TestSearchMemberItem("小微", 11), new TestSearchMemberItem("小谷", 22) } };
            testItem.Member = testItem.Members[1];
            _testItems.Add(testItem);
        }

        private IList _testItems;
        public IList TestItems
        {
            get { return _testItems; }
            set { _testItems = value; }
        }
    }
}
