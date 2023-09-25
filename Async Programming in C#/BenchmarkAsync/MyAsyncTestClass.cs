using BenchmarkDotNet.Attributes;

namespace BenchmarkAsync;

public class MyAsyncTestClass
{
    [Benchmark]
    public async Task Default()
    {
        for (int i = 0; i < 5; i++)
        {
            await Task.Run(() => Thread.Sleep(100));    
        }
        
    }
    
    [Benchmark]
    public async Task SingleAwaitWithinTaskRun()
    {
        for (int i = 0; i < 5; i++)
        {
            await Task.Run(async () => await Task.Delay(100));
        }
    }
    [Benchmark]
    public async Task MultipleAwaitWithinTaskRun()
    {
        for (int i = 0; i < 5; i++)
        {
            await Task.Run(async () =>
            {
                //effectively waiting 100ms
                await Task.Delay(10);
                await Task.Delay(10);
                await Task.Delay(10);
                await Task.Delay(10);
                await Task.Delay(10);
                await Task.Delay(10);
                await Task.Delay(10);
                await Task.Delay(10);
                await Task.Delay(10);
                await Task.Delay(10);
            }
                
            );
        }
    }
    
    [Benchmark]
    public async Task MultipleTasksWithWhenAll()
    {
        for (int i = 0; i < 5; i++)
        {
            await Task.Run(async () =>
                {
                    //effectively waiting 100ms
                    await Task.WhenAll(
                        Task.Delay(100), 
                        Task.Delay(100),
                        Task.Delay(100), 
                        Task.Delay(100),
                        Task.Delay(100),
                        Task.Delay(100),
                        Task.Delay(100),
                        Task.Delay(100),
                        Task.Delay(100),
                        Task.Delay(100))
                        .ConfigureAwait(false);
                }
                
            );
        }
    }
    
    [Benchmark]
    public async Task DefaultDontSwitchBackToCallingThread()
    {
        for (int i = 0; i < 5; i++)
        {
            await Task.Run(() => Thread.Sleep(100)).ConfigureAwait(false);
        }
    }
    
    
    
}