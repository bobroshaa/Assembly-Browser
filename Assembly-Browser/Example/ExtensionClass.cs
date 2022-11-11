namespace Example;

static public class ExtensionClass
{
    static public int Sub(this ExampleClass exampleClass, int value1, int value2)
    {
        return value1 - value2;
    }
}