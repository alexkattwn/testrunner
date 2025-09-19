using System;
using System.Collections.Generic;

namespace TestRunner
{
    public class TestResult
    {
        public string TestName { get; set; }
        public bool Success { get; set; }
        public string ErrorName { get; set; }
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Cancelled { get; set; }
    }
}
