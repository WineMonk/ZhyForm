# ZhyForm

**WPF表单组件，表单项支持：简单文本、格式校验文本、多选项、按钮选择项，支持两种界面风格。**

ZFormDialog

![ZFormDialog](https://raw.githubusercontent.com/WineMonk/images/master/blog/post/202308180906372.png)

ZFormGrid

![ZFormGrid](https://raw.githubusercontent.com/WineMonk/images/master/blog/post/202308180906782.png)

## 目录说明：

* zhy.common.form：基于.Net Framework 4.8框架。
* zhy.common.form.test：zhy.common.form的测试Demo。
* zhy.common.form.core：基于.Net 6.0框架。
* zhy.common.form.core.text：zhy.common.form.core的测试Demo。

## 项目引用：

1. 编译源码后，在项目中添加编译生成的zhy.common.form.dll或zhy.common.form.core.dll引用；[Dll文件](./dll)
2. 在解决方案中直接引入zhy.common.form.csproj或zhy.common.form.core.csproj项目；

## 代码示例：

```csharp
//简单输入项
ZTextFormItem zTextFormItem = new ZTextFormItem();
zTextFormItem.Title = "输入项";
zTextFormItem.Value = "输入值";
zTextFormItem.IsRequired = true;
//格式验证输入项
ZFormatTextFormItem zFormatTextFormItem = new ZFormatTextFormItem();
zFormatTextFormItem.Title = "格式验证项";
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
//多项选择项
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
//按钮选择项
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
```

## API参考

[zhy.common.form API参考](./zhy.common.form)

[zhy.common.form.core API参考](./zhy.common.form.core)
