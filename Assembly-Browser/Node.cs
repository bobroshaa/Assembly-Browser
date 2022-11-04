using System.Collections.Generic;

namespace Assembly_Browser
{
    public class Node
    {
        public string Name { get; set; }
        public List<string> Properties;
        public List<string> Fields;
        public List<string> Methods;

        public Node(string name)
        {
            Name = name;
            Properties = new List<string>();
            Fields = new List<string>();
            Methods = new List<string>();
        }
    }
}