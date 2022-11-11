using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Interfaces;
using Model;

namespace Services
{
    public class AssemblyFileService : IFileService
    {
        public ObservableCollection<IAssemblyUnit> Open(string filename)
        {
            Assembly assembly  = Assembly.LoadFrom(filename);
            List<Type> types = assembly.GetTypes().ToList();
            Dictionary<string, List<string>> extensionMethods = new Dictionary<string, List<string>>();
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
                    if (method.IsDefined(typeof(ExtensionAttribute), false))
                    { 
                        if (extensionMethods.ContainsKey(method.GetParameters()[0].ParameterType.Name))
                            extensionMethods[method.GetParameters()[0].ParameterType.Name].Add("EXT: " + method.ToString());
                        else
                        {
                            extensionMethods.TryAdd(method.GetParameters()[0].ParameterType.Name, new List<string>(){"★EXT: " + method.ToString()});
                        }
                    }
                        
                    else
                        node.Children.Add(new NonHierarchicalAssemblyUnit{Name = method.ToString()});
                }
                nodes.Add(node);
            }
            var root = new ObservableCollection<IAssemblyUnit>();
            foreach (var className in extensionMethods.Keys)
            {
                foreach (var node in nodes)
                {
                    if (node.Name == className)
                        foreach (var method in extensionMethods[className])
                        {
                            ((HierarchicalAssemblyUnit)node).Children.Add(new NonHierarchicalAssemblyUnit
                                { Name = method });
                        }
                }
            }
            root.Add(new HierarchicalAssemblyUnit{Name = types[types.Count - 1].Namespace, Children = nodes});
            return root;
        }
    }
}