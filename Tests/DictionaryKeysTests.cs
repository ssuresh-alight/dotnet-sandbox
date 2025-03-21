namespace Sandbox.Tests;

public class DictionaryKeysTests : ISandboxTest
{
	public void Execute()
	{
		// var testRecord1 = new TestRecord("Person", "1234", "3245");
		// var testRecord2 = new TestRecord("Person", "1234", "5678");
		// var testRecord3 = new TestRecord("Person", "1234", "7890");
		// var testRecord4 = new TestRecord("Person", "1234", "3245");
		// Console.WriteLine(testRecord1 == testRecord4); // true
		// Console.WriteLine(testRecord1.Equals(testRecord4)); // true

		// // testRecord2.id = "3456";

		// Dictionary<TestRecord, string?> dict = new();

		// dict.Add(testRecord1, testRecord1.optionalId);
		// dict.Add(testRecord2, testRecord2.optionalId);
		// dict.Add(testRecord3, testRecord3.optionalId);
		// // dict.Add(testRecord4, testRecord4.optionalId); // errors out

		// var dict2 = new Dictionary<(int PersonId, int LocationId, int SubjectId), string>();
		// dict2.Add((3, 6, 9), "ABC");
		// dict2.Add((PersonId: 4, LocationId: 9, SubjectId: 10), "XYZ");
		// // dict2.Add((3, 6, 9), "ABCD"); // errors out

		// var dict3 = new Dictionary<TestRecordMutable, string>();
		// dict3.Add(new() { name = "person", id = "1234", optionalId = "3245" }, "ABC");
		// dict3.Add(new() { name = "person", id = "3214", optionalId = "3245" }, "XYZ");
		// // dict3.Add(new() { name = "person", id = "1234", optionalId = "3245" }, "ABCD"); // errors out
		// var dict3key3 = new TestRecordMutable() { name = "person", id = "4567", optionalId = "3245" };
		// dict3key3.id = "1234";
		// dict3.Add(dict3key3, "XYZ"); // errors out

		var dict4 = new Dictionary<TestClass, string>();
		dict4.Add(new("person", "1234", "3245"), "ABC");
		dict4.Add(new("person", "3214", "3245"), "XYZ");
		if (dict4.TryGetValue(new("person", "1234", "3245"), out var str))
		{
			Console.WriteLine($"found: {str}");
		}
		else
		{
			Console.WriteLine("Not found");
		}
	}

	public ICollection<KeyValuePair<string, string>> TestReturnType() {
		var dict = new Dictionary<string, string>();
		return dict;
	}

	public record TestRecord(string name, string id, string? optionalId) { }

	public class TestClass(string name, string id, string? optionalId)
	{
		public string name { get; } = name;
		public string id { get; } = id;
		public string? optionalId { get; } = optionalId;
	}

	public record TestRecordMutable()
	{
		public required string name { get; set; }
		public required string id { get; set; }
		public string? optionalId { get; set; }
	}
}