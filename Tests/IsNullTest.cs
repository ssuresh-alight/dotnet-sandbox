namespace Sandbox.Tests;

public class IsNullTest : ISandboxTest
{
    public void Execute()
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        string a = null;
        object b = null;
        // string c = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        if (a is null)
        {
            Console.WriteLine("a is null");
        }
        if (b is null)
        {
            Console.WriteLine("b is null");
        }
        // if (a is b) // doesn't compile
        // {
        //     Console.WriteLine("a is b");
        // }
        // if (a is c) // doesn't compile either
        // {
        //     Console.WriteLine("a is c");
        // }
        if (a is "")
        {
            Console.WriteLine("a is empty string");
        }
    }
}
