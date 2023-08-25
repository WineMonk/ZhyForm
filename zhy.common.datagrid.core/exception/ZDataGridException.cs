﻿/****************************************
 * FileName:	ZDataGridException
 * Creater: 	shaozhy
 * Create Date:	2023/8/25 11:23:09
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

namespace zhy.common.datagrid.core.exception
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ZDataGridException : Exception
    {
        public ZDataGridException():base() { }
        public ZDataGridException(string  message):base(message) { }
        public ZDataGridException(string message, Exception inner):base(message, inner) { }
    }
}
