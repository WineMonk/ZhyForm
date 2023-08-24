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

namespace zhy.common.datagrid.core.attribute
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ZDataColumnAttribute: Attribute
    {
        internal int Index { get; set; }
        internal string Header { get; set; }
        internal DataGridLength Width { get; set; }
        internal bool IsReadOnly { get; set; }
        internal ZDataColumnAttribute(string header,
            int index = 0, bool isReadOnly = false, double width = 1,
            DataGridLengthUnitType dataGridLengthUnitType = DataGridLengthUnitType.Star)
        {
            Width = new DataGridLength(width, dataGridLengthUnitType);
            Header = header;
            IsReadOnly = isReadOnly;
            Index = index;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ZTextDataColumnAttribute : ZDataColumnAttribute
    {
        public ZTextDataColumnAttribute(string header,
            int index = 0, bool isReadOnly = false, double width = 1, 
            DataGridLengthUnitType dataGridLengthUnitType = DataGridLengthUnitType.Star) :
            base(header, index, isReadOnly, width, dataGridLengthUnitType)
        {
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ZCheckDataColumnAttribute : ZDataColumnAttribute
    {
        public ZCheckDataColumnAttribute(string header,
            int index = 0, bool isReadOnly = false, double width = 1, 
            DataGridLengthUnitType dataGridLengthUnitType = DataGridLengthUnitType.Star) :
            base(header, index, isReadOnly, width, dataGridLengthUnitType)
        {
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ZComboDataColumnAttribute : ZDataColumnAttribute
    {
        public string TargetProperty { get; set; }
        public string DisplayMemberPath { get; set; }
        public ZComboDataColumnAttribute(string header, string targetProperty,
            string displayMemberPath = null,
            int index = 0, bool isReadOnly = false, double width = 1, 
            DataGridLengthUnitType dataGridLengthUnitType = DataGridLengthUnitType.Star) :
            base(header, index, isReadOnly, width, dataGridLengthUnitType)
        {
            TargetProperty = targetProperty;
            DisplayMemberPath = displayMemberPath;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ZButtonDataColumnAttribute : ZDataColumnAttribute
    {
        public string RealyCommandName { get; set; }
        public string ButtonContent { get; set; }
        public ZButtonDataColumnAttribute(string header, string buttonContent, string relayCommandName,
            int index = 0, bool isReadOnly = false, double width = 1,
            DataGridLengthUnitType dataGridLengthUnitType = DataGridLengthUnitType.Star) :
            base(header, index, isReadOnly, width, dataGridLengthUnitType)
        {
            RealyCommandName = relayCommandName;
            ButtonContent = buttonContent;
        }
    }
}
