# ZhyForm

ZFormDialog：表单窗体，对话框样式，表单项支持：简单文本、格式校验文本、多选项、按钮选择项；

![ZFormDialog](https://raw.githubusercontent.com/WineMonk/images/master/blog/post/202308180906372.png)

ZFormGrid：表单窗体，数据表样式，表单项支持：简单文本、格式校验文本、多选项、按钮选择项；

![ZFormGrid](https://raw.githubusercontent.com/WineMonk/images/master/blog/post/202308180906782.png)

## 示例

```csharp
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
```



## API 参考

### ZFormItemBase类

#### 定义

```csharp
public class ZFormItemBase
```

#### 注解

表单项基类。

#### 属性

| 属性       | 说明                         |
| ---------- | ---------------------------- |
| Key        | 表单项键。自动生成唯一GUID。 |
| Title      | 表单项标题。                 |
| Data       | 附加数据。                   |
| IsReadOnly | 是否为只读。                 |
| IsRequired | 是否为必填项。               |



### ZTextFormItem类

#### 定义

```csharp
public class ZTextFormItem : ZFormItemBase, IZFormItem
```

继承 → [Object](https://learn.microsoft.com/zh-cn/dotnet/api/system.object?view=net-6.0) → ZFormItemBase → ZTextFormItem

实现 IZFormItem

#### 注解

简单文字输入表单项。

#### 属性

| 属性       | 说明                                                |
| ---------- | --------------------------------------------------- |
| Value      | 初始值。                                            |
| Key        | 表单项键。自动生成唯一GUID。（继承自ZFormItemBase） |
| Title      | 表单项标题。（继承自ZFormItemBase）                 |
| Data       | 附加数据。（继承自ZFormItemBase）                   |
| IsReadOnly | 是否为只读。（继承自ZFormItemBase）                 |
| IsRequired | 是否为必填项。（继承自ZFormItemBase）               |



### ZFormatTextFormItem类

#### 定义

```csharp
public class ZFormatTextFormItem : ZTextFormItem, IZFormItem
```

#### 注解

格式校验文字输入表单项。

#### 属性

| 属性               | 说明                                                |
| ------------------ | --------------------------------------------------- |
| Value              | 初始值。                                            |
| ErrMessage         | 校验错误时，格式提示。                              |
| FormatVerification | 格式校验委托方法。                                  |
| Key                | 表单项键。自动生成唯一GUID。（继承自ZFormItemBase） |
| Title              | 表单项标题。（继承自ZFormItemBase）                 |
| Data               | 附加数据。（继承自ZFormItemBase）                   |
| IsReadOnly         | 是否为只读。（继承自ZFormItemBase）                 |
| IsRequired         | 是否为必填项。（继承自ZFormItemBase）               |



### ZComboFormItem类

#### 定义

```csharp
public class ZComboFormItem : ZFormItemBase, IZFormItem
```

#### 注解

多项选择表单项。

#### 属性

| 属性       | 说明                                                |
| ---------- | --------------------------------------------------- |
| Values     | 选项集合。                                          |
| Key        | 表单项键。自动生成唯一GUID。（继承自ZFormItemBase） |
| Title      | 表单项标题。（继承自ZFormItemBase）                 |
| Data       | 附加数据。（继承自ZFormItemBase）                   |
| IsReadOnly | 是否为只读。（继承自ZFormItemBase）                 |
| IsRequired | 是否为必填项。（继承自ZFormItemBase）               |



### ZButtonFormItem类

#### 定义

```csharp
public class ZButtonFormItem : ZFormItemBase, IZFormItem
```

#### 注解

按钮选择表单项。

#### 属性

| 属性          | 说明                                                |
| ------------- | --------------------------------------------------- |
| ButtonCommand | 按钮选择委托方法。                                  |
| ButtonContent | 按钮标题内容。                                      |
| Value         | 初始值。                                            |
| Key           | 表单项键。自动生成唯一GUID。（继承自ZFormItemBase） |
| Title         | 表单项标题。（继承自ZFormItemBase）                 |
| Data          | 附加数据。（继承自ZFormItemBase）                   |
| IsReadOnly    | 是否为只读。（继承自ZFormItemBase）                 |
| IsRequired    | 是否为必填项。（继承自ZFormItemBase）               |



### ZFormResultItem类

#### 定义

```csharp
public class ZFormResultItem
```

#### 注解

表单结果项。

#### 属性

| 属性     | 说明         |
| -------- | ------------ |
| FormItem | 表单项。     |
| Value    | 表单结果值。 |

