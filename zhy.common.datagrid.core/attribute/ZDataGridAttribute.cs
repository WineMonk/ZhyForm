/****************************************
 * FileName:	ZDataGridAttribute
 * Creater: 	shaozhy
 * Create Date:	2023/8/24 11:54:54
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

namespace zhy.common.datagrid.core.attribute
{
    /// <summary>
    /// 
    /// </summary>
    public class ZDataGridAttribute
    {
        internal bool CanSearch { get; set; }
        internal bool CanRemove { get; set; }
        public ZDataGridAttribute(bool canSearch = true, bool canRemove = true)
        {
            CanSearch = canSearch;
            CanRemove = canRemove;
        }
    }
}
