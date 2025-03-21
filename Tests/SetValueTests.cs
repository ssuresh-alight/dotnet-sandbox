namespace Sandbox.Tests;

public class SetValueTests : ISandboxTest
{
    public void Execute()
    {
        var set1 = new HashSet<TestRecord>();
        var testRecord1 = new TestRecord() { Name = "test" };
        var testRecord2 = new TestRecord() { Name = "test" };
        var testRecord3 = new TestRecord() { Name = "abcd" };
        set1.Add(testRecord1);
        if(set1.Contains(testRecord1)) {
            Console.WriteLine("testRecord1 is in set1");
        } else {
            Console.WriteLine("testRecord1 is not in set1");
        }
        
        if(set1.Contains(testRecord2)) {
            Console.WriteLine("testRecord2 is in set1");
        } else {
            Console.WriteLine("testRecord2 is not in set1");
        }

        if(set1.Contains(testRecord3)) {
            Console.WriteLine("testRecord3 is in set1");
        } else {
            Console.WriteLine("testRecord3 is not in set1");
        }
        
        testRecord3.Name = "test";
        Console.WriteLine("testRecord3.Name updated");
        if(set1.Contains(testRecord3)) {
            Console.WriteLine("testRecord3 is in set1");
        } else {
            Console.WriteLine("testRecord3 is not in set1");
        }

        Console.WriteLine("=======");

        var set2 = new HashSet<TestRecordWithList>();
        var testRecordWithList1 = new TestRecordWithList() { Name = "test", RelatedNames = new List<string> { "test1", "test2" } };
        var testRecordWithList2 = new TestRecordWithList() { Name = "test", RelatedNames = new List<string> { "test1", "test2" } };
        set2.Add(testRecordWithList1);
        if(set2.Contains(testRecordWithList1)) {
            Console.WriteLine("testRecordWithList1 is in set2");
        } else {
            Console.WriteLine("testRecordWithList1 is not in set2");
        }
        
        if(set2.Contains(testRecordWithList2)) {
            Console.WriteLine("testRecordWithList2 is in set2");
        } else {
            Console.WriteLine("testRecordWithList2 is not in set2");
        }
        testRecordWithList2.RelatedNames = testRecordWithList1.RelatedNames;
        Console.WriteLine("testRecordWithList2.RelatedNames reference updated");
        if(set2.Contains(testRecordWithList2)) {
            Console.WriteLine("testRecordWithList2 is in set2");
        } else {
            Console.WriteLine("testRecordWithList2 is not in set2");
        }
    
    }

    public record TestRecord
    {
        public required string Name { get; set; }
    }

    public record TestRecordWithList : TestRecord
    {
        public required IList<string> RelatedNames { get; set; }
    }
}
