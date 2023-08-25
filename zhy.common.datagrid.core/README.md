# ZhyForm

ZDataGrid：WPF台账用户控件，支持CheckBox、ListBox、TextBox样式信息显示，支持操作列、顶部控制项自定义功能按钮，支持信息查询功能；

![ZDataGrid](https://raw.githubusercontent.com/WineMonk/images/master/blog/post/202308251459220.png)

## 示例

Xaml：

```xaml
<Window
    x:Class="zhy.common.datagrid.core.test.MainWindow"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:lib="clr-namespace:zhy.common.datagrid.core.view;assembly=zhy.common.datagrid.core"
    xmlns:local="clr-namespace:zhy.common.datagrid.core.test"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    Width="800"
    Height="450"
    mc:Ignorable="d">
    <Grid x:Name="grid">
        <lib:ZDataGrid ItemsSource="{Binding TestItems}" />
    </Grid>
</Window>
```

MainWindow.cs:

```csharp
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainWindowViewModel();
    }
}
```

MainWindowViewModel.cs:

```csharp
public class MainWindowViewModel:ObservableObject
{
    public MainWindowViewModel()
    {
        _testItems = new ObservableCollection<TestItem>()
        {
            new TestItem(){ IsChecked = true, Text = "测试文本1", ComboList = new List<string>(){ "选项1","选项2" }, Combo = "选项1" ,SelectText = "asd"},
            new TestItem(){ IsChecked = false, Text = "测试文本2", ComboList = new List<string>(){ "选项1","选项2","选项3" }, Combo = "选项2" },
            new TestItem(){ IsChecked = true, Text = "测试文本3", ComboList = new List<string>(){ "选项1","选项2" }, Combo = "选项1" },
            new TestItem(){ IsChecked = false, Text = "测试文本4", ComboList = new List<string>(){ "选项1","选项2" }, Combo = "选项2" },
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
```

TestItem.cs:

```csharp
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

    private string _text;
    [ZTextDataColumn(header: "文 本",index:3, isReadOnly: true,
                     width: 1, dataGridLengthUnitType: DataGridLengthUnitType.Auto)]
    public string Text
    {
        get { return _text; }
        set{ SetProperty(ref _text, value); }
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
        MessageBox.Show(testItem.Combo);
        MessageBox.Show(testItem.Member?.Name);
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
```



## API 参考

### ZDataColumnAttribute类

#### 定义

```csharp
[AttributeUsage(AttributeTargets.Property)]
public class ZDataColumnAttribute: Attribute
```

#### 注解

数据列特性基类。

#### 属性

| 属性                   | 说明           |
| ---------------------- | -------------- |
| Index                  | 列索引。       |
| Header                 | 列标题。       |
| Width                  | 列宽。         |
| DataGridLengthUnitType | 列宽属性。     |
| IsReadOnly             | 是否为只读。   |
| IsSearchProperty       | 是包含在查询。 |



### ZTextDataColumnAttribute类

#### 定义

```csharp
[AttributeUsage(AttributeTargets.Property)]
public class ZTextDataColumnAttribute : ZDataColumnAttribute
```

继承 → [Object](https://learn.microsoft.com/zh-cn/dotnet/api/system.object?view=net-6.0) → Attribute → ZDataColumnAttribute → ZTextDataColumnAttribute

#### 注解

文本输入数据列。

#### 属性

| 属性                   | 说明                                         |
| ---------------------- | -------------------------------------------- |
| Index                  | 列索引。（继承自ZDataColumnAttribute）       |
| Header                 | 列标题。（继承自ZDataColumnAttribute）       |
| Width                  | 列宽。（继承自ZDataColumnAttribute）         |
| DataGridLengthUnitType | 列宽属性。（继承自ZDataColumnAttribute）     |
| IsReadOnly             | 是否为只读。（继承自ZDataColumnAttribute）   |
| IsSearchProperty       | 是包含在查询。（继承自ZDataColumnAttribute） |



### ZCheckDataColumnAttribute类

#### 定义

```csharp
[AttributeUsage(AttributeTargets.Property)]
public class ZCheckDataColumnAttribute : ZDataColumnAttribute
```

#### 注解

勾选数据列。

#### 属性

| 属性                   | 说明                                         |
| ---------------------- | -------------------------------------------- |
| Index                  | 列索引。（继承自ZDataColumnAttribute）       |
| Header                 | 列标题。（继承自ZDataColumnAttribute）       |
| Width                  | 列宽。（继承自ZDataColumnAttribute）         |
| DataGridLengthUnitType | 列宽属性。（继承自ZDataColumnAttribute）     |
| IsReadOnly             | 是否为只读。（继承自ZDataColumnAttribute）   |
| IsSearchProperty       | 是包含在查询。（继承自ZDataColumnAttribute） |



### ZComboDataColumnAttribute类

#### 定义

```csharp
[AttributeUsage(AttributeTargets.Property)]
public class ZComboDataColumnAttribute : ZDataColumnAttribute
```

#### 注解

选项数据列。

#### 属性

| 属性                   | 说明                                         |
| ---------------------- | -------------------------------------------- |
| DisplayMemberPath      | 选择项显示成员路径。                         |
| TargetProperty         | 选择项绑定目标属性。                         |
| Index                  | 列索引。（继承自ZDataColumnAttribute）       |
| Header                 | 列标题。（继承自ZDataColumnAttribute）       |
| Width                  | 列宽。（继承自ZDataColumnAttribute）         |
| DataGridLengthUnitType | 列宽属性。（继承自ZDataColumnAttribute）     |
| IsReadOnly             | 是否为只读。（继承自ZDataColumnAttribute）   |
| IsSearchProperty       | 是包含在查询。（继承自ZDataColumnAttribute） |



### ZButtonDataColumnAttribute类

#### 定义

```csharp
[AttributeUsage(AttributeTargets.Property)]
public class ZButtonDataColumnAttribute : ZDataColumnAttribute
```

#### 注解

按钮选择表单项。

#### 属性

| 属性                   | 说明                                         |
| ---------------------- | -------------------------------------------- |
| ButtonContent          | 按钮内容。                                   |
| ButtonStyle            | 按钮样式。                                   |
| DisplayMemberPath      | 选择项显示成员路径。                         |
| RealyCommandName       | 接替指令属性名。                             |
| Index                  | 列索引。（继承自ZDataColumnAttribute）       |
| Header                 | 列标题。（继承自ZDataColumnAttribute）       |
| Width                  | 列宽。（继承自ZDataColumnAttribute）         |
| DataGridLengthUnitType | 列宽属性。（继承自ZDataColumnAttribute）     |
| IsReadOnly             | 是否为只读。（继承自ZDataColumnAttribute）   |
| IsSearchProperty       | 是包含在查询。（继承自ZDataColumnAttribute） |



### ZOperateButtonAttribute类

#### 定义

```csharp
[AttributeUsage(AttributeTargets.Property)]
public class ZOperateButtonAttribute : Attribute
```

#### 注解

操作按钮基类。

#### 属性

| 属性        | 说明       |
| ----------- | ---------- |
| ButtonStyle | 按钮样式。 |
| Content     | 按钮内容。 |
| Index       | 按钮索引。 |



### ZOperateColumnButtonAttribute类

#### 定义

```csharp
[AttributeUsage(AttributeTargets.Property)]
public class ZOperateColumnButtonAttribute : ZOperateButtonAttribute
```

#### 注解

操作列按钮类。

#### 属性

| 属性        | 说明                                        |
| ----------- | ------------------------------------------- |
| ButtonStyle | 按钮样式。（继承自ZOperateButtonAttribute） |
| Content     | 按钮内容。（继承自ZOperateButtonAttribute） |
| Index       | 按钮索引。（继承自ZOperateButtonAttribute） |



### ZOperateTopButtonAttribute类

#### 定义

```csharp
[AttributeUsage(AttributeTargets.Method)]
public class ZOperateTopButtonAttribute : ZOperateButtonAttribute
```

#### 注解

顶部控制按钮类。

#### 属性

| 属性        | 说明                                        |
| ----------- | ------------------------------------------- |
| ButtonStyle | 按钮样式。（继承自ZOperateButtonAttribute） |
| Content     | 按钮内容。（继承自ZOperateButtonAttribute） |
| Index       | 按钮索引。（继承自ZOperateButtonAttribute） |

