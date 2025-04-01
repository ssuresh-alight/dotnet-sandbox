namespace Sandbox.Tests;

#if (!async)
public class TemplateClass : ISandboxTest
#else
public class TemplateClass : ISandboxTestAsync
#endif
{
#if (!async)
    public void Execute()
#else
    public async Task ExecuteAsync()
#endif
    {
#if (!async)
        // TODO: test code here
#else
        // TODO: remove below && add test code here
        await Task.CompletedTask;
#endif
    }
}
