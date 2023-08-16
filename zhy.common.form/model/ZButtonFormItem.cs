/****************************************
 * FileName:	FileFormItem
 * Creater: 	shaozhy
 * Create Date:	2023/7/26 16:48:58
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
    /// 按钮表单项
    /// </summary>
    public class ZButtonFormItem : ZFormItemBase, IZFormItem
    {
        /// <summary>
        /// 选择按钮方法
        /// </summary>
        public Func<string, string> ButtonCommand { get; set; }
        /// <summary>
        /// 初始值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 按钮内容
        /// </summary>
        public string ButtonContent { get; set; } = "选 择";
    }
}
