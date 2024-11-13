namespace Sandbox.Tests;

public class InheritanceTets: ISandboxTest
{
	public void Execute()
	{
		var testConcrete = new ConcreteClass();
		Console.WriteLine("Main: Invoking testConcrete.TestVirtual()");
		testConcrete.TestVirtual();
	}
}

public abstract class BaseAbstractClass()
{
    public static int Count = 0;
	public static void CheckCountAndThrow()
	{
		if (Count > 20) {
			throw new StackOverflowException();
		}
		Count++;
	}

	public virtual void TestVirtual()
	{
		CheckCountAndThrow();
		Console.WriteLine("Abstract class: TestVirtual");
	}
	
	public void TestSolid()
	{
		CheckCountAndThrow();
		Console.WriteLine("Abstract class: TestSolid");
		Console.WriteLine("Abstract class: Invoking this. TestVirtual()");
		this.TestVirtual();
	}
}

public class ConcreteClass: BaseAbstractClass
{
	public override void TestVirtual()
	{
		CheckCountAndThrow();
		Console.WriteLine("Concrete class: TestVirtual");
		Console.WriteLine("Conrete class: Invoking base. TestSolid()");
		base.TestSolid();
	}
}