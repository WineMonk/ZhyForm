/****************************************
 * FileName:	FormItemBase
 * Creater: 	shaozhy
 * Create Date:	2023/7/26 16:46:38
 * Version: 	v0.0.1
 * Description:	
 * ======================================
 * Modify: —— Version: —— Date: —— Modifier: —— Content:
 ****************************************/
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhy.common.form.model
{
    /// <summary>
    /// 表单项基类
    /// </summary>
    public class ZFormItemBase
    {
        private string _key;
        public string Key 
        {
            get
            {
                if(string.IsNullOrEmpty(_key))
                    _key = Guid.NewGuid().ToString();
                return _key;
            }
        }
        public string Title { get; set; }
        public object Data { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsRequired { get; set; }
    }
}