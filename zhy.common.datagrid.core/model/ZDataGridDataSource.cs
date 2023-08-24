/****************************************
 * FileName:	ZDataGridDataSource
 * Creater: 	shaozhy
 * Create Date:	2023/8/24 9:37:56
 * Version: 	v0.0.1
 * Description:	
 * ======================================
 * Modify: —— Version: —— Date: —— Modifier: —— Content:
 ****************************************/
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhy.common.datagrid.core.model
{
    /// <summary>
    /// 
    /// </summary>
    public class ZDataGridDataSource : ObservableObject
    {
        private IList _items;
        public IList Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }


    }
}
