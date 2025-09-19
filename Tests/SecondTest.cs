using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TestRunner.Tests
{
    public class SecondTest : ITest
    {
        public string Name => "Второй тест";

        public async Task<TestResult> RunAsync(string productId, CancellationToken ct, IProgress<string> log, IProgress<int> progress)
        {
            var result = new TestResult { TestName = Name, Start = DateTime.Now, Data = new Dictionary<string, object>() };
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            int totalSeconds = rnd.Next(10, 31);
            int steps = totalSeconds * 10;

            try
            {
                for (int i = 0; i < steps; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    await Task.Delay(100, ct);
                    progress.Report((i + 1) * 100 / steps);
                    if ((i + 1) % 7 == 0) log.Report($"{Name}: {(i + 1) * 100 / steps}%");
                }
            }
            catch (OperationCanceledException)
            {
                result.Cancelled = true;
                result.End = DateTime.Now;
                return result;
            }

            result.Success = rnd.NextDouble() > 0.25;
            if (!result.Success)
            {
                string[] errors = { "Ошибка X", "Ошибка Y", "Ошибка Z" };
                result.ErrorName = errors[rnd.Next(errors.Length)];
            }

            result.Data["RandomDouble"] = Math.Round(rnd.NextDouble() * 100, 2);
            result.Data["Text"] = Guid.NewGuid().ToString().Substring(0, 6);

            result.End = DateTime.Now;
            return result;
        }
    }
}
