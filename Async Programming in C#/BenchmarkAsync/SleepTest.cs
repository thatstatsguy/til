using BenchmarkDotNet.Attributes;

namespace BenchmarkAsync;

public class SleepTest
{
    [Benchmark]
    public void BaselineSleep()
    {
        Thread.Sleep(100);    
    }
    
    [Benchmark]
    public async Task SleepAsync()
    {
        await Task.Run(() => Thread.Sleep(100));
    }
    
    [Benchmark]
    public async Task NestedAwaitsSleep()
    {
        await Task.Run(async () => await Task.Delay(100));
    }
    [Benchmark]
    public async Task DefaultDontSwitchBackToCallingThread()
    {
        await Task.Run(() => Thread.Sleep(100)).ConfigureAwait(false);
    }
    
    [Benchmark]
    public async Task BrokenUpSleepTasks()
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
    
    [Benchmark]
    public async Task MultipleSleepTasksWithWhenAllWithoutConfigureAwait()
    {
        //ten different tasks
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
    [Benchmark]
    public async Task MultipleTasksWithWhenAllWithConfigureAwait()
    {
        //ten different tasks
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
}