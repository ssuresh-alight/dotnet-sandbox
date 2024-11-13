using System.Diagnostics;

namespace Sandbox;

public class Program
{
	public static void Main()
	{
		var tests = TestManager.FindTests();
		Debug.Assert(tests.Count > 0);
		var selectedTest = TestManager.GetTestFromUserInput(tests);
		TestManager.ExecuteTest(selectedTest);
	}
}
