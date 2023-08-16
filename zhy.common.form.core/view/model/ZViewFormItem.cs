/****************************************
 * FileName:	FormItem
 * Creater: 	shaozhy
 * Create Date:	2023/7/26 17:18:50
 * Version: 	v0.0.1
 * Description:	
 * ======================================
 * Modify: —— Version: —— Date: —— Modifier: —— Content:
 ****************************************/
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using zhy.common.form.core.model.Interf;
using zhy.common.form.core.model;

namespace zhy.common.form.core.view.model
{
    /// <summary>
    /// 
    /// </summary>
    internal class ZViewFormItem : ObservableObject
    {
        #region base
        private int _index;
        public int Index
        {
            get { return _index; }
            set { SetProperty(ref _index, value); }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        #endregion base

        #region text
        private string _valueText;
        public string ValueText
        {
            get { return _valueText; }
            set { SetProperty(ref _valueText, value); }
        }
        private bool _isReadOnlyText;
        public bool IsReadOnlyTextInput
        {
            get { return _isReadOnlyText; }
            set { SetProperty(ref _isReadOnlyText, value); }
        }
        #endregion text

        #region combo
        private List<ZComboItem> _valuesCombo =
            new List<ZComboItem>();
        public List<ZComboItem> ValuesCombo
        {
            get { return _valuesCombo; }
            set { SetProperty(ref _valuesCombo, value); }
        }
        private ZComboItem _valueCombo;
        public ZComboItem ValueCombo
        {
            get { return _valueCombo; }
            set { SetProperty(ref _valueCombo, value); }
        }
        private bool _isReadOnlyCombo;
        public bool IsReadOnlyComboInput
        {
            get { return _isReadOnlyCombo; }
            set { SetProperty(ref _isReadOnlyCombo, value); }
        }
        #endregion combo

        #region button
        public RelayCommand CommandButtonClick
        {
            get
            {
                if (ButtonClick == null)
                    return new RelayCommand(() => { });
                return new RelayCommand(()=>{ ValueButton = ButtonClick(ValueButton); });
            }
        }
        public Func<string,string> ButtonClick { get; set; }

        private bool _isReadOnlyButtonInput;
        public bool IsReadOnlyButtonInput
        {
            get { return _isReadOnlyButtonInput; }
            set { SetProperty(ref _isReadOnlyButtonInput, value); }
        }
        private string _valueButton;
        public string ValueButton
        {
            get { return _valueButton; }
            set { SetProperty(ref _valueButton, value); }
        }
        private string _buttonContent;
        public string ButtonContent
        {
            get { return _buttonContent; }
            set { SetProperty(ref _buttonContent, value); }
        }
        private bool _isReadOnlyButton;
        public bool IsReadOnlyButton
        {
            get { return _isReadOnlyButton; }
            set { SetProperty(ref _isReadOnlyButton, value); }
        }
        #endregion button

        #region view
        private Visibility _textBoxVisibility = Visibility.Collapsed;
        public Visibility TextBoxVisibility
        {
            get { return _textBoxVisibility; }
            set { SetProperty(ref _textBoxVisibility, value); }
        }
        private Visibility _comboBoxVisibility = Visibility.Collapsed;
        public Visibility ComboBoxVisibility
        {
            get { return _comboBoxVisibility; }
            set { SetProperty(ref _comboBoxVisibility, value); }
        }
        private Visibility _buttonVisibility = Visibility.Collapsed;
        public Visibility ButtonVisibility
        {
            get { return _buttonVisibility; }
            set { SetProperty(ref _buttonVisibility, value); }
        }
        #endregion view

        #region data
        private IZFormItem _zFormItem;
        public IZFormItem ZFormItem
        {
            get { return _zFormItem; }
            set { SetProperty(ref _zFormItem, value); }
        }
        #endregion data
    }
}
