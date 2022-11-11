using Interfaces;
using Model;
using Services;

namespace Tests;

public class Tests
{
    public IFileService _fileService;
    public AssemblyBrowser _assemblyBrowser;
    
    [SetUp]
    public void Setup()
    {
        _assemblyBrowser = new AssemblyBrowser();
        _fileService = new AssemblyFileService(); 
        _assemblyBrowser.Namespaces = _fileService.Open("C:\\Users\\bobro\\RiderProjects\\Assembly-Browser\\Assembly-Browser\\Example\\bin\\Debug\\net6.0\\Example.dll");
    }

    [Test]
    public void TestNamespace()
    {
        Assert.That(_assemblyBrowser.Namespaces[0].Name, Is.EqualTo("Example"));
    }
    
    [Test]
    public void TestTypesCount()
    {
        Assert.That(((HierarchicalAssemblyUnit)_assemblyBrowser.Namespaces[0]).Children.Count, Is.EqualTo(5));
    }
    
    [Test]
    public void TestTypesName()
    {
        Assert.That(((HierarchicalAssemblyUnit)_assemblyBrowser.Namespaces[0]).Children[3].Name, Is.EqualTo("ExampleClass"));
        Assert.That(((HierarchicalAssemblyUnit)_assemblyBrowser.Namespaces[0]).Children[4].Name, Is.EqualTo("ExtensionClass"));
    }
    
    [Test]
    public void TestChildrenCount()
    {
        Assert.That(((HierarchicalAssemblyUnit)((HierarchicalAssemblyUnit)_assemblyBrowser.Namespaces[0]).Children[3]).Children.Count, Is.EqualTo(12));
        Assert.That(((HierarchicalAssemblyUnit)((HierarchicalAssemblyUnit)_assemblyBrowser.Namespaces[0]).Children[4]).Children.Count, Is.EqualTo(4));
    }
}