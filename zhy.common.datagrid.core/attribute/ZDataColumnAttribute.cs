/****************************************
 * FileName:	ZDataColumnAttribute
 * Creater: 	shaozhy
 * Create Date:	2023/8/22 11:56:08
 * Version: 	v0.0.1
 * Description:	
 * ======================================
 * Modify: —— Version: —— Date: —— Modifier: —— Content:
 ****************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using zhy.common.datagrid.core.enumeration;

namespace zhy.common.datagrid.core.attribute
{
    /// <summary>
    /// 数据列特性基类
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ZDataColumnAttribute: Attribute
    {
        internal int Index { get; set; }
        internal string Header { get; set; }
        internal DataGridLength Width { get; set; }
        internal bool IsReadOnly { get; set; }
        internal bool IsSearchProperty { get; set; }
        /// <summary>
        /// 数据列
        /// </summary>
        /// <param name="header">列标题</param>
        /// <param name="index">列索引</param>
        /// <param name="isReadOnly">是否为只读</param>
        /// <param name="isSearchProperty">是包含在查询</param>
        /// <param name="width">列宽</param>
        /// <param name="dataGridLengthUnitType">列宽单位</param>
        internal ZDataColumnAttribute(string header,
            int index = -1, bool isReadOnly = false, bool isSearchProperty = false, double width = 1,
            DataGridLengthUnitType dataGridLengthUnitType = DataGridLengthUnitType.Star)
        {
            Width = new DataGridLength(width, dataGridLengthUnitType);
            Header = header;
            IsReadOnly = isReadOnly;
            Index = index;
            IsSearchProperty = isSearchProperty;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ZTextDataColumnAttribute : ZDataColumnAttribute
    {
        /// <summary>
        /// 文本输入数据列
        /// </summary>
        /// <param name="header">列标题</param>
        /// <param name="index">列索引</param>
        /// <param name="isReadOnly">是否为只读</param>
        /// <param name="isSearchProperty">是包含在查询</param>
        /// <param name="width">列宽</param>
        /// <param name="dataGridLengthUnitType">列宽单位</param>
        public ZTextDataColumnAttribute(string header,
            int index = -1, bool isReadOnly = false, bool isSearchProperty = false, double width = 1, 
            DataGridLengthUnitType dataGridLengthUnitType = DataGridLengthUnitType.Star) :
            base(header, index, isReadOnly, isSearchProperty, width, dataGridLengthUnitType)
        {
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ZCheckDataColumnAttribute : ZDataColumnAttribute
    {
        /// <summary>
        /// 勾选数据列
        /// </summary>
        /// <param name="header">列标题</param>
        /// <param name="index">列索引</param>
        /// <param name="isReadOnly">是否为只读</param>
        /// <param name="isSearchProperty">是包含在查询</param>
        /// <param name="width">列宽</param>
        /// <param name="dataGridLengthUnitType">列宽单位</param>
        public ZCheckDataColumnAttribute(string header,
            int index = -1, bool isReadOnly = false, bool isSearchProperty = false, double width = 1, 
            DataGridLengthUnitType dataGridLengthUnitType = DataGridLengthUnitType.Star) :
            base(header, index, isReadOnly, isSearchProperty, width, dataGridLengthUnitType)
        {
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ZComboDataColumnAttribute : ZDataColumnAttribute
    {
        public string TargetProperty { get; set; }
        public string DisplayMemberPath { get; set; }
        /// <summary>
        /// 选项数据列
        /// </summary>
        /// <param name="header">列标题</param>
        /// <param name="targetProperty">选择项绑定目标属性</param>
        /// <param name="displayMemberPath">选择项显示成员</param>
        /// <param name="index">列索引</param>
        /// <param name="isReadOnly">是否为只读</param>
        /// <param name="isSearchProperty">是包含在查询</param>
        /// <param name="width">列宽</param>
        /// <param name="dataGridLengthUnitType">列宽属性</param>
        public ZComboDataColumnAttribute(string header, string targetProperty,
            string displayMemberPath = null, int index = -1, bool isReadOnly = false,
            bool isSearchProperty = false, double width = 1, 
            DataGridLengthUnitType dataGridLengthUnitType = DataGridLengthUnitType.Star) :
            base(header, index, isReadOnly, isSearchProperty, width, dataGridLengthUnitType)
        {
            TargetProperty = targetProperty;
            DisplayMemberPath = displayMemberPath;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ZButtonDataColumnAttribute : ZDataColumnAttribute
    {
        public string RelayCommandName { get; set; }
        public string ButtonContent { get; set; }
        public ButtonStyle ButtonStyle { get; set; }
        public string DisplayMemberPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="header">列标题</param>
        /// <param name="buttonContent">按钮内容</param>
        /// <param name="relayCommandName">接替指令属性名</param>
        /// <param name="index">列索引</param>
        /// <param name="displayMemberPath">显示成员路径</param>
        /// <param name="isReadOnly">是否为只读</param>
        /// <param name="isSearchProperty">是否包含在查询</param>
        /// <param name="buttonStyle">按钮样式</param>
        /// <param name="width">列宽</param>
        /// <param name="dataGridLengthUnitType">列宽单位</param>
        public ZButtonDataColumnAttribute(string header, string buttonContent, string relayCommandName,
            int index = -1, string displayMemberPath = null, bool isReadOnly = false, 
            bool isSearchProperty = false, ButtonStyle buttonStyle = ButtonStyle.DefaultButton, 
            double width = 1, DataGridLengthUnitType dataGridLengthUnitType = DataGridLengthUnitType.Star) :
            base(header, index, isReadOnly, isSearchProperty, width, dataGridLengthUnitType)
        {
            RelayCommandName = relayCommandName;
            ButtonContent = buttonContent;
            ButtonStyle = buttonStyle;
            DisplayMemberPath = displayMemberPath;
        }
    }
}
