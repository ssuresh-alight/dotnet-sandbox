namespace Sandbox.Tests;

public class IsTests : ISandboxTest
{
    public void Execute()
    {
        var newStringA = "ABCDEF";
        if (newStringA is StringConstants.TestA)
        {
            Console.WriteLine("newStringA is testString"); // prints
        } else 
        {
            Console.WriteLine("newStringA is not testString");
        }

#pragma warning disable CS8520 // The given expression always matches the provided constant.
        if (("ABCD" + "EF") is StringConstants.TestA)
        {
            Console.WriteLine("concatenated string is testString"); // prints
        } else 
        {
            Console.WriteLine("concatenated string is not testString");
        }
#pragma warning restore CS8520 // The given expression always matches the provided constant.

        if (new String("ABCDEF") is StringConstants.TestA)
        {
            Console.WriteLine("constructed string is testString"); // prints
        } else 
        {
            Console.WriteLine("constructed string is not testString");
        }

#pragma warning disable CS8519 // The given expression never matches the provided pattern.
        if ("abcdef" is StringConstants.TestA)
        {
            Console.WriteLine("lowercase string is testString");
        } else 
        {
            Console.WriteLine("lowercase string is not testString"); // prints
        }
#pragma warning restore CS8519 // The given expression never matches the provided pattern.
    }
}

public class StringConstants
{
    public const string TestA = "ABCDEF";
    public const string TestB = "CDEFGHI";
}
