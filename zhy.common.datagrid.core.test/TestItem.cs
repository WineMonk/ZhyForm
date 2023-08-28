/****************************************
 * FileName:	TestItem
 * Creater: 	shaozhy
 * Create Date:	2023/8/23 15:47:11
 * Version: 	v0.0.1
 * Description:	
 * ======================================
 * Modify: —— Version: —— Date: —— Modifier: —— Content:
 ****************************************/
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using zhy.common.datagrid.core.attribute;
using System.Collections.ObjectModel;
using System.Collections;
using zhy.common.datagrid.core.enumeration;
using System.Reflection;

namespace zhy.common.datagrid.core.test
{
    /// <summary>
    /// 
    /// </summary>
    public class TestItem : ObservableObject
    {
        private bool _isChecked;
        [ZCheckDataColumn(header: "选 择", width: 30, index: 0,
            dataGridLengthUnitType: DataGridLengthUnitType.Auto)]
        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }

        private string _onlyReadText;
        [ZTextDataColumn(header: "只读文本",index:3, isReadOnly: true,
            width: 1, dataGridLengthUnitType: DataGridLengthUnitType.Auto)]
        public string OnlyReadText
        {
            get { return _onlyReadText; }
            set{ SetProperty(ref _onlyReadText, value); }
        }

        private string _text;
        [ZTextDataColumn(header: "可编辑文本", index: 3, 
            width: 1, dataGridLengthUnitType: DataGridLengthUnitType.Auto)]
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private TestSearchMemberItem _member;
        public TestSearchMemberItem Member
        {
            get { return _member; }
            set { SetProperty(ref _member, value); }
        }
        private List<TestSearchMemberItem> _members = new List<TestSearchMemberItem>
        {
            new TestSearchMemberItem("小亚",1),
            new TestSearchMemberItem("小苹",2),
            new TestSearchMemberItem("小米",3),
            new TestSearchMemberItem("小腾",4),
            new TestSearchMemberItem("小易",5),
            new TestSearchMemberItem("小奇",6)
        };
        [ZComboDataColumn(header: "成员", targetProperty:nameof(Member), 
            displayMemberPath:"Name",isSearchProperty:true,
            dataGridLengthUnitType: DataGridLengthUnitType.Auto)]
        public List<TestSearchMemberItem> Members
        {
            get { return _members; }
            set { SetProperty(ref _members, value); }
        }

        private string _combo;
        public string Combo
        {
            get { return _combo; }
            set { SetProperty(ref _combo, value); }
        }
        private List<string> _comboList;
        [ZComboDataColumn(header: "选 项",index:2, targetProperty: nameof(Combo),
            width: 1, dataGridLengthUnitType: DataGridLengthUnitType.Auto)]
        public List<string> ComboList
        {
            get { return _comboList; }
            set { SetProperty(ref _comboList, value); }
        }

        private string _selectText;
        [ZButtonDataColumn(header: "路 径", buttonContent: "选 择", buttonStyle: ButtonStyle.SuccessButton,
            isSearchProperty: true, isReadOnly: true, relayCommandName: nameof(CommandOper))]
        public string SelectText
        {
            get { return _selectText; }
            set { SetProperty(ref _selectText, value); }
        }

