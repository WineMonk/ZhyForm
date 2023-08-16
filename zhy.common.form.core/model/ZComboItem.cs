/****************************************
 * FileName:	ComboItem
 * Creater: 	shaozhy
 * Create Date:	2023/8/9 10:23:22
 * Version: 	v0.0.1
 * Description:	
 * ======================================
 * Modify: —— Version: —— Date: —— Modifier: —— Content:
 ****************************************/
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhy.common.form.core.model
{
    /// <summary>
    /// 选项
    /// </summary>
    public class ZComboItem
    {
        private string _display;
        public string Display
        {
            get { return _display; }
            set { _display = value; }
        }
        private object _value;
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
