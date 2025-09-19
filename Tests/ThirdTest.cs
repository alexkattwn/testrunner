using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TestRunner.Tests
{
    public class ThirdTest : ITest
    {
        public string Name => "Третий тест";

        public async Task<TestResult> RunAsync(string productId, CancellationToken ct, IProgress<string> log, IProgress<int> progress)
        {
            var result = new TestResult { TestName = Name, Start = DateTime.Now, Data = new Dictionary<string, object>() };
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            int totalSeconds = rnd.Next(12, 31);
            int steps = totalSeconds * 10;

            try
            {
                for (int i = 0; i < steps; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    await Task.Delay(100, ct);
                    progress.Report((i + 1) * 100 / steps);
                    if ((i + 1) % 5 == 0) log.Report($"{Name}: {(i + 1) * 100 / steps}%");
                }
            }
            catch (OperationCanceledException)
            {
                result.Cancelled = true;
                result.End = DateTime.Now;
                return result;
            }

            result.Success = rnd.NextDouble() > 0.2;
            if (!result.Success)
            {
                string[] errors = { "Ошибка 1", "Ошибка 2", "Ошибка 3" };
                result.ErrorName = errors[rnd.Next(errors.Length)];
            }

            result.Data["Date"] = DateTime.Now.ToShortDateString();
            result.Data["Count"] = rnd.Next(1, 50);
            result.Data["Ratio"] = Math.Round(rnd.NextDouble(), 3);

            result.End = DateTime.Now;
            return result;
        }
    }
}
