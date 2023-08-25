# ZhyForm

**WPF表单组件，表单项支持：简单文本、格式校验文本、多选项、按钮选择项，支持两种界面风格。**

ZFormDialog

![ZFormDialog](https://raw.githubusercontent.com/WineMonk/images/master/blog/post/202308180906372.png)

ZFormGrid

![ZFormGrid](https://raw.githubusercontent.com/WineMonk/images/master/blog/post/202308180906782.png)

ZDataGrid

![ZDataGrid](https://raw.githubusercontent.com/WineMonk/images/master/blog/post/202308251459220.png)

## 目录说明：

* zhy.common.form：基于.Net Framework 4.8框架。
* zhy.common.form.test：zhy.common.form的测试Demo。
* zhy.common.form.core：基于.Net 6.0框架。
* zhy.common.form.core.text：zhy.common.form.core的测试Demo。
* zhy.common.datagrid.core：基于.Net 6.0框架。

## 项目引用：

1. 编译源码后，在项目中添加编译生成的.dll引用；[Dll文件](./dll)
2. 在解决方案中直接引入.csproj项目；

## 代码示例：

### ZDataGrid

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



### ZFormDialog && ZFormGrid

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
