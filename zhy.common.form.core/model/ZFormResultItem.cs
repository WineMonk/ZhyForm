/****************************************
 * FileName:	FormResultItem
 * Creater: 	shaozhy
 * Create Date:	2023/7/27 11:13:39
 * Version: 	v0.0.1
 * Description:	
 * ======================================
 * Modify: —— Version: —— Date: —— Modifier: —— Content:
 ****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhy.common.form.core.model.Interf;

namespace zhy.common.form.core.model
{
    /// <summary>
    /// 表单结果项
    /// </summary>
    public class ZFormResultItem
    {
        public IZFormItem FormItem { get; set; }
        public object Value { get; set; }
        internal ZFormResultItem(IZFormItem zFormItem, object value)
        {
            this.FormItem = zFormItem;
            this.Value = value;
        }
    }
}
