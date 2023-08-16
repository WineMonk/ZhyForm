/****************************************
 * FileName:	ComboTextFormItem
 * Creater: 	shaozhy
 * Create Date:	2023/7/27 9:57:44
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
using zhy.common.form.core.view.model;

namespace zhy.common.form.core.model
{
    /// <summary>
    /// 多选表单项
    /// </summary>
    public class ZComboFormItem : ZFormItemBase, IZFormItem
    {
        /// <summary>
        /// 选项集
        /// </summary>
        private List<ZComboItem> _values =
            new List<ZComboItem>();
        public List<ZComboItem> Values
        {
            get { return _values; }
            set { _values = value; }
        }
    }
}
