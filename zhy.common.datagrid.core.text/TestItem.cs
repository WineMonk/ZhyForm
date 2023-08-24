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

namespace zhy.common.datagrid.core.text
{
    /// <summary>
    /// 
    /// </summary>
    public class TestItem : ObservableObject
    {
        private bool _isChecked;
        [ZCheckDataColumn(header: "选 择", width: 30, dataGridLengthUnitType: DataGridLengthUnitType.Auto)]
        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }
        private string _text;
        [ZTextDataColumn(header: "文 本", width: 1, dataGridLengthUnitType: DataGridLengthUnitType.Auto)]
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
        private string _combo;
        public string Combo
        {
            get { return _combo; }
            set { SetProperty(ref _combo, value); }
        }
        private List<string> _comboList;
        [ZComboDataColumn(header: "选 项", targetProperty: nameof(Combo), width: 1, dataGridLengthUnitType: DataGridLengthUnitType.Auto)]
        public List<string> ComboList
        {
            get { return _comboList; }
            set { SetProperty(ref _comboList, value); }
        }
        private string _selectText;
        [ZButtonDataColumn(header: "选 择", buttonContent: "选 择", isReadOnly: true, relayCommandName: nameof(CommandOper))]
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
        [ZOperateColumnButton(content: "删除")]
        public RelayCommand<object[]> CommandOper2 => new RelayCommand<object[]>(Oper2);
        public void Oper2(object[] paras)
        {
            List<TestItem> testItems = paras[1] as List<TestItem>;
            TestItem testItem = paras[0] as TestItem;
            testItems.Remove(testItem);
        }
    }
}