        public RelayCommand<TestItem> CommandOper => new RelayCommand<TestItem>(Oper);
        public void Oper(TestItem testItem)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            bool? dr = fileDialog.ShowDialog();
            if (!(bool)dr)
                return;
            testItem.SelectText = fileDialog.FileName;
        }

        [ZOperateColumnButton(content: "删 除",index:1, buttonStyle: ButtonStyle.ErrorButton)]
        public RelayCommand<object[]> CommandOper2 => new RelayCommand<object[]>(Oper2);
        public void Oper2(object[] paras)
        {
            IList testItems = paras[1] as IList;
            TestItem testItem = paras[0] as TestItem;
            testItems.Remove(testItem);
        }

        [ZOperateColumnButton(content: "查 看",index:0, buttonStyle: ButtonStyle.WarnButton)]
        public RelayCommand<object[]> CommandOper3 => new RelayCommand<object[]>(Oper3);
        public void Oper3(object[] paras)
        {
            TestItem testItem = paras[0] as TestItem;
            string msg = null;
            PropertyInfo[] propertyInfos = testItem.GetType().GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                ZDataColumnAttribute? zDataColumnAttribute = propertyInfo.GetCustomAttribute<ZDataColumnAttribute>();
                if (zDataColumnAttribute == null)
                    continue;
                if (zDataColumnAttribute is ZComboDataColumnAttribute)
                {
                    ZComboDataColumnAttribute zComboDataColumnAttribute = (ZComboDataColumnAttribute)zDataColumnAttribute;
                    string targetProperty = zComboDataColumnAttribute.TargetProperty;
                    PropertyInfo? propertyInfo1 = testItem.GetType().GetProperty(targetProperty);
                    if (string.IsNullOrEmpty(zComboDataColumnAttribute.DisplayMemberPath))
                        msg += zDataColumnAttribute.Header + ": " + propertyInfo1.GetValue(testItem) + "\r\n";
                    else
                    {
                        object? val = propertyInfo1.GetValue(testItem);
                        if (val == null) continue;
                        PropertyInfo? propertyInfo2 = val.GetType().GetProperty(zComboDataColumnAttribute.DisplayMemberPath);
                        msg += zDataColumnAttribute.Header + ": " + propertyInfo2.GetValue(val) + "\r\n";
                    }
                }
                else if(zDataColumnAttribute is ZButtonDataColumnAttribute)
                {
                    ZButtonDataColumnAttribute zButtonDataColumnAttribute = (ZButtonDataColumnAttribute)zDataColumnAttribute;
                    if (string.IsNullOrEmpty(zButtonDataColumnAttribute.DisplayMemberPath))
                        msg += zDataColumnAttribute.Header + ": " + propertyInfo.GetValue(testItem) + "\r\n";
                    else
                    {
                        object? val = propertyInfo.GetValue(testItem);
                        if (val == null) continue;
                        PropertyInfo? propertyInfo2 = val.GetType().GetProperty(zButtonDataColumnAttribute.DisplayMemberPath);
                        msg += zDataColumnAttribute.Header + ": " + propertyInfo2.GetValue(val) + "\r\n";
                    }
                }
                else
                {
                    msg += zDataColumnAttribute.Header + ": " + propertyInfo.GetValue(testItem) + "\r\n";
                }
            }
            MessageBox.Show(msg, "属性信息", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        [ZOperateTopButton(content: "添 加",index:1, buttonStyle: ButtonStyle.InfoButton)]
        public static void Oper4(IEnumerable items)
        {
            IList<TestItem> testItems = items as IList<TestItem>;
            TestItem testItem = new TestItem() { IsChecked = true, Text = "测试文本1", ComboList = new List<string>() { "选项1", "选项2" }, Combo = "选项1", SelectText = "asd" };
            testItems.Add(testItem);
        }

        [ZOperateTopButton(content: "批量删除",index:0, buttonStyle: ButtonStyle.ErrorButton)]
        public static void Oper5(IEnumerable items)
        {
            IList<TestItem> testItems = items as IList<TestItem>;
            List<TestItem> rmItems = new List<TestItem>();
            foreach (var item in testItems)
                if(item.IsChecked)
                    rmItems.Add(item);
            foreach (var item in rmItems)
                testItems.Remove(item);
        }

        private TestSearchMemberItem _selectMember;
        [ZButtonDataColumn(header: "朋 友", buttonContent: "选 择", displayMemberPath: "Name", isSearchProperty: true,
            buttonStyle: ButtonStyle.InfoButton, isReadOnly: true, relayCommandName: nameof(CommandOper6))]
        public TestSearchMemberItem SelectMember
        {
            get { return _selectMember; }
            set { SetProperty(ref _selectMember, value); }
        }
        public RelayCommand<TestItem> CommandOper6 => new RelayCommand<TestItem>(Oper6);
        public void Oper6(TestItem objects)
        {
            string[] strings = { "小亚", "小苹", "小米", "小腾", "小易", "小奇" };
            int v = new Random().Next(0, strings.Length);
            SelectMember = new TestSearchMemberItem(strings[v], v);
        }
    }

    public class TestSearchMemberItem
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public TestSearchMemberItem(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
