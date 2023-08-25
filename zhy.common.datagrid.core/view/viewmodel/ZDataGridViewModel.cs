/****************************************
 * FileName:	ZDataGridViewModel
 * Creater: 	shaozhy
 * Create Date:	2023/8/24 14:36:56
 * Version: 	v0.0.1
 * Description:	
 * ======================================
 * Modify: —— Version: —— Date: —— Modifier: —— Content:
 ****************************************/
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using zhy.common.datagrid.core.attribute;

namespace zhy.common.datagrid.core.view.viewmodel
{
    /// <summary>
    /// 
    /// </summary>
    internal class ZDataGridViewModel : ObservableObject
    {
        public ZDataGridViewModel(IList observableObjects)
        {
            object? val = Activator.CreateInstance(observableObjects.GetType());
            _observableObjects = (IList)val;
            foreach (var item in observableObjects)
                _observableObjects.Add(item);
        }
        public ZDataGridViewModel()
        {

        }
        public IList Items
        {
            get
            {
                UpdateTotalItems();
                IList instance = (IList)Activator.CreateInstance(_observableObjects.GetType());
                foreach (var item in _totalObservableObjects)
                    instance.Add(item);
                return instance;
            }
        }
        private IList _totalObservableObjects;
        private IList _searchObservableObjects;

        private IList _observableObjects;
        public IList ObservableObjects
        {
            get { return _observableObjects; }
            set { SetProperty(ref _observableObjects, value); }
        }
        
        private Visibility _searchAllVisibility = Visibility.Collapsed;
        public Visibility SearchAllVisibility
        {
            get { return _searchAllVisibility; }
            set { SetProperty(ref _searchAllVisibility, value); }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        public RelayCommand CommandSearch => new RelayCommand(Search);
        private void Search()
        {
            UpdateTotalItems();
            if (string.IsNullOrEmpty(SearchText))
            {
                if (_totalObservableObjects == null || _totalObservableObjects.Count < 1)
                    return;
                ObservableObjects.Clear();
                foreach (var item in _totalObservableObjects)
                    ObservableObjects.Add(item);
                _totalObservableObjects = null;
                SearchAllVisibility = Visibility.Collapsed;
            }
            else
            {
                if (_totalObservableObjects == null || _totalObservableObjects.Count < 1)
                {
                    _totalObservableObjects = new List<object>();
                    foreach (var item in ObservableObjects)
                        _totalObservableObjects.Add(item);
                }
                ObservableObjects.Clear();
                List<PropertyInfo> propertyInfos = GetSearchColumnPropertyInfo();
                foreach (var item in _totalObservableObjects)
                {
                    bool check = CheckItem(item, propertyInfos, SearchText);
                    if (check)
                        ObservableObjects.Add(item);
                }
                _searchObservableObjects = new List<object>();
                foreach (var item in ObservableObjects)
                    _searchObservableObjects.Add(item);
                SearchAllVisibility = Visibility.Visible;
            }
        }
        public RelayCommand CommandSearchAll => new RelayCommand(SearchAll);
        private void SearchAll()
        {
            SearchText = string.Empty;
            Search();
        }

        private List<PropertyInfo> GetSearchColumnPropertyInfo()
        {
            List<PropertyInfo> columnPropertyInfos = new List<PropertyInfo>();
            if (!ObservableObjects.GetType().IsGenericType)
                return columnPropertyInfos;
            Type sourceItemType = ObservableObjects.GetType().GetGenericArguments()[0];
            PropertyInfo[] propertyInfos = sourceItemType.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Attribute? attributeColumn = propertyInfo.GetCustomAttribute(typeof(ZDataColumnAttribute), true);
                if (attributeColumn != null && ((ZDataColumnAttribute)attributeColumn).IsSearchProperty)
                    columnPropertyInfos.Add(propertyInfo);
            }
            return columnPropertyInfos;
        }

        private bool CheckItem(object item, List<PropertyInfo> propertyInfos, string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return true;
            foreach (var propertyInfo in propertyInfos)
            {
                object? val = propertyInfo.GetValue(item, null);
                if (val == null) continue;
                if (val.ToString().ToLower().Contains(searchText.ToLower()))
                    return true;
            }
            return false;
        }

        private bool CompareIList(IList list1, IList list2)
        {
            if (list1.Count != list2.Count)
                return false;
            foreach (var item in list1)
            {
                int idx = list2.IndexOf(item);
                if (idx < 0)
                    return false;
            }
            return true;
        }

        private void UpdateTotalItems()
        {
            if (_totalObservableObjects != null && _totalObservableObjects.Count > 0)
            {
                bool modify = !CompareIList(ObservableObjects, _searchObservableObjects);
                if (modify)
                {
                    foreach (var item in _searchObservableObjects)
                    {
                        int idxRm = ObservableObjects.IndexOf(item);
                        if (idxRm < 0)
                            _totalObservableObjects.Remove(item);
                    }
                    foreach (var item in ObservableObjects)
                    {
                        int idxAdd = _searchObservableObjects.IndexOf(item);
                        if (idxAdd < 0)
                            _totalObservableObjects.Add(item);
                    }
                }
            }
        }
    }
}
