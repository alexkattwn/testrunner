using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TestRunner.Tests
{
    public class FirstTest : ITest
    {
        public string Name => "Первый тест";

        public async Task<TestResult> RunAsync(string productId, CancellationToken ct, IProgress<string> log, IProgress<int> progress)
        {
            var result = new TestResult { TestName = Name, Start = DateTime.Now, Data = new Dictionary<string, object>() };
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            int totalSeconds = rnd.Next(10, 31); // 10-30 секунд длительность теста
            int steps = totalSeconds * 10;

            try
            {
                for (int i = 0; i < steps; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    await Task.Delay(100, ct);
                    progress.Report((i + 1) * 100 / steps);
                    // каждые ~1 секунду пишем строку в лог
                    if ((i + 1) % 10 == 0) log.Report($"{Name}: {(i + 1) * 100 / steps}%");
                }
            }
            catch (OperationCanceledException)
            {
                result.Cancelled = true;
                result.End = DateTime.Now;
                return result;
            }

            result.Success = rnd.NextDouble() > 0.3;  // определение успешности теста (70% шанс успеха) 
            if (!result.Success)
            {
                string[] errors = { "Ошибка A", "Ошибка B", "Ошибка C" };
                result.ErrorName = errors[rnd.Next(errors.Length)]; // рандомный выбор ошибки
            }

            result.Data["Value"] = rnd.Next(1, 100);
            result.Data["Flag"] = rnd.Next(0, 2) == 1;

            result.End = DateTime.Now;
            return result;
        }
    }
}
