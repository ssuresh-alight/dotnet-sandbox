using System.Net.Http.Json;

namespace Sandbox.Tests;

public class HttpClientTests: ISandboxTest
{
	public void Execute()
    {
        var httpClient = new HttpClient();
        var result = httpClient.GetFromJsonAsync<TestClass>("http://localhost:5000/test").Result;
        Console.WriteLine(result);
    }

    public class TestClass
    {
        public required string Field1 {get;set;}
        public required string Field2 {get;set;}
    }
}
