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
using zhy.common.datagrid.core.enumeration;

namespace zhy.common.datagrid.core.attribute
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ZOperateButtonAttribute : Attribute
    {
        internal int Index { get; set; }
        internal string Content { get; set; }
        internal ButtonStyle ButtonStyle { get; set; }
        /// <summary>
        /// 操作按钮基类
        /// </summary>
        /// <param name="content">按钮内容</param>
        /// <param name="index">按钮索引</param>
        /// <param name="buttonStyle">按钮样式</param>
        internal ZOperateButtonAttribute(string content, int index = -1,
            ButtonStyle buttonStyle = ButtonStyle.DefaultButton)
        {
            Content = content;
            ButtonStyle = buttonStyle;
            Index = index;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ZOperateColumnButtonAttribute : ZOperateButtonAttribute
    {
        /// <summary>
        /// 操作列按钮类
        /// </summary>
        /// <param name="content">按钮内容</param>
        /// <param name="index">按钮索引</param>
        /// <param name="buttonStyle">按钮样式</param>
        public ZOperateColumnButtonAttribute(string content, int index = -1,
            ButtonStyle buttonStyle = ButtonStyle.DefaultButton) :base(content, index, buttonStyle)
        {
        }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class ZOperateTopButtonAttribute : ZOperateButtonAttribute
    {
        /// <summary>
        /// 顶部控制按钮类
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        /// <param name="buttonStyle"></param>
        public ZOperateTopButtonAttribute(string content, int index = -1,
            ButtonStyle buttonStyle = ButtonStyle.DefaultButton) : base(content, index, buttonStyle)
        {
        }
    }
}
