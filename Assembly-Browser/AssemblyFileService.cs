using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assembly_Browser
{
    public class AssemblyFileService : IFileService
    {
        public List<Node> Open(string filename)
        {
            Assembly assembly  = Assembly.LoadFrom(filename);
            Type[] types = assembly.GetTypes();
            List<Node> nodes = new List<Node>();
            foreach (var type in types)
            {
                var node = new Node(type.Name);
                FieldInfo[] fields = type.GetFields();
                foreach (var field in fields)
                {
                    node.Fields.Add(field.Name);
                }
                PropertyInfo[] properties = type.GetProperties();
                foreach (var property in properties)
                {
                    node.Properties.Add(property.Name);
                }
                MethodInfo[] methods = type.GetMethods();
                foreach (var method in methods)
                {
                    node.Methods.Add(method.Name);
                }
                nodes.Add(node);
            }

            return nodes;
        }
    }
}