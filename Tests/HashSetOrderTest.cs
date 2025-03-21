namespace Sandbox.Tests;

public class HashSetOrderTest : ISandboxTest
{
    public void Execute()
    {
        List<int> testList1 = [1, 2, 3, 4];
        var testSet1 = new HashSet<int>(testList1);
        var testConvertedList1 = testSet1.ToList();
        Console.WriteLine(string.Join(",", testConvertedList1));


        List<int> testList2 = [3, 1, 2, 4, 2, 1, 3];
        var testSet2 = new HashSet<int>(testList2);
        var testConvertedList2 = testSet2.ToList();
        Console.WriteLine(string.Join(",", testConvertedList2));
    }
}
