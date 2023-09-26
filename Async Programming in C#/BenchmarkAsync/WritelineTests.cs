using BenchmarkDotNet.Attributes;

namespace BenchmarkAsync;

public class WritelineTests
{
    [Benchmark]
    public void BaselineWriteline()
    {
        Thread.Sleep(100);
        Console.WriteLine("Done baseline");
    }
    [Benchmark]
    public async Task BaselineWritelineAsync()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(100);
            Console.WriteLine("Done baseline");
        });
    }
    
    [Benchmark]
    public async Task ThreeNestedStatementsManyAwaits()
    {
        await Task.Run(async () =>
            await Task.Run(() =>
                Task.Run(async () =>
                    await Task.Run(async () =>
                    {
                        await Task.Delay(100);
                        Console.WriteLine("Done Nested Statements Many awaits");
                    }))));
    }
    
    [Benchmark]
    public async Task ThreeNestedStatementsPassTasks()
    {
        await Task.Run( () =>
            Task.Run(() =>
                Task.Run( () => 
                    Task.Run(() =>
                    {
                        return Task.Run(() =>
                        {
                            Thread.Sleep(100);
                            Console.WriteLine("Done Nested Statements Many awaits");
                        });
                        
                    }))));
    }
}