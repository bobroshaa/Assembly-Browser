using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Assembly_Browser
{
    public class AssemblyFileService : IFileService
    {
        public ObservableCollection<IAssemblyUnit> Open(string filename)
        {
            Assembly assembly  = Assembly.LoadFrom(filename);
            Type[] types = assembly.GetTypes();
            var nodes = new ObservableCollection<IAssemblyUnit>();
            foreach (var type in types)
            {
                var node = new HierarchicalAssemblyUnit{Name = type.Name};
                FieldInfo[] fields = type.GetFields();
                foreach (var field in fields)
                {
                    node.Children.Add(new NonHierarchicalAssemblyUnit{Name = field.Name});
                }
                PropertyInfo[] properties = type.GetProperties();
                foreach (var property in properties)
                {
                    node.Children.Add(new NonHierarchicalAssemblyUnit{Name = property.Name});
                }
                MethodInfo[] methods = type.GetMethods();
                foreach (var method in methods)
                {
                    node.Children.Add(new NonHierarchicalAssemblyUnit{Name = method.Name});
                }
                nodes.Add(node);
            }

            return nodes;
        }
    }
}