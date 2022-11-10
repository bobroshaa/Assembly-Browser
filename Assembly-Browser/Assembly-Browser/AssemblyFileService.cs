using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Assembly_Browser
{
    public class AssemblyFileService : IFileService
    {
        public ObservableCollection<HierarchicalAssemblyUnit> Open(string filename)
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
                    node.Children.Add(new NonHierarchicalAssemblyUnit{Name = field.Name + "[" + field.FieldType.Name + "]"});
                }
                PropertyInfo[] properties = type.GetProperties();
                foreach (var property in properties)
                {
                    node.Children.Add(new NonHierarchicalAssemblyUnit{Name = property.Name + "[" + property.PropertyType.Name + "]"});
                }
                MethodInfo[] methods = type.GetMethods();
                foreach (var method in methods)
                {
                    var signature = "(";
                    ParameterInfo[] parameters = method.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        var param = parameters[i];
                        // получаем модификаторы параметра
                        string modificator = "";
                        if (param.IsIn) modificator = "in";
                        else if (param.IsOut) modificator = "out";
 
                        signature +=($"{param.ParameterType.Name} {modificator} {param.Name}");
                        // если параметр имеет значение по умолчанию
                        if (param.HasDefaultValue) signature +=($"={param.DefaultValue}");
                        // если не последний параметр, добавляем запятую
                        if (i < parameters.Length - 1) signature +=(", ");
                    }

                    signature += ")";
                    node.Children.Add(new NonHierarchicalAssemblyUnit{Name = method.ReturnType.Name + " " + method.Name + signature});
                }
                nodes.Add(node);
            }
            var root = new ObservableCollection<HierarchicalAssemblyUnit>();
            root.Add(new HierarchicalAssemblyUnit{Name = types[types.Length - 1].Namespace, Children = nodes});
            return root;
        }
    }
}