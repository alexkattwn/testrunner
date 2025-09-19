using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestRunner
{
    public interface ITest
    {
        string Name { get; }
        Task<TestResult> RunAsync(string productId, CancellationToken ct, IProgress<string> log, IProgress<int> progress);
    }
}
