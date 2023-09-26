using BenchmarkAsync;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<SleepTest>();
// | Method                                             | Mean     | Error   | StdDev  |
// |--------------------------------------------------- |---------:|--------:|--------:|
// | BaselineSleep                                      | 108.2 ms | 0.46 ms | 0.43 ms |
// | SleepAsync                                         | 108.6 ms | 0.49 ms | 0.46 ms |
// | NestedAwaitsSleep                                  | 108.4 ms | 0.49 ms | 0.46 ms |
// | DefaultDontSwitchBackToCallingThread               | 108.4 ms | 0.42 ms | 0.37 ms |
// | BrokenUpSleepTasks                                 | 156.5 ms | 1.06 ms | 1.00 ms |
// | MultipleSleepTasksWithWhenAllWithoutConfigureAwait | 108.5 ms | 0.51 ms | 0.48 ms |
// | MultipleTasksWithWhenAllWithConfigureAwait         | 108.5 ms | 0.57 ms | 0.53 ms |


//not used in article, but interesting results nonetheless
BenchmarkRunner.Run<WritelineTests>();
// | Method                          | Mean     | Error   | StdDev  |
// |-------------------------------- |---------:|--------:|--------:|
// | BaselineWriteline               | 108.6 ms | 0.49 ms | 0.46 ms |
// | BaselineWritelineAsync          | 108.4 ms | 0.33 ms | 0.26 ms |
// | ThreeNestedStatementsManyAwaits | 108.5 ms | 0.39 ms | 0.37 ms |
// | ThreeNestedStatementsPassTasks  | 108.6 ms | 0.67 ms | 0.63 ms |