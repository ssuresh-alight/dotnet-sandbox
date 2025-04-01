namespace Sandbox.Tests;

public class TestAsyncOrder : ISandboxTestAsync
{
    public async Task ExecuteAsync()
    {
        Console.WriteLine("Awaiting each method as you call them");
        await this.Method1();
        await this.Method2();
        await this.Method3();

        Console.WriteLine();
        
        Console.WriteLine("Awaiting each method after you call all of them");
        var task1 = this.Method1();
        var task2 = this.Method2();
        var task3 = this.Method3();
        await task1;
        await task2;
        await task3;

        Console.WriteLine();

        Console.WriteLine("Calling each method but not awaiting them");
        _ = this.Method1();
        _ = this.Method2();
        _ = this.Method3();
        
        // prevent exiting method
        await Task.Delay(500);
        
        /*
        Output:
            Awaiting each method as you call them
            Method1 start
            Method1 end
            Method2 start
            Method2 end
            Method3 start
            Method3 end

            Awaiting each method after you call all of them
            Method1 start
            Method2 start
            Method3 start
            Method3 end
            Method2 end
            Method1 end

            Calling each method but not awaiting them
            Method1 start
            Method2 start
            Method3 start
            Method3 end
            Method2 end
            Method1 end
        */
    }

    public async Task Method1()
    {
        Console.WriteLine(nameof(Method1) + " start");
        await Task.Delay(400); // slowest
        Console.WriteLine(nameof(Method1) + " end");
    }
    
    public async Task Method2()
    {
        Console.WriteLine(nameof(Method2) + " start");
        await Task.Delay(200); // slow
        Console.WriteLine(nameof(Method2) + " end");
    }
    
    public async Task Method3()
    {
        Console.WriteLine(nameof(Method3) + " start");
        await Task.Delay(100); // fast
        Console.WriteLine(nameof(Method3) + " end");
    }
}
