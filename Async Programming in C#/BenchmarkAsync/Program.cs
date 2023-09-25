using BenchmarkAsync;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<MyAsyncTestClass>();
// BenchmarkRunner.Run<NestedAsyncClass>();