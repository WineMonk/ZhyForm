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
            List<IZFormItem> zFormItems = new List<IZFormItem>
            {
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZTextFormItem()
                {
                    Title = "输入项",
                    Value = "输入值" ,
                    IsRequired = true
                },
                new ZComboFormItem()
                {
                    Title = "多选项",
                    Values = new List<ZComboItem>
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
                    }
                },
            };
            ZButtonFormItem button = new ZButtonFormItem
            {
                Title = "选择项",
                ButtonContent = "参数选择",
                Value = "选择值",
                IsReadOnly = true
            };
            button.ButtonCommand = (val) =>
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectedPath = folderBrowserDialog.SelectedPath;
                    if (selectedPath.Last() != Path.DirectorySeparatorChar)
                        selectedPath += Path.DirectorySeparatorChar;
                    return selectedPath;
                }
                return val;
            };
            ZFormatTextFormItem zFormatTextFormItem = new ZFormatTextFormItem
            {
                Title = "格式验证项",
                IsRequired = true,
                ErrMessage = "输入必须位数字！"
            };
            zFormatTextFormItem.FormatVerification = (val) =>
            {
                try
                {
                    int v = int.Parse(val);
                    return true;
                }
                catch { return false; }
            };
            zFormItems.Add(button);
            zFormItems.Add(zFormatTextFormItem);
            ZFormGrid zFormGrid = new ZFormGrid(zFormItems);
            zFormGrid.Title = "测试";
            zFormGrid.Show();
            
            ZFormDialog zFormDialog = new ZFormDialog(zFormItems);
            zFormDialog.Title = "测试";
            bool dr = (bool)zFormDialog.ShowDialog();
            if (dr)
            {
                List<ZFormResultItem> resultItems = zFormDialog.ResultItems;
            }
        }
    }
}