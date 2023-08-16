/****************************************
 * FileName:	FormatTextFormItem
 * Creater: 	shaozhy
 * Create Date:	2023/7/27 13:36:31
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
using zhy.common.form.model.Interf;

namespace zhy.common.form.model
{
    /// <summary>
    /// 校验格式表单项
    /// </summary>
    public class ZFormatTextFormItem : ZTextFormItem, IZFormItem
    {
        /// <summary>
        /// 格式提示
        /// </summary>
        public string ErrMessage { get; set; }
        /// <summary>
        /// 格式校验方法
        /// </summary>
        public Func<string, bool> FormatVerification { get; set; }
    }
}
