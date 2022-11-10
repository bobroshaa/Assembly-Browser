using System.Collections.ObjectModel;
using System.Reflection;
using Interfaces;
using Model;

namespace Services
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
                        string modificator = "";
                        if (param.IsIn) modificator = "in";
                        else if (param.IsOut) modificator = "out";
 
                        signature +=($"{param.ParameterType.Name} {modificator} {param.Name}");
                        if (param.HasDefaultValue) signature +=($"={param.DefaultValue}");
                        if (i < parameters.Length - 1) signature +=(", ");
                    }

                    signature += ")";
                    node.Children.Add(new NonHierarchicalAssemblyUnit{Name = method.ReturnType.Name + " " + method.Name + signature});
                }
                nodes.Add(node);
            }
            var root = new ObservableCollection<IAssemblyUnit>();
            root.Add(new HierarchicalAssemblyUnit{Name = types[types.Length - 1].Namespace, Children = nodes});
            return root;
        }
    }
}