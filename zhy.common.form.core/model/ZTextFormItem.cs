/****************************************
 * FileName:	TextFormItem
 * Creater: 	shaozhy
 * Create Date:	2023/7/26 16:47:59
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
    /// 输入表单项
    /// </summary>
    public class ZTextFormItem : ZFormItemBase, IZFormItem
    {
        /// <summary>
        /// 初始值
        /// </summary>
        public string Value { get; set; }
    }
}
