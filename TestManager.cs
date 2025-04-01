using System.Diagnostics;
using System.Reflection;
using Sandbox.Tests;

namespace Sandbox;

public class TestManager
{
    public static IList<Type> FindTests()
    {
        var asm = Assembly.GetExecutingAssembly();
        List<Type> classes = asm
            .GetTypes()
            .Where(t => !t.IsInterface && (
                t.GetInterfaces().Contains(typeof(ISandboxTest)) ||
                t.GetInterfaces().Contains(typeof(ISandboxTestAsync))
            ))
            .ToList();
        return classes;
    }

    public static Type GetTestFromUserInput(IList<Type> tests)
    {
        var testOptions = tests.Select((test, i) => $"[{i}]: {test.Name}").ToList();
        Console.Write(
            $"""
			Possible tests:
			{string.Join("\n", testOptions)}
			Your choice: 
			"""
        );
        var choiceInput = Console.ReadLine();
        if (!int.TryParse(choiceInput?.Trim(), out int choice))
        {
            Console.WriteLine("Invalid value entered for choice. Must be a number.");
            throw new ArgumentException(nameof(choiceInput));
        }
        return GetTestAtIndex(choice, tests);
    }

    public static Type GetTestAtIndex(int index, IList<Type> tests)
    {
        if (index < 0 || index >= tests.Count)
        {
            Console.WriteLine("Bad choice. Not a valid option.");
            throw new ArgumentException(nameof(index));
        }
        return tests[index];
    }

    public static async Task ExecuteTest(Type sandboxTestType)
    {
        if (!sandboxTestType.IsClass || (
            !sandboxTestType.GetInterfaces().Contains(typeof(ISandboxTest)) &&
            !sandboxTestType.GetInterfaces().Contains(typeof(ISandboxTestAsync))
        ))
        {
            throw new ArgumentException(
                $"Invalid test - must be a concrete class implementing {nameof(ISandboxTest)} or {nameof(ISandboxTestAsync)} "
            );
        }

        var test = Activator.CreateInstance(sandboxTestType)!;
        Debug.Assert(test is not null);
        if (test is ISandboxTest)
        {
            ((ISandboxTest)test).Execute();
        }
        else if (test is ISandboxTestAsync)
        {
            await ((ISandboxTestAsync)test).ExecuteAsync();
        }
    }
}
