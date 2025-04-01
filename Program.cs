using System.Diagnostics;

namespace Sandbox;

public class Program
{
	public static async Task Main()
	{
		var tests = TestManager.FindTests();
		Debug.Assert(tests.Count > 0);
		var selectedTest = TestManager.GetTestFromUserInput(tests);
		await TestManager.ExecuteTest(selectedTest);
	}
}
