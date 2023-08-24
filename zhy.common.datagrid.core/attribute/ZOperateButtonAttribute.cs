/****************************************
 * FileName:	ZOperateButtonAttribute
 * Creater: 	shaozhy
 * Create Date:	2023/8/22 11:58:10
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

namespace zhy.common.datagrid.core.attribute
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ZOperateButtonAttribute : Attribute
    {
        public string Content { get; set; }
        public ZOperateButtonAttribute(string content)
        {
            Content = content;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ZOperateColumnButtonAttribute : ZOperateButtonAttribute
    {
        public ZOperateColumnButtonAttribute(string content):base(content)
        {
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ZOperateTopButtonAttribute : ZOperateButtonAttribute
    {
        public ZOperateTopButtonAttribute(string content) : base(content)
        {
        }
    }
}
