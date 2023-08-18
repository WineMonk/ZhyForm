using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using zhy.common.form.model;
using zhy.common.form.model.Interf;
using zhy.common.form.view;

namespace zhy.common.form.test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZTextFormItem zTextFormItem = new ZTextFormItem();
            zTextFormItem.Title = "输入项";
            zTextFormItem.Value = "输入值";
            zTextFormItem.IsRequired = true;

            ZComboFormItem zComboFormItem = new ZComboFormItem();
            zComboFormItem.Title = "多选项";
            zComboFormItem.Values = 
                new List<ZComboItem>
                {
                    new ZComboItem()
                    {
                        Display = "项1",
                        Value="值1"
                    },
                    new ZComboItem()
                    {
                        Display = "项2",
                        Value="值2"
                    },
                    new ZComboItem()
                    {
                        Display = "项3",
                        Value="值3"
                    }
                };

            ZButtonFormItem zButtonFormItem = new ZButtonFormItem();
            zButtonFormItem.Title = "选择项";
            zButtonFormItem.ButtonContent = "参数选择";
            zButtonFormItem.Value = "选择值";
            zButtonFormItem.IsReadOnly = true;
            zButtonFormItem.ButtonCommand = (currentVal) =>
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectedPath = folderBrowserDialog.SelectedPath;
                    if (selectedPath.Last() != Path.DirectorySeparatorChar)
                        selectedPath += Path.DirectorySeparatorChar;
                    return selectedPath;
                }
                return currentVal;
            };

            ZFormatTextFormItem zFormatTextFormItem = new ZFormatTextFormItem();
            zFormatTextFormItem.Title = "格式验证项";
            zFormatTextFormItem.Value = "格式验证值";
            zFormatTextFormItem.IsRequired = true;
            zFormatTextFormItem.ErrMessage = "输入必须位数字！";
            zFormatTextFormItem.FormatVerification = (currentVal) =>
            {
                try
                {
                    int v = int.Parse(currentVal);
                    return true;
                }
                catch { return false; }
            };

            List<IZFormItem> zFormItems = new List<IZFormItem>();
            zFormItems.Add(zTextFormItem);
            zFormItems.Add(zFormatTextFormItem);
            zFormItems.Add(zComboFormItem);
            zFormItems.Add(zButtonFormItem);

            ZFormGrid zFormGrid = new ZFormGrid(zFormItems);
            zFormGrid.Title = "测试";
            bool dr = (bool)zFormGrid.ShowDialog(); ;
            if (dr)
            {
                List<ZFormResultItem> resultItems = zFormGrid.ResultItems;
            }

            ZFormDialog zFormDialog = new ZFormDialog(zFormItems);
            zFormDialog.Title = "测试";
            bool dr1 = (bool)zFormDialog.ShowDialog();
            if (dr1)
            {
                List<ZFormResultItem> resultItems = zFormDialog.ResultItems;
            }
        }
    }
}