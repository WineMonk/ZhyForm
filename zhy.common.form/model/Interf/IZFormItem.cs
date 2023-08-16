/****************************************
 * FileName:	IZFormItem
 * Creater: 	shaozhy
 * Create Date:	2023/8/8 18:20:06
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

namespace zhy.common.form.model.Interf
{
    /// <summary>
    /// 表单项接口
    /// </summary>
    public interface IZFormItem
    {
        /// <summary>
        /// 唯一键
        /// </summary>
        string Key { get; }
        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        object Data { get; set; }
        /// <summary>
        /// 是否只读
        /// </summary>
        bool IsReadOnly { get; set; }
        /// <summary>
        /// 是否必须
        /// </summary>
        bool IsRequired { get; set; }
    }
}
