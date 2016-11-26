using Microsoft.Win32;
using EPAM.DBAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EPAM.FunctionTypes.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String _filePath;
        public String FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        private String _attributeProperties;
        public String AttributeProperties
        {
            get { return _attributeProperties; }
            set
            {
                _attributeProperties = value;
                OnPropertyChanged("AttributeProperties");
            }
        }

        private List<Type> _interfaces;
        public List<Type> Interfaces
        {
            get { return _interfaces; }
            set
            {
                _interfaces = value;
                OnPropertyChanged("Interfaces");
            }
        }

        private List<MethodInfo> _methods;
        public List<MethodInfo> Methods
        {
            get { return _methods; }
            set
            {
                _methods = value;
                OnPropertyChanged("Methods");
            }
        }

        public MainWindowVM()
        {
            FilePath = "";
            Interfaces = new List<Type>();
            Methods = new List<MethodInfo>();
        }

        public void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }

        public void btnFileDialog_Click()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "DLL Files (.dll)|*.dll";
            bool? res = dialog.ShowDialog();
            if (res == true)
                FilePath = dialog.FileName;
        }

        public void btnStart_Click()
        {
            var file = Assembly.LoadFrom(FilePath);

            List<Type> types = new List<Type>();
            foreach (var t in file.GetTypes())
                if(t.IsInterface && t.GetCustomAttributes(typeof(TransactionIntrefaceAttribute), false).Length > 0)
                {
                    types.Add(t);
                }
            Interfaces = types;
        }

        public void lbInterfaces_Changed(object sender)
        {
            var lb = (ListBox)sender;
            var type = (Type)lb.SelectedItem;
            List<MethodInfo> methods = new List<MethodInfo>();
            foreach (var m in type.GetMethods())
                if(m.GetCustomAttributes(typeof(TransactionTypeAttribute), false).Length > 0)
                    methods.Add(m);
            Methods = methods;
        }

        public void lbMethods_Changed(object sender)
        {
            var lb = (ListBox)sender;
            var methodInfo = (MethodInfo)lb.SelectedItem;
            var atr = (TransactionTypeAttribute)methodInfo.GetCustomAttributes(typeof(TransactionTypeAttribute)).FirstOrDefault();
            AttributeProperties = String.Format("TransactionType - {0}, cashe size = {1}", atr.TransactionType, atr.CacheSize);

        }
    }
}
