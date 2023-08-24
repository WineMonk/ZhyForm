/****************************************
 * FileName:	ZDataGridViewModel
 * Creater: 	shaozhy
 * Create Date:	2023/8/21 17:58:36
 * Version: 	v0.0.1
 * Description:	
 * ======================================
 * Modify: —— Version: —— Date: —— Modifier: —— Content:
 ****************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using zhy.common.datagrid.core.model;

namespace zhy.common.datagrid.core.view.viewmodel
{
    /// <summary>
    /// 
    /// </summary>
    internal class ZDataGridViewModel:ObservableObject
    {
        private DataTable _prpoertyDataTable;
        public DataTable PrpoertyDataTable
        {
            get { return _prpoertyDataTable; }
            set { SetProperty(ref _prpoertyDataTable, value); }
        }
        public ZDataGridViewModel() 
        {
            PrpoertyDataTable = new DataTable();
            PrpoertyDataTable.Columns.Add(new ZDataColumn("Id", typeof(int)));
            PrpoertyDataTable.Columns.Add(new ZDataColumn("Name", typeof(string)));
            PrpoertyDataTable.Columns.Add(new ZDataColumn("Desc", typeof(string)));
            PrpoertyDataTable.Rows.Add(new object[] { 1, "测试1", "测试行" });
            PrpoertyDataTable.Rows.Add(new object[] { 2, "测试2", "测试行" });
            PrpoertyDataTable.Rows.Add(new object[] { 3, "测试3", "测试行" });
            PrpoertyDataTable.Rows.Add(new object[] { 4, "测试4", "测试行" });
            PrpoertyDataTable.Rows.Add(new object[] { 5, "测试5", "测试行" });
        }
    }
}
