using System.Diagnostics;

namespace Sandbox;

public class Program
{
	public static async Task Main(string[] args)
	{
		var tests = TestManager.FindTests();
		Debug.Assert(tests.Count > 0);

		Type? selectedTest;
		if (args.Length == 1 && int.TryParse(args[0], out var choice))
		{
			selectedTest = TestManager.GetTestAtIndex(choice, tests);
		}
		else
		{
			selectedTest = TestManager.GetTestFromUserInput(tests);
		}
		await TestManager.ExecuteTest(selectedTest);
	}
}
