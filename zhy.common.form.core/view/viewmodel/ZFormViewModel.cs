/****************************************
 * FileName:	ZFormDialogViewModel
 * Creater: 	shaozhy
 * Create Date:	2023/8/9 9:47:54
 * Version: 	v0.0.1
 * Description:	
 * ======================================
 * Modify: —— Version: —— Date: —— Modifier: —— Content:
 ****************************************/
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using zhy.common.form.core.model;
using zhy.common.form.core.model.Interf;
using zhy.common.form.core.view.model;

namespace zhy.common.form.core.view.viewmodel
{
    /// <summary>
    /// 
    /// </summary>
    internal class ZFormViewModel : ObservableObject
    {
        private ObservableCollection<ZViewFormItem> _viewFormItems =
            new ObservableCollection<ZViewFormItem>();
        public ObservableCollection<ZViewFormItem> ViewFormItems
        {
            get { return _viewFormItems; }
            set { SetProperty(ref _viewFormItems, value); }
        }

        private RelayCommand _commandOK;
        public RelayCommand CommandOK
        {
            get
            {
                if (_commandOK == null)
                    _commandOK = new RelayCommand(OK);
                return _commandOK;
            }
        }
        
        private RelayCommand _commandCancel;
        public RelayCommand CommandCancel
        {
            get
            {
                if (_commandCancel == null)
                    _commandCancel = new RelayCommand(Cancel);
                return _commandCancel;
            }
        }

        public ZFormViewModel(List<IZFormItem> zFormItems, Action<bool> actionDr)
        {
            _actionDr = actionDr;
            ViewFormItemBoxing(zFormItems);
        }

        public List<ZFormResultItem> ResultItems = null;

        private Action<bool> _actionDr = null;
        private void OK()
        {
            if (!CheckItem())
                return;
            ResultItemsBoxing();
            _actionDr(true);
        }
        private void Cancel()
        {
            _actionDr(false);
        }
        private void ResultItemsBoxing()
        {
            ResultItems = new List<ZFormResultItem>();
            foreach (var item in ViewFormItems)
            {
                ZFormResultItem zFormResultItem = null;
                if (item.ZFormItem is ZTextFormItem)
                    zFormResultItem = new ZFormResultItem(item.ZFormItem, item.ValueText);
                else if(item.ZFormItem is ZComboFormItem)
                    zFormResultItem = new ZFormResultItem(item.ZFormItem, item.ValueCombo?.Value);
                else if(item.ZFormItem is ZButtonFormItem)
                    zFormResultItem = new ZFormResultItem(item.ZFormItem, item.ValueButton);
                if (zFormResultItem != null) 
                    ResultItems.Add(zFormResultItem);
            }
        }
        private void ViewFormItemBoxing(List<IZFormItem> zFormItems)
        {
            foreach (IZFormItem item in zFormItems)
            {
                ZViewFormItem zViewFormItem = null;
                if (item is ZTextFormItem)
                {
                    ZTextFormItem zTextFormItem = (ZTextFormItem)item;
                    zViewFormItem = new ZViewFormItem()
                    {
                        Index = zFormItems.IndexOf(item)+1,
                        TextBoxVisibility = Visibility.Visible,
                        Title = zTextFormItem.Title,
                        ValueText = zTextFormItem.Value,
                        IsReadOnlyTextInput = zTextFormItem.IsReadOnly,
                        ZFormItem = zTextFormItem
                    };
                }
                else if (item is ZComboFormItem)
                {
                    ZComboFormItem zComboFormItem = (ZComboFormItem)item;
                    zViewFormItem = new ZViewFormItem()
                    {
                        Index = zFormItems.IndexOf(item) + 1,
                        ComboBoxVisibility = Visibility.Visible,
                        Title = zComboFormItem.Title,
                        ValuesCombo = zComboFormItem.Values,
                        IsReadOnlyComboInput = zComboFormItem.IsReadOnly,
                        ZFormItem = zComboFormItem
                    };
                }
                else if (item is ZButtonFormItem)
                {
                    ZButtonFormItem zButtonFormItem = (ZButtonFormItem)item;
                    zViewFormItem = new ZViewFormItem()
                    {
                        Index = zFormItems.IndexOf(item) + 1,
                        ButtonVisibility = Visibility.Visible,
                        Title = zButtonFormItem.Title,
                        ValueButton = zButtonFormItem.Value,
                        ZFormItem = zButtonFormItem,
                        ButtonContent = zButtonFormItem.ButtonContent,
                        IsReadOnlyButtonInput = zButtonFormItem.IsReadOnly,
                        ButtonClick = zButtonFormItem.ButtonCommand
                    };
                }
                if (zViewFormItem != null)
                    ViewFormItems.Add(zViewFormItem);
            }
        }
        private bool CheckItem()
        {
            foreach (var item in ViewFormItems)
            {
                if (item.ZFormItem is ZTextFormItem)
                {
                    if (item.ZFormItem.IsRequired && string.IsNullOrEmpty(item.ValueText))
                    {
                        NotNullTip(item);
                        return false;
                    }
                    if (item.ZFormItem is ZFormatTextFormItem)
                    {
                        ZFormatTextFormItem zFormatTextFormItem = (ZFormatTextFormItem)item.ZFormItem;
                        Func<string, bool> formatVerification = zFormatTextFormItem.FormatVerification;
                        if (formatVerification != null && !formatVerification(item.ValueText))
                        {
                            VerificationFailedTip(item, zFormatTextFormItem.ErrMessage);
                            return false;
                        }
                    }
                }
                else if (item.ZFormItem is ZComboFormItem)
                {
                    if (item.ZFormItem.IsRequired && item.ValueCombo == null)
                    {
                        NotNullTip(item);
                        return false;
                    }
                }
                else if (item.ZFormItem is ZButtonFormItem)
                {
                    if (item.ZFormItem.IsRequired && string.IsNullOrEmpty(item.ValueButton))
                    {
                        NotNullTip(item);
                        return false;
                    }
                }
            }
            return true;
        }
        private void NotNullTip(ZViewFormItem item)
        {
            MessageBox.Show(
                $"“ {item.Index}. {item.Title} ” 项不可为空！", 
                "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void VerificationFailedTip(ZViewFormItem item, string errMsg)
        {
            MessageBox.Show(
                $"“ {item.Index}. {item.Title} ” 项格式验证未通过！\r\n说明：\r\n    " 
                + errMsg, "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
